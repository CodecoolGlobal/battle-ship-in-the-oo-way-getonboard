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
                Console.ForegroundColor = ConsoleColor.Red;
                symbol = "X";    
            }
            else if (isShip == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                symbol = "@";
                Console.ResetColor(); 

            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                symbol = " ";

            }
        return symbol;
        }


    }










}
