namespace MyApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Задача 1. Задайте двумерный массив. Напишите программу, которая упорядочит 
            // по убыванию элементы каждой строки двумерного массива.

            Console.Clear();

            int n = Quantity.EnterNumber("Введите количество строк: ");
            int m = Quantity.EnterNumber("Введите количество столбцов: ");

            int[ , ] array = Quantity.InitializeArray(n, m);

            Quantity.FillArray(array);

            Console.WriteLine("Исходный массив");
            Quantity.PrintArray(array);

            Quantity.ArrangeTheArrayByRowsInDescendingOrder(array);

            Console.WriteLine("Массив с отсортированными элементами в каждой строке (в порядке убывания)");
            Quantity.PrintArray(array);

            // Задача 2.  Задайте прямоугольный двумерный массив. Напишите программу, 
            // которая будет находить строку с наименьшей суммой элементов.

            // (будем использовать уже созданный массив с отсортированными элементами в каждой строке)
            
            Quantity.FindRowWithSmallestSumOfElements(array);

            // Задача 3. Задайте две матрицы. Напишите программу, 
            // которая будет находить произведение двух матриц.

            int[ , ] matrix1 = {
                                {2, 4},
                                {3, 2}
                                };
            int[ , ] matrix2 = {
                                {3, 4},
                                {3, 3}
                                };
            
            Console.WriteLine("Матрица 1");
            Quantity.PrintArray(matrix1);

            Console.WriteLine("Матрица 2");
            Quantity.PrintArray(matrix2);

            Console.WriteLine("Произведение матриц");
            Quantity.FindSumOfMatrix(matrix1, matrix2);

            // Задача 4. Сформируйте трёхмерный массив из неповторяющихся 
            // двузначных чисел. Напишите программу, которая будет построчно 
            // выводить массив, добавляя индексы каждого элемента.

            int[ , , ] array2 = 
            {
                {
                    {2, 3},
                    {3, 4}
                },

                {
                    {7, 1},
                    {8, 1}
                }
            };

            for (int i = 0; i < array2.GetLength(0); i++)
            {
                for (int j = 0; j < array2.GetLength(1); j++)
                {
                    for (int k = 0; k < array2.GetLength(2); k++)
                    {
                        Console.Write(string.Format("{0, 4}", array2[i, j, k] + $"({i} {j} {k}) "));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            // Задача 5. Напишите программу, которая заполнит спирально массив 4 на 4.

            int[ , ] array3 = new int [4, 4];
            
            int number = 1;
            int str = 0;
            int column = 0;

            int stopRight = array3.GetLength(0);
            int stopDown = array3.GetLength(1);
            int stopLeft = 0;
            int stopUp = 1;

            Quantity.FillArraySpirally(array3, number, str, column, stopRight, stopDown, stopLeft, stopUp);
        }
    }
}