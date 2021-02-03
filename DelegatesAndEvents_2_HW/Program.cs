using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using static DelegatesAndEvents_2_HW.SpaceQuestGameManager;

namespace DelegatesAndEvents_2_HW
{
    class Program
    {
        private static Random r = new Random();

        private static SpaceQuestGameManager myGame;

        static void Main(string[] args)
        {
            
            myGame = new SpaceQuestGameManager(100, 0, 0, 11);
            GameViewer gv = new GameViewer();

            myGame.GoodSpaceShipHPChanged += gv.GoodSpaceShipHPChangedEventHandler;
            myGame.GoodSpaceShipLocationChanged += gv.GoodSpaceShipLocationChangedEventHandler;
            myGame.GoodSpaceShipDestroyed += gv.GoodSpaceShipDestroyedEventHandler;
            myGame.BadShipExploded += gv.BadShipExplodedEventHandler;
            myGame.LevelUpReached += gv.LevelUpReachedEventHandler;

            Console.WriteLine($"***** LEVEL {myGame._currentLevel} *****");

            Timer t = new Timer(1000);
            t.Elapsed += (sender, e) => {

                if (myGame._currentLevel < 3 && myGame._numberOfBadShips == 0)
                {
                    myGame.LevelUp();
                    myGame._numberOfBadShips = 11;
                    myGame._goodSpaceShipHitPoints = 100;
                }
                int flag = r.Next(1, 5);
                switch (flag)
                {
                    case 1:
                        myGame.MoveSpaceShip(r.Next(0, 200), r.Next(0, 200));
                        break;
                    case 2:
                        myGame.EnemyShipsDestroyed(r.Next(1, myGame._numberOfBadShips+1));
                        break;
                    case 3:
                        myGame.GoodSpaceShipGotDamaged(r.Next(1, myGame._goodSpaceShipHitPoints + 1));
                        break;
                    case 4:
                        myGame.GoodSpaceShipGotExtreHP(r.Next(1, 100 - myGame._goodSpaceShipHitPoints+1));
                        break;
                }
            };

            t.Start();

            while (true) {
                if (myGame._currentLevel == 3) {
                    Console.WriteLine("***** YOU WON *****");
                    break;
                }
                if (myGame._goodSpaceShipHitPoints == 0)
                {
                    break;
                }
            }
        }
    }
}
