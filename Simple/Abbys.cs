using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets.Simple
{
    public class Abbys
    {
        public void MyMain()
        {
            int value, gap = 0, largeCoun = 0, ones = 0;



            do
            {
                Console.Write("Number = ");


                value = int.Parse(Console.ReadLine());

                gap = Gap(value);

                Console.WriteLine($"gap :{gap} \n");
            } while (true);


            Console.ReadLine();
        }

        static int Gap(int N)
        {
            int gap = 0, coun = 0;

            string binary = Convert.ToString(N, 2);
            Console.WriteLine($"Number convert to binary is : {binary}");

            foreach (char i in binary)
            {
                if (i == '1')
                {
                    if (coun > gap) gap = coun;
                    coun = 0;
                }
                else coun++;
            }
            return gap;
        }

    }
}
