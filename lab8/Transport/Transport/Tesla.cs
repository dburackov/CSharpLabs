using System;
using System.Media;

namespace Transport {
    class Tesla : Car {
        public delegate void CarDelegate(string message);
        public event CarDelegate MoveNotification;
        public event CarDelegate HornNotification;
        public Tesla(int cost = 0, int loadLimit = 0) : base(cost, loadLimit) {
            Name = "Tesla";
            Condition = "Full battery";
        }
        public int batteryLevel = 100;
        public string Condition { get; set; }
        public void Charging () {
            batteryLevel = 100;
            Condition = "Full baterry";
        }
        public override void Horn() {
            SoundPlayer horn = new SoundPlayer(@"..\..\src\teslahorn.wav");
            horn.PlaySync();
            HornNotification?.Invoke($"\"{Name}\" Car is horning");
        }
        public override void Move() {
            SoundPlayer move = new SoundPlayer(@"..\..\src\teslamove.wav");
            move.PlaySync();
            batteryLevel -= 10;
            if (batteryLevel <= 0) {
                Condition = "Empty battery";
            } else if (batteryLevel <= 30) {
                Condition = "Low battery";
            }
            MoveNotification?.Invoke($"\"{Name}\" Car is riding");
        }
    }
}
