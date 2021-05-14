using System;
using mydll;

namespace WorkWithDLL {
    class Program {
        static void Main(string[] args) {
            Pair<char> a = new Pair<char>('A'); 
            Pair<char> b = new Pair<char>('B'); 
            Pair<char> c = new Pair<char>('C');

            Pair<int> i1 = new Pair<int>(12);
            Pair<int> i2 = new Pair<int>(567);
            Pair<int> i3 = new Pair<int>(972);

            Pair<bool> x = new Pair<bool>(true);
            Pair<bool> y = new Pair<bool>(false);

            UnMemory<char>.SaveInMemory(a.value, ref a.ptr);
            UnMemory<char>.SaveInMemory(b.value, ref b.ptr);
            UnMemory<char>.SaveInMemory(c.value, ref c.ptr);

            UnMemory<int>.SaveInMemory(i1.value, ref i1.ptr);
            UnMemory<int>.SaveInMemory(i2.value, ref i2.ptr);
            UnMemory<int>.SaveInMemory(i3.value, ref i3.ptr);

            UnMemory<bool>.SaveInMemory(x.value, ref x.ptr);
            UnMemory<bool>.SaveInMemory(y.value, ref y.ptr);

            Console.WriteLine(UnMemory<char>.ReadInMemory(a.ptr));
            Console.WriteLine(UnMemory<char>.ReadInMemory(b.ptr));
            Console.WriteLine(UnMemory<char>.ReadInMemory(c.ptr));

            Console.WriteLine(UnMemory<int>.ReadInMemory(i1.ptr));
            Console.WriteLine(UnMemory<int>.ReadInMemory(i2.ptr));
            Console.WriteLine(UnMemory<int>.ReadInMemory(i3.ptr));

            Console.WriteLine(UnMemory<bool>.ReadInMemory(x.ptr));
            Console.WriteLine(UnMemory<bool>.ReadInMemory(y.ptr));

            UnMemory.FreeMemory();
        }
    }
}
