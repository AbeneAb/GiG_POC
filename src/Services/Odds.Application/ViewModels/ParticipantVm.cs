using Odds.Application.Features;
using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.ViewModels
{
    public class ParticipantVm : BaseViewModel<Participant>
    {
        public string Name { get; private set; }
        public ParticipantVm(Participant participant):base(participant)
        {
            Name = participant.Name;
        }
    }
}
