using System;
using System.Runtime.CompilerServices;
using Atbash.Helpers.Constants;

namespace Atbash.Helpers.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class SortByAttribute : Attribute
    {
        public string Name { get; set; }

        public int Priority { get; set; }

        public SortDirection Direction { get; set; }

        public SortByAttribute([CallerMemberName] string name = null)
        {
            this.Direction = SortDirection.Asc;
            this.Name = name;
            this.Priority = 0;
        }

        public SortByAttribute(SortDirection direction, [CallerMemberName] string name = null)
        {
            this.Direction = direction;
            this.Name = name;
        }

        public SortByAttribute(int priority, SortDirection direction, [CallerMemberName] string name = null)
        {
            this.Direction = direction;
            this.Name = name;
            this.Priority = priority;
        }
    }
}
