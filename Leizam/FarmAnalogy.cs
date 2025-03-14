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
            try
            {
                #region Declaration of variables
                int index = 0, length, width, farmArea, cowArea = 3,
                        cowNumPerPaddock, onePaddockArea, noOfPaddocks, operation;
                double farmValue, paddockValue, remainingArea, cowValue = 20000;
                int[] paddockCowCount;
                char[][] paddocksList, paddockNames;
                int[][] paddockDimensions, paddocksAreaList, paddocksArea;
                double[][][] paddockCoordinates;
                bool esc = true;
                #endregion

                #region Getting the Length and Width
                do
                {
                    Console.Write("Length = ");
                    //length  = int.Parse(Console.ReadLine());
                    length = CaptureNValidateInt();
                    if (length >= 210) esc = false;//length % 3 == 0 &&
                    else Console.WriteLine("Please provide a number that is greater than 210");

                } while (esc);
                esc = true;
                do
                {
                    Console.Write("Width = ");
                    //width = int.Parse(Console.ReadLine());
                    width = CaptureNValidateInt();

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
                    //cowNumPerPaddock = int.Parse(Console.ReadLine());
                    cowNumPerPaddock = CaptureNValidateInt();
                    if (cowNumPerPaddock < 0) Console.WriteLine("Number of cows cannot be a negative");
                    onePaddockArea = cowNumPerPaddock * cowArea;
                    if (onePaddockArea > farmArea) Console.WriteLine("Not enough farm space to accommodate all cows"); else esc = false;
                } while (esc);
                esc = true;

                //Console.Write("\n\nEnter the value of each cows : ");
                cowValue = 1000; //double.Parse(Console.ReadLine());

                paddockValue = cowNumPerPaddock * cowValue;

                #region paddock area
                // Grazing ( 2 x 1.5 )
                double paddockLength = Math.Sqrt(onePaddockArea);
                double paddockWidth = onePaddockArea / paddockLength;
                double accuratePaddockArea = paddockWidth * paddockLength;
                noOfPaddocks = (int)(farmArea / onePaddockArea);
                remainingArea = farmArea - (noOfPaddocks * accuratePaddockArea);
                #endregion
                esc = true;
                farmValue = noOfPaddocks * paddockValue;

                if (accuratePaddockArea > farmValue)
                {
                    Console.WriteLine("Size of area occopied by cows cannot be a more than thw farm area");
                    Console.ReadLine();
                    return;
                }


                //Console.WriteLine($"\n\n-----------------------------ORIGINAL READINGS--------------------------" +
                //    $"\nNumber of cows : {cowNumPerPaddock} " +
                //    $"| Area of each paddock : {accuratePaddockArea} " +
                //    $"| Number of paddocks : {noOfPaddocks}" +
                //    $"\nFarm Area  : {farmArea}" +
                //    $"| paddock value  : {paddockValue}" +
                //    $"| Remaining Area : {remainingArea}");

                int remainingWidth = (int)(remainingArea / paddockLength);
                //Console.WriteLine($"\n\n-----------------------------ADJUSTED READINGS--------------------------" +
                //    $"\nNumber of cows : {cowNumPerPaddock} " +
                //    $"| Area of each paddock : {accuratePaddockArea} except paddock A which has {accuratePaddockArea + remainingArea}" +
                //    $" (length = {paddockLength}, width = {remainingWidth + paddockWidth})" +
                //    $"| Number of paddocks : {noOfPaddocks}" +
                //    $"| paddock value  : {paddockValue}" +
                //    $"| Remaining Area : {0}");

                Console.WriteLine();
                #endregion

                #region setting each paddock a name and an initial number of cows

                // paddocksAreaList = new int[noOfPaddocks][];
                paddockNames = AssignNames(noOfPaddocks);
                // paddocksArea = setPaddockArea(paddocksAreaList, noOfPaddocks, onePaddockArea);
                //paddockDimensions = SetPaddockDimensions(noOfPaddocks, onePaddockArea);
                paddockDimensions = SetPaddockDimensions2(noOfPaddocks, onePaddockArea, length, width);
                paddockCoordinates = SetPaddockCoordinates(noOfPaddocks, paddockDimensions, length, width);
                int n = PrintPaddocks(noOfPaddocks, paddockDimensions, width, length);
                Console.WriteLine("Redistributing the remaining area to paddocks");
                int coveredArea = n * onePaddockArea;
                int remaining = farmArea - coveredArea;
                int eachIncrease = remaining / n;
                Console.WriteLine($"Each paddock increases by {eachIncrease}");

                paddockCowCount = new int[noOfPaddocks];
                for (int i = 0; i < noOfPaddocks; i++)
                {
                    paddockCowCount[i] = cowNumPerPaddock;
                }
                #endregion

                #region Farm Operations
                do
                {
                    Console.WriteLine("\n\n\n\n\nWhich operation would you like to carry out: \n" +
                        "0 : GetPaddock Coordinates\n" +
                        "1 : Move cow(s)\n" +
                        "2 : Sell cow(s)\n" +
                        "3 : Restock cow(s)\n" +
                        "98 : Exit\n" +
                        "------------------------------------------------");
                    operation = CaptureNValidateInt();
                    char[] from;
                    char[] to;
                    int num;
                    double[][] coordinates;
                    switch (operation)
                    {
                        case 0:
                            Console.Write("Enter paddock name to get coordinates: ");
                            char[] inputPaddockName = CaptureNValidateChar();
                            int paddockIndex = GetPaddockIndex(paddockNames, inputPaddockName);
                            if (paddockIndex < 0)
                            {
                                break;
                            }
                            coordinates = GetPaddockCoordinates(paddockCoordinates, paddockIndex);
                            if (paddockIndex == null)
                            {
                                break;
                            }
                            //Console.WriteLine($"Paddock {inputPaddockName} coordinates:\n" +
                            //    $"\nTop-Left: {coordinates[0][0]},{coordinates[0][1]}" +
                            //    $"\nTop-Right: {coordinates[1][0]},{coordinates[1][1]}" +
                            //    $"\nBottom-Right: {coordinates[2][0]},{coordinates[2][1]}" +
                            //    $"\nBottom-Left: {coordinates[3][0]},{coordinates[3][1]}");
                            PrintPaddockCoordinates(inputPaddockName.ToString(), coordinates);
                            break;
                        case 1:
                            Console.Write("Which paddock would you like to Move FROM: ");
                            from = CaptureNValidateChar();
                            Console.Write("Which paddock would you like to Move the cow TO: ");
                            to = CaptureNValidateChar();
                            Console.Write("How many cows would you like to move: ");
                            num = CaptureNValidateInt();
                            Move(paddockNames, paddockCowCount, from, to, num);
                            break;
                        case 2:
                            Console.Write("From which paddock would you like to sell: ");
                            from = CaptureNValidateChar();
                            Console.Write("How many cows would you like to sell: ");
                            num = CaptureNValidateInt();
                            Sell(paddockNames, paddockCowCount, from, num);
                            break;
                        case 3:
                            Console.Write("To which paddock would you like to restock: ");
                            from = CaptureNValidateChar();
                            Console.Write("How many cows would you like to add: ");
                            num = CaptureNValidateInt();
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
                Console.WriteLine("Press Enter twice to close");
                #endregion

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occored in the program. Please rerun");
                throw;
            }
        }
        #region MyHelper functions

        public static char[] CaptureNValidateChar()
        {
            char[] returnValue;
            do
            {
                string? cap = Console.ReadLine();
                if (!string.IsNullOrEmpty(cap) && cap.All(char.IsUpper))
                {
                    returnValue = cap.ToCharArray();
                    break;
                }
                Console.WriteLine("Please enter the a valid Character (A-Z)");
            } while (true);
            return returnValue;
        }
        public static int CaptureNValidateInt()
        {
            int returnValue = 0;
            do
            {
                string? cap = Console.ReadLine();
                if (int.TryParse(cap, out returnValue)) break;
                Console.WriteLine("Please enter the a valid number");
            } while (true);
            return returnValue;
        }
        public static int PrintPaddocks(int noOfPaddocks, int[][] paddockDimensions, int farmLength, int farmWidth)
        {
            // double[][][] paddockCoordinates = SetPaddockCoordinates(noOfPaddocks, paddockDimensions, farmLength, farmWidth);

            int rows = farmWidth / paddockDimensions[0][1];
            int cols = farmLength / paddockDimensions[0][0];

            char[,] grid = new char[rows * 3, cols * 5];

            #region setting dimentions 

            #endregion

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = ' ';
                }
            }

            int paddockIndex = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (paddockIndex >= noOfPaddocks) break;

                    int startRow = r * 3;
                    int startCol = c * 5;
                    char paddockLabel = (char)('A' + paddockIndex);

                    for (int i = 0; i < 5; i++)
                    {
                        grid[startRow, startCol + i] = '-';
                        grid[startRow + 2, startCol + i] = '-';
                    }


                    grid[startRow, startCol] = '+'; // Top-left corner
                    grid[startRow, startCol + 4] = '+'; // Top-right corner
                    grid[startRow + 2, startCol] = '+'; // Bottom-left corner
                    grid[startRow + 2, startCol + 4] = '+'; // Bottom-right corner
                    grid[startRow + 1, startCol] = '|'; // Left border
                    grid[startRow + 1, startCol + 4] = '|'; // Right border

                    grid[startRow + 1, startCol + 2] = paddockLabel;

                    paddockIndex++;
                }
            }
            // Print the grid
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{paddockIndex} paddocks out of the predicted {noOfPaddocks} were able to fit the farm");
            return paddockIndex;
        }

        public static double[][][] SetPaddockCoordinates(int noOfPaddocks, int[][] paddockDimensions, int farmLength, int farmWidth)
        {
            double[][][] paddockCoordinates = new double[noOfPaddocks][][];
            double x = 0, y = 0;

            for (int i = 0; i < noOfPaddocks; i++)
            {
                double width = paddockDimensions[i][0];
                double height = paddockDimensions[i][1];

                if (x + width > farmLength)
                {
                    x = 0;
                    y += height;
                }

                if (y + height > farmWidth)
                {
                    break;
                }

                paddockCoordinates[i] = new double[][]
                {
                    new double[] { x, y },
                    new double[] { x + width, y },
                    new double[] { x + width, y + height },
                    new double[] { x, y + height }
                };

                x += width;
            }

            return paddockCoordinates;
        }

        public static char[][] AssignNames(int noOfPaddocks)
        {
            char[][] paddocksList = new char[noOfPaddocks][];
            char[] alphabets = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int index = 0;
            int letterCount = 1;

            int[] positions = new int[letterCount];

            while (index < noOfPaddocks)
            {
                // Create a new paddock name using the positions array
                paddocksList[index] = new char[letterCount];
                for (int i = 0; i < letterCount; i++)
                {
                    paddocksList[index][i] = alphabets[positions[i]];
                }

                index++;

                // Increment the base-26 counter (similar to how Excel columns increment)
                int pos = letterCount - 1;
                while (pos >= 0)
                {
                    positions[pos]++;
                    if (positions[pos] < alphabets.Length)
                        break;

                    // Carry over
                    positions[pos] = 0;
                    pos--;

                    // If we have carried past the first position, increase letter count
                    if (pos < 0)
                    {
                        letterCount++;
                        positions = new int[letterCount];
                    }
                }
            }


            // Print paddocks
            //for (int i = 0; i < paddocksList.Length; i++)
            //{
            //    Console.Write("Paddock ");
            //    for (int j = 0; j < paddocksList[i].Length; j++)
            //    {
            //        Console.Write(paddocksList[i][j]);
            //    }
            //    Console.Write(". ");
            //}

            Console.WriteLine($"\nPredicted total number of paddocks: {paddocksList.Length}\n");
            return paddocksList;
        }

        public static int[][] setPaddockArea(int[][] paddocksList, int noOfPaddocks, int paddockArea)
        {
            char[] alphabets = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int index = 0;
            int paddockLength = (int)Math.Sqrt(paddockArea);
            int paddockWidth = paddockArea / paddockLength;

            //Console.WriteLine($"\nEach paddock has a length of {paddockLength} and a width of {paddockWidth}\n");

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

        public static int[][] SetPaddockDimensions(int noOfPaddocks, int paddockArea)
        {
            int[][] paddockDimensions = new int[noOfPaddocks][];
            int paddockLength = (int)Math.Sqrt(paddockArea);
            int paddockWidth = paddockArea / paddockLength;

            while (!((paddockLength % 2 == 0 && paddockWidth % 3 == 0) ||
                (paddockWidth % 2 == 0 && paddockLength % 3 == 0)) ||
                (paddockLength * paddockWidth != paddockArea))
            {
                paddockLength--;
                paddockWidth = paddockArea / paddockLength;

                //if (paddockLength * paddockWidth == paddockArea) break;
            }

            Console.WriteLine($"\nEach paddock has a length of {paddockLength} and a width of {paddockWidth}\n");

            for (int i = 0; i < noOfPaddocks; i++)
            {
                paddockDimensions[i] = new int[] { paddockLength, paddockWidth };
            }

            return paddockDimensions;
        }
        public static int[][] SetPaddockDimensions2(int noOfPaddocks, int paddockArea, int farmLength, int farmWidth)
        {
            int[][] paddockDimensions = new int[noOfPaddocks][];
            int paddockLength = 0 ; //(int)Math.Sqrt(paddockArea);
            int paddockWidth = 0 ; // paddockArea / paddockLength;
            Action<int, int> print = (paddockLength, paddockWidth) => Console.WriteLine($"\nEach paddock has a length of {paddockLength} and a width of {paddockWidth}\n");

            ///while (!((paddockLength % 2 == 0 && paddockWidth % 3 == 0) ||
            ///    (paddockWidth % 2 == 0 && paddockLength % 3 == 0)) ||
            ///    (paddockLength * paddockWidth != paddockArea))
            ///{
            ///    paddockLength--;
            ///    paddockWidth = paddockArea / paddockLength;
            ///    //if (paddockLength * paddockWidth == paddockArea) break;
            ///}

            ///Presuming every cow takes a length of 1.5 and height of 2
            if (farmLength % 3 == 0 || farmWidth % 3 == 0)
            {
                paddockLength = farmLength % 3 == 0 ? farmLength: farmWidth;
                paddockWidth = paddockArea / paddockLength;
                //Console.WriteLine($"\nEach paddock has a length of {paddockLength} and a width of {paddockWidth}\n");
                goto done;//could have used elseif but decided to go with goto:
            }
            ///Presuming every cow takes a length of 2 and height of 1.5
            if (farmLength % 2 == 0 || farmWidth % 2 == 0)
            {
                paddockLength = farmLength % 2 == 0 ? farmLength: farmWidth;
                paddockWidth = paddockArea / paddockLength;
                //Console.WriteLine($"\nEach paddock has a length of {paddockLength} and a width of {paddockWidth}\n");
                //print(paddockLength, paddockWidth);
                goto done;
            }

            while (!((paddockLength % 2 == 0 && paddockWidth % 3 == 0) ||
                     (paddockWidth % 2 == 0 && paddockLength % 3 == 0)) ||
                     (paddockLength * paddockWidth != paddockArea))
            {
                 paddockLength--;
                 paddockWidth = paddockArea / paddockLength;
            }
            done:
            print(paddockLength, paddockWidth);
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

        public static double[][] GetPaddockCoordinates(double[][][] paddockCoordinates, int index)
        {
            if (index < 0 || index >= paddockCoordinates.Length)
            {
                Console.WriteLine("There exists no such paddock");
                return null;
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

        public static void Move(char[][] paddockNames, int[] paddockCowCount, char[] fromPaddock, char[] toPaddock, int num)
        {
            int fromIndex = GetPaddockIndex(paddockNames, fromPaddock);
            int toIndex = GetPaddockIndex(paddockNames, toPaddock);

            if (paddockCowCount[fromIndex] > 0 && paddockCowCount[toIndex] > 0)
            {

                if (paddockCowCount[fromIndex] > num)
                {
                    paddockCowCount[fromIndex] -= num;
                    paddockCowCount[toIndex] += num;
                    Console.WriteLine($"Moved {num} cow(s) from paddock {fromPaddock} to paddock {toPaddock}");
                }
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
        }

        public static void PrintPaddockCoordinates(string paddockName, double[][] coordinates)
        {
            Console.WriteLine($"\nPaddock {paddockName} Coordinates:\n");

            string topCoordinates = $"{coordinates[0][0]},{coordinates[0][1]}".PadRight(20) + $"{coordinates[1][0]},{coordinates[1][1]}";
            string bottomCoordinates = $"{coordinates[3][0]},{coordinates[3][1]}".PadRight(20) + $"{coordinates[2][0]},{coordinates[2][1]}";

            Console.WriteLine(topCoordinates);
            Console.WriteLine(new string('-', 20));

            Console.WriteLine("|" + new string(' ', 18) + "|");

            Console.WriteLine(new string('-', 20));
            Console.WriteLine(bottomCoordinates);
        }



        #endregion

    }
}
