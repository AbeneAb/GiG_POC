using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Selection.Client.Contracts;
using Selection.Client.Services;
using Polly.Extensions.Http;
using Polly;
using System.Net.Http;
using Serilog;
using System.Threading.Tasks;
using EventBus.Messages;
using System.Threading;
using Microsoft.Extensions.Hosting;

namespace Selection.Client
{
    class Program
    {
        public static IConfiguration Configuration { get; private set; }
        static async Task Main(string[] args)
        {
            try
            {

                var host = new HostBuilder()
                  .ConfigureHostConfiguration(configHost =>
                  {
                  })
                  .ConfigureServices((hostContext, services) =>
                  {
                      services.AddHostedService<SelectionUpdateRecevier>();

                  })
                 .UseConsoleLifetime()
                 .Build();

                Configuration = new ConfigurationBuilder()
                                           .SetBasePath(Directory.GetCurrentDirectory())
                                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                                           .AddCommandLine(args)
                                           .AddEnvironmentVariables()
                                           .Build();
                Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration)
                                                      .Enrich.FromLogContext()
                                                      .Enrich.WithMachineName()
                                                      .CreateLogger();
                Log.Information("Starting up...");

                var services = ConfigureServices();
                var serviceProvider = services.BuildServiceProvider();
              
                await serviceProvider.GetService<SelectionUpdateRecevier>().StartAsync(new CancellationToken());

                host.Run();


            }
            catch (Exception ex) 
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally 
            {
                Log.CloseAndFlush();
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args);
               
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            // register the services

            // Configuration should be singleton as the entire application should use one
            services.AddSingleton(Configuration);
            // for strongly typed options to be injected as IOption<T> in constructors
            services.AddOptions();
            var config = Configuration["EventBusSettings:HostAddress"];
            var serviceClientSettingsConfig = Configuration.GetSection("RabbitMq");
            var serviceClientSettings = serviceClientSettingsConfig.Get<RabbitMqConfiguration>();
            services.Configure<RabbitMqConfiguration>(serviceClientSettingsConfig);
            // General Configuration
           
            // Register the actual application entry point
            services.AddTransient<LoggingDelegatingHandler>();
            services.AddTransient<OddsDisplay>();
            services.AddHostedService<SelectionUpdateRecevier>();


            services.AddHttpClient<ISelectionService, SelectionService>(c =>
               c.BaseAddress = new Uri(Configuration["ApiSettings:GatewayAddress"]))
               .AddHttpMessageHandler<LoggingDelegatingHandler>()
               .AddPolicyHandler(GetRetryPolicy())
               .AddPolicyHandler(GetCircuitBreakerPolicy());

            return services;
        }
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            // In this case will wait for
            //  2 ^ 1 = 2 seconds then
            //  2 ^ 2 = 4 seconds then
            //  2 ^ 3 = 8 seconds then
            //  2 ^ 4 = 16 seconds then
            //  2 ^ 5 = 32 seconds

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (exception, retryCount, context) =>
                    {
                        Log.Error($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
                    });
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 5,
                    durationOfBreak: TimeSpan.FromSeconds(30)
                );
        }


    }
}
