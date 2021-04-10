using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameLib
{

   public class ExpectionCollection : Exception
    {


        public void MinimumError()
        {
            Console.WriteLine("Minimum length for row and col is 1. Closing Application.");
            Console.ReadKey();
            Environment.Exit(-1);
        }



    }


   public class Conwaygame
    {

        private int M;
        private int N;

        private int[,] CellularAutomata;
        private int[,] TempCA;

        private char dead;
        private char alive;

        public Conwaygame(char newdead = '0', char newalive = '1')
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


                if (M < 1 || N < 1)
                {
                    throw new ExpectionCollection();
                }

            }
            catch (ExpectionCollection e)
            {

                e.MinimumError();

            }

            // Do not make any changes in it
            TempCA = new int[M, N];


        }

        private int Countneighbour(int m, int n)    // Calculating neighbours of a cell which is at [i,j] position
        {

            int neighbour = 0;


            for (int i = m - 1; i <= m + 1; i++)
                for (int j = n - 1; j <= n + 1; j++)
                    neighbour += CellularAutomata[i, j];

            return neighbour - CellularAutomata[m, n];           // [m,n] is also included , so just remove it :)


        }



        public void NextGeneration()
        {


            for (int i = 1; i < M - 1; i++)
            {

                for (int j = 1; j < N - 1; j++)
                {


                    int alive = Countneighbour(i, j);


                    // Rules for the Life game as mentioned in the question paper.


                    //Death by underpopulation

                    if (CellularAutomata[i, j] == 1 && alive < 2)
                    {
                        TempCA[i, j] = 0;
                    }



                    // Death by overpopulation
                    // this rule was not there in the question , but i added it so that it could be Turing-Complete :)

                    else if (CellularAutomata[i, j] == 1 && alive > 3)
                    {
                        TempCA[i, j] = 0;
                    }


                    //Survival

                    else if (CellularAutomata[i, j] == 1 && (alive == 2 || alive == 3))
                    {
                        TempCA[i, j] = 1;
                    }


                    //Rebirth

                    else if (CellularAutomata[i, j] == 0 && alive == 3)
                    {
                        TempCA[i, j] = 1;
                    }



                }


            }

        }


        public void Printgeneration ()
        {
            // Printing the grid 

            for (int i = 0; i < M; i++)
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

                Console.WriteLine();

            }

            Console.Write("\n\n\n");
        }





    }
}
