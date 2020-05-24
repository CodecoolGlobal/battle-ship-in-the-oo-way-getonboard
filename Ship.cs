using System.Collections.Generic;

namespace battle_ship_in_the_oo_way_getonboard

{

    public class Ship
    {
    private List<Square> squares;
    private int YCoordinates = 3;
    private int XCoordinates = 3;
    private int shipLength = 3;
    private bool isVertical = false;

    public Ship(List<Square> squares, int YCoordinates, int XCoordinates, int shipLength, bool isVertical)
        {
            this.squares = squares;
            this.YCoordinates = YCoordinates;
            this.XCoordinates = XCoordinates;
            this.shipLength = shipLength;
            this.isVertical = isVertical;
        }

    public override string ToString()
        {
        
        }

    }
}
