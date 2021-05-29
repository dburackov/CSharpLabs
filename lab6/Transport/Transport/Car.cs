using System;
using System.Media;

namespace Transport {
    class Car : Vehicle, IComparable<Car> {
        protected static int carsNumber = 0;
        public Car(int cost = 0, int loadLimit = 0) : base(cost, loadLimit) {
            if (carsNumber == Int32.MaxValue) {
                throw new Exception("Too many cars \n");
            }
            Number = carsNumber;
            ++carsNumber;
        }
        public string Name { get; set; } = "Unnamed";
        public int Number { get; private set; }
        public int CompareTo(Car car) {
            int result = 0;
            if (Number < car.Number) {
                result = -1;
            }
            if (Number > car.Number) {
                result = 1;
            }
            return result;
        }
        public void PrintInfo() {
            Console.WriteLine("name: " + Name);
            Console.WriteLine("number : " + Number);
        }
        public override void Horn() {
            SoundPlayer horn = new SoundPlayer(@"..\..\src\horn.wav");
            horn.PlaySync();
            
        }
        public override void Move() {
            SoundPlayer move = new SoundPlayer(@"..\..\src\move.wav");
            move.PlaySync();
        }
    }
}
