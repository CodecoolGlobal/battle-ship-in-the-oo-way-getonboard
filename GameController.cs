using System;
using System.Collections.Generic;
using System.IO;

namespace battle_ship_in_the_oo_way_getonboard
{
    public class GameController
    {
        public Player Player1 {get; set;}
        public Player Player2 {get; set;}


        public GameController()
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

            this.Player2 = new Player(Player.GetPlayerName());

            if (Player2.IsCreateShipAuto())
            {
                Player2.AutoCreateShip();
            }
            else
            {
                Player2.CreateShip();
            }
            Console.Clear();
        }

        public void SetFirstPlayer()
        {
            List<Player> playerList = new List<Player> {Player1, Player2};
            Random choosePlayer = new Random();
            int index = choosePlayer.Next(playerList.Count);
            playerList[index].IsFirst = true;
            Console.WriteLine($"{playerList[index].Name} starts first");
        }

        public Player GetFirstPlayer()
        {
            if (Player1.IsFirst)
            {
                return Player1;
            }
            else
            {
                return Player2;
            }
        }

        public Player GetSecondPlayer()
        {
            Player FirstPlayer = GetFirstPlayer();

            if (FirstPlayer == Player1)
            {
                return Player2;
            }
            else
            {
                return Player1;
            }
        }
        public void PlayerTurn()
        {
            while (Player1.IsShipLeft() && Player2.IsShipLeft())
            {
                Player FirstPlayer = GetFirstPlayer();
                Player SecondPlayer = GetSecondPlayer();
                
                PrintPlayersBoards(FirstPlayer, SecondPlayer);
                Console.WriteLine("\n");
                Console.WriteLine("Give firing coordinates: ");
                string message = SecondPlayer.Attacked();
                Console.Clear();
                
                PrintPlayersBoards(FirstPlayer, SecondPlayer);
                Console.WriteLine(message);
                Console.WriteLine("Press any key to end your turn... ");
                Console.ReadKey();
                Console.Clear();
                ChangePlayerTurn();

            }
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
        public void ChangePlayerTurn()
        {
            if (Player1.IsFirst)
            {
                Player1.IsFirst = false;
                Player2.IsFirst = true;
            }
            else
            {
                Player1.IsFirst = true;
                Player2.IsFirst = false;
            }

        }

        public void IsWin()
        {
            if (Player1.IsShipLeft() == false)
            {
                Console.WriteLine($"{Player2.Name} wins!");
            }
            else if (Player2.IsShipLeft() == false)
            {
                Console.WriteLine($"{Player1.Name} wins!");
            }
        }


    public static void PrintTitle()
    {
        using (StreamReader stream = File.OpenText(@"title.txt"))
            {
            String battleshipTitle = "";

            while ((battleshipTitle = stream.ReadLine()) != null)
                {
                Console.WriteLine(battleshipTitle); 
                }
            }
    }

        public void Play()
        {

            SetFirstPlayer();
            Console.WriteLine("Press any key to start your turn");
            Console.ReadKey();
            Console.Clear();
            PlayerTurn();
            IsWin();
        }

        
    }
}
