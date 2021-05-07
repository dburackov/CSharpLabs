using System;
using System.Collections.Generic;
using System.Text;

namespace Transport {
    abstract class Vehicle {
        public static int VehicleNumber = 0;
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
            ++VehicleNumber;
        }
        abstract public void HornSound();
        abstract public void MovementSound();
    }
}
