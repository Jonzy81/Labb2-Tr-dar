namespace Labb2_Trådar
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Car car1 = new Car(" Porsche 918 Spyder");
            Car car2 = new Car("Lamborghini Aventador");
            Car car3 = new Car("McLaren F1");
            Car car4 = new Car("Ferrari LaFerrari");

            List<Car> list = new List<Car> { car1, car2, car3, car4 };

            Task taskCar1 = Task.Run(() => RaceMethods.Race(car1));
            Task taskCar2 = Task.Run(() => RaceMethods.Race(car2));
            Task taskCar3 = Task.Run(() => RaceMethods.Race(car3));
            Task taskCar4 = Task.Run(() => RaceMethods.Race(car4));

            await Task.WhenAll(taskCar1, taskCar2, taskCar3, taskCar4);
            Console.WriteLine("Race Finished");
        }
    }
}
