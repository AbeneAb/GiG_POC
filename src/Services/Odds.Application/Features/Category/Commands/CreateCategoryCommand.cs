using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.Features.Category.Commands
{
    public class CreateCategoryCommand : BaseViewModel<Domain.Entities.Category>
    {
        public CreateCategoryCommand(Domain.Entities.Category category):base(category)
        {

        }
    }
}
