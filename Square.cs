using System;

namespace battle_ship_in_the_oo_way_getonboard
{

    public class Square
    {
    private bool isHit;
    private int YCoordinates;
    private int XCoordinates;
    private string symbol;

    public Square(int yCoordinates, int xCoordinates)
    {
        this.YCoordinates = yCoordinates;
        this.XCoordinates = xCoordinates;
    }

    public Square(int yCoordinates, int xCoordinates, bool isHit)
    {
        this.YCoordinates = yCoordinates;
        this.XCoordinates = xCoordinates;
        this.isHit = isHit;
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
            else
            {
                symbol = "_";
            }
        return symbol;
        }


    }










}
