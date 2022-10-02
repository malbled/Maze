using System;
using System.Runtime.ConstrainedExecution;

namespace Лабиринт
{
    class Program
    {
        static void field_output(int[,] labirint)
        {
            var x = 0;
            var y = 0;
            Console.SetCursorPosition(37, 0);
            Console.Write("               Welcom, в игру Бегущий в лабиринте!");
            Console.SetCursorPosition(37, 2);
            Console.Write("          Нет лабиринтов, из которых невозможно выбраться");
            Console.SetCursorPosition(37, 4);
            Console.Write("                   Цель: ☺ должен придти к ♥");

            Console.SetCursorPosition(37, 6);
            Console.Write(@"                     ******************** 
                                                          *       Шаги:      *                                       
                                                          *  Вверх  -    w   *                                         
                                                          *  Вниз   -    s   *                                         
                                                          *  Вправо  -   d   *                                         
                                                          *  Влево   -   a   *     
                                                          ********************");

            Console.SetCursorPosition(x, y);
            int i, j;
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (i = 0; i < labirint.GetLength(0); i++, ++y)
            {
                for (j = 0; j < labirint.GetLength(1); j++, ++x)
                {
                    Console.SetCursorPosition(x, y);
                    if (labirint[i, j] == 1)
                    {
                        Console.Write("░");
                    }

                    if (labirint[i, j] == 3)
                    {
                        Console.Write("♥");
                    }
                }
                x = 0;
            }
            Console.ResetColor();
        }
        static void final(int[,] labirint, int x, int y)
        {
            Console.Clear();
            field_output(labirint);
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("☺");
            Console.SetCursorPosition(55, 15);
            Console.WriteLine("Вы пришли к концу лабиринта!");
            Console.SetCursorPosition(55, 16);
                Console.Write("        Поздравляю!!!");
            Console.ResetColor();
        }

        static void Check(int[,] labirint, int x, int y, bool step)
        {
            if (step)
            {
                Console.Clear();
                field_output(labirint);
                Console.SetCursorPosition(x, y);
                Console.Write("☺");
                Console.SetCursorPosition(52,0);
            }
            else
            { 
                Console.Clear();
                field_output(labirint);
                Console.SetCursorPosition(x, y);
                Console.Write("☺");
                Console.SetCursorPosition(58,15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Вы уперлись в стену!");
                Console.ResetColor();
            }
        }


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(95,33);

            int[,] labirint =
            {
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,3,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1 },
                { 1,0,1,1,1,0,1,1,1,0,1,0,1,1,1,1,1,0,1,0,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,1,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1 },
                { 1,0,0,0,1,0,1,0,0,0,1,0,1,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1 },
                { 1,0,1,1,1,0,1,0,1,1,1,0,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1 },
                { 1,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,1 },
                { 1,1,1,0,1,1,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1,1,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1 },
                { 1,0,0,0,1,0,1,0,1,0,1,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,1,0,1 },
                { 1,0,1,1,1,0,1,0,1,0,1,0,1,1,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1 },
                { 1,0,1,0,0,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,0,0,0,0,1,0,1,0,1,0,0,0,1,0,1 },
                { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,0,0,0,0,1,0,0,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,1 },
                { 1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,0,1,0,1 },
                { 1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0,1,0,1,0,0,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,1,1,0,1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,0,1,1,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,1 },
                { 1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,1,1,0,1,0,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,0,1 },
                { 1,0,1,0,1,0,1,0,0,0,1,0,0,0,1,0,1,0,1,0,1,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,0,1,0,1,0,1,0,1,1,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                { 1,0,1,0,1,0,1,0,0,0,0,0,0,0,1,0,1,0,0,0,1,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1 },
                { 1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,0,1,0,1,1,1,0,1,1,1,1,1,1,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0,0,0,0,0,0,0,1,0,0,0,1,0,1,0,1,0,1,0,0,0,1,0,0,0,1,0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0,1,1,1,1,1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,0,1,0,1,0,1,0,1,0,1,0,1 },
                { 1,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,0,0,1,0,1,0,1,0,1 },
                { 1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,1,1,1,1,1,1,0,1,1,1,0,1 },
                { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
            };


            field_output(labirint);
            var x = 17;
            var y = 1;
            Console.SetCursorPosition(x, y);
            Console.Write("☺");
            var GameOver = false;
            while (!GameOver)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case ('w'):
                        if (labirint[--y, x] == 1)
                        {
                            ++y;
                            Check(labirint, x, y, false);
                        }
                        else
                        if (labirint[--y, x] == 0)
                        {
                            Check(labirint, x, y, true);
                        }
                        else
                        {
                            final(labirint,x, y);
                            
                        }
                        break;

                    case ('s'):
                        if (labirint[++y, x] == 1)
                        {
                            --y;
                            Check(labirint, x, y, false);
                        }
                        else
                        if (labirint[++y, x] == 0)
                        {   
                            Check(labirint, x, y, true);
                        }
                        else
                        {
                            final(labirint,x, y);
                            
                        }
                        break;
                        
                    case ('a'):
                        if (labirint[y, --x] == 1)
                        {
                            ++x;
                            Check(labirint, x, y, false);
                        }
                        else
                        if (labirint[y, --x] == 0)
                        {
                            Check(labirint, x, y, true);
                        }
                        else
                        {
                            final(labirint, x,y);
                            
                        }
                        break;

                    case ('d'):
                        if (labirint[y, ++x] == 1)
                        {
                            --x;
                            Check(labirint, x, y, false);
                        }
                        else
                        if (labirint[y, ++x] == 0)
                        {
                            Check(labirint, x, y, true);
                        }
                        else
                        {
                            final(labirint, x,y);
                           
                        }
                        break;
                    default:
                        Console.Clear();
                        field_output(labirint);
                        Console.SetCursorPosition(x, y);
                        Console.Write("☺");
                        Console.SetCursorPosition(58, 15);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Не правильная клавиша!");
                        Console.ResetColor();
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
