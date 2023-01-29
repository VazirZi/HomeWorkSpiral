public static class Quantity
{
    public static int EnterNumber(string str)       // ввод значений в консоли
    {
        Console.Write(str);
        int number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        return number;
    }
    public static int[ , ] InitializeArray(int str, int column) // инициализация двумерного массива
    {
        int[ , ] array = new int[str, column];
        return array;
    }

    public static void FillArray(int[ , ] array)   // заполнение двумерного массива случайными числами
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = new Random().Next(1, 10);
            }
        }
    }

    public static void PrintArray(int[ , ] array)   // вывод двумерного массива в консоль
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(string.Format("{0, 5}", array[i, j]));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void ArrangeTheArrayByRowsInDescendingOrder (int[ , ] array)  // сортировка элементов каждой строки в порядке убывания
    {
        int k = 0;
        int temp = 0;

        while (k < array.GetLength(1))
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (array[i, j] < array[i, j + 1])
                    {
                        temp = array[i, j];
                        array[i, j] = array[i, j + 1];
                        array[i, j + 1] = temp;
                    }
                }
            }
            k++;
        }
    }

    private static void WriteSumOfEachRowInArray(int[ , ] array, int[] newArray)    // запись суммы элементов строки в новый массив
    {
        
        int sum = 0;

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                sum += array[i, j];
            }

            newArray[i] = sum;
            sum = 0;
        }
    }

    public static void FindRowWithSmallestSumOfElements(int[ , ] array)     // нахождение индекса строки с минимальной суммой элементов
    {
        int[] newArray = new int[array.GetLength(0)];

        WriteSumOfEachRowInArray(array, newArray);

        int min = newArray[0];
        int minIndex = 0;

        for (int i = 0; i < newArray.Length - 1; i++)
        {
            if (min > newArray[i + 1])
            {
                min = newArray[i + 1];
                minIndex = i + 1; 
            }
        }

        Console.WriteLine($"Наименьшая сумма элементов в строке с индексом {minIndex}\n");
    }

    public static void FindSumOfMatrix(int[ , ] matrix1, int[ , ] matrix2)      // нахождение произведения матриц
    {
        int[ , ] sumMatrix = new int [matrix1.GetLength(0), matrix2.GetLength(1)];

        for (int i = 0; i < sumMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < sumMatrix.GetLength(1); j++)
            {
                for (int k = 0; k < sumMatrix.GetLength(0); k++)
                {
                    sumMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        PrintArray(sumMatrix);
    }

    private static void FillUp(int[ , ] array, int number, int str, int column, int stopRight, int stopDown, int stopLeft, int stopUp)  // заполнение вверх
    {
        for (int i = str; i >= stopUp; i--)
        {
            array[i, column] = number;
            number++;
        }

        str = stopUp;
        stopUp++;
        column = stopLeft;

        if (number <= (array.GetLength(0) * array.GetLength(1)))
        {
            FillArraySpirally(array, number, str, column, stopRight, stopDown, stopLeft, stopUp);
        }
        else 
        {
            PrintArray(array);
            return;
        }
    } 

    private static void FillLeft(int[ , ] array, int number, int str, int column, int stopRight, int stopDown, int stopLeft, int stopUp)    // заполнение влево
    {
        for (int j = column; j >= stopLeft; j--)
        {
            array[str, j] = number;
            number++;
        }

        column = stopLeft;
        stopLeft++;
        str = stopDown - 1;

        if (number <= (array.GetLength(0) * array.GetLength(1)))
        {
            FillUp(array, number, str, column, stopRight, stopDown, stopLeft, stopUp);
        }
        else 
        {
            PrintArray(array);
            return;
        }
    }

    private static void FillDown(int[ , ] array, int number, int str, int column, int stopRight, int stopDown, int stopLeft, int stopUp)    // заполнение вниз
    {
        for (int i = str; i < stopDown; i++)
        {
            array[i, column] = number;
            number++;
        }

        stopDown--;
        str = stopDown;
        column = stopRight - 1;

        if (number <= (array.GetLength(0) * array.GetLength(1)))
        {
            FillLeft(array, number, str, column, stopRight, stopDown, stopLeft, stopUp);
        } 
        else 
        {
            PrintArray(array);
            return;
        }
    }
    public static void FillArraySpirally(int[ , ] array, int number, int str, int column, int stopRight, int stopDown, int stopLeft, int stopUp)    // заполнение вправо
    {      
        for (int j = column; j < stopRight; j++)
        {
            array[str, j] = number;
            number++;
        }

        stopRight--;
        column = stopRight;
        str = stopUp;

        if (number <= (array.GetLength(0) * array.GetLength(1)))
        {
            FillDown(array, number, str, column, stopRight, stopDown, stopLeft, stopUp);
        }
        else 
        {
            PrintArray(array);
            return;
        }
    }
    
}