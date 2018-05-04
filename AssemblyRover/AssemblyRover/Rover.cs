using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyRover
{
    public class Rover
    {
        private Tuple<int, int> position;
        private readonly Grid grid;

        public Rover(Grid grid, Tuple<int, int> position) 
        {
            this.grid = grid ?? throw new Exception("The grid is null");
            this.position = position ?? throw new Exception("The rover position is null");
        }

        public string PickUpAllComponents()
        {
            var route = new StringBuilder();
            for (var i = 0; i < this.grid.Components.Count; i++)
            {
                var component = this.grid.Components[i];
                route.Append(PickUpOneComponent(component));
                this.position = component;
            }

            return route.ToString();
        }

        private string PickUpOneComponent(Tuple<int, int> component)
        {
            var routeLongitude = RichOneCoordinate(component.Item1, this.position.Item1, 'E', 'W');
            var routeLatitude = RichOneCoordinate(component.Item2, this.position.Item2, 'N', 'S');
            return routeLongitude + routeLatitude + "P";
        }

        private static string RichOneCoordinate(int componentCoordinate, int roverCoordinate, char decrease, char increase)
        {
            var diff = componentCoordinate - roverCoordinate;
            if (diff == 0) return "";
            var direction = diff > 0 ? decrease : increase;
            return new string(direction, Math.Abs(diff));
        }
    }
}
