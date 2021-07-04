using Odds.Domain.Entities;
using Odds.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Odds.UnitTest.Domain
{
    public class EventEntityTests 
    {
        [Fact]
        public void Create_Category_success()
        {
            //Arrange    
            var name = "Football";
            var category = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var startDate = DateTime.UtcNow;
            var competitionGuid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            int status = 1;
            //Act 
            var fakeCategoryItem = new Event(category,startDate, competitionGuid,name,status);

            //Assert
            Assert.NotNull(fakeCategoryItem);
        }
        [Fact]
        public void Add_Participant_Success() 
        {
            //Arrange
            var name = "Football";
            var category = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var startDate = DateTime.UtcNow;
            var competitionGuid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            int status = 1;
            //Act
            var fakeCategoryItem = new Event(category, startDate, competitionGuid, name, status);
            string pDesc = "Liverpool";
            int index = 1;
            var participant = Guid.NewGuid();
            var participantDetail = new ParticipantDetail(participant, index, pDesc);
            fakeCategoryItem.AddParticipants(participantDetail);

            //Asseet
            Assert.NotNull(fakeCategoryItem.Participants);
        }
        [Fact]
        public void Add_Participant_Duplicate() 
        {
            //Arrange
            var name = "Football";
            var category = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var startDate = DateTime.UtcNow;
            var competitionGuid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            int status = 1;
            //Act
            var fakeCategoryItem = new Event(category, startDate, competitionGuid, name, status);
            string pDesc = "Liverpool";
            int index = 1;
            var participant = Guid.NewGuid();
            var participantDetail = new ParticipantDetail(participant, index, pDesc);
            fakeCategoryItem.AddParticipants(participantDetail);



            //Asseet
            Assert.Throws<DomainException>(() => fakeCategoryItem.AddParticipants(participantDetail));
        }

    }
}
