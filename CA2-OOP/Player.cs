using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_OOP
{
    internal class Player
    {
        //Variables
        public string Name { get; set; }
        public string ResultRecord { get; set; }
        public int Points { get; set; }

        //Constructors
        public Player() { }

        public Player(string name, string record)
        {
            Name = name;
            ResultRecord = record;
            //Points not needed as it will be calculated in the Calculate() method
        }
    }
}
