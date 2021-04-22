using System;
using System.Globalization;

namespace Triangle {

    class Program {
        static Triangle triangle = new Triangle();
        static void Main(string[] args) {
            Input();
            Calculate();
            Output();
        }

        static void Input() {
            Content.Push("Choice input format of triangle parameters:\n");
            Content.Push("1. Three sides\n");
            Content.Push("2. Two sides and the angle between them\n");
            Content.Push("3. Two angles and the side adjacent to the given angles\n");
            int inputType = 0;
            while (!int.TryParse(Content.ReadLine(), out inputType) || inputType < 1 || inputType > 3) {
                Content.Pop();
            }

            switch (inputType) {
                case 1:
                    triangle.sideA = GetTriangleParameter("Enter first side: ");
                    triangle.sideB = GetTriangleParameter("Enter second side: ");
                    triangle.sideC = GetTriangleParameter("Enter third side: ");
                    break;
                case 2:
                    triangle.sideA = GetTriangleParameter("Enter first side: ");
                    triangle.sideB = GetTriangleParameter("Enter second side: ");
                    triangle.angleC = GetTriangleParameter("Enter the angle: ");
                    break;
                case 3:
                    triangle.sideA = GetTriangleParameter("Enter the side: ");
                    triangle.angleC = GetTriangleParameter("Enter first angle: ");
                    triangle.angleB = GetTriangleParameter("Enter second angle: ");
                    break;
            }
        }

        static double GetTriangleParameter(string text) {
            Content.Push(text);
            double result;
            while (!double.TryParse(Content.ReadLine(), NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"),
                out result) || result <= 0) {
                Content.Pop();
            }
            return result;
        }

        static void Calculate() {
            if (triangle.angleC == 0) {
                triangle.angleC = Math.Acos((Math.Pow(triangle.sideA, 2) + Math.Pow(triangle.sideB, 2) 
                    - Math.Pow(triangle.sideC, 2)) / (2 * triangle.sideA * triangle.sideB)) * 180 / Math.PI;
            }
            if (triangle.angleB == 0) {
                if (triangle.sideC == 0) {
                    triangle.sideC = Math.Sqrt(Math.Pow(triangle.sideA, 2) + Math.Pow(triangle.sideB, 2)
                        - 2 * triangle.sideA * triangle.sideB * Math.Cos(Radians(triangle.angleC)));
                }
                triangle.angleB = Math.Asin(Math.Sin(Radians(triangle.angleC)) * triangle.sideB 
                    / triangle.sideC) * 180 / Math.PI;
            }
            triangle.angleA = 180 - triangle.angleB - triangle.angleC;
            if (triangle.sideB == 0) {
                triangle.sideB = triangle.sideA * Math.Sin(Radians(triangle.angleB)) 
                    / Math.Sin(Radians(triangle.angleA));
            }
            if (triangle.sideC == 0) {
                Console.WriteLine("!!!!!");
                triangle.sideC = triangle.sideA * Math.Sin(Radians(triangle.angleC))
                    / Math.Sin(Radians(triangle.angleA));
            }
            triangle.perimeter = triangle.sideA + triangle.sideB + triangle.sideC;
            triangle.area = Math.Sqrt(triangle.perimeter / 2 * (triangle.perimeter / 2 - triangle.sideA) 
                * (triangle.perimeter / 2 - triangle.sideB) * (triangle.perimeter / 2 - triangle.sideC));
            triangle.inscribedCircleRadius = 2 * triangle.area / triangle.perimeter;
            triangle.circumscribedCircleRadius = triangle.sideA * triangle.sideB * triangle.sideC / (4 * triangle.area);
        }

        static double Radians(double degrees) {
            return degrees * Math.PI / 180;
        }

        static void Output() {
            Content.Clear();
            if (triangle.Exist()) {
                Console.WriteLine("Side A = " + Math.Round(triangle.sideA, 2));
                Console.WriteLine("Side B = " + Math.Round(triangle.sideB, 2));
                Console.WriteLine("Side C = " + Math.Round(triangle.sideC, 2));
                Console.WriteLine("The angle opposite side A = " + Math.Round(triangle.angleA, 2));
                Console.WriteLine("The angle opposite side B = " + Math.Round(triangle.angleB, 2));
                Console.WriteLine("The angle opposite side C = " + Math.Round(triangle.angleC, 2));
                Console.WriteLine("Perimert = " + Math.Round(triangle.perimeter, 2));
                Console.WriteLine("Area = " + Math.Round(triangle.area, 2));
                Console.WriteLine("Radius of inscribed circle = " + Math.Round(triangle.inscribedCircleRadius, 2));
                Console.WriteLine("Radius of circumscribed circle  = " + Math.Round(triangle.circumscribedCircleRadius, 2));
            } else {
                Console.WriteLine("This triangle can't exist!");
            }
        }
    }
}
