using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace SpaceWars {
    class Space {
        public List<Object> enemy;
        public List<Object> playerBullet;
        public List<Object> enemyBullet;
        public Object boss;
        public Object playerShip;
        public Object bossBullet;
        private static Space space;

        private Space(Settings settings) {
            playerShip = ObjectCreation.PlayerShipCreation(settings);
            playerBullet = new List<Object>();
            enemyBullet = new List<Object>();
            enemy = new List<Object>();
        }

        public static Space GetSpace(Settings settings) {
            if (space == null) {
                space = new Space(settings);
            }
            return space;
        }
    }
}
