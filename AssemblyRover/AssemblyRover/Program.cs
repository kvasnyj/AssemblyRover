using System;
using System.Collections.Generic;

namespace AssemblyRover
{
    internal class Program
    {
        private static void Main()
        {
            var grid = ReadGridData();
            var roverPosition = ReadRoverData(grid.GridSize);

            var rover = new Rover(grid, roverPosition);
            var route = rover.PickUpAllComponents();

            Console.WriteLine("The route is: " + route);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            // TODO The rover can only detect a component if the rover and the component share the same grid oordinates.
        }

        private static Tuple<int, int> ReadRoverData(int gridSize)
        {
            var roverPosition = ReadHelper.ReadTuple("Enter the starting position of the rover:");
            ValidateCoordinates(roverPosition, gridSize);
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
                ValidateCoordinates(component, gridSize);
                components.Add(component);
            }

            return new Grid
            {
                GridSize = gridSize,
                Components = components
            };
        }

        private static void ValidateCoordinates(Tuple<int, int> coordinates, int gridSize)
        {
            if (coordinates == null) throw new ArgumentNullException(nameof(coordinates));
            if (coordinates.Item1 < 0 || coordinates.Item1 >= gridSize) throw new Exception("Invalide first coordinate");
            if (coordinates.Item2 < 0 || coordinates.Item2 >= gridSize) throw new Exception("Invalide second coordinate");
        }
    }
}
