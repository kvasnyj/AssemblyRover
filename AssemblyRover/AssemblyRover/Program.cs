using System;
using System.Collections.Generic;

namespace AssemblyRover
{
    internal class Program
    {
        private static void Main()
        {
            var grid = ReadGridData();
            var roverPosition = ReadRoverData();

            var rover = new Rover(grid, roverPosition.Item1, roverPosition.Item2);
            var route = rover.Collect();

            Console.WriteLine($"The route is: {route}");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            //TODO From the description not clear is GridSize and number of components available for a rover or not.
            //TODO I assume GridSize as public and NumberOfPickedComponents as private.
            //TODO I also assume a cost of observation as 0. 
            //TODO And from the description not clear should I apply SOLID principles or not.
        }

        private static Tuple<int, int> ReadRoverData()
        {
            var roverPosition = ReadHelper.ReadTuple("Enter the starting position of the rover:");
            return roverPosition;
        }

        private static Grid ReadGridData()
        {
            var gridSize = ReadHelper.ReadInt("Enter the grid size:");

            var numberOfComponents = ReadHelper.ReadInt("Enter the number of components:");
            var components = new List<Tuple<int, int>>(numberOfComponents);

            for (var i = 0; i < numberOfComponents; i++)
            {
                var component = ReadHelper.ReadTuple($"Enter two coordinaties of component #{i}, separate by space:");
                components.Add(component);
            }

            return new Grid(gridSize, components);
        }
    }
}
