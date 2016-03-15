using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Personnages
    {
        public string name { get; set; }
        public string race { get; set; }
        public string gender { get; set; }
        public string profession { get; set; }
        public string level { get; set; }
        public IList<EquipmentItem> equipment { get; set; }
    }

    class EquipmentItem
    {
        public string id { get; set; }
        public string slot { get; set; }
        public List<int> upgrades { get; set; }
    }
}
