using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_getonboard

{
    public class Ship
    {
    private List<Square> Squares;
    private int ShipLength;
    public bool isVertical;
    private bool isSunk;
    public static Dictionary<string, int> ShipTypes = new Dictionary<string, int>()
    {
        {"Carrier", 5}, {"Battleship", 4}, {"Cruiser", 3}, {"Submarine", 3}, {"Destroyer", 2}
    };

    public Ship(int shipLength, bool isVertical, int yCoordinates, int xCoordinates)
        {
            this.Squares = new List<Square> ();
            this.ShipLength = shipLength;
            this.isVertical = isVertical;

            for (int i = 0; i < ShipLength; i++)
            {
                if (isVertical)
                {
                    Squares.Add(new Square(yCoordinates + i, xCoordinates, true));
                }
                else
                {
                    Squares.Add(new Square(yCoordinates, xCoordinates + i, true));
                }
                
            }

        }
    
    public int GetLength()
    {
        return ShipLength;
    }

    public Square GetSquare(int index)
    {
        return Squares[index];
    }

    public bool GetIsSunk()
    {
        return isSunk;
    }

    public void SetIsSunk()
    {
        isSunk = true;
    }


    }
}