using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyRover.Tests
{
    [TestClass]
    public class RoverTest
    {
        private static int NumberOfPickup(string route)
        {
            return route.Count(c => c.Equals('P'));
        }

        [TestMethod]
        public void Figure1()
        {
            var grid = new Grid
            (
                2,
                new List<Tuple<int, int>>
                {
                    new Tuple<int, int> (1, 1),
                    new Tuple<int, int> (0, 0)
                }
            );

            var rover = new Rover(grid, 1, 0);
            var route = rover.Collect();

            //TODO Compare not only count but coordinates also.
            Assert.IsTrue(grid.CheckNumberOfComponent(rover.NumberOfPickedComponents));
            Assert.AreEqual(NumberOfPickup(route), rover.NumberOfPickedComponents);
        }

        [TestMethod]
        public void Figure2()
        {
            var grid = new Grid
            (
                3,
                new List<Tuple<int, int>>
                {
                    new Tuple<int, int>(1, 1),
                    new Tuple<int, int>(0, 1)
                }
            );

            var rover = new Rover(grid, 0, 2);
            var route = rover.Collect();

            Assert.IsTrue(grid.CheckNumberOfComponent(rover.NumberOfPickedComponents));
            Assert.AreEqual(NumberOfPickup(route), rover.NumberOfPickedComponents);
        }

        [TestMethod]
        public void Figure3()
        {
            var grid = new Grid
            (
                4,
                new List<Tuple<int, int>>
                {
                    new Tuple<int, int> (1, 0),
                    new Tuple<int, int> (2, 2),
                    new Tuple<int, int> (0, 3)
                }
            );

            var rover = new Rover(grid, 1, 1);
            var route = rover.Collect();

            Assert.IsTrue(grid.CheckNumberOfComponent(rover.NumberOfPickedComponents));
            Assert.AreEqual(NumberOfPickup(route), rover.NumberOfPickedComponents);
        }

        [TestMethod]
        public void Figure4()
        {
            var grid = new Grid
            (
                8,
                new List<Tuple<int, int>>
                {
                    new Tuple<int, int> (5, 4),
                    new Tuple<int, int> (6, 6),
                    new Tuple<int, int> (1, 0),
                    new Tuple<int, int> (0, 5),
                    new Tuple<int, int> (5, 1)
                }
            );

            var rover = new Rover(grid, 4, 6);
            var route = rover.Collect();

            Assert.IsTrue(grid.CheckNumberOfComponent(rover.NumberOfPickedComponents));
            Assert.AreEqual(NumberOfPickup(route), rover.NumberOfPickedComponents);
        }
    }
}
