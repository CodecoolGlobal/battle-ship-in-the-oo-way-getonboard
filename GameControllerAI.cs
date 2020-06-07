using System;
using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_getonboard
{
    public class GameControllerAI
    {
        public Player Player1 { get; set; }
        public PlayerAIEasy PlayerAI { get; set; }

        public PlayerAIMedium PlayerAI2 {get; set;}

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

            this.PlayerAI = new PlayerAIEasy("Jack Sparrow");
            PlayerAI.AutoCreateShip();
            Console.Clear();
            this.PlayerAI2 = new PlayerAIMedium("Cthulhu");
            PlayerAI2.AutoCreateShip();
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


        public void GameEasy()
        {
            while (Player1.IsShipLeft() && PlayerAI.IsShipLeft())
            {
                PrintPlayersBoards(Player1, PlayerAI);
                Console.WriteLine("Give firing coordinates: ");
                string message = Player1.Attacks(PlayerAI);
                Console.Clear();
                PrintPlayersBoards(Player1, PlayerAI);
                Console.WriteLine(message);
                Console.WriteLine("Press any key to end your turn... ");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine(PlayerAI);
                PlayerAI.AIAttacks(Player1);
                Console.ReadKey();
                Console.Clear();
            }
            IsWin();
        }

        public void GameMedium()
        {
            while (Player1.IsShipLeft() && PlayerAI2.IsShipLeft())
            {
                PrintPlayersBoards(Player1, PlayerAI2);
                Console.WriteLine("Give firing coordinates: ");
                string message = Player1.Attacks(PlayerAI2);
                Console.Clear();
                PrintPlayersBoards(Player1, PlayerAI2);
                Console.WriteLine(message);
                Console.WriteLine("Press any key to end your turn... ");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine(PlayerAI2);
                PlayerAI2.AIAttacks(Player1);
                Console.ReadKey();
                Console.Clear();
            }
            IsWin();
        }
        

            public void PrintPlayersBoards(Player FirstPlayer, Player SecondPlayer)
        {
            Console.WriteLine(FirstPlayer);
            Console.WriteLine("\n");
            Console.WriteLine("This is the firing board");
            SecondPlayer.PlayerBoard.HideAllShips();
            Console.WriteLine(SecondPlayer.PlayerBoard);
            Console.WriteLine("\n");
            Console.WriteLine("This is your board");
            FirstPlayer.PlayerBoard.RevealAllShips();
            Console.WriteLine(FirstPlayer.PlayerBoard);
        }

    }
}
