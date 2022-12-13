Console.WriteLine("Ты ввел число: " + GetNumber());
        

        static int GetNumber()
{
    bool isNumberEntered = false;
    int number = 0;

    while (isNumberEntered == false)
    {
        Console.Clear();
        Console.Write("Введи число: ");

        string imput = Console.ReadLine();

        if (int.TryParse(imput, out number) == true)
        {
            isNumberEntered = true;
        }
    }


    return number;
}