using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dabydi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = new string[5];
            string[] secondArray = new string[7];
            firstArray = FillArray(firstArray);
            ShowArray(firstArray);
            Console.WriteLine();
            secondArray = FillArray(secondArray);
            ShowArray(secondArray);
            Console.WriteLine();

            List<string> numbers = new List<string>();

            SelectUniqueNumber(numbers, firstArray);
            SelectUniqueNumber(numbers, secondArray);

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }

        static void SelectUniqueNumber(List<string> numbers, string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (numbers.Contains(array[i]) == false)
                {
                    numbers.Add(array[i]);
                }
            }
        }

        static string[] FillArray (string[] array)
        {
            int minValue = 0;
            int maxValue = 10;
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToString(random.Next(minValue, maxValue));
            }
            return array;
        }

        static void ShowArray (string[] array)
        {
            for (int i =0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}