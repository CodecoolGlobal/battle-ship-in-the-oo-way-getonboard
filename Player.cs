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
                var loop = true;
                while(loop)
                {
                    Console.WriteLine($"You are now placing a {item.Key} that is {item.Value} squares long.");
                    bool shipDirection = GetShipDirection();
                    var shipY = GetShipY();
                    var shipX = GetShipX();
                    var ship = new Ship(item.Value, shipDirection, shipY, shipX);
                    if (!ship.isVertical && (item.Value + shipX) > 10)
                    {
                        Console.WriteLine("You cannot place a ship outside the board!");
                        continue;
                    }
                    else if (ship.isVertical && (item.Value + shipY)> 10)
                    {
                        Console.WriteLine("You cannot place a ship outside the board!");
                        continue;
                    }
                    else
                    {
                    shipList.Add(ship);
                    PlayerBoard.PlaceShips(shipList);
                    loop = false;
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
        public int LetterToInt(char letter)
        {
            int index = char.ToUpper(letter) - 64;
            return index;
        }
        public int GetShipY()
        {
            try
            {
                Console.WriteLine("Enter Y Coordinate A - J: ");
                char letter = char.Parse(Console.ReadLine());
                int y = LetterToInt(letter) - 1;
                if (y<10)
                    {
                        return y;
                    }
                    else
                    {
                        Console.WriteLine("You can only use letters A - J.");
                        return GetShipY();
                    }
            }
            catch (FormatException)
            {
                Console.WriteLine("You can only use a single letter as Y coordinate.");
                return GetShipY();
            }
        }

        public int GetShipX()
        {
            try
            {
                Console.WriteLine("Enter X Coordinate 1 - 10: ");
                int x = Convert.ToInt32(Console.ReadLine()) - 1;
                if (x<10)
                {
                    return x;
                }
                else
                {
                    Console.WriteLine("You can only use numbers 1 - 10");
                    return GetShipX();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You can only use numbers 1 - 10 as X coordinate.");
                return GetShipX();
            }
        }

        public bool GetShipDirection()
        {
            Console.WriteLine("Enter ship direction, V - vertical, or H - horizontal: ");
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
                Console.WriteLine("You can enter only V or H.");
                return GetShipDirection();
            }

        }

        public void Attacked()
        {
            var shipY = GetShipY();
            var shipX = GetShipX();
            var target = PlayerBoard.GetSquare(shipY, shipX);

            if (target.IsThisShip())
            {
                target.IsHit();
                Console.WriteLine("\nHit!\n");
            }
            else
            {
                target.IsMissed();
                Console.WriteLine("\nMissed!\n");
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
