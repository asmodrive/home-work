int minBoarder = 2;
int maxBoarder = 30000;
int randomSeed = 1938;
int degree = 0;
int baseNumber = 2;
var baseInDegree = MathF.Pow(baseNumber, degree);
Random random = new Random(randomSeed);
var number = random.Next(minBoarder, maxBoarder);
Console.WriteLine(number);

while (number > baseInDegree)
{
   degree++;
   baseInDegree = MathF.Pow(baseNumber, degree);
}

Console.WriteLine($"Число = {number},\nстепень основного числа {baseNumber} = {degree}, \nосновное число в степени = {baseInDegree}.");