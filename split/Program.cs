string textLine = "You win some. You lose some.";
string[] subString = textLine.Split(' ');

foreach (string sub in subString)
{
    Console.WriteLine($"Substring: {sub}");
}