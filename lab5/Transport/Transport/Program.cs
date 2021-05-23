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
            Console.WriteLine(delorean.Compare(car));
            DeLorean delorean2 = new DeLorean(2000, 200);
            delorean2.ReduceRelevantTime(1000);
            Console.WriteLine(delorean2.Relevant);
            Cadillac cadillac = new Cadillac();
            Console.WriteLine(cadillac.Compare(delorean2));
            Console.WriteLine(cadillac.Destroy());
            Console.WriteLine(cadillac.Repair());
            Tesla tesla = new Tesla(2000, 200000);
            Cars list = new Cars();
            list[delorean.Number] = delorean;
            list[delorean.Number].PrintInfo();
            for (int i = 0; i < 10; ++i) {
                tesla.Move();
            }
            Console.WriteLine(tesla.Condition);
        }
    }
}
