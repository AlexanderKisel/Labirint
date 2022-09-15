using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Runtime.CompilerServices;

class Program
{
    static string[] texts = new string[] { "Сделайте выбор уровня или завершите программу, выбирайте стрелками вниз-вверх, что бы поддтвердить нажми - Enter\n",
                "1 : 1 - уровень", "2 : 2 - уровень", "3 : 3 - уровень (В разработке)","4 : Выход" };
    static void Main(string[] args)
    {
    restart:      
        Console.Clear();
        Console.CursorVisible = false;
        Console.SetWindowSize(110, 50);
            foreach (string text in texts)
                Console.WriteLine(text);
            int num = keys();//вызов менюшки 
            var lvl = 0;
            var n = 0;
            var m = 0;
            switch (num)
            {
                case 1: { lvl = 1; n = 12; m = 17; Console.ReadKey(); } break;
                case 2: { lvl = 2; n = 27; m = 27; Console.ReadKey(); } break;
                case 3: { System.Diagnostics.Process.Start(@"3.mp4"); goto restart; }
                case 4: { }; goto end;
            }
                var exit = 0;
                var player_x = 0;
                var player_y = 0;
                var map_i = 0;
                var map_j = 0;
                int i, j;
                int x;
                int y = (Console.WindowHeight / 2) - 6;
                string[] lines1 = File.ReadAllLines(@"maps\1level.txt");
                string[] lines2 = File.ReadAllLines(@"maps\2level.txt");
                char[,] map = new char[30, 30];
                if (lvl == 1)
                {
                    for (i = 0; i < 12; i++)
                    {
                        for (j = 0; j < 17; j++)
                        {
                            map[i, j] = lines1[i][j];
                        }
                    }
                }
                if (lvl == 2)
                {
                    for (i = 0; i < 27; i++)
                    {
                        for (j = 0; j < 27; j++)
                        {
                            map[i, j] = lines2[i][j];
                        }
                    }
                }
                Console.Clear();
                for (i = 0; i < n; i++)
                {
                    x = (Console.WindowWidth / 2) - 8;
                    for (j = 0; j < m; j++)
                    {
                        if (map[i, j] == '1')
                        {
                            Console.SetCursorPosition(x, y); Console.Write("█"); x++; continue;
                        }
                        if (map[i, j] == '2')
                        {
                            map_i = i;
                            map_j = j;
                            player_x = x;
                            player_y = y;
                            Console.SetCursorPosition(x, y); Console.Write("☺"); x++; continue;
                        }
                        if (map[i, j] == '3')
                        {
                        Console.SetCursorPosition(x, y); Console.Write("♥"); x++; continue;
                        }
                        if (map[i, j] == '4')
                        {
                            Console.SetCursorPosition(x, y); Console.Write("☼"); x++; continue;
                        }
                        if (map[i, j] == '5')
                        {
                            Console.SetCursorPosition(x, y); Console.Write("П"); x++; continue;
                        }
                        if (map[i, j] == '6')
                        {
                            Console.SetCursorPosition(x, y); Console.Write("."); x++; continue;
                        }
                        else
                        {
                            Console.SetCursorPosition(x, y); Console.Write(" "); x++; continue;
                        }
                    }
                    y++;
                }
                Console.WriteLine();
                x = player_x;
                y = player_y;
                i = map_i;
                j = map_j;
                Console.SetCursorPosition(x, y);
                Console.CursorVisible = false;
                ConsoleKey key;
                while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter && exit == 0)
                {
                    if (exit == 1)
                    {
                        break;
                    }
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (map[i - 1, j] == '0' || map[i - 1, j] == '2' || map[i - 1, j] == '3' || map[i - 1, j] == '4' || map[i - 1, j] == '5' || map[i - 1, j] == '6')
                            {
                                Console.SetCursorPosition(x, y--); Console.Write(" ");
                                Console.SetCursorPosition(x, y); Console.Write("☺");
                                if (map[i - 1, j] == '3')
                                if (map[i - 1, j] == '5')
                                {
                                goto restart;
                                }
                                i--;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (map[i + 1, j] == '0' || map[i + 1, j] == '2' || map[i + 1, j] == '3' || map[i + 1, j] == '4' || map[i + 1, j] == '5' || map[i + 1, j] == '6')
                            {
                                Console.SetCursorPosition(x, y++); Console.Write(" ");
                                Console.SetCursorPosition(x, y); Console.Write("☺");
                                if (map[i + 1, j] == '5')
                                {
                                goto restart;
                                }
                                i++;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (map[i, j + 1] == '0' || map[i, j + 1] == '2' || map[i, j + 1] == '3' || map[i, j + 1] == '4' || map[i, j + 1] == '5' || map[i, j + 1] == '6')
                            {
                                Console.SetCursorPosition(x++, y); Console.Write(" ");
                                Console.SetCursorPosition(x, y); Console.Write("☺");
                                if (map[i, j + 1] == '5')
                                {
                                goto restart;
                                }
                            j++;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (map[i, j - 1] == '0' || map[i, j - 1] == '2' || map[i, j - 1] == '3' || map[i, j - 1] == '4' || map[i, j - 1] == '5' || map[i, j - 1] == '6')
                            {
                                Console.SetCursorPosition(x--, y); Console.Write(" ");
                                Console.SetCursorPosition(x, y); Console.Write("☺");
                                if (map[i, j - 1] == '5')
                                {
                                goto restart;
                                }
                                j--;
                                }
                            break;
                    }
                }
                Console.CursorVisible = false;
                Console.WriteLine();
               end: Console.ReadKey();
        }
    static void Text(int i)//Замена цвета менющки
    {
        if (i == 1)
        {
            Console.Clear();
            Console.WriteLine(texts[0]);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(texts[1]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(texts[2]);
            Console.WriteLine(texts[3]);
            Console.WriteLine(texts[4]);
        }
        if (i == 2)
        {
            Console.Clear();
            Console.WriteLine(texts[0]);
            Console.WriteLine(texts[1]);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(texts[2]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(texts[3]);
            Console.WriteLine(texts[4]);
        }
        if (i == 3)
        {
            Console.Clear();
            Console.WriteLine(texts[0]);
            Console.WriteLine(texts[1]);
            Console.WriteLine(texts[2]);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(texts[3]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(texts[4]);
        }
        if (i == 4)
        {
            Console.Clear();
            Console.WriteLine(texts[0]);
            Console.WriteLine(texts[1]);
            Console.WriteLine(texts[2]);
            Console.WriteLine(texts[3]);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(texts[4]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    static int keys()//работа менюшки
    {
        int num = 0;
        bool flag = false;
        do
        {
            ConsoleKeyInfo keyPushed = Console.ReadKey();
            if (keyPushed.Key == ConsoleKey.DownArrow)
            {
                num++;
                Text(num);
            }
            if (keyPushed.Key == ConsoleKey.UpArrow)
            {
                num--;
                Text(num);
            }
            if (keyPushed.Key == ConsoleKey.Enter)
            {
                flag = true;
            }
            if (num == 0)
            {
                num = 4;
                Text(4);
            }
            if (num == 5)
            {
                num = 1;
                Text(1);
            }
        } while (!flag);
        return num;
    }
}