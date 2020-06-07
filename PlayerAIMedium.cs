using System;

namespace battle_ship_in_the_oo_way_getonboard
{
    public class PlayerAIMedium : Player
    {
        public PlayerAIMedium(string name) : base(name)
        {

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

        public string AIAttacks(Player player)
        {
            return player.AttackedByAI(GetShipYAI(), GetShipXAI());
        }
        

    }
    
}