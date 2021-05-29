using System;
using System.Media;

namespace Transport {
    class Cadillac : Car, IBreakable {
        public delegate void CarDelegate(string message);
        public event CarDelegate MoveNotification;
        public event CarDelegate HornNotification;
        public Cadillac(int cost = 0, int loadLimit = 0) : base(cost, loadLimit) {
            Name = "Cadillac";
            Condition = "Can be used";
        }
        public string Condition { get; set; }
        public string Destroy() {
            Condition = "Useless";
            return $"\"{Name}\" Car {Number} is destroyed";
        }
        public string Repair() {
            Condition = "Can be used";
            return $"\"{Name}\" Car {Number} is repaired"; 
        }
        public override void Horn() {
            SoundPlayer horn = new SoundPlayer(@"..\..\src\cadillachorn.wav");
            horn.PlaySync();
            HornNotification?.Invoke($"\"{Name}\" Car is horning");
        }
        public override void Move() {
            SoundPlayer move = new SoundPlayer(@"..\..\src\cadillacmove.wav");
            move.PlaySync();
            MoveNotification?.Invoke($"\"{Name}\" Car is riding");
        }
    }
}
