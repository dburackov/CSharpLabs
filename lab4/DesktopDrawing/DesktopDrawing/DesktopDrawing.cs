using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DesktopDrawing {
    class DesktopDrawing {
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll")]
        static extern void ReleaseDC(IntPtr ptr);

        private static Color color = Color.White;

        public static Color Clr {
            get {
                return color;
            }
            set {
                color = value;
            }
        }

        public static void Draw(Point a, Point b) {
            IntPtr DesktopDC = GetDC(IntPtr.Zero);
            Graphics graphics = Graphics.FromHdc(DesktopDC);
            Pen pen = new Pen(color);
            graphics.DrawLine(pen, a, b);
            graphics.Dispose();
            ReleaseDC(DesktopDC);
        }
    }
}
