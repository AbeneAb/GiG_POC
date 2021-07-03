using Odds.Domain.Seed;
using Odds.Domain.Exceptions;
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
        public virtual IReadOnlyCollection<Category> Children => _children?.ToList();

        private ICollection<Region> _regions;
        public virtual IReadOnlyCollection<Region> Regions => _regions?.ToList();
        private Category()
        {
            _children = new HashSet<Category>();
            _regions = new HashSet<Region>();
        }
        public Category(string name, Guid? parentGuid):this()
        {
            _name = name;
            _parentGuid = parentGuid;
        }
        public void AddChildren() 
        {
        }
        public void AddRegion(Region region) 
        {
            var exitingRegion = _regions.Where(x => x.Name == region.Name).SingleOrDefault();
            if(exitingRegion != null) 
            {
                throw new DomainException($"Region {region.Name} has already been added in the same Category");
            }
            _regions.Add(region);
        }
       
    }
}
