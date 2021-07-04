using System;
using Xunit;
using Odds.Domain.Entities;
using Odds.Domain.Exceptions;

namespace Odds.UnitTest.Domain
{
    public class SelectionEntityTest
    {
        [Fact]
        public void Create_selection_success()
        {
            //Arrange    
            decimal odd = 1.4m;
            int index = 1;
            int selectionItemStatus = 1;
            string label = "Home";

            //Act 
            var fakeOrderItem = new Selection(odd,index,label,selectionItemStatus);

            //Assert
            Assert.NotNull(fakeOrderItem);
        }
        [Fact]
        public void Updaye_selection_success() 
        {
            //Arrange
            //
            Guid marketId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            decimal odd = 1.4m;
            int index = 1;
            int selectionItemStatus = 1;
            string label = "Home";


            //Act 
            var fakeOrderItem = new Selection(marketId, odd, index, label, selectionItemStatus);


            //Assert
            Assert.Equal(marketId, fakeOrderItem.MarketGuid);
        }

        [Fact]
        public void Create_Selection_with_odd_less_than_zero() 
        {
            //Arrange 
            int index = 1;
            int selectionItemStatus = 1;
            string label = "Home";

            //Act
            decimal odd = -1.4m;


            //Aseert

            Assert.Throws<DomainException>(() => new Selection(odd, index, label, selectionItemStatus));

        }


    }
}
