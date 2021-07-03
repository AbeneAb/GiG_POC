using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.Features.Category.Commands
{
    public class CreateCategoryCommand : BaseModel<Domain.Entities.Category>
    {

        public override Domain.Entities.Category MapToModel()
        {
            throw new NotImplementedException();
        }

        public override Domain.Entities.Category MapToModel(Domain.Entities.Category t)
        {
            throw new NotImplementedException();
        }
    }
}
