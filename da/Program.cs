namespace da
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как вас зовут?");
            int name = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько вам лет?");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Где вы работаете?");
            string job = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}, вам {age} лет, вы работаете на {job}");

        }
    }
}