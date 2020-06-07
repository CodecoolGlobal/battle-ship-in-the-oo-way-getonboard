using System.Collections.Generic;
using System;

namespace battle_ship_in_the_oo_way_getonboard
{
    public class PlayerAIEasy : Player
    {
        public int Y {get; set;}
        public int X {get; set;}

        public PlayerAIEasy(string name) : base(name)
        {

        }

        public void SearchHit(Player player)
        {

            this.Y = new Random().Next(0, 10);

            this.X = new Random().Next(0, 10);
        }

        public int GetShipYAI()
        {
            Random random = new Random();
            int y = random.Next(0, 10);
            return Y;
        }

        public int GetShipXAI()
        {
            return X;
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
