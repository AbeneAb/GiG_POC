using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odds.Domain.Entities
{
    public class Category : EntityBase
    {
        private readonly string _name;
        public string Name => _name;
        private readonly Guid? _parentGuid;
        public Guid? ParentGUID => _parentGuid;
        private Category _parent;
        public virtual Category Parent => _parent;
        private ICollection<Category> _children;
        public virtual IReadOnlyList<Category> Children => _children?.ToList();

        private ICollection<Region> _regions;
        public virtual IReadOnlyCollection<Region> Regions => _regions?.ToList();
        private Category()
        {
            _children = new HashSet<Category>();
        }
        public Category(string name, Guid? parentGuid)
        {
            _name = name;
            _parentGuid = parentGuid;
        }
       
    }
}
