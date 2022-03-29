using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2_v1
{
    public class Store
    {

        MenuCatalog _menuCatalog = new MenuCatalog();
        
        public static void Run()
        {
            MenuCatalog menu = new MenuCatalog();

            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            
            menu.Start();          
            menu.PrintUserMenu();            
            Console.ReadKey();
        }
    }
}
