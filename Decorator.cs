using System;
using System.IO;

namespace CurrentTask
{
    class Program
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("data.txt");
            string str = reader.ReadLine();
            Console.WriteLine(str);

        }
    }
}

