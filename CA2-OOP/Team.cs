using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_OOP
{
    internal class Team : IComparable<Team>
    {
        //Variables
        public string Name { get; set; }
        public List<Player> Players = new List<Player>();
        public int Points { get; set; }

        public int CompareTo(Team other)
        {
            // Compare teams based on their ratings
            return this.Points.CompareTo(other.Points);
        }

        //Constructors
        public Team() { }

        public Team(string name)
        {
            Name = name;
        }
    }
}