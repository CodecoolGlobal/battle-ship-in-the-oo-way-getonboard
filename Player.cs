using System.Collections.Generic;
using System;

namespace battle_ship_in_the_oo_way_getonboard
{
    public class Player
    {
        public string Name {get; set;}
        public List<Ship> shipList {get; set;}
        public Ocean PlayerBoard {get; set;}
        public bool IsFirst {get; set;}
        
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
                    else if (PlayerBoard.IsShipContacting(shipList, ship))
                    {
                        Console.WriteLine("The new ship cannot contact already placed ship!");
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

        public void AutoCreateShip()
        {
            foreach (KeyValuePair<string, int> item in Ship.ShipTypes)
            {
                Console.Clear();
                Console.WriteLine(PlayerBoard);
                bool shipNotAdded = true;

                while(shipNotAdded)
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

         public bool IsCreateShipAuto()
        {
            Console.WriteLine("Would you like your ships to be placed automatically? Y/N");
            var choice = Console.ReadLine();
            if(choice.ToUpper() == "Y")
                {
                    return true;
                }
            else if (choice.ToUpper() == "N")
                {
                    return false;
                }
            else
            {
                Console.WriteLine("You can enter only Y or N.");
                return IsCreateShipAuto();
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


        public int GetShipYAI()
        {
            Random random = new Random();
            int y = random.Next(0, 10);
            return y;
        }

        public int GetShipXAI()
        {
            Random random = new Random();
            int x = random.Next(0, 10);
            return x;
        }

        public int GetShipY()
        {
            try
            {
                Console.WriteLine("Enter Y Coordinate A - J: ");
                char letter = char.Parse(Console.ReadLine());
                if (char.IsLetter(letter))
                {
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

        public string Attacked()
        {
            var shipY = GetShipY();
            var shipX = GetShipX();
            var target = PlayerBoard.GetSquare(shipY, shipX);

            if (IsSquareUsed(target))
            {
                Console.WriteLine("This field was already attacked.");
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

        public string AttackedByAI()
        {
            var shipY = GetShipYAI();
            var shipX = GetShipXAI();
            var target = PlayerBoard.GetSquare(shipY, shipX);

            if (IsSquareUsed(target))
            {
                return AttackedByAI();
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



        public static string GetPlayerName()
        {
            Console.WriteLine("\nEnter Your name: \n");
            return Console.ReadLine();
        }

        public override string ToString()
        {
            return $"\n{Name}'s turn.\n";
        }
    }
}
