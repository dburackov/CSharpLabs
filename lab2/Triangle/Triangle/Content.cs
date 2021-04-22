using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle {
    static class Content {
        private static List<string> consoleItem = new List<string>();

        private static void Display() {
            Console.Clear();
            for (int i = 0; i < consoleItem.Count; ++i) {
                Console.Write(consoleItem[i]);
            }
        }

        public static void Push(string line) {
            consoleItem.Add(line);
            Display();
        }

        public static void Pop() {
            consoleItem.RemoveAt(consoleItem.Count - 1);
            Display();
        }

        public static string ReadLine() {
            string result = Console.ReadLine();
            Push(result + '\n');
            return result;
        }

        public static void Clear() {
            consoleItem.Clear();
            Display();
        }
    }
}
