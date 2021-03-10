using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace SpaceWars {
    class ObjectCreation {
        public static Object PlayerShipCreation(Settings settings) {
            Object playerShip = new Object();
            playerShip.positionX = settings.playerShipStartPositionX;
            playerShip.positionY = settings.playerShipStartPositionY;
            playerShip.body = settings.playerShip;
            playerShip.bodyWidth = settings.playerShipBodyWidth;
            playerShip.bodyHeight = settings.playerShipBodyHeight;
            playerShip.hitPoints = settings.playerShipHitPoints;
            playerShip.color = settings.playerShipColor;
            return playerShip;
        }

        public static Object EnemyCreation(Settings settings, int positionX, int positionY) {
            Object enemy = new Object();
            enemy.positionX = positionX;
            enemy.positionY = positionY;
            enemy.body = settings.enemy;
            enemy.bodyWidth = settings.enemyBodyWidth;
            enemy.bodyHeight = settings.enemyShipBodyHeight;
            enemy.hitPoints = settings.enemyHitPoints;
            enemy.color = settings.enemyColor;
            return enemy;
        }

        public static Object PlayerBulletCreation(Settings settings, int positionX, int positionY) {
            Object playerBullet = new Object();
            playerBullet.positionX = positionX;
            playerBullet.positionY = positionY;
            playerBullet.body = settings.playerBullet;
            playerBullet.bodyWidth = settings.playerBulletBodyWidth;
            playerBullet.bodyHeight = settings.playerBulletBodyHeight;
            playerBullet.color = settings.playerBulletColor;
            return playerBullet;
        }

        public static Object EnemyBulletCreation(Settings settings, int positionX, int positionY) {
            Object enemyBullet = new Object();
            enemyBullet.positionX = positionX;
            enemyBullet.positionY = positionY;
            enemyBullet.body = settings.enemyBullet;
            enemyBullet.bodyWidth = settings.enemyBulletBodyWIdth;
            enemyBullet.bodyHeight = settings.enemyBulletBodyHeight;
            enemyBullet.color = settings.enemyBulletColor;
            return enemyBullet;
        }
        public static Object BossCreation(Settings settings) {
            Object boss = new Object();
            boss.positionX = settings.bossSrartPositionX;
            boss.positionY = settings.bossStartPositionY;
            boss.body = settings.boss;
            boss.bodyWidth = settings.bossBodyWidth;
            boss.bodyHeight = settings.bossBodyHeight;
            boss.hitPoints = settings.bossHitPoints;
            boss.color = settings.bossColor;
            return boss;
        }

        public static Object BossBulletCreation(Settings settings, int positionX, int positionY) {
            Object bossBullet = new Object();
            bossBullet.positionX = positionX;
            bossBullet.positionY = positionY;
            bossBullet.body = settings.bossBullet;
            bossBullet.bodyWidth = settings.bossBulletBodyWidth;
            bossBullet.bodyHeight = settings.bossBulletBodyHeight;
            bossBullet.color = settings.bossBulletColor;
            return bossBullet;
        }
    }
}
