using System.Collections.Generic;
using System;

namespace battle_ship_in_the_oo_way_getonboard
{
    public class Player
    {
        public string Name {get; set;}
        public List<Ship> shipList {get; set;}
        public Ocean PlayerBoard {get; set;}
        public Player(string name)
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
                Console.WriteLine($"You are now placing a {item.Key} that is {item.Value} squares long.");
                bool shipDirection = GetShipDirection();
                var shipY = GetShipY();
                var shipX = GetShipX();
                shipList.Add(new Ship (item.Value, shipDirection, shipY, shipX));
                PlayerBoard.PlaceShips(shipList);
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
            Console.WriteLine("Enter Y Coordinate: ");
            int y = Convert.ToInt32(Console.ReadLine()) - 1;
            return y;
        }

        public int GetShipX()
        {
            Console.WriteLine("Enter X Coordinate: ");
            int y = Convert.ToInt32(Console.ReadLine()) - 1;
            return y;
        }

        public bool GetShipDirection()
        {
            Console.WriteLine("Enter ship direction(H,V): ");
            var direction = Console.ReadLine();
            if(direction.ToUpper() == "V")
                {
                    return true;
                }
            else if (direction.ToUpper() == "H")
                {
                    return false;
                }
            else
            {
                Console.WriteLine("Enter V or H");
                return GetShipDirection();
            }

        }

        public string GetPlayerName()
        {
            Console.WriteLine("Enter Your name: ");
            return Console.ReadLine();
        }

        public override string ToString()
        {
            return $"{Name}'s turn.";
        }
    }
}
