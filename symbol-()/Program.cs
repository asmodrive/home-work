using static System.Net.Mime.MediaTypeNames;

var text = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13 };
foreach (var symbol in text)
{
    Console.Write($"{symbol} ");
}