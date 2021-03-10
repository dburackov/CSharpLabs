using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace SpaceWars {
    class Object {
        public int positionX;
        public int positionY;
        public int hitPoints;
        public char[,] body;
        public int bodyWidth;
        public int bodyHeight;
        public ConsoleColor color;
    }
}
