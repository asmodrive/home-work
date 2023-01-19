using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dabydi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers  = new List<string>();

            numbers.AddRange(new string[] { "1", "2", "1" });
            numbers.AddRange(new string[] { "3", "2" });
            numbers.Remove("2");

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}