using System;

namespace Transport {
    class Program {
        static void Main(string[] args) {
            Car car = new Car(100, 2000);
            car.Horn();
            car.Move();
            Car delorean = new DeLorean(0, 1000);
            delorean.PrintInfo();
            delorean.Horn();
            DeLorean delorean2 = new DeLorean(2000, 200);
            delorean2.ReduceRelevantTime(1000);
            Console.WriteLine(delorean2.Relevant);
            Cadillac cadillac = new Cadillac();
            Console.WriteLine(cadillac.Destroy());
            Console.WriteLine(cadillac.Repair());
            Tesla tesla = new Tesla(2000, 200000);
            Cars list = new Cars();
            list[delorean.Number] = delorean;
            list[delorean.Number].PrintInfo();
            IBreakable breakableCar = new Cadillac(157, 7897);
            Console.WriteLine(breakableCar.Condition);
            breakableCar.Destroy();
            IObsoleable interfaceCar = new DeLorean();
            Console.WriteLine(interfaceCar.Relevant);
            interfaceCar.ReduceRelevantTime(1000000000);
            Console.WriteLine(interfaceCar.Relevant);
            Console.WriteLine("==[]===============[]==");
            delorean2.MoveNotification += (message) => Console.WriteLine("Move event was called:" + message);
            delorean2.HornNotification += (message) => Console.WriteLine("Horn event was called:" + message);
            delorean2.Move();
            delorean2.Horn();
        }
    }
}
