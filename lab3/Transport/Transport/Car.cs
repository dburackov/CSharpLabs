using System;
using System.Collections.Generic;
using System.Text;

namespace Transport {
    //temporary realization
    class Car : Vehicle {
        public Car(int cost = 0, int loadLimit = 0) : base(cost, loadLimit) {

        }
        public override void Horn() {
            Console.WriteLine("Beep!");
        }
        public override void Movement() {
            
        }
    }
}
