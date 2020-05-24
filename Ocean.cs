using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_getonboard

{
    public class Ocean 
    {
    private static int WIDTH = 10;
    private static int HEIGHT = 10;

    private List<List<Square>> Board;
    private List<Ship> ships;

    public Ocean(List<List<Square>> Board, List<Ship> ships)
        {
            this.Board = Board;
            this.ships = ships;
            List<Square> boardRow = new List<Square>{};
            
            for (int y = 0; y < WIDTH; y++)
            {
                boardRow = new List<Square>{}; 

                for (int x = 0; x < HEIGHT; x++)
                {
                    boardRow.Add(new Square());
                } 
                Board.Add(boardRow);
            }               
               
        }
    
    public override string ToString()
        {
            string printBoard = "";

            for (int y = 0; y < WIDTH; y++)
            {
                string printRow = "";

                for (int x = 0; x < HEIGHT; x++)
                {
                    printRow += Board[y][x];
                } 
                printBoard += printRow + "\n";
            }     
            return printBoard;          
        }

    }



}
