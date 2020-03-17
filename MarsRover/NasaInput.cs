using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class NasaInput
    {
        public int XBorder { get; set; }
        public int YBorder { get; set; }
        public List<RoverInput> RoverInputList { get; set; }

        public NasaInput(){}

        public NasaInput(int xBorder, int yBorder, 
            List<RoverInput> roverInputList)
        {
            XBorder = xBorder;
            YBorder = yBorder;
            RoverInputList = roverInputList;
        }
    }
}
