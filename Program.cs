using System;
using System.Collections.Generic;


namespace battle_ship_in_the_oo_way_getonboard
{
    class Program
    {
        static void Main(string[] args)
        {
            var shipList = new List<Ship>();
            shipList.Add(new Ship(4, true, 5, 0));
            shipList.Add(new Ship(3, false, 9, 3));
            shipList.Add(new Ship(2, true, 2, 2));
            shipList.Add(new Ship(3, false, 4, 6));
    

            Ocean ocean = new Ocean();

            ocean.PlaceShips(shipList); 
            Console.WriteLine(ocean);

        }
    }
}
