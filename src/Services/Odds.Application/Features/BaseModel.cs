using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.Features
{
    public abstract class BaseModel<T> where T: EntityBase
    {
        public abstract T MapToModel();
        public abstract T MapToModel(T t);
    }
}
