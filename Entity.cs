using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmen2._0
{
    internal abstract class Entity
    {
        public int Id { get; set; }
        protected string Name { get; set; }
        public static int NewId = 1;

        public Entity(string name)
        {
            Id = NewId++;
            Name = name;

        }

        public abstract string GetDescription();

    }
    
}
