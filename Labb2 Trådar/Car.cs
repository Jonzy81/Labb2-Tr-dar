using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Trådar
{
    internal class Car
    {
        
        public string CarName { get; set; }
        public double Distance { get; set; }
        public int Speed { get; set; }

        public Car(string carName) 
        {
            CarName = carName;
            Distance = 0;
            Speed = 120;
        }
    }
}
