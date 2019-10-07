using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMenu
{
    class Stat
    {
        public string StatName { get; set; }
        public int StatValue { get; set; }
        public string StatVisual { get; set; }

        public Stat(string name)
        {
            StatName = name;
            StatValue = 0;
            StatVisual = string.Empty;
        }
    }
}
