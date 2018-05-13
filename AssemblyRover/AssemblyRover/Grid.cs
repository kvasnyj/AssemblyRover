using System;
using System.Collections.Generic;

namespace AssemblyRover
{
    public class Grid
    {
        public int Size;

        private int NumberOfComponents { get; }

        private readonly int[,] _data;

        public Grid(int size, IEnumerable<Tuple<int, int>> components)
        {
            Size = size;
            _data = new int[size, size];

            foreach (var component in components)
            {
                _data[component.Item1, component.Item2] = ++NumberOfComponents;
            }
        }

        public int CheckCell(int x, int y)
        {
            return _data[x, y];
        }

        public bool CheckNumberOfComponent(int number)
        {
            return NumberOfComponents == number;
        }
    }
}
