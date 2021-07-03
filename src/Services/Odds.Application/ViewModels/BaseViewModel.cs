using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.Features
{
    public abstract class BaseViewModel<T> where T: EntityBase
    {
        public BaseViewModel(T entity)
        {
            Id = entity.Id;
            CreatedDate = entity.CreatedDate;
            IsActive = entity.IsActive;
            CreatedByUser = entity.CreatedBy;
        }
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public bool IsActive { get; protected set; }
        public Guid CreatedByUser { get; protected set; }
    }
}
