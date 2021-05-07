using System;

namespace Transport {
    class Program {
        static void Main(string[] args) {
            Vehicle car1 = new Car();
            Vehicle car2 = new Car(4000);
            Vehicle car3 = new Car(1000, 2000);

            car1.Cost = 100;
            car1.LoadLimit = 90;

            Console.WriteLine(car1.Cost + " " + car1.LoadLimit);
            Console.WriteLine(car2.Cost + " " + car2.LoadLimit);
            Console.WriteLine(car3.Cost + " " + car3.LoadLimit);

            car1.HornSound();

            Console.WriteLine(Vehicle.VehicleNumber);
        }
    }
}
