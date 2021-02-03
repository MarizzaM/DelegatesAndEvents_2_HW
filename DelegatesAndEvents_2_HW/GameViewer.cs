using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DelegatesAndEvents_2_HW.SpaceQuestGameManager;

namespace DelegatesAndEvents_2_HW
{
    class GameViewer
    {
        public void GoodSpaceShipHPChangedEventHandler(object sender, PointsEventArgs e){

            Console.WriteLine($"\n***BONUS*** \nHit Points of spaceship: {e.HitPoints}");

        }
        public void GoodSpaceShipLocationChangedEventHandler(object sender, LocationEventArgs e)
        {
            Console.WriteLine($"\nThe spaceship has moved to a new location (x, y): ({e.X}, {e.Y})");
        }
        public void GoodSpaceShipDestroyedEventHandler(object sender, PointsEventArgs e)
        {
            if (e.HitPoints <= 0)
            {
                Console.WriteLine("***** GAME OVER *****");
            }
            else {
                Console.WriteLine($"\n***DAMAGE***\nHit Points of spaceship: {e.HitPoints}");
            }
        }
        public void BadShipExplodedEventHandler(object sender, BadShipsExplodedEventArgs e)
        {
            Console.WriteLine($"\n{e.NumberOfExplodedBadShips} enemies left") ;
        }
        public void LevelUpReachedEventHandler(object sender, LevelEventArgs e)
        {
            Console.WriteLine($"\n***** LEVEL {e.CurrentLevel} *****");

        }
    }
}
