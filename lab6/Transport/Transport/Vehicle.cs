using System;

namespace Transport {
    abstract class Vehicle {
        private int loadLimit;
        private int cost;
        public int LoadLimit {
            get {
                return loadLimit;
            }
            set {
                if (value >= 0) {
                    loadLimit = value;
                } else {
                    throw new Exception("LoadLimit must be not negative number \n");
                }
            }
        }
        public int Cost {
            get {
                return cost;
            }
            set {
                if (value >= 0) {
                    cost = value;
                } else {
                    throw new Exception("Cost must be not negative number \n");
                }
            }
        }
        public Vehicle(int cost = 0, int loadLimit = 0) {
            Cost = cost;
            LoadLimit = loadLimit;
        }
        abstract public void Horn();
        abstract public void Move();
    }
}
