using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieHard
{
    class Program
    {
        public static void Print(int[,] bla)
        {
            for (int i = 0; i < bla.GetLength(0); i++)
            {
                for (int j = 0; j < bla.GetLength(1); j++)
                {
                    if (true)
                    {

                    }
                    Console.Write(bla[i,j] == 0 ? " ": bla[i, j]+"");
                }
                Console.WriteLine();
            }
            Console.WriteLine("**********");
        }

        public static int[,] Tick(int[,] bla)
        {
            int x = bla.GetLength(0);
            int y = bla.GetLength(1);

            int[,] next = new int[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    next[i, j] = ComputeState(i,j, bla, bla[i,j]);
                }
            }


            return next;
        }

        public static int ComputeState(int i, int j, int[,] bla, int currentState)
        {
            int state;
            int sum = -1;
            int x = bla.GetLength(0);
            int y = bla.GetLength(1);

            if (i > 0 && j > 0 && i <= x - 2 && j <= y - 2)
            {
                sum = bla[i - 1, j - 1] + bla[i - 1, j] + bla[i - 1, j + 1] +
                      bla[i, j - 1] + bla[i, j] + bla[i, j + 1] +
                      bla[i + 1, j - 1] + bla[i + 1, j] + bla[i + 1, j + 1];
            }
            else
            {
                if (i < 1 && j < 1)
                {
                    sum = bla[x - 1, y - 1] + bla[x - 1, j] + bla[x - 1, j + 1] +
                      bla[i, y - 1] + bla[i, j] + bla[i, j + 1] +
                      bla[i + 1, y - 1] + bla[i + 1, j] + bla[i + 1, j + 1];
                }
                else if (i > x - 1 - 1 && j > y - 1 - 1)
                {
                    sum = bla[i - 1, j - 1] + bla[i - 1, j] + bla[i - 1, 0] +
                      bla[i, j - 1] + bla[i, j] + bla[i, 0] +
                      bla[0, j - 1] + bla[0, j] + bla[0, 0];
                }
                else if (i < 1 && j > y - 1 - 1)
                {
                    sum = bla[x - 1, j - 1] + bla[x - 1, j] + bla[x - 1, 0] +
                      bla[i, j - 1] + bla[i, j] + bla[i, 0] +
                      bla[i + 1, j - 1] + bla[i + 1, j] + bla[i + 1, 0];
                }
                else if (j < 1 && i > 0 && i > x - 2 && j < y - 2)
                {
                    sum = bla[i - 1, y - 1] + bla[i - 1, j] + bla[i - 1, j + 1] +
                     bla[i, y - 1] + bla[i, j] + bla[i, j + 1] +
                     bla[0, y - 1] + bla[0, j] + bla[0, j + 1];
                }

                else if (i < 1 && j > 0 && i < x - 2 && j <= y - 2)
                {
                    sum = bla[x - 1, j - 1] + bla[x - 1, j] + bla[x - 1, j + 1] +
                          bla[i, j - 1] + bla[i, j] + bla[i, j + 1] +
                          bla[i + 1, j - 1] + bla[i + 1, j] + bla[i + 1, j + 1];
                }

                else if (j < 1 && i > 0 && i <= x - 2 && j < y - 2)
                {
                    sum = bla[i - 1, y - 1] + bla[i - 1, j] + bla[i - 1, j + 1] +
                      bla[i, y - 1] + bla[i, j] + bla[i, j + 1] +
                      bla[i + 1, y - 1] + bla[i + 1, j] + bla[i + 1, j + 1];
                }

                else if (i > 0 && j > 0 && i <= x - 2 && j > y - 1 - 1)
                {
                    sum = bla[i - 1, j - 1] + bla[i - 1, j] + bla[i - 1, 0] +
                     bla[i, j - 1] + bla[i, j] + bla[i, 0] +
                     bla[i + 1, j - 1] + bla[i + 1, j] + bla[i + 1, 0];
                }
                else if (i > 0 && j > 0 && j <= y - 2 && i > x - 1 - 1)
                {
                    sum = bla[i - 1, j - 1] + bla[i - 1, j] + bla[i - 1, j + 1] +
                      bla[i, j - 1] + bla[i, j] + bla[i, j + 1] +
                      bla[0, j - 1] + bla[0, j] + bla[0, j + 1];
                }
                


            }
           

            if (sum == 3)
            {
                return state = 1;
            }
            else if (sum == 4)
            {
                return state = currentState;
            }
            else
            {
                return state = 0;
            }
        }
        static void Main(string[] args)
        {

            //int[,] current = new int[5, 10] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //                                  { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            //                                  { 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
            //                                  { 0, 0, 1, 0, 0, 0, 1, 1, 1, 0 },
            //                                  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            //                                                                    };

            int[,] current = new int[40, 40];
            current[20, 27] = 1;
            current[21, 21] = 1;
            current[21, 22] = 1;
            current[22, 22] = 1;
            current[22, 26] = 1;
            current[22, 27] = 1;
            current[22, 28] = 1;

            //int[,] current = new int[10, 10];
            //current[4, 5] = 1;
            //current[4, 6] = 1;
            //current[4, 7] = 1;

            //current[5, 4] = 1;
            //current[5, 5] = 1;
            //current[5, 6] = 1;

            int[,] next;

            for (int i = 1; i < 131; i++)
            {
                Console.WriteLine(i);
                next = Tick(current);
                current = next;
                //next = Tick(current);

                Print(next);
               // Task.Factory.StartNew(() => Console.ReadKey()).Wait(TimeSpan.FromSeconds(2.0));

            }
            //int[,] next = Tick(current);


            //Print(next);
            Console.ReadKey();
        }
    }
}
