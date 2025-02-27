using System.Collections.Immutable;
using System.Xml.Schema;

namespace Y10_Challenge_Kaprikars_Constant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Kaprekar's Constant is 6174
            //1. take a 4 digit start number using at least two different digits...e.g. 9218
            //2. order the digits descending 4321, then ascending to get two 4 digit numbers (add leading zeros if needed)
            //3. subtract smaller number from bigger number e.g. 9821-1289=8532
            //4. Go back to step 2 replacing start number with result of step 3, repeat until numbers converge to 6174

            //Task: Write a program to compute Kaprekar's constant using any four digit start number
            //Ext: Display the number of iterations needed until 6174 is reached

            Console.WriteLine("Enter four digit number:");
            string x = Console.ReadLine();
            while (Convert.ToInt32(x) <= 0 || Convert.ToInt32(x) >= 9999 || x.Length != 4)
            {
                Console.WriteLine("Invalid. Enter again.");
                x = Console.ReadLine();
            }
            char[] xArr = x.ToCharArray();
            char temp = ' ';

            while (x != "6174")
            {
                bool swap = true;
                while (swap == true)
                {
                    swap = false;
                    for (int i = 0; i < xArr.Length - 1; i++)
                    {
                        if (xArr[i] > xArr[i + 1])
                        {
                            temp = xArr[i];
                            xArr[i] = xArr[i + 1];
                            xArr[i + 1] = temp;
                            swap = true;
                        }
                    }
                }
                char[] xArrReverse = xArr.Reverse().ToArray(); //REVERSES → DESCENDING
                string xReverse = new string(xArrReverse); //USED FOR SUBTRACTION (DESCENDING)
                string xNotAnArr = new string(xArr); //USED FOR SUBTRACTION (ASCENDING)
                x = Convert.ToString(Convert.ToInt32(xReverse) - Convert.ToInt32(xNotAnArr));
                Console.WriteLine(xReverse + " - " + xNotAnArr + " = " + x);
                xArr = x.ToCharArray();
            }
            Console.WriteLine("6174: Kaprekar's Constant");
        }
    }
}
