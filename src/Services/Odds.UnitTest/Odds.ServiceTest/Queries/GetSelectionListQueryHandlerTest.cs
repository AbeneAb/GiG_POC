using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Xunit;
using Odds.Application.Features.Selection.Query;
using Odds.Domain.Interfaces;
using Odds.Domain.Entities;
using Odds.Application.ViewModels;

namespace Odds.ServiceTest.Queries
{
    public class GetSelectionListQueryHandlerTest
    {
        private readonly ISelectionRepository _selectionRepo;
        private readonly GetSelectionListQueryHandler _testee;
        private readonly List<Selection> _selections;
        public GetSelectionListQueryHandlerTest()
        {
            _selectionRepo = A.Fake<ISelectionRepository>();
            _testee = new GetSelectionListQueryHandler(_selectionRepo);
            _selections = new List<Selection>
            {
                new Selection(1.4m,1,"Home",1),
                new Selection(3.2m,2,"Draw",1),
                new Selection(5.1m,3,"Away",1)
            };

        }

        [Fact]
        public async Task Handle_Should_Return_Selections()
        {
            A.CallTo(() =>  _selectionRepo.GetAllSelection()).Returns(_selections);

            var result = await _testee.Handle(new GetSelectionListQuery(), default);

            A.CallTo(() => _selectionRepo.GetAllSelection()).MustHaveHappenedOnceExactly();
            result.Should().BeOfType<List<SelectionVm>>();
            result.Count.Should().Be(3);
        }
    }
}
