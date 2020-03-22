using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Tests
{
    [TestClass()]
    public class RoboticRoverTests
    {
        [TestMethod()]
        public void GenerateRoboticRover()
        {
            //arrange

            var borders = new int[] { 5, 6 };
            var coordinates = new int[] { 1, 2 };
            var direction = 'N';
            var instructions = new List<char>()
            {
                'L','M','L','M','L','M','L','M','M'
            };


            //act
            var roboticRover = new RoboticRover(borders, coordinates, direction, instructions);

            //assert
            Assert.AreEqual(roboticRover.BorderX, borders[0]);
            Assert.AreEqual(roboticRover.BorderY, borders[1]);
            Assert.AreEqual(roboticRover.CoordinateX, coordinates[0]);
            Assert.AreEqual(roboticRover.CoordinateY, coordinates[1]);
            Assert.AreEqual(roboticRover.Direction.ToString()[0], direction);
            //Assert.AreEqual(roboticRover.Instructions, instructions);

        }
    }
}