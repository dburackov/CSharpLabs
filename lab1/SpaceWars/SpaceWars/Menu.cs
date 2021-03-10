using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace SpaceWars {
    class Menu {
        public MenuItem mainMenu;
        private Engine engine;
        private Settings settings;
        private static Menu menu;

        private Menu(Settings settings) {
            this.settings = settings;
            engine = Engine.GetEngine(settings);
            mainMenu = new MenuItem();
            mainMenu.subMenu.Add(new MenuItem("Play", true));
            mainMenu.subMenu.Add(new MenuItem("Game mode", false));
            mainMenu.subMenu.Add(new MenuItem("Exit", false));
            mainMenu.FindItem("Game mode").subMenu.Add(new MenuItem("Easy", false));
            mainMenu.FindItem("Game mode").subMenu.Add(new MenuItem("Normal", true));
            mainMenu.FindItem("Game mode").subMenu.Add(new MenuItem("Hard", false));
        }

        public static Menu GetMenu(Settings settings) {
            if (menu == null) {
                menu = new Menu(settings);
            }
            return menu;
        }
        public void MainMenu(List<MenuItem> menuItem) {
            int activeItem = 0;
            for (int i = 0; i < menuItem.Count(); ++i) {
                if (menuItem[i].active) {
                    activeItem = i;
                    break;
                }
            }
            while (true) {
                Console.Clear();
                for (int i = 0; i < menuItem.Count(); ++i) {
                    int CursorPositionX = settings.consoleWidth / 2 - menuItem[i].name.Length / 2;
                    int CursorPositionY = settings.consoleHeight / 2 + i;
                    if (menuItem[i].active) {
                        Console.SetCursorPosition(CursorPositionX - 2, CursorPositionY);
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("> " + menuItem[i].name + " <");
                        Console.ResetColor();
                    } else {
                        Console.SetCursorPosition(CursorPositionX, CursorPositionY);
                        Console.WriteLine(menuItem[i].name);
                    }
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key) {
                    case ConsoleKey.UpArrow:
                        menuItem[activeItem].active = false;
                        activeItem = (activeItem - 1 + menuItem.Count()) % menuItem.Count();
                        menuItem[activeItem].active = true;
                        break;
                    case ConsoleKey.DownArrow:
                        menuItem[activeItem].active = false;
                        activeItem = (activeItem + 1) % menuItem.Count();
                        menuItem[activeItem].active = true;
                        break;
                    case ConsoleKey.Enter:
                        switch (menuItem[activeItem].name) {
                            case "Play":
                                engine.Run();
                                engine.Restart();
                                break;
                            case "Game mode":
                                MainMenu(menuItem[activeItem].subMenu);
                                break;
                            case "Exit":
                                Environment.Exit(0);
                                return;
                            case "Easy":
                                settings.enemiesNumber = 5;
                                settings.enemyHitPoints = 2;
                                settings.bossHitPoints = 15;
                                settings.bossBulletSpeed = 4;
                                engine.settings = settings;
                                return;
                            case "Normal":
                                settings.enemiesNumber = 10;
                                settings.enemyHitPoints = 3;
                                settings.bossHitPoints = 25;
                                settings.bossBulletSpeed = 3;
                                engine.settings = settings;
                                return;
                            case "Hard":
                                settings.enemiesNumber = 20;
                                settings.enemyHitPoints = 4;
                                settings.bossHitPoints = 50;
                                settings.bossBulletSpeed = 2;
                                engine.settings = settings;
                                return;
                        }
                        break;
                }
            }
        }
    }
}
