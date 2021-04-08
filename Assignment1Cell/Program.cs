using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assignment1Cell
{


    class ExpectionCollection : Exception
    {


        public void MinimumError()
        {
            Console.WriteLine("Minimum length for row and col is 1. Closing Application.");
            Console.ReadKey();
            Environment.Exit(-1);
        }



    }


    class Conwaygame
    {

        private int M;
        private int N;

       private int[,] CellularAutomata;
       private int[,] TempCA;

       private char dead  ;
       private char alive ;

        public Conwaygame(char newdead='0' , char newalive='1')
        {

             dead = newdead;
             alive = newalive;

            // you can edit this grid to make different generation :)
            CellularAutomata = new int[,]{

            { 0,0,0,0,0},
            { 0,0,1,0,0},
            { 0,0,1,0,0},
            { 0,0,1,0,0},
            { 0,0,0,0,0},
            

        };

            try
            {
                M = CellularAutomata.GetLength(0);
                N = CellularAutomata.GetLength(1);


                if (M < 1 || N <1)
                {
                    throw new ExpectionCollection();
                }

            }
            catch(ExpectionCollection e)
            {

                e.MinimumError();

            }

            // Do not make any changes in it
            TempCA = new int[M, N];


        }

        private int conuntneigh(int m,int n)    // Calculating neighbours of a cell which is at [i,j] position
        {

            int neighbour = 0;


            for (int i = m - 1; i <= m + 1; i++)
                for (int j = n - 1; j <= n + 1; j++)
                    neighbour += CellularAutomata[i, j];

            return neighbour - CellularAutomata[m, n];           // [i,j] is also included , so just remove it :)


        }



public void NextGeneration ()
        {


            for (int i = 1; i < M-1; i++)
            {

                for (int j = 1; j < N-1; j++)
                {


                    int alive = conuntneigh(i, j);


                    // Rules for the Life game as mentioned in the question paper.

                    if (CellularAutomata[i, j] == 1 && alive < 2)
                    {
                        TempCA[i, j] = 0;
                    }

                    else if (CellularAutomata[i, j] == 1 && alive > 3)
                    {
                        TempCA[i, j] = 0;
                    }


                    else if (CellularAutomata[i, j] == 0 && alive == 3)
                    {
                        TempCA[i, j] = 1;
                    }


                    else TempCA[i, j] = CellularAutomata[i, j];



                }


            }


            // Printing the grid 

            for ( int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {

                    CellularAutomata[i, j] = TempCA[i, j];

                    if (CellularAutomata[i, j] == 0)
                    Console.Write(dead + " ");

                    else
                        Console.Write(alive + " ");

                    TempCA[i, j] = 0;
                }

                Console.Write("\n");

            }



            Console.Write("\n\n\n");

        }






    }
    class Program
    {
        static void Main(string[] args)
        {

            Conwaygame game = new Conwaygame('.' , 'O');  // Creating instance of the Conwaygame class and assining the custom visual char
                                                          // For example 
                                                          // .  = Dead cell
                                                          // O  = Live cell 


reinout:
            Console.WriteLine("Do you want animation ? y/n");   // Prompting user if he wants animation or the steps.
  
            char choice = ' ';

          

                choice = Console.ReadKey().KeyChar;



            if (choice == 'y' || choice == 'Y')    // If animation is selected
            {
                Console.Clear();

                while (true)
                {


                    game.NextGeneration();

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

                }



            }


            else {

                Console.WriteLine("\nInvalid Input Try again\n");

                goto reinout; }
         
         

            Console.ReadKey();




        }
    }





}
