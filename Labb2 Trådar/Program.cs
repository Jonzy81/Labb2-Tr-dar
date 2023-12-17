namespace Labb2_Trådar
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Car car1 = new Car("Porsche 918 Spyder");
            //Car car2 = new Car("Lamborghini Aventador");
            //Car car3 = new Car("McLaren F1");
            //Car car4 = new Car("Ferrari LaFerrari");

            List<Car> list = new List<Car>();
            bool progress=true;

            Thread thread1 = new Thread(() => RaceMethods.Race(new Car("Porsche 918 Spyder"), list));  //Creating Threads that delegates my race method and declares object for them 
            Thread thread2 = new Thread(() => RaceMethods.Race(new Car("Lamborghini Aventador"), list));
            Thread thread3 = new Thread(() => RaceMethods.Race(new Car("McLaren F1"), list));
            Thread thread4 = new Thread(() => RaceMethods.Race(new Car("Ferrari LaFerrari"), list));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            while (progress)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please press [enter key] to check the status of the race: ");
                Console.ResetColor();
                ConsoleKeyInfo key = Console.ReadKey();
            }

            thread1.Join(); //Joins for a smooth landing
            thread2.Join();
            thread3.Join();
            thread4.Join();

            lock (RaceMethods.lockObject)
            {
                foreach (Car cars in list)
                {
                    Console.WriteLine($"{cars.CarName} placement in the race");
                }
            }
            Console.WriteLine("Race Finished");
           
        }
    }
}
