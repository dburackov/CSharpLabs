using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace SpaceWars {
    class ScreenRender {
        private int consoleWidth;
        private int consoleHeight;
        private static ScreenRender screenRender;

        private ScreenRender(Settings settings) {
            consoleWidth = settings.consoleWidth;
            consoleHeight = settings.consoleHeight;
            Console.SetWindowSize(consoleWidth, consoleHeight);
            Console.SetBufferSize(consoleWidth, consoleHeight);
            Console.CursorVisible = false;
            Console.Title = "Space Wars";
        }

        public static ScreenRender GetScreenRender(Settings settings) {
            if (screenRender == null) {
                screenRender = new ScreenRender(settings);
            }
            return screenRender;
        }

        public void Render(Space space) {
            if (space.boss != null) {
                RenderObject(space.boss);
            }
            if (space.bossBullet != null) {
                RenderObject(space.bossBullet);
            }
            RenderObjectList(space.playerBullet);
            RenderObject(space.playerShip);
            RenderObjectList(space.enemyBullet);
            RenderObjectList(space.enemy);
        }

        public void ClearScreen() {
            Console.Clear();
        }

        private void RenderObject(Object gameObject) {
            Console.ForegroundColor = gameObject.color;
            for (int i = 0; i < gameObject.bodyHeight; ++i) {
                Console.SetCursorPosition(gameObject.positionX, gameObject.positionY + i);
                for (int j = 0; j < gameObject.bodyWidth; ++j) {
                   Console.Write(gameObject.body[i, j]);
                }
            }
            Console.ResetColor();
        }

        private void RenderObjectList(List<Object> objectList) {
            for (int i = 0; i < objectList.Count(); ++i) {
                RenderObject(objectList[i]);
            }
        }
            
        public void GameOverCase(Object wreckedShip) { 
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(consoleWidth / 2 - 1, consoleHeight / 2);
            Console.WriteLine(" GAME ");
            Console.SetCursorPosition(consoleWidth / 2 - 1, consoleHeight / 2 + 1);
            Console.WriteLine(" OVER ");
            Console.ResetColor();
            Random randomValue = new Random();
            for (int i = 0; i < (wreckedShip.bodyHeight * wreckedShip.bodyWidth) / 2; ++i) {
                int coordinateX = randomValue.Next() % wreckedShip.bodyWidth;
                int coordinateY = randomValue.Next() % wreckedShip.bodyHeight;
                Console.SetCursorPosition(coordinateX + wreckedShip.positionX, coordinateY + wreckedShip.positionY);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write('*');
                Thread.Sleep(40);
                Console.SetCursorPosition(coordinateX + wreckedShip.positionX, coordinateY + wreckedShip.positionY);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write('*');
                Thread.Sleep(100);
            }
            Console.ResetColor();
            Thread.Sleep(2000);
        }
        public void WinCase(Object wreckedShip) {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(consoleWidth / 2 - 1, consoleHeight / 2);
            Console.WriteLine(" WIN ");
            Console.ResetColor();
            Random randomValue = new Random();
            for (int i = 0; i < (wreckedShip.bodyHeight * wreckedShip.bodyWidth) / 2; ++i) {
                int coordinateX = randomValue.Next() % wreckedShip.bodyWidth;
                int coordinateY = randomValue.Next() % wreckedShip.bodyHeight;
                Console.SetCursorPosition(coordinateX + wreckedShip.positionX, coordinateY + wreckedShip.positionY);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write('*');
                Thread.Sleep(40);
                Console.SetCursorPosition(coordinateX + wreckedShip.positionX, coordinateY + wreckedShip.positionY);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write('*');
                Thread.Sleep(100);
            }
            Console.ResetColor();
            Thread.Sleep(2000);
        }
    }
}
