using System;
using System.Runtime.InteropServices;

namespace mydll {
    public static class UnMemory<T> where T : struct {
        public static void SaveInMemory(T memoryObject, ref IntPtr ptr) {
            if (default(T).Equals(memoryObject)) {
                ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(T)));
                UnMemory.Enqueue(ptr);
            } else {
                if (ptr == IntPtr.Zero) {
                    ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(T)));
                    Marshal.StructureToPtr(memoryObject, ptr, false);
                } else {
                    Marshal.StructureToPtr(memoryObject, ptr, true);
                }
                UnMemory.Enqueue(ptr);
            }
        }

        public static T ReadInMemory(IntPtr ptr) {
            return (T)Marshal.PtrToStructure(ptr, typeof(T));
        }
    }
}
