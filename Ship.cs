using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_getonboard

{

    public class Ship
    {
    private List<Square> Squares;
    private int ShipLength = 3;
    private bool isVertical;

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

    }
}
