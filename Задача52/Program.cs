// задача 52
Console.Clear();
string rowsValue = GetValue("Введите количество строк массива:");
string columnsValue = GetValue("Введите количество столбцов массива:");
bool isRowsValid = IsNumberInt(rowsValue);
bool isColumnsValid = IsNumberInt(columnsValue);

if (isRowsValid && isColumnsValid)
{
    int n = int.Parse(rowsValue);
    int m = int.Parse(columnsValue);
    bool isNValid = IsNumberValid(n);
    bool isMValid = IsNumberValid(m);

    if (isNValid && isMValid)
    {
        int[,] myArray = CreateMatrix(n, m, -200, 200);
        PrintMatrix(myArray);
        double[] arithMean = GetArithmeticMean(myArray);
        Console.WriteLine();
        PrintArray(arithMean);
    }
    else
    {
        Console.WriteLine("Ошибка. Введите число больше 0");
    }
}
else
{
    Console.WriteLine("Неверные данные");
}

// Метод для считывания строки
string GetValue(string message)
{
    Console.WriteLine(message);
    string value = Console.ReadLine();
    return value;
}

//Метод для проверки числа int
bool IsNumberInt(string valueB)
{
    int Exp2;
    bool IsIntNum = Int32.TryParse(valueB, out Exp2);
    if (IsIntNum)
        return true;
    return false;
}

//Метод для проверки числа
bool IsNumberValid(int num)
{
    if (num > 0)
        return true;
    return false;
}

// Метод для создания двумерного массива, заполненного рандомно
int[,] CreateMatrix(int rows, int columns, int min, int max)
{
    int[,] aMatrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            aMatrix[i, j] = new Random().Next(min, max);
        }
    }
    return aMatrix;
}

// Метод для печати двумерного массива
void PrintMatrix(int[,] bMatrix)

{
    for (int i = 0; i < bMatrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < bMatrix.GetLength(1); j++)
        {
            Console.Write($"{string.Format("{0,5} ", bMatrix[i, j])}|");
        }
        Console.WriteLine();
    }
}

//Метод для расчета среднего арифметического для каждого столбца
double[] GetArithmeticMean(int[,] matrix)
{
    double[] result = new double[matrix.GetLength(1)];

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            result[j] += matrix[i,j]; 
        }
        result[j] = Math.Round(result[j]*1.0/matrix.GetLength(0),2);
    }
    return result;
}

//Метод для вывода массива
void PrintArray(double[] arr)
{
    Console.Write("[ ");
    for (int i = 0; i < arr.Length - 1; i++)
    {
        Console.Write(arr[i] + " | ");
    }
    Console.Write(arr[arr.Length - 1] + " ]");
}