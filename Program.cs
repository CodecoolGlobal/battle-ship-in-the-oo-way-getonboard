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
            var Player2 = new Player("player2name");
            Player2.CreateShip();
            Console.Clear();

            while (Player1.IsShipLeft() && Player2.IsShipLeft())
            {
                Console.WriteLine("Player 1 round");
                Console.WriteLine("This is the firing board");
                Player2.PlayerBoard.HideAllShips();
                Console.WriteLine(Player2.PlayerBoard);
                Console.WriteLine("This is your board");
                Player1.PlayerBoard.RevealAllShips();
                Console.WriteLine(Player1.PlayerBoard);
                Console.WriteLine("Give firing coordinates: ");
                Player2.Attacked();
                Console.WriteLine("Press any key to end your turn... ");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Player 2 round");
                Console.WriteLine("This is the firing board");
                Player1.PlayerBoard.HideAllShips();
                Console.WriteLine(Player1.PlayerBoard);
                Console.WriteLine("This is your board");
                Player2.PlayerBoard.RevealAllShips();
                Console.WriteLine(Player2.PlayerBoard);
                Console.WriteLine("Give firing coordinates: ");
                Player1.Attacked();
                Console.WriteLine("Press any key to end your turn... ");
                Console.ReadKey();
                Console.Clear();


            }
            // Player1.CreateShip();
            // Console.WriteLine(Player1.PlayerBoard);
            // Player1.PlayerBoard.RevealAllShips();
            // Console.WriteLine(Player1.PlayerBoard);

            // Player2.CreateShip();
            // Console.WriteLine(Player2.PlayerBoard);
            // Player2.PlayerBoard.RevealAllShips();
            // Console.WriteLine(Player2.PlayerBoard);
 

        }
    }
}
