using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConwayGameLib;

namespace Assignment1Cell
{

    class Program
    {
        static void Main(string[] args)
        {

            const char DeadCell = '.';
            const char AliveCell = 'O';

            Conwaygame game = new Conwaygame(DeadCell , AliveCell);  // Creating instance of the Conwaygame class and assigning the custom visual char
                                                          // For example 
                                                          // .  = Dead cell
                                                          // O  = Live cell 


         
            Console.WriteLine("Do you want animation ? y/n");   // Prompting user if he wants animation or the steps.
  
            char choice = ' ';

          

                choice = Console.ReadKey().KeyChar;



            if (choice == 'y' || choice == 'Y')    // If animation is selected
            {
                Console.Clear();

                while (true)
                {


                    game.NextGeneration();
                    game.Printgeneration();

                    Thread.Sleep(700);

                    Console.Clear();

                }



            }

            else if (choice == 'n' || choice == 'N')   // If animation is not selected
            {

                Console.Clear();

                Console.Write("Enter the number of generation : ");

                int n = Convert.ToInt32(Console.ReadLine());  // Ask user that till how many generation he wants.




                for (int i = 0; i < n; i++)         // Print the grid till Nth generation
                {

                    Console.WriteLine("generation " + (i + 1));
                    game.NextGeneration();
                    game.Printgeneration();

                }



            }


            else {

                Console.WriteLine("\nInvalid Input Try again\n");


            }
         
               Console.ReadKey();


        }
    }



}
