using System.Collections.Generic;

namespace MarsRover
{
    public partial class RoboticRover
    {
        //X coordinate of upperRight
        public int BorderX { get; set; }

        //Y coordinate of upperRight
        public int BorderY { get; set; }

        //X Coordinate of the RoboticRover
        public int CoordinateX { get; set; }

        //Y Coordinate of the RoboticRover
        public int CoordinateY { get; set; }

        //Direction of the RoboticRover
        public IDirection Direction { get; set; }

        //Instructions given to the RoboticRover
        public List<char> Instructions { get; set; }

        public RoboticRover()
        {

        }

        public RoboticRover(int[] borders, int[] coordinates, 
            char direction, List<char> instructions)
        {
            SetBorders(borders);
            SetRoverPosition(coordinates);
            SetDirection(direction);
            SetInstructions(instructions);
        }

        private void SetBorders(int[] borders)
        {
            BorderX = borders[0];
            BorderY = borders[1];
        }

        private void SetRoverPosition(int[] coordinates)
        {
            CoordinateX = coordinates[0];
            CoordinateY = coordinates[1];
        }

        private void SetDirection(char direction)
        {
            switch (direction)
            {
                case 'N':
                    Direction = IDirection.North;
                    break;
                case 'E':
                    Direction = IDirection.East;
                    break;
                case 'W':
                    Direction = IDirection.West;
                    break;
                case 'S':
                    Direction = IDirection.South;
                    break;
                default:
                    break;
            }
        }

        private void SetInstructions(List<char> _ins)
        {
            Instructions = _ins;
        }

        public void ReadInstructions()
        {
            foreach (var inst in Instructions)
            {
                switch (inst)
                {
                    case 'M':
                        Move();
                        break;
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                    default: //Invalid Instruction
                        break;
                }
            }
        }

        public string DeclareFinalDestination()
        {
            return $"{CoordinateX} {CoordinateY} {Direction.ToString()[0]}";
        }
    }
}
