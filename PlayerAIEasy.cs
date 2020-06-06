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
            Name = name;
            PlayerBoard = new Ocean();
            shipList = new List<Ship>();
        }


        public void CreateShip()
        {
            foreach (KeyValuePair<string, int> item in Ship.ShipTypes)
            {
                Console.Clear();
                Console.WriteLine(PlayerBoard);
                bool shipNotAdded = true;

                while (shipNotAdded)
                {

                    bool shipDirection = new Random().Next(2) == 0;
                    var shipY = new Random().Next(10);
                    var shipX = new Random().Next(10);
                    var ship = new Ship(item.Value, shipDirection, shipY, shipX);

                    if (!PlayerBoard.IsShipContacting(shipList, ship) && (!ship.isVertical && (item.Value + shipX) <= 10) || (!PlayerBoard.IsShipContacting(shipList, ship)) && (ship.isVertical && (item.Value + shipY) <= 10))
                    {
                        shipList.Add(ship);
                        PlayerBoard.PlaceShips(shipList);
                        shipNotAdded = false;

                    }

                }
            }
        }

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

            if (IsSquareUsed(target))
            {
                return Attacked();
            }

            if (target.IsThisShip())
            {
                target.IsHit();
                        
                foreach (Ship ship in shipList)
                {
                    for (int i = 0; i < ship.GetLength(); i++)
                    {
                        if (target == ship.GetSquare(i))
                        {
                            for (int j = 0; j < ship.GetLength(); j++)
                            {
                                if (!ship.GetSquare(j).GetIsHit())
                                {
                                    return "\nHit!\n";
                                }
    
                            }
                        ship.SetIsSunk();
                        }
                        
                    }
                    
                }
                
                return "\nHit and sunk!\n";
            }
            
            else
            {
                target.IsMissed();
                return "\nMissed!\n";
            }
        }

        public bool IsSquareUsed(Square target)
        {
            if (target.GetIsHit() || target.GetIsMissed())
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"\n{Name}'s turn.\n";
        }

    }
}
