using System;

namespace FileStreamTest
{
    internal class Program
    {

        private static bool isOnPlay = true, isX_Turn = true;
        private static int score;
        
        public static void Main()
        {
            int[,] table = new int[3,3];
            while (isOnPlay)
            {
                Console.Clear();
                Show(table);
                table = Сhoosing(table);
                WinChecker(table);
            }
            Console.WriteLine("Press any key to restart...");
            Console.ReadKey();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    table[i, j] = 0;
                }
            }
            isOnPlay = true;
            score = 0;
            Main();
        }

        private static void WinChecker(int[,] table)
        {
            char WhoWin = '0';
            
            int xDia1 = 0, oDia1 = 0;
            int xDia2 = 0, oDia2 = 0;
            for (int i = 0; i < 3; i++)
            {
                switch (table[i,i])
                {
                    case 1:
                        xDia1++;
                        break;
                    case 2:
                        oDia1++;
                        break;
                }
                switch (table[i,2-i])
                {
                    case 1:
                        xDia2++;
                        break;
                    case 2:
                        oDia2++;
                        break;
                }
                int xRow = 0, oRow = 0, xCol = 0, oCol = 0;
                for (int j = 0; j < 3; j++)
                {
                    switch (table[i,j])
                    {
                        case 1:
                            xRow++;
                            break;
                        case 2:
                            oRow++;
                            break;
                    }
                    switch (table[j,i])
                    {
                        case 1:
                            xCol++;
                            break;
                        case 2:
                            oCol++;
                            break;
                    }
                }
                if ((xRow == 3 || xCol == 3)||(xRow == 3 && xCol == 3)||(xDia1 == 3 || xDia2 == 3)||(xDia1 == 3 && xDia2 == 3))
                {
                    WhoWin = 'X';
                }
                if ((oRow == 3 || oCol == 3)||(oRow == 3 && oCol == 3)||(oDia1 == 3 || oDia2 == 3)||(oDia1 == 3 && oDia2 == 3))
                {
                    WhoWin = 'O';
                }
                if (score >= 9)
                {
                    WhoWin = '-';
                }
            }
            
            switch (WhoWin)
            {
                case 'X':
                    Console.WriteLine("X win!");
                    isOnPlay = false;
                    break;
                case 'O':
                    Console.WriteLine("O win!");
                    isOnPlay = false;
                    break;
                case '-':
                    Console.WriteLine("Dead heat!");
                    isOnPlay = false;
                    break;
            }
        }

        private static int[,] Сhoosing(int[,] table)
        {
            int whatsNow = isX_Turn ? 1 : 2;
            Console.Write("Select row: ");
            string Row = Console.ReadLine();
            Console.Write("Select col: ");
            string Col = Console.ReadLine();
            int row, col;
            bool Rsuc = int.TryParse(Row, out row);
            bool Csuc = int.TryParse(Col, out col);
            if (Rsuc && Csuc)
            {
                row--;
                col--;
                Console.WriteLine();
                if (row >= 0 && row < 3 && col >= 0 && col < 3)
                {
                    if (table[row, col] == 0)
                    {
                        table[row, col] = whatsNow;
                        isX_Turn = !isX_Turn;
                        score++;
                        return table;
                    }
                }
            }
            return table;
        }

        private static void Show(int[,] table)
        {
            char xorO = isX_Turn ? 'X' : 'O';
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int x = table[i, j];
                    switch (x)
                    {
                        case 1:
                            Console.Write("X\t");
                            break;
                        case 2:
                            Console.Write("O\t");
                            break;
                        default:
                            Console.Write("-\t");
                            break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Now is " + xorO + " player turn.");
        }
    }
}