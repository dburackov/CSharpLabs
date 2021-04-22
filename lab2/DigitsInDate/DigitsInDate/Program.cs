using System;

namespace DigitsInDate {
    class Program {
        static void Main(string[] args) {
            string firstFormat = DateTime.Now.ToString("f");
            string secondFormat = DateTime.Now.ToString("g");
            Console.WriteLine(firstFormat);
            Console.WriteLine(secondFormat);
            int[] result = new int[10];
            for (int i = 0; i < secondFormat.Length; i++) {
                int current = (int)secondFormat[i] - 48;
                if (0 <= current && current <= 9) {
                    ++result[current];
                }
            }
            for (int i = 0; i < 10; ++i) {
                Console.WriteLine();
                Console.Write(i + " |");
                for (int j = 0; j < result[i]; ++j) {
                    if (i % 2 == 0) {
                        Console.BackgroundColor = ConsoleColor.Green;
                    } else {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.Write("  ");
                    Console.ResetColor();
                }
                if (result[i] > 0) {
                    Console.Write(" " + result[i]);
                }
            }
        }
    }
}
