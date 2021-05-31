using System;

namespace Lab7 {
    class Program {
        static void Main(string[] args) {
            RationalNumber a1 = new RationalNumber("0.(3)");
            RationalNumber b1 = new RationalNumber("1/3");
            RationalNumber res1 = a1 + b1;
            Console.WriteLine(res1);
            Console.WriteLine(a1);
            Console.WriteLine(b1);
            Console.WriteLine(a1.ToString());
            Console.WriteLine(b1.ToString());

            Console.WriteLine();

            Console.WriteLine(a1.ToStirng("{0:C}"));
            Console.WriteLine(a1.ToStirng("{0:f4}"));
            Console.WriteLine(a1.ToStirng("{0:P1}"));

            Console.WriteLine();

            RationalNumber a2 = new RationalNumber("0.654(32)");
            RationalNumber b2 = new RationalNumber("-36.987");
            RationalNumber res2 = a2 - b2;
            Console.WriteLine(res2);
            Console.WriteLine(a2);
            Console.WriteLine(b2);
            Console.WriteLine(a2.ToString());
            Console.WriteLine(b2.ToString());

            RationalNumber res3 = a2 * b2;
            Console.WriteLine(res3);

            RationalNumber res4 = a2 / b2;
            Console.WriteLine(res4);

            double d = a1;
            int i = (int)a1;

            Console.WriteLine(d);
            Console.WriteLine(i);
        }
    }
}