using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyTest.Models
{
    public class Component
    {
        public string Name { get; set; }


        public IList<Component> Dependencies { get; set; }

        public Component()
        {
            Dependencies = new List<Component>();
        }

        /// <summary>
        /// Add a new component
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dependencies"></param>
        public void addItem(string name)
        {
            this.Name = name.Trim();
        }

        public void RemoveItem()
        {

        }

        public void Adddependency(Component component)
        {
            this.Dependencies.Add(component);
        }
    }
}
