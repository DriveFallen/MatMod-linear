using System;

namespace ConsoleApp1
{
    class Program
    {
        private static void showMat(double[,] actMat)
        {
            for (int i = 0; i < actMat.GetLength(0); i++)
            {
                for (int j = 0; j < actMat.GetLength(1); j++)
                {
                    Console.Write("{0, 8}", Math.Round(actMat[i, j], 2));

                    if (j == actMat.GetLength(1) - 2)
                    {
                        Console.Write("{0, 8}", "|");
                    }
                }
                Console.WriteLine();

                if (i == actMat.GetLength(0) - 2)
                {
                    for (int j = 0; j < actMat.GetLength(1) + 1; j++)
                    {
                        Console.Write("{0, 8}", "-");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        private static bool isAllElRight(double[,] matrix)
        {
            bool cond = false;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[matrix.GetLength(0) - 1, j] > 0)
                {
                    cond = true;
                }
            }
            return cond;
        }

        private static void doFunc(double[,] matrix)
        {
            int k = 0;
            do
            {
                k++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Цикл № " + k);
                Console.ResetColor();

                double[,] changedMat = matrix.Clone() as double[,];

                //Деление
                Console.WriteLine("Деление");
                Console.WriteLine();

                for (int i = 0; i < changedMat.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < changedMat.GetLength(1) - 1; j++)
                    {
                        if (changedMat[changedMat.GetLength(0) - 1, j] > 0)
                        {
                            if (changedMat[i, j] != 0)
                            {
                                changedMat[i, j] = Math.Round(changedMat[i, changedMat.GetLength(1) - 1] / changedMat[i, j], 2);
                            }
                        }
                    }
                }
                showMat(changedMat);

                //Нахождение минимального
                Console.WriteLine("Нахождение минимального и умножение");
                Console.WriteLine();

                for (int j = 0; j < changedMat.GetLength(1) - 1; j++)
                {
                    double min = 99999;
                    for (int i = 0; i < changedMat.GetLength(0) - 1; i++)
                    {
                        double n = changedMat[i, j];
                        if (n > 0)
                        {
                            if (n < min)
                                min = n;
                        }
                    }
                    changedMat[changedMat.GetLength(0) - 1, j] = min * changedMat[matrix.GetLength(0) - 1, j];
                }
                showMat(changedMat);

                //Нахождение максимального
                double max = -99999;
                int needCol = 0;
                for (int j = 0; j < changedMat.GetLength(1) - 1; j++)
                {
                    double n = changedMat[matrix.GetLength(0) - 1, j];
                    if (n != 0)
                    {
                        if (n > max)
                        {
                            max = n;
                            needCol = j;
                        }
                    }
                }

                Console.WriteLine("Нахождение максимального: " + Math.Round(max, 2));
                Console.WriteLine();

                //Нахождение ведущей строки
                int needRow = 0;
                double needMin = 99999;
                for (int i = 0; i < changedMat.GetLength(0) - 1; i++)
                {
                    if (changedMat[i, needCol] > 0)
                    {
                        if (changedMat[i, needCol] < needMin)
                        {
                            needMin = changedMat[i, needCol];
                            needRow = i;
                        }
                    }
                }

                Console.WriteLine("Ведущая строка: " + (needRow + 1));
                double needNum = matrix[needRow, needCol];
                Console.WriteLine("Ведущее число: " + needNum);
                Console.WriteLine();

                //Деление всех элементов на ведущее число
                Console.WriteLine("Подсчет ведущей строки");
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[needRow, j] = Math.Round(matrix[needRow, j] / needNum, 2);
                }
                showMat(matrix);

                //Вычетание всех строк
                Console.WriteLine("Метод вычитания");
                Console.WriteLine();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    double extraNum = matrix[i, needCol];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (i != needRow)
                        {
                            matrix[i, j] = Math.Round(matrix[i, j] - matrix[needRow, j] * extraNum, 2);
                        }
                    }
                }
                showMat(matrix);
            }
            while (isAllElRight(matrix) == true);
        }

        private static void doFunc2(double[,] matrix)
        {
            int k = 0;
            do
            {
                k++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Цикл № " + k);
                Console.ResetColor();

                double[,] changedMat = matrix.Clone() as double[,];

                //Деление
                Console.WriteLine("Деление");
                Console.WriteLine();

                //for (int j = 0; j < changedMat.GetLength(1) - 1; j++) // двигаемся по столбцам
                //{
                //    double lastRowEl = changedMat[changedMat.GetLength(0) - 1, j]

                //    for (int i = 0; i < changedMat.GetLength(0) - 1; i++) // двигаемся по строкам
                //    {
                //        if (changedMat[i,j] > 0)
                //        {
                //            changedMat[i, j] = changedMat.GetLength;
                //        }
                //    }
                //}

                for (int i = 0; i < changedMat.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < changedMat.GetLength(1) - 1; j++)
                    {
                        if (changedMat[changedMat.GetLength(0) - 1, j] > 0)
                        {
                            if (changedMat[i, j] != 0)
                            {
                                changedMat[i, j] = Math.Round(changedMat[i, changedMat.GetLength(1) - 1] / changedMat[i, j], 2);
                            }
                        }
                    }
                }
                showMat(changedMat);

                //Нахождение минимального
                Console.WriteLine("Нахождение минимального и умножение");
                Console.WriteLine();

                for (int j = 0; j < changedMat.GetLength(1) - 1; j++)
                {
                    double min = 99999;
                    for (int i = 0; i < changedMat.GetLength(0) - 1; i++)
                    {
                        double n = changedMat[i, j];
                        if (n > 0)
                        {
                            if (n < min)
                                min = n;
                        }
                    }
                    changedMat[changedMat.GetLength(0) - 1, j] = min * changedMat[matrix.GetLength(0) - 1, j];
                }
                showMat(changedMat);

                //Нахождение максимального
                double max = -99999;
                int needCol = 0;
                for (int j = 0; j < changedMat.GetLength(1) - 1; j++)
                {
                    double n = changedMat[matrix.GetLength(0) - 1, j];
                    if (n != 0)
                    {
                        if (n > max)
                        {
                            max = n;
                            needCol = j;
                        }
                    }
                }

                Console.WriteLine("Нахождение максимального: " + Math.Round(max, 2));
                Console.WriteLine();

                //Нахождение ведущей строки
                int needRow = 0;
                double needMin = 99999;
                for (int i = 0; i < changedMat.GetLength(0) - 1; i++)
                {
                    if (changedMat[i, needCol] > 0)
                    {
                        if (changedMat[i, needCol] < needMin)
                        {
                            needMin = changedMat[i, needCol];
                            needRow = i;
                        }
                    }
                }

                Console.WriteLine("Ведущая строка: " + (needRow + 1));
                double needNum = matrix[needRow, needCol];
                Console.WriteLine("Ведущее число: " + needNum);
                Console.WriteLine();

                //Деление всех элементов на ведущее число
                Console.WriteLine("Подсчет ведущей строки");
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[needRow, j] = Math.Round(matrix[needRow, j] / needNum, 2);
                }
                showMat(matrix);

                //Вычетание всех строк
                Console.WriteLine("Метод вычитания");
                Console.WriteLine();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    double extraNum = matrix[i, needCol];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (i != needRow)
                        {
                            matrix[i, j] = Math.Round(matrix[i, j] - matrix[needRow, j] * extraNum, 2);
                        }
                    }
                }
                showMat(matrix);
            }
            while (isAllElRight(matrix) == true);
        }

        static void Main(string[] args)
        {
            double[,] mat =
            {
                {2.1 , 2.3, 3.2, 1, 0, 0, 1500 },
                {0.09, 0.07, 0.7, 0, 1, 0, 400 },
                {7, 9 , 8, 0, 0, 1, 420 },
                {28, 35, 34, 0, 0, 0, 0 }
            };

            Console.WriteLine("Начальная матрица");
            showMat(mat);
            doFunc2(mat);

            Console.Read();
        }
    }
}