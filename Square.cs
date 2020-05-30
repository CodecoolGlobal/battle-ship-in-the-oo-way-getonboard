using System;

namespace battle_ship_in_the_oo_way_getonboard
{

    public class Square
    {
    private bool isHit;
    private bool isMissed;
    private bool isShip;
    private int YCoordinates;
    private int XCoordinates;
    private string symbol;

    public Square(int yCoordinates, int xCoordinates)
    {
        this.YCoordinates = yCoordinates;
        this.XCoordinates = xCoordinates;
    }

    public Square(int yCoordinates, int xCoordinates, bool isShip)
    {
        this.YCoordinates = yCoordinates;
        this.XCoordinates = xCoordinates;
        this.isShip = isShip;
    }
    
    public void IsHit()
        {
            isHit = true;
        }

    public int GetX()
    {
        return XCoordinates;
    }

    public int GetY()
    {
        return YCoordinates;
    }


    public override string ToString()
        {
            if (isHit == true)
            {
                symbol = "X";    
            }
            else if (isShip == true)
            {
                symbol = "@";
            }
            else
            {
                symbol = " ";
            }
        return symbol;
        }


    }










}
