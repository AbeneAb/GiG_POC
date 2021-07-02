using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Odds.Domain.Seed
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        protected Enumeration(string name, int id) 
        {
            Id = Id;
            Name = name;
        }
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly).
                Select(f => f.GetValue(null)).Cast<T>();
        }
        public static T FromValue<T>(int value)  where T: Enumeration
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
            return matchingItem;
        }
        public static T FromDisplayName<T>(string description) where T: Enumeration 
        {
            var matchingItem = Parse<T, string>(description, "display name", item => item.Name == description);
            return matchingItem;
        }
        private static T Parse<T,K>(K value, string description,Func<T,bool> predicate) where T : Enumeration 
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);
            return matchingItem;
        }
        public override string ToString() => Name;
        public override int GetHashCode() => Id.GetHashCode();
        public override bool Equals(object obj)
        {
            if(obj is not Enumeration otherValue) 
            {
                return false;
            }
            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);
            return typeMatches && valueMatches;
        }
        public int CompareTo(object obj) => Id.CompareTo(((Enumeration)obj).Id);
      
    }
}
