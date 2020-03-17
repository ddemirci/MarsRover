namespace MarsRover
{
    //Movement part of RoboticRover
    public partial class RoboticRover
    {
        public void Move()
        {
            if (!CanMove()) return;
            switch (Direction)
            {
                case IDirection.East:
                    MoveRight();
                    break;
                case IDirection.West:
                    MoveLeft();
                    break;
                case IDirection.South:
                    MoveBackward();
                    break;
                case IDirection.North:
                    MoveForward();
                    break;
                default:
                    break;
            }
        }

        //Checks that if the robot tries to pass the borders or not
        private bool CanMove()
        {
            if (Direction == IDirection.North && CoordinateY == BorderY) return false;
            else if (Direction == IDirection.South && CoordinateY == 0) return false;
            else if (Direction == IDirection.West && CoordinateX == 0) return false;
            else if (Direction == IDirection.East && CoordinateX == BorderX) return false;
            else return true;
        }

        private void MoveForward()
        {
            CoordinateY++;
        }

        private void MoveBackward()
        {
            CoordinateY--;
        }

        private void MoveLeft()
        {
            CoordinateX--;
        }

        private void MoveRight()
        {
            CoordinateX++;
        }

        private void RotateLeft()
        {
            switch (Direction)
            {
                case IDirection.East:
                    Direction = IDirection.North;
                    break;
                case IDirection.South:
                    Direction = IDirection.East;
                    break;
                case IDirection.West:
                    Direction = IDirection.South;
                    break;
                case IDirection.North:
                    Direction = IDirection.West;
                    break;
                default:
                    break;
            }
        }

        private void RotateRight()
        {
            switch (Direction)
            {
                case IDirection.North:
                    Direction = IDirection.East;
                    break;
                case IDirection.East:
                    Direction = IDirection.South;
                    break;
                case IDirection.South:
                    Direction = IDirection.West;
                    break;
                case IDirection.West:
                    Direction = IDirection.North;
                    break;
                default:
                    break;
            }
        }
    }
}
