using System;
using System.Collections.Generic;
using System.Text;

namespace Odds.Domain.Seed
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public bool IsActive { get; protected set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

    }
}
