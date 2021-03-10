using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace SpaceWars {
    class MenuItem {
        public string name;
        public List<MenuItem> subMenu;
        public bool active;

        public MenuItem() {
            subMenu = new List<MenuItem>();
            active = false;
        }

        public MenuItem(string name, bool active) {
            this.name = name;
            subMenu = new List<MenuItem>();
            this.active = active;
        }

        public MenuItem FindItem(string name) {
            MenuItem result = this;
            for (int i = 0; i < subMenu.Count(); ++i) {
                if (name == subMenu[i].name) {
                    result = subMenu[i];
                    break;
                }
            }
            return result;
        }
    }
}
