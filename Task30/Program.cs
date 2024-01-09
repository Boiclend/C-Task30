// Дана квадратная матрица размером nxn. Найти минимальный элемент среди элементов, 
// расположенных ниже главной диагонали, найти максимальный элемент, среди элементов расположенных выше побочной диагонали.
// Найденные минимальный и максимальный элементы поменять местами и вывести их индексы.

using System.ComponentModel.DataAnnotations;

int Message(string text) { 
    Console.WriteLine(text);
    int num = int.Parse(Console.ReadLine());
    return num;
}

int[,] FillArray(int r, int c) // заполнение матрицы
{
    Random rnd = new Random();
    int[,] arr = new int[r,c];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i,j] = rnd.Next(-1,10);
        }
    }
    return arr;
}

void PrintArray(int[,] arr) { // печать матрицы
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(String.Format("{0,3}", arr[i, j])); // красивый вывод матрицы
        }
        Console.WriteLine();
    }
}

int findSizeForMainDiagonalNumbers(int[,] arr) {
    int count = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if(j < i) 
            {
                count++;
            }
        }
    }
    return count;
}

int findSizeForSideDiagonalNumbers(int[,] arr) {
    int count = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if(j > i) 
            {
                count++;
            }
        }
    }
    return count;
}

int findMinElemLowerThenMainDiag(int[,] arr, ref int indexMinI, ref int indexMinJ) {
    int min = 0;
    int count = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if(j < i) 
            {
                if(count == 0)
                {
                    min = arr[i,j];
                    count++;
                    indexMinI = i;
                    indexMinJ = j;
                }
                if (min > arr[i,j]) 
                {
                    min = arr[i,j];
                    indexMinI = i;
                    indexMinJ = j;
                }
            }
        }
    }
    Console.WriteLine($"Минимальный элемент ниже главной диагонали равен = {min} и находится под индексом {indexMinI},{indexMinJ} ");
    return min;
}

int findMaxElemUpperWhenSideDiag(int[,] arr, ref int indexMaxI, ref int indexMaxJ) 
{
    int max = 0;
    for (int i = 0; i < arr.GetLength(0) - 1; i++) 
    {
        for (int j = 0; j < arr.GetLength(1) - i - 1; j++) 
        {
                if (max < arr[i,j]) 
                {
                    max = arr[i,j];
                    indexMaxI = i;
                    indexMaxJ = j;
                } 
        }    
    }
    Console.WriteLine($"Максимальный элемент выше побочной диагонали равен = {max} и находится под индексом {indexMaxI},{indexMaxJ} ");
    return max;
}

void ChangeNumbers(int[,] arr,int indexMinI,int indexMinJ, int indexMaxI,int indexMaxJ)
{
    int temp = arr[indexMaxI,indexMaxJ];
    arr[indexMaxI,indexMaxJ] = arr[indexMinI,indexMinJ];
    arr[indexMinI,indexMinJ] = temp;

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(String.Format("{0,3}", arr[i, j])); // красивый вывод матрицы
        }
        Console.WriteLine();
    }

}
int rows = Message("Введите количество строк");
int columns = Message("Введите количество столбцов");
int[,] MyArray = FillArray(rows,columns);
Console.WriteLine();
PrintArray(MyArray);
Console.WriteLine();
int p1 = 0;
int p2 = 0;
int p3 = 0;
int p4 = 0;
int min = findMinElemLowerThenMainDiag(MyArray,ref p1, ref p2);
int max = findMaxElemUpperWhenSideDiag(MyArray,ref p3, ref p4);
Console.WriteLine();
Console.WriteLine("Элементы поменяны местами:");
ChangeNumbers(MyArray,p1,p2,p3,p4);
