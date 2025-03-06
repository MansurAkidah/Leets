using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets.Leizam
{
    public class IntArrayOperations
    {
        public int[] MyMain(int[] predefinedArr)
        {
            #region Declaration of variables
            Random rnd = new Random();
            int size = 20;
            int[] nums20 = new int[size];
            int count = 0, temp = 0;
            int index = 0, smallest = int.MinValue;
            int[] ints = predefinedArr ?? nums20,
                  arr = predefinedArr == null ? new int[nums20.Length] : new int[predefinedArr.Length] ; 
            #endregion

            #region Generating and displaying
            if(predefinedArr == null)
            {

                Console.WriteLine("Displaying the generated random numbers");

                for (int i = 0; i < nums20.Length; i++)
                {
                    nums20[i] = rnd.Next(1, 101);
                    Console.Write(nums20[i] + ", ");
                }

                Console.WriteLine(IsSorted(nums20) ? "\nOg array is sorted" : "\nOg array is not sorted");

            }
            #endregion


            do
            {
                var result = findSmallest(ints);
                smallest = result.small;
                index = result.ind;

                arr[count] = smallest;
                int[] newArr = removeSmallest(new int[ints.Length - 1], ints, index);//return an arr with one less
                ints = new int[ints.Length - 1];
                ints = assign(ints, newArr);

                count++;

            } while (count < arr.Length);

            display(arr);
            Console.WriteLine(IsSorted(arr) ? "\nNew array is sorted" : "\nNew array is not sorted");
            //Console.ReadLine();
            return arr;

        }
        public class twoInts
        {
            public int small { get; set; }
            public int ind { get; set; }
        }
        public static twoInts findSmallest(int[] nums)
        {
            int smallest = nums[0], index = 0;
            if (nums.Length == 0) return new twoInts { small = smallest, ind = index };

            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] < smallest)
                {
                    smallest = nums[j];
                    index = j;
                }
            }

            return new twoInts { small = smallest, ind = index };
        }
        public static int[] assign(int[] nums, int[] numsOg)
        {

            for (int j = 0; j < nums.Length; j++)
            {
                nums[j] = numsOg[j];
            }

            return nums;
        }
        public static int[] removeSmallest(int[] nums, int[] numsOg, int index)
        {

            for (int j = 0, i = 0; j < numsOg.Length; j++, i++)
            {
                if (j == index)
                {
                    i--;
                    continue;
                }
                nums[i] = numsOg[j];
            }

            return nums;
        }
        public static bool IsSorted(int[] nums)
        {
            for (int j = 0; j < nums.Length - 1; j++)
            {
                if (nums[j] > nums[j + 1])
                {
                    return false;
                }
            }

            return true;
        }
        public static void display(int[] n)
        {
            Console.Write($"\n\nDisplaying the sorted array of random numbers\n");
            foreach (int i in n) { Console.Write(i + ", "); }
        }
    }
}
