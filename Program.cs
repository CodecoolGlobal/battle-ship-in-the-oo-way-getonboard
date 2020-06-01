using System;
using System.Collections.Generic;


namespace battle_ship_in_the_oo_way_getonboard
{
    class Program
    {
        static void Main(string[] args)
        {
            var Player1 = new Player("playername");

            Player1.CreateShip();
            Player1.PlayerBoard.PlaceShips(Player1.shipList);
            Console.WriteLine(Player1.PlayerBoard);


        }
    }
}
