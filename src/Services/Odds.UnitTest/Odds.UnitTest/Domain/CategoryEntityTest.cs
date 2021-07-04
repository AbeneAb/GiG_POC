using Xunit;
using Odds.Domain.Entities;
using Odds.Domain.Exceptions;

namespace Odds.UnitTest.Domain
{
    public class CategoryEntityTest
    {
        [Fact]
        
        public void Create_Category_success()
        {
            //Arrange    
            var name = "Football";


            //Act 
            var fakeCategoryItem = new Category(name, null);

            //Assert
            Assert.NotNull(fakeCategoryItem);
        }
        [Fact]
        public void Add_Region_success() 
        {
            //arrange
            var name = "Football";
            Category category = new Category(name,null);
            var region = new Region("Europe");
            //ACT
            category.AddRegion(region);
            //ASSERT
            Assert.NotNull(region);
        }

        [Fact]
        public void Add_Region_Duplicate_Error() 
        {
            //Arrange
            var name = "Football";
            Category category = new Category(name, null);
            var region = new Region("Europe");

            //Act
            category.AddRegion(region);

            //Assert
            Assert.Throws<DomainException>(() => category.AddRegion(region));

        }

    }
}
