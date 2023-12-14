using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Trådar
{
    internal class RaceMethods
    {
        public static async Task Race(Car carName)
        {
            //I want them to start the race

            for (int i = 0; i < 100; i++)   //Simulates 10km of racetrack 
            {
                await Console.Out.WriteLineAsync($"{carName.CarName}-{i}");
                await Task.Delay(10);
            }

        }
    }
}
