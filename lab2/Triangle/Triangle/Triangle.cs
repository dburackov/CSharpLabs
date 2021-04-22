using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle {
    class Triangle {
        public double sideA = 0;
        public double sideB = 0;
        public double sideC = 0;
        public double angleA = 0;
        public double angleB = 0;
        public double angleC = 0;
        public double perimeter = 0;
        public double area = 0;
        public double inscribedCircleRadius = 0;
        public double circumscribedCircleRadius = 0;

        public bool Exist() {
            bool result = true;
            if (sideA >= sideB + sideC) {
                result = false;
            }
            if (sideB >= sideA + sideC) {
                result = false;
            }
            if (sideC >= sideA + sideB) {
                result = false;
            }
            if (angleA + angleB + angleC > 180) {
                result = false;
            }
            return result;
        }
    }
}
/*
 
   /\
B / a\
 /    \ C
/c    b\
-------- 
    A

 */