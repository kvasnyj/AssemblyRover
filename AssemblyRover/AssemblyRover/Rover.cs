using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyRover
{
    public enum Direction
    {
        Longitude,
        Latitude
    };

    public class Rover
    {
        private readonly Grid _grid;
        private int _posX;
        private int _posY;
        private readonly StringBuilder _route;
        private readonly IDictionary<int, Tuple<int, int>> _discoveredComponents;
        private readonly IList<int> _pickedComponents;

        public int NumberOfPickedComponents => _pickedComponents.Count;

        public Rover(Grid grid, int posX, int posY)
        {
            _grid = grid ?? throw new Exception("The grid is null");
            _posX = posX;
            _posY = posY;

            _discoveredComponents = new Dictionary<int, Tuple<int, int>>();
            _pickedComponents = new List<int>();

            _route = new StringBuilder();
        }

        public string Collect()
        {
            GotoStartPosition();
            Traversal();
            PickUpAllDiscoveredComponents();

            return _route.ToString();
        }

        private void Traversal()
        {
            var directionX = _posX == 0 ? 1 : -1;

            for (var i = 0; i < _grid.Size - 1; i++)
            {
                var x = _posX + directionX;
                var y = _posY == 0 ? _grid.Size - 1 : 0;

                GotoTarget(x, y);
            }
        }

        private void GotoStartPosition()
        {
            var startX = _grid.Size / 2 < _posX ? 0 : _grid.Size - 1;
            var startY = _grid.Size / 2 < _posY ? 0 : _grid.Size - 1;

            GotoTarget(startX, startY);
        }

        private void PickUpAllDiscoveredComponents()
        {
            for (var i = _pickedComponents.Count + 1; i <= _discoveredComponents.Count; i++)
            {
                GotoTarget(_discoveredComponents[i].Item1, _discoveredComponents[i].Item2);
            }
            Observe();
        }

        private void GotoTarget(int x, int y)
        {
            GotoOneCoordinate(x, _posX, Direction.Longitude);
            GotoOneCoordinate(y, _posY, Direction.Latitude);
        }

        private void GotoOneCoordinate(int targetCoordinate, int roverCoordinate, Direction direction)
        {
            var sign = Math.Sign(targetCoordinate - roverCoordinate);
            if (sign == 0) return; // Same coordinates

            if (direction == Direction.Longitude)
            {
                for (_posX = roverCoordinate; _posX != targetCoordinate; _posX += sign)
                {
                    Observe();
                    _route.Append(sign > 0 ? 'E' : 'W');
                }
            }
            else
            {
                for (_posY = roverCoordinate; _posY != targetCoordinate; _posY += sign)
                {
                    Observe();
                    _route.Append(sign > 0 ? 'N' : 'S');
                }
            }
        }

        private void Observe()
        {
            var component = _grid.CheckCell(_posX, _posY);

            if (component == 0)
            {
                return;
            }

            if (!_discoveredComponents.ContainsKey(component))
            {
                _discoveredComponents.Add(component, new Tuple<int, int>(_posX, _posY));
            }

            if (component == _pickedComponents.Count + 1)
            {
                _pickedComponents.Add(component);
                _route.Append("P");
            }
        }
    }
}