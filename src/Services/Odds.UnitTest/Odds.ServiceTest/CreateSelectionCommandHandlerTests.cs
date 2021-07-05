using Odds.Application.Features.Selection.Command;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using EventBus.Messages.Interface;
using Xunit;
using Odds.Domain.Entities;
using FluentAssertions;


namespace Odds.ServiceTest
{
    public class CreateSelectionCommandHandlerTests
    {
        private readonly ISelectionRepository _selectionRepo;
        private readonly CreateSelectionCommandHandler _testee;
        private readonly ISelectionUpdateSender _updater;
        public CreateSelectionCommandHandlerTests()
        {
            _selectionRepo = A.Fake<ISelectionRepository>();
            _updater = A.Fake<ISelectionUpdateSender>();
            _testee = new CreateSelectionCommandHandler(_selectionRepo, _updater);
        }
        [Fact]
        public async void Handle_ShouldReturnCreatedSelection()
        {
            A.CallTo(() => _selectionRepo.AddAsync(A<Selection>._)).Returns(new Selection(1.2m,1,"Label",1));

            var result = await _testee.Handle(new CreateSelectionCommand() {  Odds = 1.2m, Index = 1, Status = 1, Label = "Label"}, default);
            Assert.IsType<Guid>(result);
        }

        [Fact]
        public async void Handle_ShouldCallRepositoryAddAsync()
        {
            await _testee.Handle(new CreateSelectionCommand() {  Odds = 2.5m, Index =1, Label = "Test", MarketGuid = Guid.NewGuid(), Status =1}, default);

            A.CallTo(() => _selectionRepo.AddAsync(A<Selection>._)).MustHaveHappenedOnceExactly();
        }
        

    }
}
