using System;
using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_getonboard
{
    public class PlayerAIMedium : Player
    {
        public int Y {get; set;}
        public int X {get; set;}
        public PlayerAIMedium(string name) : base(name)
        {

        }

        public int GetShipYAI()
        {
            return Y;
        }

        public int GetShipXAI()
        {
            return X;
        }

        public void SearchHit(Player player)
        {

            this.Y = new Random().Next(0, 10);

            this.X = new Random().Next(0, 10);

            foreach (Ship ship in player.shipList)
            {
                for (int i = 0; i < ship.GetLength(); i++)
                {
                    if(ship.GetSquare(i).GetIsHit() && !ship.GetIsSunk())
                    {
                        int squareX = ship.GetSquare(i).GetX();
                        int squareY = ship.GetSquare(i).GetY();

                        if(ship.isVertical)
                        {
                        Random randomX = new Random();
                        int x = randomX.Next(squareX-1, squareX + 2);
                        this.X = x;

                        Random randomY = new Random();
                        int y = randomY.Next(squareY-ship.GetLength(), squareY + ship.GetLength());
                        this.Y = y;
                        }
                        else
                        {
                        Random randomX = new Random();
                        int x = randomX.Next(squareX-ship.GetLength(), squareX + ship.GetLength());
                        this.X = x;

                        Random randomY = new Random();
                        int y = randomY.Next(squareY-1, squareY + 2);
                        this.Y = y;
                        }

                        if(X>9)
                        {
                            this.X = 9;
                        }
                        else if(X<0)
                        {
                            this.X = 0;
                        }
                        if(Y>9)
                        {
                            this.Y = 9;
                        }
                        else if(Y<0)
                        {
                            this.Y = 0;
                        }
                        return;
                    }
                }
            }
            
        }

        public string AIAttacks(Player player)
        {
            do
            {
            SearchHit(player);
            }
            while (IsSquareUsed(player.PlayerBoard.GetSquare(Y, X)));

            return player.AttackedByAI(GetShipYAI(), GetShipXAI());
        }
        

    }
    
}