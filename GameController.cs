using System;

namespace battle_ship_in_the_oo_way_getonboard
{
    public class GameController
    {
        public static void PvsP()
        {
            var Player1 = new Player(Player.GetPlayerName());
            Player1.CreateShip();
            var Player2 = new Player(Player.GetPlayerName());
            Player2.CreateShip();
            Console.Clear();

            while (Player1.IsShipLeft() && Player2.IsShipLeft())
            {
                Console.WriteLine(Player1);
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

                Console.WriteLine(Player2);
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
        }
    }
}
