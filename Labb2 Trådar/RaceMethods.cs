using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace Labb2_Trådar
{
    internal class RaceMethods
    {
        public static object lockObject = new object();
        public static void Race(Car car, List<Car> list, CancellationTokenSource cts)
        {
            Thread.Sleep(100);
            Timer timer = new Timer(state => { RaceProblems(car); }, null, 3000, 3000) ;  
            /*Timer class, has a delegate that calls on method, the timer starts at 300 ms and repeats every 300ms, very fancy stuff*/   
                
            //The time ratio is negative one 0, making me remove one 0 from the rest of th algorithm 
            Console.WriteLine($"{ car.CarName} has started the race");
            while (car.Distance <= 1)
            {
                car.Distance += (car.Speed / 360000.0);     //meajures distance traveled over time its the basic km/h. 
                // Console.WriteLine($"{car.CarName} {car.Distance}");
                Thread.Sleep(10);     //adding a threadSleep so that the program dont end immedietly 
               
                if (car.Distance >= 1)
                {   
                    //Console.WriteLine($"{car.CarName} Reached the finish line");
                    lock (lockObject)
                    {
                        list.Add(car);
                    }
                    if (list.Count == 1)
                    {
                        lock (lockObject)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{car.CarName} is the winner!");
                            Console.ResetColor();
                        }
                    }
                    cts.Cancel();
                    break;
                }
            }
            timer.Dispose();
        }
        public static void RaceProblems(Car car)
        {
            Random rnd = new Random();

            if (rnd.Next(1, 51) == 1)
            {
                Console.WriteLine($"{car.CarName} forogt to fuel so the driver is on the side of the road begging for gas. Adding additional time to the race");
                Thread.Sleep(3000);
            }
            if (rnd.Next(1, 26) == 1)
            {
                Console.WriteLine($"{car.CarName} The driver got a flat tire and is now looking for his jack and tireiron. Adding additional time to the race");
                Thread.Sleep(2000);
            }
            if (rnd.Next(1, 11) == 1)
            {
                Console.WriteLine($"{car.CarName} got sick and vomited all ower his windshield. Adding additional time to the race");
                Thread.Sleep(1000);
            }
            if (rnd.Next(1, 6) == 1)
            {  
                Console.WriteLine($"{car.CarName} got some engine failure, they fueled the car with diesel instead of petrol speed reduced with 1km/h");
                car.Speed -= 1;
            }
        }
       
    }
}
