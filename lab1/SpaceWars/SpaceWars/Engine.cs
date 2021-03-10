using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace SpaceWars {
    class Engine {
        public bool gameOver;
        public bool win;
        public Settings settings;
        private Space space;
        private ScreenRender screenRender;
        private int bossShiftX;
        private int bossStep;
        private static Engine engine;

        private Engine(Settings settings) {
            gameOver = true;
            win = false;
            bossShiftX = 1;
            bossStep = 0;
            this.settings = settings;
            space = Space.GetSpace(settings);
            screenRender = ScreenRender.GetScreenRender(settings);
        }

        public static Engine GetEngine(Settings settings) {
            if (engine == null) {
                engine = new Engine(settings);
            }
            return engine;
        }

        public void Run() {
            int enemyMoveCounter = 0;
            int addingEnemyCouter = 0;
            int playerBulletMoveCounter = 0;
            int addingPlayerBulletCouter = 0;
            int enemyBulletMoveCounter = 0;
            int addingEnemyBulletCounter = 0;
            int bossBulletMoveCounter = 0;
            int addingBossBulletCounter = 0;
            int bossMoveCounter = 0;
            int enemiesCounter = 0;
            int bossDelay = 0;
            bool bossCreation = false;
            Random randomeValue = new Random();
            gameOver = false;

            do {
                screenRender.ClearScreen();
                screenRender.Render(space);
                CalculateCollision();
                Thread.Sleep(settings.updateRate);
                if (enemyMoveCounter == settings.enemySpeed) {
                    EnemyMove();
                    enemyMoveCounter = 0;
                }
                if (addingEnemyCouter == settings.speedAddingEnemy && enemiesCounter < settings.enemiesNumber) {
                    int enemyStartPosition = randomeValue.Next() % (settings.consoleWidth - settings.enemyBodyWidth + 1);
                    space.enemy.Add(ObjectCreation.EnemyCreation(settings, enemyStartPosition, 0));
                    ++enemiesCounter;
                    if (enemiesCounter == settings.enemiesNumber) {
                        bossCreation = true;
                    }
                    addingEnemyCouter = 0;
                }
                if (playerBulletMoveCounter == settings.playerBulletSpeed) {
                    PlayerBulletMove();
                    playerBulletMoveCounter = 0;
                }
                if (addingPlayerBulletCouter == settings.speedAddingPlayerBullet) {
                    int startPositionX = space.playerShip.positionX + space.playerShip.bodyWidth / 2;
                    int startPositionY = space.playerShip.positionY - 1;
                    space.playerBullet.Add(ObjectCreation.PlayerBulletCreation(settings, startPositionX, startPositionY));
                    if (PositionPossibility(space.playerBullet[space.playerBullet.Count() - 1], 0, 0) == false) {
                        space.playerBullet.RemoveAt(space.playerBullet.Count() - 1);
                    }
                    addingPlayerBulletCouter = 0;
                }
                if (enemyBulletMoveCounter == settings.enemyBulletSpeed) {
                    EnemyBulletMove();
                    enemyBulletMoveCounter = 0;
                }
                if (addingEnemyBulletCounter == settings.speedAddingEnemyBullet) {
                    for (int i = 0; i < space.enemy.Count(); ++i) {
                        int startPositionX = space.enemy[i].positionX + space.enemy[i].bodyWidth / 2;
                        int startPositionY = space.enemy[i].positionY + space.enemy[i].bodyHeight;
                        space.enemyBullet.Add(ObjectCreation.EnemyBulletCreation(settings, startPositionX, startPositionY));
                        if (PositionPossibility(space.enemyBullet[space.enemyBullet.Count() - 1], 0, 0) == false) {
                            space.enemyBullet.RemoveAt(space.enemyBullet.Count() - 1);
                        }
                    }
                    addingEnemyBulletCounter = 0;
                }
                if (bossCreation == true) {
                    if (bossDelay < settings.speedAddingEnemy) {
                        ++bossDelay;
                    } else {
                        space.boss = ObjectCreation.BossCreation(settings);
                        bossCreation = false;
                    }
                }
                if (bossMoveCounter == settings.bossSpeed) {
                    BossMove();
                    bossMoveCounter = 0;
                }
                if (addingBossBulletCounter == settings.speedAddingBossBullet) {
                    int startPositionX = space.boss.positionX;
                    int startPositionY = space.boss.positionY + space.boss.bodyHeight;
                    space.enemyBullet.Add(ObjectCreation.EnemyBulletCreation(settings, startPositionX + 2, startPositionY - 1));
                    space.enemyBullet.Add(ObjectCreation.EnemyBulletCreation(settings, startPositionX + 5, startPositionY));
                    space.enemyBullet.Add(ObjectCreation.EnemyBulletCreation(settings, startPositionX + 9, startPositionY));
                    space.enemyBullet.Add(ObjectCreation.EnemyBulletCreation(settings, startPositionX + 12, startPositionY - 1));
                    addingBossBulletCounter = 0;
                }
                if (space.boss != null && space.bossBullet == null) {
                    int startPositionX = space.boss.positionX + space.boss.bodyWidth / 2;
                    int srartPositionY = space.boss.positionY + space.boss.bodyHeight - 1;
                    space.bossBullet = ObjectCreation.BossBulletCreation(settings, startPositionX, srartPositionY);
                }
                if (bossBulletMoveCounter == settings.bossBulletSpeed) {
                    BossBulletMove();
                    bossBulletMoveCounter = 0;
                }
                if (space.boss != null) {
                    ++bossMoveCounter;
                    ++bossBulletMoveCounter;
                    ++addingBossBulletCounter;
                }
                ++enemyBulletMoveCounter;
                ++addingEnemyBulletCounter;
                ++enemyMoveCounter;
                ++addingEnemyCouter;
                ++playerBulletMoveCounter;
                ++addingPlayerBulletCouter;
            } while (!gameOver);
        }

        public void PlayerShipMove(int shiftX, int shiftY) {
            if (PositionPossibility(space.playerShip, shiftX, shiftY) == true) {
                space.playerShip.positionX += shiftX;
                space.playerShip.positionY += shiftY;
            }
        }

        private void EnemyMove() {
            for (int i = 0; i < space.enemy.Count(); ++i) {
                if (PositionPossibility(space.enemy[i], 0, 1) == true) {
                    ++space.enemy[i].positionY;
                } else {
                    space.enemy.RemoveAt(i);
                    --i;
                }
            }
        }

        private void PlayerBulletMove() {
            for (int i = 0; i < space.playerBullet.Count(); ++i) {
                if (PositionPossibility(space.playerBullet[i], 0, -1) == true) {
                    --space.playerBullet[i].positionY;
                } else {
                    space.playerBullet.RemoveAt(i);
                    --i;
                }
            }
        }

        private void EnemyBulletMove() {
            for (int i = 0; i < space.enemyBullet.Count(); ++i) {
                if (PositionPossibility(space.enemyBullet[i], 0, 1) == true) {
                    ++space.enemyBullet[i].positionY;
                } else {
                    space.enemyBullet.RemoveAt(i);
                    --i;
                }
            }
        }

        private void BossMove() {
            if (bossStep > 10) {
                bossShiftX *= -1;
                bossStep = 0;
            }
            ++bossStep;
            space.boss.positionX += bossShiftX;
        }

        private void BossBulletMove() {
            int shiftX = 0;
            if (space.playerShip.positionX + space.playerShip.bodyWidth / 2 < space.bossBullet.positionX) {
                shiftX = -1;
            } else if (space.playerShip.positionX + space.playerShip.bodyWidth / 2 > space.bossBullet.positionX) {
                shiftX = 1;
            }
            if (PositionPossibility(space.bossBullet, shiftX, 1) == true) {
                space.bossBullet.positionX += shiftX;
                ++space.bossBullet.positionY;
            } else {
                space.bossBullet = null;
            }
        }

        private bool PositionPossibility(Object oneObject, int shiftX, int ShiftY) { //true if position is correct
            bool result = true;
            if (oneObject.positionX + shiftX < 0) {
                result = false;
            }
            if (oneObject.positionX + shiftX + oneObject.bodyWidth - 1 >= settings.consoleWidth) {
                result = false;
            }
            if (oneObject.positionY + ShiftY < 0) {
                result = false;
            }
            if (oneObject.positionY + ShiftY + oneObject.bodyHeight - 1 >= settings.consoleHeight) {
                result = false;
            }
            return result;
        }

        private void CalculateCollision() {
            for (int i = 0; i < space.playerBullet.Count(); ++i) {
                for (int j = 0; j < space.enemy.Count(); ++j) {
                    if (ObjectIntersection(space.playerBullet[i], space.enemy[j]) == true) {
                        --space.enemy[j].hitPoints;
                        if (space.enemy[j].hitPoints == 0) {
                            space.enemy.RemoveAt(j);
                        }
                        space.playerBullet.RemoveAt(i);
                        break;
                    }
                }
            }
            for (int i = 0; i < space.playerBullet.Count() && space.boss != null; ++i) {
                if (ObjectIntersection(space.playerBullet[i], space.boss) == true) {
                    --space.boss.hitPoints;
                    if (space.boss.hitPoints <= settings.bossHitPoints * 0.2) {
                        space.boss.color = ConsoleColor.DarkYellow;
                    }
                    if (space.boss.hitPoints == 0) {
                        gameOver = win = true;
                        break;
                    }
                    space.playerBullet.RemoveAt(i);
                }
            }
            for (int i = 0; i < space.enemyBullet.Count(); ++i) {
                if (ObjectIntersection(space.enemyBullet[i], space.playerShip) == true) {
                    --space.playerShip.hitPoints;
                    if (space.playerShip.hitPoints <= settings.playerShipHitPoints * 0.2) {
                        space.playerShip.color = ConsoleColor.DarkYellow;
                    }
                    if (space.playerShip.hitPoints == 0) {
                        gameOver = true;
                        break;
                    }
                    space.enemyBullet.RemoveAt(i);
                }
            }
            for (int i = 0; i < space.enemy.Count(); ++i) {
                if (ObjectIntersection(space.enemy[i], space.playerShip) == true) {
                    gameOver = true;
                    break;
                }
            }
            if (space.boss != null) {
                if (ObjectIntersection(space.playerShip, space.boss) == true) {
                    gameOver = true;
                }
            }
            if (space.bossBullet != null) {
                if (ObjectIntersection(space.playerShip, space.bossBullet) == true) {
                    --space.playerShip.hitPoints;
                    if (space.playerShip.hitPoints == 0) {
                        gameOver = true;
                    }
                    space.bossBullet = null;
                }
            }
        }

        //true if objects is intersected
        private bool ObjectIntersection(Object first, Object second) {
            bool result = false;
            List<(int, int)> coordinates = new List<(int, int)>();
            for (int i = 0; i < first.bodyHeight; ++i) {
                for (int j = 0; j < first.bodyWidth; ++j) {
                    if (first.body[i, j] != ' ') {
                        coordinates.Add((first.positionX + j, first.positionY + i));
                    }
                }
            }
            coordinates.Sort();
            for (int i = 0; i < second.bodyHeight && !result; ++i) {
                for (int j = 0; j < second.bodyWidth && !result; ++j) {
                    if (second.body[i, j] != ' ' && coordinates.BinarySearch((second.positionX + j, second.positionY + i)) >= 0) {
                        result = true;
                    }
                }
            }
            return result;
        }

        public void Restart() {
            if (win) {
                screenRender.WinCase(space.boss);
            } else {
                screenRender.GameOverCase(space.playerShip);
            }
            win = false;
            space.enemy.Clear();
            space.enemyBullet.Clear();
            space.playerBullet.Clear();
            space.boss = null;
            space.bossBullet = null;
            space.playerShip.hitPoints = settings.playerShipHitPoints;
            space.playerShip.positionX = settings.playerShipStartPositionX;
            space.playerShip.positionY = settings.playerShipStartPositionY;
        }
    }

}
