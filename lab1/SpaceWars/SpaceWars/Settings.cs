using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace SpaceWars {
    class Settings {
        public int updateRate = 40;
        public int playerBulletSpeed = 1;
        public int enemySpeed = 8;
        public int enemyBulletSpeed = 3;
        public int bossSpeed = 8;
        public int bossBulletSpeed = 3;
        public int speedAddingEnemy = 80;
        public int speedAddingPlayerBullet = 10;
        public int speedAddingEnemyBullet = 40;
        public int speedAddingBossBullet = 30;
        public int enemiesNumber = 10;

        public int playerShipHitPoints = 5;
        public int enemyHitPoints = 3;
        public int bossHitPoints = 25;

        public int playerShipStartPositionX = 30;
        public int playerShipStartPositionY = 35;
        public int bossSrartPositionX = 20;
        public int bossStartPositionY = 2;
        public int consoleWidth = 60;
        public int consoleHeight = 40;

        public ConsoleColor playerShipColor = ConsoleColor.White;
        public ConsoleColor enemyColor = ConsoleColor.White;
        public ConsoleColor bossColor = ConsoleColor.White;
        public ConsoleColor bossBulletColor = ConsoleColor.Magenta;
        public ConsoleColor playerBulletColor = ConsoleColor.Blue;
        public ConsoleColor enemyBulletColor = ConsoleColor.Red;

        public char[,] playerShip = { {' ', ' ', '/', '^', '\\', ' ', ' '},
                                      {' ', '/', '|', 'O', '|', '\\', ' '},
                                      {'<', '=', '{', 'W', '}', '=', '>'},
                                      {' ', ' ', ' ', '^', ' ', ' ', ' '} };
        public int playerShipBodyWidth = 7;
        public int playerShipBodyHeight = 4;

        public char[,] enemy = { {' ', '/', 'T', '*', 'T', '\\', ' '},
                                 {'(', 'I', '=', 'O', '=', 'I', ')'},
                                 {' ', ' ', ' ' , 'V', ' ', ' ', ' '} };
        public int enemyBodyWidth = 7;
        public int enemyShipBodyHeight = 3;

        public char[,] boss = { {' ', '/', ']', '_', '_', '/', 'T', '*', 'T', '\\', '_', '_', '[', '\\', ' '},
                                {'(', '(', 'I', '=', '=', 'I', '[', 'O', ']', 'I', '=', '=', 'I', ')', ')'},
                                {' ', '\\', 'V', ' ', ' ', '|', '(', ':', ')', '|', ' ', ' ', 'V', '/', ' '},
                                {' ', ' ', ' ', ' ', ' ', 'V', ' ', ' ', ' ', 'V', ' ', ' ', ' ', ' ', ' ',} };
        public int bossBodyWidth = 15;
        public int bossBodyHeight = 4;

        public char[,] playerBullet = { { '|' } };
        public int playerBulletBodyWidth = 1;
        public int playerBulletBodyHeight = 1;

        public char[,] enemyBullet = { { 'Y' } };
        public int enemyBulletBodyWIdth = 1;
        public int enemyBulletBodyHeight = 1;

        public char[,] bossBullet = { {'+'} };
        public int bossBulletBodyWidth = 1;
        public int bossBulletBodyHeight = 1;
    }
}
/*
playerShip:
  /^\
 /|O|\  
<={W}=>
   ^

enemy:
 /T*T\   
(I=O=I) 
   V

boss:            
 /]__/T*T\__[\            
((I==I[O]I==I))     
 \V  |(:)|  V/
     v   V    

*/