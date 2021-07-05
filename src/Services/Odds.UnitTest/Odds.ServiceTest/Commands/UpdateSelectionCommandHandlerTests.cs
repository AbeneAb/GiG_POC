using EventBus.Messages.Interface;
using FakeItEasy;
using Odds.Application.Features.Selection.Command;
using Odds.Domain.Entities;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Odds.ServiceTest
{
    public class UpdateSelectionCommandHandlerTests
    {
        private readonly ISelectionRepository _selectionRepo;
        private readonly UpdateSelectionCommandHandler _testee;
        private readonly ISelectionUpdateSender _updater;
        public UpdateSelectionCommandHandlerTests()
        {
            _selectionRepo = A.Fake<ISelectionRepository>();
            _updater = A.Fake<ISelectionUpdateSender>();
            _testee = new UpdateSelectionCommandHandler(_selectionRepo, _updater);
        }

        [Fact]
        public async void Handle_ShouldCallRepositoryGetSelection()
        {
            await _testee.Handle(new UpdateSelectionCommand() { Odds = 2.5m, Index = 1, Label = "Test", MarketGuid = Guid.NewGuid(), Status = 1 }, default);

            A.CallTo(() => _selectionRepo.GetSelection(A<Guid>._)).MustHaveHappenedOnceExactly();
        }
        [Fact]
        public async void Handle_Should_Call_Repository_UpdateAsync()
        {
            await _testee.Handle(new UpdateSelectionCommand() { Odds = 2.5m, Index = 1, Label = "Test", MarketGuid = Guid.NewGuid(), Status = 1 }, default);

            A.CallTo(() => _selectionRepo.UpdateAsync(A<Selection>._)).MustHaveHappenedOnceExactly();
        }

    }
}
