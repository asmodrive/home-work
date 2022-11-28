int sumSecondLine = 1;
int sumNumbers = 0;
int productFirstColumn = 0;
int productNumbers = 1; 
int[,] array = {
    { 1, 5, 3 },
    { 6, 7, 3},
    { 7, 7, 3} };

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
    sumNumbers += array[sumSecondLine,i];
}
Console.WriteLine($"Сумма второй строки равна - {sumNumbers}");

for (int i = 0; i < array.GetLength(0); i++)
{
    productNumbers *= array[i,productFirstColumn];
}
Console.WriteLine($"Произведение первого столбца равно - {productNumbers}");