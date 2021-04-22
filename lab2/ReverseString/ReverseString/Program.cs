using System;
using System.Text;

namespace ReverseString {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter string:");
            StringBuilder s = new StringBuilder(Console.ReadLine());
            for (int i = 0; i < s.Length / 2; ++i) {
                char temp = s[i];
                s[i] = s[s.Length - i - 1];
                s[s.Length - i - 1] = temp;
            }
            s.Append(' ');
            int beginOfWord = 0;
            int endOfWord = 0;
            for (int i = 0; i < s.Length; ++ i) {
                if (s[i] == ' ') {
                    for (int l = beginOfWord, r = endOfWord; l < r; ++l, -- r) {
                        char temp = s[l];
                        s[l] = s[r];
                        s[r] = temp;
                    }
                    beginOfWord = i;
                } else {
                    endOfWord = i;
                    if (s[beginOfWord] == ' ') {
                        beginOfWord = i;
                    }
                }
            }
            Console.WriteLine(s);
        }
    }
}
