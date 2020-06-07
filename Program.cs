using System;


namespace battle_ship_in_the_oo_way_getonboard
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController.PrintTitle();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("1 - To play against player\n");
            Console.WriteLine("2 - To play against AI\n");
            var gameMode = Convert.ToInt32(Console.ReadLine());
            if(gameMode == 1)
            {
                GameController game = new GameController();
                game.Play();
            }
            else if (gameMode ==2)
            {

                Console.WriteLine("Please choose the difficulty by entering digit: \n1 - Easy \n2 - Medium");
                var difficultyChoice = Convert.ToInt32(Console.ReadLine());
                if(difficultyChoice == 1)
                {
                    GameControllerAI game  = new GameControllerAI();
                    game.GameEasy();
                }
                else
                {
                    GameControllerAI game  = new GameControllerAI();
                    game.GameMedium();
                }
            }


            
        }
    }
}
