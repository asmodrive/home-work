int minBoarder = 2;
int maxBoarder = 3000;
int degree = 0;
int baseNumber = 2;
int foundNumber = 1;
Random random = new Random();
int randomNumber = random.Next(minBoarder, maxBoarder);

while (randomNumber >= foundNumber)
{
    Console.WriteLine($"{randomNumber} >= {foundNumber}");
    foundNumber *= baseNumber;
    degree++;
}

Console.WriteLine($"{foundNumber} > {randomNumber}, где {foundNumber} это {baseNumber} в степени {degree}");