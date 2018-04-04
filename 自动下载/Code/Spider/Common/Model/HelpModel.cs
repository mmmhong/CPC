using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class HelpModel
    {
        public HelpModel()
        {
            Name1 = Name2 = null;
        }
        public HelpModel(string name1, string name2)
        {
            Name1 = name1;
            Name2 = name2;
        }

        public string Name1 { get; set; }
        public string Name2 { get; set; }
    }
}
