using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class NasaInput
    {
        public int XBorder { get; set; }
        public int YBorder { get; set; }
        public List<RoverInput> RoverInputList { get; set; }
    }

    public class RoverInput
    {
        public int Cx { get; set; }
        public int Cy { get; set; }
        public char Direction { get; set; }
        public string Instructions { get; set; }

        public RoverInput()
        {

        }

        public RoverInput(string position, string instructions)
        {
            SetRobotPosition(position);
            Instructions = instructions;
        }

        private void SetRobotPosition(string position)
        {
            var coordinates = position.Split(' ');
            Cx = Convert.ToInt32(coordinates[0]);
            Cy = Convert.ToInt32(coordinates[1]);
            Direction = Convert.ToChar(coordinates[2]);
        }
    }
}
