﻿using System;
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
            List<string> value  = new List<string>();

            value.AddRange(new string[] { "1", "2", "1" });
            value.AddRange(new string[] { "3", "2" });
            value.Remove("2");

            for (int i = 0; i < value.Count; i++)
            {
                Console.WriteLine(value[i]);
            }
        }
    }
}