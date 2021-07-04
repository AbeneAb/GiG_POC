using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Xunit;
using Moq;
using Odds.Domain.Interfaces;
using System;
using Odds.Application.Features.Selection.Command;
using System.Threading.Tasks;
using Odds.Domain.Entities;
using MassTransit;
using System.Threading;

namespace Odds.UnitTest.Application
{
    public class CreateSelectionCommadHandlerTest
    {
        private readonly Mock<ISelectionRepository> _selectionRepositoryMock;
        private readonly Mock<IPublishEndpoint> _publisher;
        public CreateSelectionCommadHandlerTest()
        {
            _selectionRepositoryMock = new Mock<ISelectionRepository>();
            _publisher = new Mock<IPublishEndpoint>();
        }
        [Fact]
        public async Task Handle_throws_exception_when_marketGuid_isnull()
        {
            var fakeSelectCmd = FakeCreateCommandWithMarketGuid(new Dictionary<string, object>
            { ["MarketGuid"] = Guid.Empty });

            //Assert
            var handler = new CreateSelectionCommandHandler(_selectionRepositoryMock.Object, _publisher.Object);
            var cltToken = new System.Threading.CancellationToken();
            await Assert.ThrowsAsync<Exception>(async () => await handler.Handle(fakeSelectCmd, cltToken));
        }
        [Fact]
        public async Task Handle_return_false_if_order_is_not_persisted()
        {

            var fakeSelectCmd = FakeCreateCommandWithMarketGuid(new Dictionary<string, object>
            { ["MarketGuid"] = Guid.NewGuid() });

            _selectionRepositoryMock.Setup(orderRepo => orderRepo.GetByIdAsync(It.IsAny<Guid>()))
               .Returns(Task.FromResult<Selection>(FakeSelection()));



            //Act
            var handler = new CreateSelectionCommandHandler(_selectionRepositoryMock.Object, _publisher.Object);
            var cltToken = new System.Threading.CancellationToken();
            var result = await handler.Handle(fakeSelectCmd, cltToken);

            //Assert
            Assert.NotEqual(result,fakeSelectCmd.MarketGuid);
        }
        private Selection FakeSelection() 
        {
            return new Selection(1.5m, 1, "Label", 1);
        }


        private CreateSelectionCommand FakeCreateCommandWithMarketGuid(Dictionary<string,object> args = null) 
        {
            return new CreateSelectionCommand
            {
                 MarketGuid = args != null && args.ContainsKey("MarketGuid") ? (Guid)args["MarketGuid"] : Guid.Empty,
                 Index =  args != null && args.ContainsKey("Index") ? (int)args["Index"] : 1,
                 Label= args != null && args.ContainsKey("Label") ? (string)args["Label"] : "Home",
                  Odds = args != null && args.ContainsKey("Odds") ? (decimal)args["Odds"] : 1.5m,
                   Status  = args != null && args.ContainsKey("Status") ? (int)args["Status"] : 1


            };
        }
    }
}
