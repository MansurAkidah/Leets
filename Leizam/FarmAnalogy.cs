using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Leets.Leizam
{
    public class FarmAnalogy
    {
        public void MyMain()
        {
            #region Declaration of variables
            int index = 0, length, width, farmArea, cowArea = 3,
                    cowNumPerPaddock, onePaddockArea, noOfPaddocks,
                    remainingArea, operation;
            double farmValue, paddockValue, cowValue = 20000;
            int[] paddockCowCount;
            char[][] paddocksList, paddockNames;
            int[][] paddockDimensions, paddockCoordinates;
            bool esc = true;
            #endregion

            #region Getting the Length and Width
            do
            {
                Console.Write("Length = ");
                length = int.Parse(Console.ReadLine());

                if (length >= 210) esc = false;//length % 3 == 0 &&
                else Console.WriteLine("Please provide a number that is greater than 210");

            } while (esc);
            esc = true;
            Console.WriteLine();
            do
            {
                Console.Write("Width = ");
                width = int.Parse(Console.ReadLine());

                if (width >= 300) esc = false;//width % 3 == 0 &&
                else Console.WriteLine("Please provide a number that is greater than 300");

            } while (esc);
            esc = true;

            farmArea = width * length;

            Console.WriteLine($"\n\nLength : {length} | Width : {width} \nTotal farm Area = {farmArea}");

            #endregion

            #region Getting number of cows per paddock
            do
            {
                Console.Write("\n\nEnter the number of cows per paddock:  ");
                cowNumPerPaddock = int.Parse(Console.ReadLine());
                if (cowNumPerPaddock < 0) Console.WriteLine("Number of cows cannot be a negative");
                onePaddockArea = cowNumPerPaddock * cowArea;
                if (onePaddockArea > farmArea) Console.WriteLine("Not enough farm space to accommodate all cows"); else esc = false;
            } while (esc);
            esc = true;

            //Console.Write("\n\nEnter the value of each cows : ");
            //cowValue = double.Parse(Console.ReadLine());

            paddockValue = cowNumPerPaddock * cowValue;
            noOfPaddocks = (int)(farmArea / onePaddockArea);
            farmValue = noOfPaddocks * paddockValue;
            remainingArea = farmArea - (noOfPaddocks * onePaddockArea);
            Console.WriteLine($"Number of cows : {cowNumPerPaddock} " +
                $"| Area of each paddock : {onePaddockArea} " +
                $"| Number of paddocks : {noOfPaddocks}" +
                $"\nFarm value  : {farmValue}" +
                $"| paddock value  : {paddockValue}" +
                $"| Remaining Area : {remainingArea}");

            Console.WriteLine();
            #endregion

            #region Assigning each paddock a name and an initial number of cows
            paddocksList = new char[noOfPaddocks][];
            paddockNames = AssignPaddocks(paddocksList, noOfPaddocks);
            paddockDimensions = AssignPaddockDimensions(noOfPaddocks, onePaddockArea);
            paddockCoordinates = AssignPaddockCoordinates(noOfPaddocks, paddockDimensions, width);
            paddockCowCount = new int[noOfPaddocks];
            for (int i = 0; i < noOfPaddocks; i++)
            {
                paddockCowCount[i] = cowNumPerPaddock;
            }
            #endregion

            #region Getting Coordinates
            int[] dimensions, coordinates;

            Console.Write("Enter paddock name: ");
            char[] inputPaddockName = Console.ReadLine().ToCharArray();
            int paddockIndex = GetPaddockIndex(paddockNames, inputPaddockName);
            coordinates = GetPaddockCoordinates(paddockCoordinates, paddockIndex);
            Console.WriteLine($"Paddock {inputPaddockName} coordinates: X = {coordinates[0]}, Y = {coordinates[1]}");
            //for (int i = 0; i < noOfPaddocks; i++)
            //{
            //    coordinates = GetPaddockCoordinates(paddockCoordinates, i);
            //    dimensions = GetPaddockDimensions(paddockDimensions, i);
            //    Console.WriteLine($"Paddock {new string(paddockNames[i])} dimensions: Length = {dimensions[0]}, Width = {dimensions[1]}, coordinates: X = {coordinates[0]}, Y = {coordinates[1]}");

            //} 
            #endregion

            #region Farm Operations
            do
            {
                Console.WriteLine("Which operation would you like to carry out: \n" +
                    "0 : GetPaddock Coordinates\n" +
                    "1 : Move cow(s)\n" +
                    "2 : Sell cow(s)\n" +
                    "3 : Restock cow(s)\n" +
                    "98 : Exit");
                operation = int.Parse(Console.ReadLine());
                char[] from;
                char[] to;
                int num;
                switch (operation)
                {
                    case 0:
                        //Console.Write("Enter paddock name to get coordinates: ");
                        //from = Console.ReadLine().ToCharArray();
                        //int paddockIndex = GetPaddockIndex(paddockNames, from);
                        //int[] coordinates = GetPaddockCoordinates(paddockCoordinates, paddockIndex);
                        //Console.WriteLine($"Paddock {new string(from)} coordinates: X = {coordinates[0]}, Y = {coordinates[1]}");
                        break;
                    case 1:
                        Console.Write("Which paddock would you like to Move FROM: ");
                        from = Console.ReadLine().ToCharArray();
                        Console.Write("Which paddock would you like to Move the cow TO: ");
                        to = Console.ReadLine().ToCharArray();
                        Move(paddockNames, paddockCowCount, from, to);
                        break;
                    case 2:
                        Console.Write("From which paddock would you like to sell: ");
                        from = Console.ReadLine().ToCharArray();
                        Console.Write("How many cows would you like to sell: ");
                        num = int.Parse(Console.ReadLine());
                        Sell(paddockNames, paddockCowCount, from, num);
                        break;
                    case 3:
                        Console.Write("To which paddock would you like to restock: ");
                        from = Console.ReadLine().ToCharArray();
                        Console.Write("How many cows would you like to add: ");
                        num = int.Parse(Console.ReadLine());
                        Restock(paddockNames, paddockCowCount, from, num);
                        break;
                    case 98:
                        esc = false;
                        break;
                    default:
                        Console.WriteLine("Invalid operation. Please try again.");
                        break;
                }
            } while (esc);
            #endregion
        }
        #region MyHelper functions

        public static char[][] AssignPaddocks(char[][] paddocksList, int noOfPaddocks)
        {

            char[] alphabets = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                labels;
            int index = 0;


            for (int i = 0; i < alphabets.Length && index < noOfPaddocks; i++)
            {
                paddocksList[index] = new char[] { alphabets[i] };
                index++;
            }

            if (index < noOfPaddocks)
            {
                for (int i = 0; i < alphabets.Length && index < noOfPaddocks; i++)
                {
                    for (int j = 0; j < alphabets.Length && index < noOfPaddocks; j++)
                    {
                        paddocksList[index] = new char[] { alphabets[i], alphabets[j] };
                        index++;
                    }
                }
            }

            for (int i = 0; i < paddocksList.Length; i++)
            {
                Console.Write("\nPaddock ");
                for (int j = 0; j < paddocksList[i].Length; j++)
                {
                    Console.Write($"{paddocksList[i][j]}");
                }
            }

            Console.WriteLine($"\nTotal number of paddocks : {paddocksList.Length}");

            return paddocksList;

        }

        public static int[][] AssignPaddockArea(int[][] paddocksList, int noOfPaddocks, int paddockArea)
        {
            char[] alphabets = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int index = 0;
            int paddockLength = (int)Math.Sqrt(paddockArea);
            int paddockWidth = paddockArea / paddockLength;

            for (int i = 0; i < alphabets.Length && index < noOfPaddocks; i++)
            {
                paddocksList[index] = new int[] { paddockLength, paddockWidth };
                index++;
            }

            if (index < noOfPaddocks)
            {
                for (int i = 0; i < alphabets.Length && index < noOfPaddocks; i++)
                {
                    for (int j = 0; j < alphabets.Length && index < noOfPaddocks; j++)
                    {
                        paddocksList[index] = new int[] { paddockLength, paddockWidth };
                        index++;
                    }
                }
            }

            for (int i = 0; i < paddocksList.Length; i++)
            {
                for (int j = 0; j < paddocksList[i].Length; j++)
                {
                    Console.Write($"{paddocksList[i][j]}");
                }
                Console.WriteLine($" - Paddock {i}");
            }

            Console.WriteLine($"\nTotal number of paddocks : {paddocksList.Length}");

            return paddocksList;
        }

        public static int[][] AssignPaddockDimensions(int noOfPaddocks, int paddockArea)
        {
            int[][] paddockDimensions = new int[noOfPaddocks][];
            int paddockLength = (int)Math.Sqrt(paddockArea);
            int paddockWidth = paddockArea / paddockLength;

            for (int i = 0; i < noOfPaddocks; i++)
            {
                paddockDimensions[i] = new int[] { paddockLength, paddockWidth };
            }

            return paddockDimensions;
        }

        public static int[] GetPaddockDimensions(int[][] paddockDimensions, int index)
        {
            if (index < 0 || index >= paddockDimensions.Length)
            {
                Console.WriteLine("Index is out of range");
            }
            return paddockDimensions[index];
        }

        public static int[][] AssignPaddockCoordinates(int noOfPaddocks, int[][] paddockDimensions, int farmWidth)
        {
            int[][] paddockCoordinates = new int[noOfPaddocks][];
            int x = 0, y = 0;

            for (int i = 0; i < noOfPaddocks; i++)
            {
                paddockCoordinates[i] = new int[] { x, y };
                x += paddockDimensions[i][0];
                if (x + paddockDimensions[i][0] > farmWidth) // If x exceeds farm width, move to next row
                {
                    x = 0;
                    y += paddockDimensions[i][1]; // Move y-coordinate based on paddock width
                }
            }

            return paddockCoordinates;
        }

        public static int[] GetPaddockCoordinates(int[][] paddockCoordinates, int index)
        {
            if (index < 0 || index >= paddockCoordinates.Length)
            {
                Console.WriteLine("There exists no such paddock");
            }
            return paddockCoordinates[index];
        }

        public static int GetPaddockIndex(char[][] paddockNames, char[] inputName)
        {
            for (int i = 0; i < paddockNames.Length; i++)
            {
                if (paddockNames[i].SequenceEqual(inputName))
                {
                    return i;
                }
            }
            Console.WriteLine("Paddock name not found");
            return -1;
        }

        public static void Move(char[][] paddockNames, int[] paddockCowCount, char[] fromPaddock, char[] toPaddock)
        {
            int fromIndex = GetPaddockIndex(paddockNames, fromPaddock);
            int toIndex = GetPaddockIndex(paddockNames, toPaddock);

            if (paddockCowCount[fromIndex] > 0 && paddockCowCount[toIndex] > 0)
            {
                paddockCowCount[fromIndex]--;
                paddockCowCount[toIndex]++;
                Console.WriteLine($"Moved a cow from paddock {fromPaddock} to paddock {toPaddock}");
            }
            else
            {
                Console.WriteLine($"No cows to move from paddock {fromPaddock}");
            }
        }

        public static void Sell(char[][] paddockNames, int[] paddockCowCount, char[] paddock, int numberOfCows)
        {
            int index = GetPaddockIndex(paddockNames, paddock);

            if (paddockCowCount[index] >= numberOfCows)
            {
                paddockCowCount[index] -= numberOfCows;
                Console.WriteLine($"Sold {numberOfCows} cow(s) from paddock {new string(paddock)}");
            }
            else
            {
                Console.WriteLine($"There are only {paddockCowCount[index]} in this paddock");
            }
        }

        public static void Restock(char[][] paddockNames, int[] paddockCowCount, char[] paddock, int numberOfCows)
        {
            int index = GetPaddockIndex(paddockNames, paddock);

            paddockCowCount[index] += numberOfCows;
            Console.WriteLine($"Restocked {numberOfCows} cow(s) to paddock {new string(paddock)}");
            #endregion
        }
    }
}
