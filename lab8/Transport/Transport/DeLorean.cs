using System;
using System.Media;

namespace Transport {
    class DeLorean : Car, IObsoleable {
        public delegate void CarDelegate(string message);
        public event CarDelegate MoveNotification;
        public event CarDelegate HornNotification;
        public DeLorean(int cost = 0, int loadLimit = 0) : base(cost, loadLimit) {
            Name = "DeLorean";
            Relevant = true;
        }
        private int timeLeft = 360;
        public bool Relevant { get; private set; }
        public void ReduceRelevantTime(int months) {
            if (months > 0) {
                timeLeft -= months;
            }
            if (timeLeft <= 0) {
                Relevant = false;
            }
        }
        public override void Horn() {
            SoundPlayer horn = new SoundPlayer(@"..\..\src\deloreanhorn.wav");
            horn.PlaySync();
            HornNotification?.Invoke($"\"{Name}\" Car is horning");

        }
        public override void Move() {
            SoundPlayer move = new SoundPlayer(@"..\..\src\deloreanmove.wav");
            move.PlaySync();
            MoveNotification?.Invoke($"\"{Name}\" Car is riding");
        }
    }
}
