using System;

namespace battle_ship_in_the_oo_way_getonboard
{

    public class Square
    {
    private bool isShip;
    private string symbol;
    
    public void IsThisShip()
        {
            isShip = true;
        }

    public override string ToString()
        {
            if (isShip == true)
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
