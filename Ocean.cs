using System;
using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_getonboard

{
    public class Ocean 
    {
    private static int WIDTH = 10;
    private static int HEIGHT = 10;
    public List<List<Square>> Board;

    public Ocean()
        {
            this.Board = new List<List<Square>>();
            List<Square> boardRow = new List<Square>();
            
            for (int y = 0; y < WIDTH; y++)
            {
                boardRow = new List<Square>(); 

                for (int x = 0; x < HEIGHT; x++)
                {
                    boardRow.Add(new Square(y,x));
                } 
                Board.Add(boardRow);
            }               
               
        }


    public Square GetSquare(int y, int x)
    {
        return Board[y][x];
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
    


    public void RevealAllShips()
    {
        foreach (List<Square> boardRow in Board)
        {
            foreach (Square Square in boardRow)
            {
                Square.SetIsVisibleTrue();
            }
        }

    }

    public void HideAllShips()
    {
        foreach (List<Square> boardRow in Board)
        {
            foreach (Square Square in boardRow)
            {
                Square.SetIsVisibleFalse();
            }
        }
    }

    public bool IsShipLeft(List<Ship> ships)
    {
        foreach (Ship ship in ships)
        {
            for (int i = 0; i < ship.GetLength(); i++)
            {
                bool isSquareHit = ship.GetSquare(i).GetIsHit();

                if (isSquareHit == false)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsShipContacting(List<Ship> ships, Ship newShip)
    {

        foreach (Ship ship in ships)
        {
            for (int i = 0; i < ship.GetLength(); i++)
            {
                int squareX = ship.GetSquare(i).GetX();
                int squareY = ship.GetSquare(i).GetY();
                List<int> rangeX = new List<int>{squareX-1, squareX, squareX+1};
                List<int> rangeY = new List<int>{squareY-1, squareY, squareY+1};

                for (int j = 0; j < newShip.GetLength(); j++)
                {
                    int newSquareX = newShip.GetSquare(j).GetX();
                    int newSquareY = newShip.GetSquare(j).GetY();

                    if (rangeX.Contains(newSquareX) && rangeY.Contains(newSquareY))
                    {
                        Console.WriteLine(newSquareX);
                        Console.WriteLine(newSquareY);
                        Console.WriteLine(squareX);
                        Console.WriteLine(squareY);
                        return true;
                    }
                }
   
            }
        }
        return false;
    }

    public override string ToString()
        {
            string printBoard = "  1 2 3 4 5 6 7 8 9 10\n +--------------------+\n";
            List<string> alphabet = new List<string>{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O","P","Q","R","S","T","W","X","Y","Z"};

            for (int y = 0; y < WIDTH; y++)
            {
                string printRow = "";

                for (int x = 0; x < HEIGHT; x++)
                {
                    printRow += Board[y][x] + " ";
                } 
                printBoard += alphabet[y] + "|" + printRow + "|" +"\n";
            }     
            printBoard += " +--------------------+";
            return printBoard;          
        }

    }



}
