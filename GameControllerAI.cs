using System;
using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_getonboard
{
    public class GameControllerAI
    {
        public Player Player1 { get; set; }
        public PlayerAIEasy PlayerAI { get; set; }

        public GameControllerAI()
        {
            this.Player1 = new Player(Player.GetPlayerName());
            if (Player1.IsCreateShipAuto())
            {
                Player1.AutoCreateShip();
            }
            else
            {
                Player1.CreateShip();
            }
            Console.Clear();

            this.PlayerAI = new PlayerAIEasy("Komputer");
            PlayerAI.CreateShip();
            Console.Clear();
        }

        public void IsWin()
        {
            if (Player1.IsShipLeft() == false)
            {
                Console.WriteLine($"{PlayerAI.Name} wins!");
            }
            else if (PlayerAI.IsShipLeft() == false)
            {
                Console.WriteLine($"{Player1.Name} wins!");
            }
        }


        public void Game()
        {
            while (Player1.IsShipLeft() && PlayerAI.IsShipLeft())
            {
                Console.WriteLine(Player1);
                Console.WriteLine("This is the firing board");
                Player1.PlayerBoard.HideAllShips();
                Console.WriteLine(Player1.PlayerBoard);
                Console.WriteLine("This is your board");
                PlayerAI.PlayerBoard.RevealAllShips();
                Console.WriteLine(PlayerAI.PlayerBoard);
                Console.WriteLine("Give firing coordinates: ");
                Player1.Attacked();
                Console.WriteLine("Press any key to end your turn... ");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine(PlayerAI);
                PlayerAI.Attacked();
                Console.ReadKey();
                Console.Clear();
            }
            IsWin();
        }

    }
}
