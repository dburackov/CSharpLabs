using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopDrawing {
    class Program {
        static void Main(string[] args) {
            Console.CursorVisible = false;
            Point previous = new Point();
            bool initialized = false;
            List<Color> colorList = new List<Color>() {Color.Blue, Color.Green, Color.Pink, Color.White};
            int colorIndex = 0;
            while (true) {
                if (Console.KeyAvailable) {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape) {
                        break;
                    } else if (key.Key == ConsoleKey.Spacebar) {
                        colorIndex = (colorIndex + 1) % colorList.Count;
                        DesktopDrawing.Clr = colorList[colorIndex];
                    }
                } else {
                    if (initialized) {
                        Point current = new Point(Cursor.Position.X, Cursor.Position.Y);
                        DesktopDrawing.Draw(previous, current);
                        previous = current;
                    } else {
                        previous.X = Cursor.Position.X;
                        previous.Y = Cursor.Position.Y;
                        initialized = true;
                    }
                }
            }
        }
    }
}
