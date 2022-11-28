int sumOfLine = 1;
int sumNumbers = 0;
int productCollumn = 0;
int productNumbers = 1;
int rowCount = 5;
int collumnCount = 5;
Random random = new Random();
int[,] array = new int[rowCount, collumnCount];

for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < collumnCount; j++)
    {
        array[i, j] = random.Next(0, 20);
    }
}

for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        Console.Write(array[i, j]);
    }

    Console.WriteLine();
}

for (int i = 0; i < array.GetLength(1); i++)
{
    sumNumbers += array[sumOfLine, i];
}

Console.WriteLine($"Сумма второй строки равна - {sumNumbers}");

for (int i = 0; i < array.GetLength(0); i++)
{
    productNumbers *= array[i,productCollumn];
}
Console.WriteLine($"Произведение первого столбца равно - {productNumbers}");