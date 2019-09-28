using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester1Project
{
    public class ScienceField
    {
        private Dictionary<string, List<Formula>> categories = new Dictionary<string, List<Formula>>();
        public string Name { get; }

        public ScienceField(string name)
        {
            Name = name;
            categories = new Dictionary<string, List<Formula>>();
        }

        public ScienceField(string name, Dictionary<string, List<Formula>> categories)
        {
            Name = name;
            this.categories = categories;
        }

        public void AddCategory(string categoryName)
        {
            categories.Add(categoryName, new List<Formula>());
        }

        public List<string> GetCategoryNames()
        {
            var res = new List<string>();
            foreach (var str in categories.Keys)
            {
                res.Add(str);
            }
            return res;
        }
    }

    public struct Formula
    {
        public string name;
        public string formula;
        public string description;
        public Formula(string n, string f, string d) { name = n; formula = f; description = d; }
    }
}
