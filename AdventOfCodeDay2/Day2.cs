using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

//Test code:
//brackets are just for readability
//(1,0,0,3,99) -> reads the values at position 0 and 0, adds them up and stores the value at position 3 and halts the program
//(1,10,20,30) -> reads the values at position 10 and 20, add them and stores the value at position 30
//(1,9,10,3,2,3,11,0,99,30,40,50) -> 30+40=70, (1, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50) -> 70*50=3500, (3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50)
//(1,0,0,0,99) -> (2, 0, 0, 0, 99)
//(2, 3, 0, 3, 99) -> (2, 3, 0, 6, 99)
//(2, 4, 4, 5, 99, 0) -> (2, 4, 4, 5, 99, 9801)
//(1, 1, 1, 4, 99, 5, 6, 0, 99) -> (30, 1, 1, 4, 2, 5, 6, 0, 99)

//Intcode program list of integers separated by commas
//position 0 contains opcode(1, 2 or 99)
//99 means that the program is finished and should stop
//unknown opcode (something other than 1, 2 or 99) something went wrong
//opcode 1 adds numbers from two positions and stores the result in a third position
//the three ints after the opcode tell the three position, first two indicate positions from where to read the input values
//third integer specifies the position where the result is stored
//opcode 2 multiplies the two inputs, following the rules as before with opcode 1
//the integers after the opcode specifies WHERE the inputs and outputs are, NOT the values
//once done processing an opcode, move forward 4 positions
//before running the program, replace position 1 with the value 12 and replace position 2 with the value 2,
//Q: What value is left at position 0 after the program halts?

namespace AdventOfCodeDay2
{
    public class Day2
    {
        public static void Main(string[] args)
        {
            string filePath = "D:\\Mykola\\Pictures\\inputDay2.txt";
            FindVerbAndNoun(filePath, 19690720);
        }

        public static List<int> ParseInput(string filePath)
        {
            List<int> tempIntcode = new List<int>();
            string lines;
            string number = "";
            
            try
            {
                lines = File.ReadAllText(filePath);
                // string[] numbers = lines.Split(',');
                
                foreach(char letter in lines)
                {
                    if (letter == ',')
                    {
                        tempIntcode.Add(int.Parse(number));
                        number = "";
                    }
                    else
                    {
                        number += letter;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return tempIntcode;
        }

        public static List<int> IterateThroughIntcode(List<int> intcode)
        {
            int currentKeycode = 0;

            while (currentKeycode <= intcode.Count)
            {
                switch (intcode[currentKeycode])
                {
                    case 1:
                        //Add things together
                        intcode[intcode[currentKeycode + 3]] = AddValues(intcode[currentKeycode + 1], intcode[currentKeycode + 2], intcode);
                        break;
                    case 2:
                        //multiply things together
                        intcode[intcode[currentKeycode + 3]] = MultiplyValues(intcode[currentKeycode + 1], intcode[currentKeycode + 2], intcode);
                        break;
                    case 99:
                        //break out of do while loop
                        return intcode;
                    default:
                        break;
                }
                currentKeycode += 4;
            };
            return intcode;
        }

        public static int AddValues(int location1, int location2, List<int> intcode)
        {
            return intcode[location1] + intcode[location2];
        }

        public static int MultiplyValues(int location1, int location2, List<int> intcode)
        {
            return intcode[location1] * intcode[location2];
        }

        public static void ResetMemory(List<int> intcode)
        {
            intcode.Clear();
        }

        public static bool OutputChecker(List<int> intcode, int output)
        {
            return intcode[0] == output;
        }

        public static void FindVerbAndNoun(string filePath, int output)
        {
            List<int> memory = ParseInput(filePath);

            for(int i = 0; i <= 1000000000; i++)
            {
                for (int noun = 0; noun <= 99; noun++)
                {
                    for (int verb = 0; verb <= 99; verb++)
                    {
                        List<int> intcode = new List<int>(memory);
                        intcode[1] = noun;
                        intcode[2] = verb;
                        intcode = IterateThroughIntcode(intcode);
                        if (OutputChecker(intcode, output))
                        {
                            Console.WriteLine(100 * noun + verb);
                            return;
                        }
                        ResetMemory(intcode);
                    }
                }
            }

            Console.WriteLine("No noun and verb found for finding the output.");
        }
    }
}