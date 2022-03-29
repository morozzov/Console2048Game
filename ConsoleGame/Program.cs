using System;
using System.Threading;

namespace ConsoleGame
{
    class Field
    {
        private int[,] field = new int[4, 4];
        public Field()
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    field[i, j] = 0;
                }
            }
        }

        public void RandomBlock()
        {
            Random rnd = new Random();
            bool isNotNew = true;
            do
            {
                (int, int) pos = (rnd.Next(4), rnd.Next(4));
                if (field[pos.Item1, pos.Item2] == 0)
                {
                    int rndInt = rnd.Next(100);
                    if (rndInt > 30)
                    {
                        field[pos.Item1, pos.Item2] = 2;
                    }
                    else
                    {
                        field[pos.Item1, pos.Item2] = 4;
                    }

                    isNotNew = false;
                }
            } while (isNotNew);
        }

// void move_up(int a[][4])
// 	
// void move_down(int a[][4])
// 
// void move_left(int a[][4])
//
// void move_right(int a[][4])
// 
        public void move(ConsoleKey key)
        {
            bool isMove = false;
            
            if (key == ConsoleKey.U)
            {
                print();
            }

            else if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
            {
                int i, j, k, n;
                int flag = 0;
                for (j = 0; j < 4; j++) // row 
                {
                    flag = 0;
                    for (i = 1; i < 4; i++) // column 
                    {
                        n = 4;
                        while (n-- != 1)
                        {
                            if (field[i - 1, j] == 0)
                            {
                                for (k = i; k < 4; k++)
                                {
                                    field[k - 1, j] = field[k, j];
                                    field[k, j] = 0;

                                    isMove = true;
                                }
                                Thread.Sleep(10);

                            }
                        }
                    }
                    
                    
                    for (i = 1; i < 4; i++)
                    {
                        n = 4;
                        if (flag == 0)
                            if (field[i - 1, j] == field[i, j])
                            {
                                field[i - 1, j] *= 2;
                                field[i, j] = 0;
                                flag = 1;

                            }

                        while (n-- != 1)
                        {
                            if (field[i - 1, j] == 0)
                                for (k = i; k < 4; k++)
                                {
                                    field[k - 1, j] = field[k, j];
                                    field[k, j] = 0;

                                    isMove = true;
                                }
                        }
                    }
                }
            }


            else if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
            {
                int i, j, k, n;
                int flag = 0;
                for (j = 0; j < 4; j++) // column 
                {
                    flag = 0;
                    for (i = 3; i >= 1; i--) // row 
                    {
                        n = 4;
                        while (n-- != 1)
                        {
                            if (field[i, j] == 0)
                            {
                                for (k = i; k >= 1; k--)
                                {
                                    field[k, j] = field[k - 1, j];
                                    field[k - 1, j] = 0;

                                    isMove = true;
                                }
                            }
                        }
                    }

                    for (i = 2; i >= 0; i--)
                    {
                        n = 4;
                        if (flag == 0)
                            if (field[i + 1, j] == field[i, j])
                            {
                                field[i + 1, j] *= 2;
                                field[i, j] = 0;
                                flag = 1;

                            }

                        while (n-- != 1)
                        {
                            if (field[i, j] == 0)
                                for (k = i; k >= 1; k--)
                                {
                                    field[k, j] = field[k - 1, j];
                                    field[k - 1, j] = 0;

                                    isMove = true;
                                }
                        }
                    }
                }
            }

            else if (key == ConsoleKey.A || key == ConsoleKey.LeftArrow)
            {
                int i, j, k, n;
                int flag = 0;
                for (i = 0; i < 4; i++) // row 
                {
                    flag = 0;
                    for (j = 1; j < 4; j++) // column 
                    {
                        n = 4;
                        while (n-- != 1)
                        {
                            if (field[i, j - 1] == 0)
                            {
                                for (k = j; k < 4; k++)
                                {
                                    field[i, k - 1] = field[i, k];
                                    field[i, k] = 0;

                                    isMove = true;
                                }
                            }
                        }
                    }

                    for (j = 1; j < 4; j++)
                    {
                        n = 4;
                        if (flag == 0)
                            if (field[i, j - 1] == field[i,j])
                            {
                                field[i, j - 1] *= 2;
                                field[i, j] = 0;
                                flag = 1;
                                
                            }

                        while (n-- != 1)
                        {
                            if (field[i, j - 1] == 0)
                                for (k = j; k < 4; k++)
                                {
                                    field[i, k - 1] = field[i, k];
                                    field[i, k] = 0;

                                    isMove = true;
                                }
                        }
                    }
                }
            }
            else if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
            {
                int i, j, k, n;
                int flag = 0;
                for (i = 0; i < 4; i++) // row
                {
                    flag = 0;
                    for (j = 3; j >= 1; j--) // column 
                    {
                        n = 4;
                        while (n-- != 1)
                        {
                            if (field[i, j] == 0)
                            {
                                for (k = j; k >= 1; k--)
                                {
                                    field[i, k] = field[i, k - 1];
                                    field[i, k - 1] = 0;
                                    
                                    isMove = true;
                                }
                            }
                        }
                    }

                    for (j = 2; j >= 0; j--)
                    {
                        n = 4;
                        if (flag == 0)
                            if (field[i, j + 1] == field[i, j])
                            {
                                field[i, j + 1] *= 2;
                                field[i, j] = 0;
                                flag = 1;
                            }

                        while (n-- != 1)
                        {
                            if (field[i, j] == 0)
                                for (k = j; k >= 1; k--)
                                {
                                    field[i, k] = field[i, k - 1];
                                    field[i, k - 1] = 0;
                                    
                                    isMove = true;
                                }
                        }
                    }
                }
            }
            else
            {
                print();
            }

            if (isMove)
            {
                RandomBlock();
                print();
            }
        }

        public void print()
        {
            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (field[i,j]==0)
                    {
                        Console.Write("__".PadRight(3).PadLeft(4));
                    }
                    else
                    {
                        ConsoleColor temp = Console.BackgroundColor;   
                        
                        if (field[i, j] == 2)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        else if (field[i, j] == 4)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                        else if (field[i, j] == 8)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else if (field[i, j] == 16)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                        }
                        else if (field[i, j] == 32)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else if (field[i, j] == 64)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                        }
                        else if (field[i, j] == 128)
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                        }
                        else if (field[i, j] == 256)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        Console.Write(field[i, j].ToString().PadRight(3).PadLeft(4));

                        Console.BackgroundColor = temp;

                    }
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Field field = new Field();
            field.RandomBlock();
            
            field.print();
            // field.move(Console.ReadKey().Key);
            Thread.Sleep(3000);

            while (true)
            {
                field.move(Console.ReadKey().Key);
            }


            field.print();
        }
    }
}