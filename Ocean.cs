using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_getonboard

{
    public class Ocean 
    {
    private static int WIDTH = 10;
    private static int HEIGHT = 10;

    private List<List<Square>> Board;
    //private List<Ship> Ships;

    public Ocean()
        {
            this.Board = new List<List<Square>>();
            List<Square> boardRow = new List<Square>();
            
            for (int y = 0; y < WIDTH; y++)
            {
                boardRow = new List<Square>{}; 

                for (int x = 0; x < HEIGHT; x++)
                {
                    boardRow.Add(new Square(y,x));
                } 
                Board.Add(boardRow);
            }               
               
        }

    public void PlaceShips(List<Ship> ships)
    {
        foreach (Ship ship in ships)
        {
            for (int i = 0; i < ship.GetLength(); i++)
            {
                Square shipSquare = ship.GetSquare(i);
                int Y = shipSquare.GetY();
                int X = shipSquare.GetX();

                Board[Y][X] = shipSquare;
            }
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
