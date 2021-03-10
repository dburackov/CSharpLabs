using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceWars {
    class Controller {
        private Engine engine;
        private static Controller controller;

        private Controller(Settings settings) {
            engine = Engine.GetEngine(settings);
        }

        public static Controller GetController(Settings settings) {
            if (controller == null) {
                controller = new Controller(settings);
            }
            return controller;
        }

        public void WaitingPressKey() {
            while (true) {
                if (!engine.gameOver) {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key) {
                        case ConsoleKey.UpArrow:
                            engine.PlayerShipMove(0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            engine.PlayerShipMove(0, 1);
                            break;
                        case ConsoleKey.LeftArrow:
                            engine.PlayerShipMove(-2, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            engine.PlayerShipMove(2, 0);
                            break;
                    }
                }
            }
        }
    }
}
