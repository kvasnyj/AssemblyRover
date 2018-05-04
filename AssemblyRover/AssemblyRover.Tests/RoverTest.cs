using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyRover.Tests
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void Figure1()
        {
            var grid = new Grid
            {
                GridSize = 2,
                Components = new List<Tuple<int, int>>
                {
                    new Tuple<int, int> (1, 1),
                    new Tuple<int, int> (0, 0)
                }
            };

            var rover = new Rover(grid, new Tuple<int, int>(1, 0));
            var route = rover.PickUpAllComponents();

            Assert.AreEqual(route, "NPWSP");
        }

        [TestMethod]
        public void Figure2()
        {
            var grid = new Grid
            {
                GridSize = 3,
                Components = new List<Tuple<int, int>>
                {
                    new Tuple<int, int> (1, 1),
                    new Tuple<int, int> (0, 1)
                }
            };

            var rover = new Rover(grid, new Tuple<int, int>(0, 2));
            var route = rover.PickUpAllComponents();

            Assert.AreEqual(route, "ESPWP");
        }

        [TestMethod]
        public void Figure3()
        {
            var grid = new Grid
            {
                GridSize = 4,
                Components = new List<Tuple<int, int>>
                {
                    new Tuple<int, int> (1, 0),
                    new Tuple<int, int> (2, 2),
                    new Tuple<int, int> (0, 3)
                }
            };

            var rover = new Rover(grid, new Tuple<int, int>(1, 1));
            var route = rover.PickUpAllComponents();

            Assert.AreEqual(route, "SPENNPWWNP");
        }

        [TestMethod]
        public void Figure4()
        {
            var grid = new Grid
            {
                GridSize = 8,
                Components = new List<Tuple<int, int>>
                {
                    new Tuple<int, int> (5, 4),
                    new Tuple<int, int> (6, 6),
                    new Tuple<int, int> (1, 0),
                    new Tuple<int, int> (0, 5),
                    new Tuple<int, int> (5, 1)
                }
            };

            var rover = new Rover(grid, new Tuple<int, int>(4, 6));
            var route = rover.PickUpAllComponents();

            Assert.AreEqual(route, "ESSPENNPWWWWWSSSSSSPWNNNNNPEEEEESSSSP");
        }
    }
}
