using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets.Leizam
{
    public class MultiArrayOperations
    {
        public void MyMain()
        {
            int cols = 7, 
                rows = 7, 
                odds = 1, 
                evens = 0;

            int[,] multiArr = new int[rows, cols];


            int[,] result = Initialize(multiArr, cols, rows);

            Console.WriteLine("\n\n-----------------------------Initializing Done-------------------------\n\n");

            SortingMultiArray(result, rows, cols);

            Console.WriteLine("\n\n-----------------------------Cumbersome Sorting Done-------------------------\n\n");

            SortingMultiArray2(result, rows, cols);

            Console.WriteLine("\n\n-----------------------------Sorting Using IntOperations Class Done-------------------------\n\n");

            SortingMultiArray3(result, rows, cols);

            Console.WriteLine("\n\n-----------------------------Sorting Using 4 for loops Done-------------------------\n\n");


        }
        public static bool ItExists(int[,] arr, int rows, int cols, int n)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (arr[row, col] == n) { return true; }
                }
            }
            return false;
        }
        public static int[,] Initialize(int[,] multiArr, int rows, int cols)
        {
            Random rnd = new Random();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (col == 0)
                    {
                        multiArr[row, col] = row + 1 ;
                    }
                    else
                    if (row == 0)
                    {
                        multiArr[row, col] = col + 1 ;
                    }
                    else
                    if (row == 1 && col != 0)
                    {
                        int odd = generateRandom();
                        while (odd % 2 == 0)
                        {
                            odd = generateRandom();
                        }
                        multiArr[row, col] = odd;
                    }
                    else
                    if (row == 2 && col != 0)
                    {
                        int even = generateRandom();
                        while (even % 2 != 0)
                        {
                            even = generateRandom();
                        }
                        multiArr[row, col] = even;
                    }
                    else
                    if (row == 3 && col != 0)
                    {
                        int n = generateRandom();
                        while (ItExists(multiArr, rows, cols, n))
                        {
                            n = generateRandom();
                        }
                        multiArr[row, col] = n;
                    }
                    else
                    {
                        int n;
                        do
                        {
                            n = rnd.Next(1, 1000);
                        }
                        while (ItExists(multiArr, rows, cols, n));
                        multiArr[row, col] = n;
                    }


                    Console.Write(multiArr[row, col] + "|\t");
                }
                Console.Write("\n\n");
            }

            return multiArr;
        }
        public class indexCarrier
        {
            public int colIndex { get; set; } = 1;
            public int rowIndex { get; set; } = 1;
            public int smallest { get; set; } = -1;
            public int largestColIndex { get; set; } = 1;
            public int largestRowIndex { get; set; } = 1;
            public int largest { get; set; }

        }
        public static int generateRandom()
        {
            Random rnd = new Random();
            return rnd.Next(10, 10001);
        }
        public static void SortingMultiArray(int[,] multiArr, int rows, int cols)
        {
            indexCarrier result = new indexCarrier();
            int[,] returnArr = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (col == 0)
                    {
                        Console.Write(multiArr[row, col] + "|\t");
                        continue;
                    }
                    else
                    if (row == 0)
                    {
                        Console.Write(multiArr[row, col] + "|\t");
                        continue;
                    }
                    else
                    {
                        result = findSmallest(multiArr, rows, cols, result);
                        returnArr[row, col] = result.smallest;
                    }
                    Console.Write(returnArr[row, col] + "|\t");
                }
                Console.Write("\n\n");
            }
            //return multiArr;
        }
        public static indexCarrier findSmallest(int[,] multiArr, int rows, int cols, indexCarrier indexCarrier)
        {
            //int n = multiArr[1, 1], r = 1, c = 1;

            indexCarrier = findLargest(multiArr, rows, cols, indexCarrier);
            int n = indexCarrier.largest, r = indexCarrier.largestRowIndex, c = indexCarrier.largestColIndex;

            //if (indexCarrier.smallest == -1) n = multiArr[1, 1]; else n = multiArr[1, 1];
            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (col == indexCarrier.largestColIndex && row == indexCarrier.largestRowIndex)
                    {
                        continue;
                    }

                    if (multiArr[row, col] <= n && multiArr[row, col] > indexCarrier.smallest)
                    {
                        n = multiArr[row, col];
                        r = row;
                        c = col;
                    }
                }
            }
            indexCarrier.smallest = n;
            indexCarrier.rowIndex = r;
            indexCarrier.colIndex = c;
            return indexCarrier;
        }
        public static indexCarrier findLargest(int[,] multiArr, int rows, int cols, indexCarrier indexCarrier)
        {
            int large = multiArr[1, 1];
            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (multiArr[row, col] > indexCarrier.largest)
                    {
                        indexCarrier.largest = multiArr[row, col];
                        indexCarrier.largestRowIndex = row;
                        indexCarrier.largestColIndex = col;
                    }
                }
            }

            return indexCarrier;
        }
        public static void SortingMultiArray2(int[,] multiArr, int rows, int cols)
        {
            indexCarrier result = new indexCarrier();
            int[,] returnArr = new int[rows, cols];
            int[] newArr = new int[(rows - 1) * (cols - 1)], newArr2 = new int[(rows - 1) * (cols - 1)];
            
            
            for (int row = 1, c = 0; row < rows; row++)
            {
                for (int col = 1; col < cols; col++, c++)
                {
                    newArr[c] = multiArr[row, col];
                }
            }
            IntArrayOperations intArrayOperations = new IntArrayOperations();

            newArr2 = intArrayOperations.MyMain(newArr);


            
            for (int row = 0, index = 0; row < rows; row++)
            {
                for (int col = 0; col < cols && index < newArr2.Length; col++)
                    {
                    if (col == 0)
                    {
                        multiArr[row, col] = row + 1;
                    }
                    else if (row == 0)
                    {
                        multiArr[row, col] = col + 1;
                    }
                    else { 
                        multiArr[row, col] = newArr2[index]; 
                        index++;
                    }

                    Console.Write(multiArr[row, col] + "|\t");

                    }
                    Console.Write("\n\n");
                }
            }

        public static void SortingMultiArray3(int[,] multiArr, int rows, int cols)
        {
            indexCarrier result = new indexCarrier();
            
            for (int row = 0, index = 0; row < rows; row++)
            {
                for (int col = 0; col < cols ; col++)
                {
                    for (int irow = 0; irow < rows; irow++)
                    {
                        for (int icol = 0; icol < cols ; icol++, index++)
                        {
                            if (col == 0)
                            {
                                multiArr[row, col] = row + 1;
                            } else 
                            if (row == 0)
                            {
                                multiArr[row, col] = col + 1;
                            } else
                            if (multiArr[row, col] < multiArr[irow, icol])
                            {
                                int temp = multiArr[row, col];
                                multiArr[row, col] = multiArr[irow, icol];
                                multiArr[irow, icol] = temp;
                            }

                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(multiArr[row, col] + "|\t");
                }
                Console.Write("\n\n");
            }

        }

    }

}
