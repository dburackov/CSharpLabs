using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace mydll {
    public static class UnMemory {
        private static Queue<IntPtr> queue = new Queue<IntPtr>();

        public static void Enqueue(IntPtr ptr) {
            queue.Enqueue(ptr);
        }

        private static void FreeIntPtr(IntPtr ptr) {
            if (ptr != IntPtr.Zero) {
                Marshal.FreeCoTaskMem(ptr);
            }
        }

        public static void FreeMemory() {
            while(queue.Count > 0) {
                IntPtr temp = queue.Dequeue();
                FreeIntPtr(temp);
            }
        }
    }
}
