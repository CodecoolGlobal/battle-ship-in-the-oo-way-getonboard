using System.Collections.Generic;
using System;

namespace battle_ship_in_the_oo_way_getonboard
{
    public class PlayerAIEasy
    {
        public string Name { get; set; }
        public List<Ship> shipList { get; set; }
        public Ocean PlayerBoard { get; set; }
        public bool IsFirst { get; set; }

        public PlayerAIEasy(string name)
        {
            Name = "Komputer";
            PlayerBoard = new Ocean();
            shipList = new List<Ship>();
        }


        public void CreateShip()
        { }

        public bool IsShipLeft()
        {
            if (PlayerBoard.IsShipLeft(shipList))
            {
                return true;
            }
            return false;
        }

        public int GetShipY()
        {
            Random random = new Random();
            int y = random.Next(0, 10);
            return y;
        }

        public int GetShipX()
        {
            Random random = new Random();
            int x = random.Next(0, 10);
            return x;
        }

        public bool GetShipDirection()
        {
            Random random = new Random();
            bool randomDirection = random.Next(2) == 1;
            return randomDirection;
        }

        public string Attacked()
        {
            var shipY = GetShipY();
            var shipX = GetShipX();
            var target = PlayerBoard.GetSquare(shipY, shipX);

            if (target.IsThisShip())
            {
                target.IsHit();
                return "\nHit!\n";
            }
            else
            {
                target.IsMissed();
                return "\nMissed!\n";
            }
        }

        public override string ToString()
        {
            return $"\n{Name}'s turn.\n";
        }

    }
}
