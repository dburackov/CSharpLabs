using System;
using System.Collections.Generic;

namespace WorkWithDLL {
    class Pair<T> where T : struct {
        public T value;
        public IntPtr ptr;
        public Pair(T value) {
            this.value = value;
            ptr = IntPtr.Zero;
        }
    }
}
