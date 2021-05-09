using System;

namespace _8queens
{
    internal class Program
    {
        private static int nums = 0;
        private static int[] queen = new int[8];

        private static void Main(string[] args)
        {
            DecidePosition(0);
            Console.ReadKey();
        }

        private static int Attack(int row, int col)
        {
            int i = 0, atk = 0;
            int offset_row = 0;
            int offset_col = 0;
            while (atk != 1 && i < col)
            {
                offset_col = Math.Abs(i - col);
                offset_row = Math.Abs(queen[i] - row);
                //判斷是不是在同一列或對角線上
                if ((queen[i] == row) || (offset_row == offset_col))
                {
                    atk = 1;
                }

                i++;
            }

            return atk;
        }

        private static void DecidePosition(int col)
        {
            int row = 0;
            while (row < 8)
            {
                if (Attack(row, col) != 1)
                {
                    queen[col] = row;

                    if (col == 7)
                    {
                        Print();
                    }
                    else
                    {
                        DecidePosition(col + 1);
                    }
                }
                //被攻擊就往下找
                row++;
            }
        }

        private static void Print()
        {
            nums++;
            Console.WriteLine($"solution{nums}");
            for (int i = 0; i < 8; i++)//row
            {
                for (int j = 0; j < 8; j++)//col
                {
                    if (i == queen[j])
                        Console.Write("Q");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------");
        }
    }
}