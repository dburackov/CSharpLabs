using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace SpaceWars {
    class Program {
        static Menu menu;
        static Settings settings;
        static Controller controller;

        static void Main(string[] args) {
            Preparation(); 
            while (true) {
                menu.MainMenu(menu.mainMenu.subMenu);
            }
        }

        static void Preparation() {
            settings = new Settings();
            menu = Menu.GetMenu(settings);
            controller = Controller.GetController(settings);
            Thread controllerThread = new Thread(controller.WaitingPressKey);
            controllerThread.Start();
        }
    }
}
