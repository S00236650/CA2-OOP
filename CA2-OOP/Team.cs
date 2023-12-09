using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_OOP
{
    internal class Team
    {
        //Variables
        public string Name { get; set; }
        public List<Player> Players = new List<Player>();

        //Constructors
        public Team() { }
    }
}
