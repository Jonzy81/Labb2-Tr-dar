using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Labb2_Trådar
{
    internal class RaceMethods
    {

        public static void Race(Car car)
        {

            int sleepTime = (360 * 1); //3600×1000 is the time in a hour by millisecond keeping the nr1 if i want to change the timespan later
                       
            Timer timer = new Timer( callback: state =>
                {
                    sleepTime += RaceProblems(car, sleepTime);
                },
                null,
                0,
                30000
                );

            timer.Change(0, 30000);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{car.CarName} - Distance: {i + 1} km");

                Thread.Sleep(sleepTime);

                sleepTime += RaceProblems(car, sleepTime);  //Random addition of time to the race


            }
            timer.Dispose();
        }

        //used in new method later
        /* if(rnd.Next(1, 5)==rnd.Next(1, 5))
            {
                Console.WriteLine($"{car.CarName} mechanic got drunk yesterday and forgot one of the bolts of the tires making the car perform a bit less, making the car drive for 1km/h slower)
            }*/
        public static int RaceProblems(Car car, int addedTime)
        {
            Random rnd = new Random();

            if (rnd.Next(1, 51) == rnd.Next(1, 51))
            {
                Console.WriteLine($"{car.CarName} forogt to fuel so the driver is on the side of the road begging for gas. Adding additional time to the race");
                return addedTime + 300;
            }
            if (rnd.Next(1, 26) == rnd.Next(1, 26))
            {
                Console.WriteLine($"{car.CarName} The driver got a flat tire and is now looking for his jack and his tireiron. Adding additional time to the race");
                return addedTime + 200;
            }
            if (rnd.Next(1, 11) == rnd.Next(1, 11))
            {
                Console.WriteLine($"{car.CarName} got sick and vomited all ower his windshield he is now cleaning it up. Adding additional time to the race");
                return addedTime + 100;
            }

            return 0;
        }
    }
}
