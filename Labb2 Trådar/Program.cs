namespace Labb2_Trådar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(" Porsche 918 Spyder", 10);
            Car car2 = new Car("Lamborghini Aventador", 10);
            Car car3 = new Car("McLaren F1", 10);
            Car car4 = new Car("Ferrari LaFerrari", 10);

            List<Car> list = new List<Car> { car1, car2, car3, car4 };

            Thread thread1 = new Thread(() => RaceMethods.Race(car1));  //Creating Threads that delegates my race method and declares object for them 
            Thread thread2 = new Thread(() => RaceMethods.Race(car2));
            Thread thread3 = new Thread(() => RaceMethods.Race(car3));
            Thread thread4 = new Thread(() => RaceMethods.Race(car4));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            thread1.Join(); //Joins for a smooth landing
            thread2.Join();
            thread3.Join();
            thread4.Join();

            Console.WriteLine("Race Finished");
        }
    }
}
