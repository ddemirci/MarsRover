using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Program
    {
        private const string NasaInputPath = @"C:\NASAInput.txt";
        public static void Main(string[] args)
        {
            try
            {
                //First read input file
                var inputLines = System.IO.File.ReadAllLines(NasaInputPath);
                if (inputLines == null || inputLines.Length == 0) return;

                //Parsing the inputLines
                var nasaInput = ParseInputFileArray(inputLines);
                var output = Process(nasaInput);
                PrintResult(output);

                //To stop auto termination
                Console.ReadKey();
            }
            catch
            {

            }
        }

        private static NasaInput ParseInputFileArray(string[] arr)
        {
            var roverInputList = new List<RoverInput>();
            var length = arr.Length;
            //Retrieving the upper-right coordinates
            var upperRight = arr[0].Trim().Split(' ');
            var xBorder = Convert.ToInt32(upperRight[0]);
            var yBorder = Convert.ToInt32(upperRight[1]);

            for (int i = 1; i < arr.Length; i = i + 2)
            {
                roverInputList.Add(new RoverInput(arr[i], arr[i + 1]));
            }

            return new NasaInput()
            {
                XBorder = xBorder,
                YBorder = yBorder,
                RoverInputList = roverInputList
            };
        }

        private static List<string> Process(NasaInput input)
        {
            var finalPositions = new List<string>();
            var roverInputList = input.RoverInputList;
            if (roverInputList == null || !roverInputList.Any())
                return finalPositions;

            foreach (var roverInput in roverInputList)
            {
                //Generating the Robotic Rover
                var robot = new RoboticRover(roverInput.Cx, roverInput.Cy,
                    input.XBorder, input.YBorder, roverInput.Direction,
                    roverInput.Instructions.ToCharArray().ToList());
                //Doing the Instructions for Robotic Rover
                robot.ReadInstructions();
                finalPositions.Add(robot.DeclareFinalDestination());
            }
            return finalPositions;
        }

        private static void PrintResult(List<string> outputs)
        {
            foreach (var output in outputs)
            {
                Console.WriteLine(output.ToString());
            }
        }
    }
}
