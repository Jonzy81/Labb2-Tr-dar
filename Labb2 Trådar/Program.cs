namespace Labb2_Trådar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Porsche 918 Spyder");
            Car car2 = new Car("Lamborghini Aventador");
            Car car3 = new Car("McLaren F1");
            Car car4 = new Car("Ferrari LaFerrari");

            CancellationTokenSource cts = new CancellationTokenSource();


            List<Car> list = new List<Car>();
            bool progress = true;

            Thread thread1 = new Thread(() => RaceMethods.Race(car1, list, cts));  //Creating Threads that delegates my race method and declares object for them 
            Thread thread2 = new Thread(() => RaceMethods.Race(car2, list, cts));
            Thread thread3 = new Thread(() => RaceMethods.Race(car3, list, cts));
            Thread thread4 = new Thread(() => RaceMethods.Race(car4, list, cts));


            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            while (!cts.Token.IsCancellationRequested)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please press [enter key] to check the status of the race: ");
                Console.ResetColor();

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {   
                    Console.Clear();
                    Console.WriteLine("Current Race Status:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{car1.CarName,-23} - Distance: {car1.Distance*10,-6:0.###}km, \tSpeed: {car1.Speed,-8}");
                    Console.WriteLine($"{car2.CarName,-23} - Distance: {car2.Distance*10,-6:0.###}km, \tSpeed: {car2.Speed,-8}");
                    Console.WriteLine($"{car3.CarName,-23} - Distance: {car3.Distance * 10,-6:0.###}km, \tSpeed: {car3.Speed,-8}");
                    Console.WriteLine($"{car4.CarName,-23} - Distance: {car4.Distance * 10,-6:0.###}km, \tSpeed: {car4.Speed,-8}");
                    Console.ResetColor();
                    if(list.Count > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Winner{list[0].CarName} is the winner of the race");
                        Console.ResetColor();
                    }
                }
            }

            thread1.Join(); //Joins for a smooth landing
            thread2.Join();
            thread3.Join();
            thread4.Join();

            lock (RaceMethods.lockObject)
            {
                int index=0;
                foreach (Car cars in list)
                {

                    Console.WriteLine($"{index+1} {cars.CarName} placement in the race");
                    index++;
                }
            }
            Console.WriteLine("Race Finished");

        }
    }
}
