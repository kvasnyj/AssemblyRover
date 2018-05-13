using System;

namespace AssemblyRover
{
    public static class ReadHelper
    {
        public static int ReadInt(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        public static Tuple<int, int> ReadTuple(string message)
        {
            Console.WriteLine(message);
            return StringToIntTuple(Console.ReadLine());
        }

        public static Tuple<int, int> StringToIntTuple(string input)
        {
            var stringArray = input.Split(' ');
            var intArray = Array.ConvertAll(stringArray, int.Parse);
            return new Tuple<int, int>(intArray[0], intArray[1]);
        }
    }
}
