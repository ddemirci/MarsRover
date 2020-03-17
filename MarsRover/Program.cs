using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MarsRover
{
    public class Program
    {
        private const string NasaInputFileName = @"NASAInput.txt";
        public static void Main(string[] args)
        {
            try
            {
                //First read input file
                var marsRoverPath = Directory.GetParent(Directory.GetCurrentDirectory())
                    .Parent.FullName;
                var marsRoverInputFilePath = Path.Combine(new string[]
                    { marsRoverPath, "Input", NasaInputFileName });

                var inputLines = File.ReadAllLines(marsRoverInputFilePath);
                if (inputLines == null || inputLines.Length == 0) return;

                //Parsing the inputLines
                var nasaInput = ParseInputFileArray(inputLines);
                var output = Process(nasaInput);
                PrintResult(output);

                //To stop auto termination
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
                //To stop auto termination
                Console.ReadKey();
            }
        }

        private static NasaInput ParseInputFileArray(string[] arr)
        {
            try
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

                return new NasaInput(xBorder, yBorder, roverInputList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<string> Process(NasaInput input)
        {
            try
            {
                var finalPositions = new List<string>();
                var roverInputList = input.RoverInputList;
                if (roverInputList == null || !roverInputList.Any())
                    return finalPositions;

                var borderX = input.XBorder;
                var borderY = input.YBorder;
                foreach (var roverInput in roverInputList)
                {
                    //Generating the Robotic Rover
                    var robot = new RoboticRover(
                        borders: new int[] { borderX, borderY },
                        coordinates: new int[] { roverInput.Cx, roverInput.Cy },
                        direction: roverInput.Direction,
                        instructions: roverInput.Instructions.ToCharArray().ToList());

                    //Doing the Instructions for Robotic Rover
                    robot.ReadInstructions();
                    finalPositions.Add(robot.DeclareFinalDestination());
                }
                return finalPositions;
            }
            catch(Exception ex)
            {
                throw ex;
            }
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
