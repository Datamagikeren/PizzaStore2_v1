using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore2_v1
{
    public class MenuCatalog
    {


        #region Lists

        public List<Pizza> pizzaList = new List<Pizza>();
        public List<Topping> toppingList = new List<Topping>();
       
        #endregion       

        #region Methods      

        public string FormatUserMenu() //Metode til at formatere User Menu string
        {
            return "{0,-4} {1,0}";
        }

        public void Start()
        {

            Topping t1 = new Topping(1, "Cheese", 5);
            Topping t2 = new Topping(2, "Tomato sauce", 5);
            Topping t3 = new Topping(3, "Ham", 5);
            Topping t4 = new Topping(4, "Mushroom", 5);
            Topping t5 = new Topping(5, "Pineapple", 5);
            Topping t6 = new Topping(6, "Mixed salad", 7);
            Topping t7 = new Topping(7, "Kebab", 10);
            Topping t8 = new Topping(8, "Dressing", 5);
            Topping t9 = new Topping(9, "Chicken", 10);

            toppingList.AddRange(new List<Topping>() { t1, t2, t3, t4, t5, t6, t7, t8, t9 });       

            Pizza p1 = new Pizza(1, "Mushroom", 69);
            p1.ToppingList.AddRange(new List<Topping>() { t1, t2, t4 });           

            Pizza p2 = new Pizza(2, "Ham", 55);
            p2.ToppingList.AddRange(new List<Topping>() { t1, t2, t3 });            

            Pizza p3 = new Pizza(3, "Hawaii", 59);
            p3.ToppingList.AddRange(new List<Topping>() { t1, t2, t3, t5 });
            
            Pizza p4 = new Pizza(4, "Salatpizza m. Kebab", 79);
            p4.ToppingList.AddRange(new List<Topping>() { t1, t6, t7, t8 });            

            Pizza p5 = new Pizza(5, "Salatpizza m. Kylling", 69);
            p5.ToppingList.AddRange(new List<Topping>() { t1, t6, t7, t9 });            

            Pizza p6 = new Pizza(6, "Vegetar", 49);
            p6.ToppingList.Add(t6);

            pizzaList.AddRange(new List<Pizza>() { p1, p2, p3, p4, p5, p6 });

            
            

        }

        public void RemovePizza()
        {        
            ReturnToMenuMessage();
            Console.WriteLine();
            Console.WriteLine("Which pizza no. do you wish to remove from the menu?");
            int o = 1;
            foreach (Pizza i in pizzaList)
            {
                Console.WriteLine($"{o}. {i.Name}");
                o++;
            }

            while (true)
            {
                try
                {
                    int userInput;                    
                    userInput = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (userInput == pizzaList.Count + 1)
                    {
                        Console.Clear();
                        PrintUserMenu();
                    }
                    Console.Clear();
                    Console.WriteLine($"{pizzaList[userInput]} was successfully removed from the menu!");
                    pizzaList.RemoveAt(userInput);
                    Console.WriteLine();
                    break;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The number you typed does not exist on the menu. Please try a new number");
                    RemovePizza();

                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please only insert numbers");
                }

            }
            while (true)
            {
                Console.WriteLine("Type 'y' to see the updated menu");
                Console.WriteLine("Type 'n' to return to the User Menu");
                Console.WriteLine("Type 'o' to delete another pizza from the menu");

                string userInput2;
                userInput2 = Console.ReadLine();

                if (userInput2 == "y")
                {
                    Console.Clear();
                    PrintMenu();
                }
                else if (userInput2 == "n")
                {
                    Console.Clear();
                    PrintUserMenu();
                }
                else if (userInput2 == "o")
                {
                    Console.Clear();
                    RemovePizza();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You typed something that leads you nowhere. Check your options, and try again!");
                    Console.WriteLine();
                }
            }


        }

        public void PrintMenu() //fix forkert input
        {
            while (true)
            {
                string userInputString;
                Console.WriteLine("BigMamaPizzaria's Menu Catalog");
                foreach (Pizza i in pizzaList)
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.Write("{0,-3}{1,-35}", $"{i.ItemId}.", $"{i.Name}");
                    Console.WriteLine("{0,6}", $"{i.Price},-");
                    Console.Write("{0,2}", "");
                    foreach (Topping o in i.ToppingList)
                    {
                        Console.Write($"- {o} ");                        
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Type 'y' change the order of the menu");
                Console.WriteLine("Type 'o' to return to the User Menu");

                userInputString = Console.ReadLine();
                if (userInputString == "y")
                {
                    Console.WriteLine("Type '1' to sort the menu by number ID (starting from '1')");
                    Console.WriteLine("Type '2' to sort the menu by name (from A - Z)");
                    Console.WriteLine("Type '3' to sort the menu by price (starting from lowest price)");
                    userInputString = Console.ReadLine();
                    if (userInputString == "1")
                    {
                        SortMenuById();
                        Console.Clear();
                        PrintMenu();
                    }
                    else if (userInputString == "2")
                    {
                        SortMenuByName();
                        Console.Clear();
                        PrintMenu();
                    }
                    else if (userInputString == "3")
                    {
                        SortMenuByPrice();
                        Console.Clear();
                        PrintMenu();
                    }

                }
                else if (userInputString == "o")
                {
                    Console.Clear();
                    PrintUserMenu();
                }                
                Console.WriteLine("Please enter something");
            }
        }

        public void SortMenuByPrice()
        {
            pizzaList.Sort(delegate (Pizza x, Pizza y)
            {
                return x.Price.CompareTo(y.Price);
            });
        }

        public void SortMenuById()
        {
            pizzaList.Sort(delegate (Pizza x, Pizza y)
            {
                return x.ItemId.CompareTo(y.ItemId);
            });
        }

        public void SortMenuByName()
        {
            pizzaList.Sort(delegate (Pizza x, Pizza y)
            {
                return x.Name.CompareTo(y.Name);
            });
        }

        public void SearchPizza()
        {           
                string userInputString;
                int userInputInt;
                ReturnToMenuMessage();
                Console.WriteLine();
                Console.WriteLine("Type 'y' to search for pizza by number");
                Console.WriteLine("Type 'n' to search for pizza by name");
                userInputString = Console.ReadLine();
            if (userInputString == GoBackButtonString)
            {
                Console.Clear();
                PrintUserMenu();
            }
            #region If search by number
            else if (userInputString == "y")
            {
                Console.Clear();
                while (true)
                {                    
                    Console.WriteLine("Search for pizza by number:");
                    try
                    {
                        userInputInt = Convert.ToInt32(Console.ReadLine());
                        if (userInputInt == GoBackButtonInt)
                        {
                            Console.Clear();
                            PrintUserMenu();
                        }
                        foreach (Pizza i in pizzaList)
                        {
                            if (i.ItemId == userInputInt)
                            {
                                Console.Clear();
                                Console.WriteLine($"Your search returned this information about pizza number {i.ItemId}:");
                                Console.WriteLine();
                                Console.WriteLine($"{i.Name} has ID. no {i.ItemId} and costs {i.Price}");
                                Console.Write("Contains pizzatoppings: ");
                                foreach (Topping o in i.ToppingList)
                                {
                                    Console.Write($"{o.Name}, ");
                                }
                                Console.WriteLine();
                                Console.WriteLine();
                                SearchPizzaReturnToMenu();
                            }

                            else if (userInputInt > pizzaList.Count - 1)
                            {
                                Console.Clear();
                                Console.WriteLine($"Type '{GoBackButtonString}' to return to User Menu");
                                Console.WriteLine("The number you searched for is not on the menu");
                            }
                        }

                    }
                    catch (System.FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("Please only insert numbers!");
                    }
                }                
            }

            #endregion

            #region If search by name

            else if (userInputString == "n")
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Search for pizza by name:");                    
                    try
                    {
                        userInputString = Console.ReadLine();
                        if (userInputString == $"{GoBackButtonString}")
                        {
                            Console.Clear();
                            PrintUserMenu();
                        }
                        foreach (Pizza i in pizzaList)
                        {
                            if (i.Name == userInputString)
                            {
                                Console.Clear();
                                Console.WriteLine($"Your search returned this information about pizza '{i.Name}':");
                                Console.WriteLine();
                                Console.WriteLine($"{i.Name} has ID. no {i.ItemId} and costs {i.Price}");
                                Console.Write("Contains pizzatoppings: ");
                                foreach (Topping o in i.ToppingList)
                                {
                                    Console.Write($"{o.Name}, ");
                                }
                                Console.WriteLine();
                                SearchPizzaReturnToMenu();
                            }
                            
                        }
                        Console.Clear();
                        Console.WriteLine($"Your search came back empty. Try check your spelling, or type {GoBackButtonString} to return to the User Menu");
                        Console.WriteLine("Note: Every pizza starts with a capital letter");
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Please insert something");
                    }
                }
            }
            #endregion
            Console.Clear();
            Console.WriteLine("Please choose one of the following options");
            SearchPizza();
        }

        public void SearchPizzaReturnToMenu()
        {
            while (true)
            {
                Console.WriteLine("Type 'y' to return to the User Menu");
                Console.WriteLine("Type 'o' to search for a new pizza");

                string userInput2;
                userInput2 = Console.ReadLine();

                if (userInput2 == "y")
                {
                    Console.Clear();
                    PrintUserMenu();
                }
                else if (userInput2 == "o")
                {
                    Console.Clear();
                    SearchPizza();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You typed something that leads you nowhere. Check your options, and try again!");
                    Console.WriteLine();
                }

            }
        }

        public void CreatePizza() // Fix total reset ved forkert indtastning (chrisfix lav metode og smid i catch. Navn må ikke være tomt.
        {

            string pizzaName;
            int pizzaPrice;
            int ItemId;
            int userInput;
            string userInputString;
            while (true)
            {
                try
                {                                      
                    Console.WriteLine($"Your pizza will be added to the menu as number {pizzaList.Count + 1}");
                    Console.WriteLine();
                    ItemId = pizzaList.Count + 1;
                    Console.WriteLine();
                    Console.WriteLine("What would you like to name the pizza?");
                    Console.WriteLine();
                    pizzaName = Console.ReadLine();                    
                    Console.WriteLine();
                    Console.WriteLine($"What would you like to set price of {pizzaName}?");
                    Console.WriteLine();
                    pizzaPrice = Convert.ToInt32(Console.ReadLine());
                        
                    Pizza p = new Pizza(ItemId, pizzaName, pizzaPrice);
                    
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"What topping would you like to add to {pizzaName}?");
                        Console.WriteLine("List of toppings:");
                        Console.WriteLine();
                        PrintToppingMenu();
                        userInput = Convert.ToInt32(Console.ReadLine());
                        p.ToppingList.Add(toppingList[userInput - 1]);
                        Console.Clear();
                        Console.WriteLine($"{toppingList[userInput - 1]} was successfully added to your pizza!");
                        Console.WriteLine($"This is how your pizza is currently setup: ");
                        Console.WriteLine();
                       
                        Console.Write($"Number: {p.ItemId}\nName: {p.Name}\nPrice: {p.Price}\nTopping: ");
                        foreach (Topping i in p.ToppingList)
                        {
                                Console.Write($"{i}, ");
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("To add more topping, type 'y'");
                        Console.WriteLine("To finish the pizza, type 'n'");
                        userInputString = Console.ReadLine();
                        Console.Clear();
                        if (userInputString == "n")
                            break;                      
                    }

                    pizzaList.Add(p);
                    Console.Clear();
                    Console.WriteLine($"Your new pizza: '{p.Name}' was successfully created. It's listed as ID no. '{p.ItemId}', and the price is set to '{p.Price}'");
                    Console.WriteLine();
                    SortMenuById();
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("You have to enter a number");

                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The number you entered is not on the list of options. Try again!");
                }

            }
            while (true)
            {                
                Console.WriteLine("Type 'y' to see the updated menu");
                Console.WriteLine("Type 'n' to return to the User Menu");
                Console.WriteLine("Type 'o' to add another pizza to the menu");

                string userInput2;
                userInput2 = Console.ReadLine();

                if (userInput2 == "y")
                {
                    Console.Clear();
                    PrintMenu();
                }
                else if (userInput2 == "n")
                {
                    Console.Clear();
                    PrintUserMenu();
                }
                else if (userInput2 == "o")
                {
                    Console.Clear();
                    CreatePizza();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You typed something that leads you nowhere. Check your options, and try again!");
                    Console.WriteLine();
                }
            }




        }

        public void PrintUserMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("PizzaStore ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MenuApp");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(FormatUserMenu(), "1.", "Add new pizza to the menu");
            Console.WriteLine(FormatUserMenu(), "2.", "Delete pizza");
            Console.WriteLine(FormatUserMenu(), "3.", "Update pizza");
            Console.WriteLine(FormatUserMenu(), "4.", "Search pizza");
            Console.WriteLine(FormatUserMenu(), "5.", "Display pizza menu");
            Console.WriteLine();
            Console.WriteLine("Please type the menu section no. you wish to access, and click 'enter'");

            int userInput;
            while (true)
            {
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput > 5 || userInput < 0)
                    {
                        Console.WriteLine("Please select an option between 0 and 5");
                    }
                    else
                        break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please insert only numbers");
                }
            }

            if (userInput == 1)
            {
                Console.Clear();
                CreatePizza();
            }

            else if (userInput == 2)
            {
                Console.Clear();
                RemovePizza();
            }
            else if (userInput == 3)
            {
                Console.Clear();
                UpdatePizza();
            }
            else if (userInput == 4)
            {
                Console.Clear();
                SearchPizza();
            }
            else if (userInput == 5)
            {
                Console.Clear();
                PrintMenu();
            }



        }

        public void UpdatePizza() // Opdater til individuel ændring
        {
            ReturnToMenuMessage();
            Console.WriteLine();
            Console.WriteLine("Which pizza do you wish to update?");
            Console.WriteLine();
            int o = 1;
            foreach (Pizza i in pizzaList)
            {
                Console.WriteLine($"{o}. {i.Name}");
                o++;
            }
            while (true)
            {
                try
                {
                    
                    int userInput;
                    userInput = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (userInput == pizzaList.Count)
                    {
                        Console.Clear();
                        PrintUserMenu();
                    }
                    Console.Clear();
                    Console.WriteLine($"You are now updating the pizza: {pizzaList[userInput]}");
                    Console.WriteLine();
                    Console.WriteLine($"What do you wish for the new name to be?");                 
                    pizzaList[userInput].Name = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine($"What do you wish for the new updated price to be? Its previous price was {pizzaList[userInput].Price}");
                    pizzaList[userInput].Price = Convert.ToInt32(Console.ReadLine()); ;
                    Console.WriteLine();
                    Console.WriteLine($"What do you wish for the new updated number on menu to be? It was previously listed as number {pizzaList[userInput].ItemId}");
                    pizzaList[userInput].ItemId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine($"Update complete: The new name of the pizza is now '{pizzaList[userInput].Name}'. It's now listed as no. {pizzaList[userInput].ItemId}, and the price is set to {pizzaList[userInput].Price}");
                    break;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The number you typed does not exist on the menu. Please try a new number");
                    UpdatePizza();
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please only insert numbers");
                }                
            }
            while (true)
            {
                Console.WriteLine("Type 'y' to see the updated menu");
                Console.WriteLine("Type 'n' to return to the User Menu");
                Console.WriteLine("Type 'o' to update another pizza to the menu");

                string userInput2;
                userInput2 = Console.ReadLine();

                if (userInput2 == "y")
                {
                    Console.Clear();
                    PrintMenu();
                }
                else if (userInput2 == "n")
                {
                    Console.Clear();
                    PrintUserMenu();
                }
                else if (userInput2 == "o")
                {
                    Console.Clear();
                    CreatePizza();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You typed something that leads you nowhere. Check your options, and try again!");
                    Console.WriteLine();
                }
            }            
        }

        public void ReturnToMenuMessage()
        {
            Console.WriteLine($"Type '{pizzaList.Count + 1}' to return to User Menu");
        }

        public void PrintToppingMenu()
        {
            foreach (Topping i in toppingList)
            {
                Console.WriteLine($"{i.ItemId}. {i.Name}");
            }
        }

        public void PrintSimplePizzaInfo()
        {
            foreach (Pizza i in pizzaList)
            {
                Console.WriteLine($"{i.ItemId}. {i.Name}");
            }
        }

        #endregion

        #region Properties

        public string GoBackButtonString
        {
            get { return $"{pizzaList.Count + 1}"; }
        }

        public int GoBackButtonInt
        {
            get { return pizzaList.Count + 1; }
        }

        #endregion


    }
}