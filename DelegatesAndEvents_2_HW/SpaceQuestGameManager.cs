using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents_2_HW
{
    class SpaceQuestGameManager
    {
        public int _goodSpaceShipHitPoints;
        private int _shipXLocation;
        private int _shipYLocation;
        public int _numberOfBadShips;
        public int _currentLevel = 1;
        public class PointsEventArgs : EventArgs {
            public int HitPoints { get; set; }
        }

        public class LocationEventArgs : EventArgs {
            public int X { get; set; }
            public int Y { get; set; }
        }
        public class BadShipsExplodedEventArgs : EventArgs {
            public int NumberOfExplodedBadShips { get; set; }
        }

        public class LevelEventArgs : EventArgs {
            public int CurrentLevel { get; set; }
        }

        public event EventHandler<PointsEventArgs> GoodSpaceShipHPChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipLocationChanged;
        public event EventHandler<PointsEventArgs> GoodSpaceShipDestroyed;
        public event EventHandler<BadShipsExplodedEventArgs> BadShipExploded;
        public event EventHandler<LevelEventArgs> LevelUpReached;

        public SpaceQuestGameManager(int goodSpaceShipHitPoints, int shipXLocation, int shipYLocation, int numberOfBadShips)
        {
            _goodSpaceShipHitPoints = goodSpaceShipHitPoints;
            _shipXLocation = shipXLocation;
            _shipYLocation = shipYLocation;
            _numberOfBadShips = numberOfBadShips;
        }

        private void OnGoodSpaceShipHPChanged() {

            if (GoodSpaceShipHPChanged != null)
            {
                GoodSpaceShipHPChanged.Invoke(this, new PointsEventArgs { HitPoints = _goodSpaceShipHitPoints });
            }
        }

        private void OnGoodSpaceShipLocationChanged()
        {

            if (GoodSpaceShipLocationChanged != null)
            {
                GoodSpaceShipLocationChanged.Invoke(this, new LocationEventArgs { X = _shipXLocation, Y = _shipYLocation });
            }
        }

        private void OnGoodSpaceShipDestroyed()
        {

            if (GoodSpaceShipDestroyed != null)
            {
                GoodSpaceShipDestroyed.Invoke(this, new PointsEventArgs { HitPoints = _goodSpaceShipHitPoints });
            }
        }

        private void OnBadShipExploded()
        {

            if (BadShipExploded != null)
            {
                BadShipExploded.Invoke(this, new BadShipsExplodedEventArgs {NumberOfExplodedBadShips = _numberOfBadShips });
            }
        }

        private void OnLevelUpReached()
        {

            if (LevelUpReached != null)
            {
                LevelUpReached.Invoke(this, new LevelEventArgs { CurrentLevel = _currentLevel });
            }
        }

        public void MoveSpaceShip(int newX, int newY) {
            _shipXLocation = newX;
            _shipYLocation = newY;

            OnGoodSpaceShipLocationChanged();
        }

        public void GoodSpaceShipGotDamaged(int damage) {
            _goodSpaceShipHitPoints -= damage;

            OnGoodSpaceShipDestroyed();
        }
        public void GoodSpaceShipGotExtreHP(int extra)
        {
            _goodSpaceShipHitPoints += extra;

            OnGoodSpaceShipHPChanged();
        }
        public void EnemyShipsDestroyed(int numberOfBadShipsDestroyed) {
            _numberOfBadShips -= numberOfBadShipsDestroyed;

            OnBadShipExploded();
        }

        public void LevelUp() {
            _currentLevel++;

            OnLevelUpReached();
        }
    }
}
