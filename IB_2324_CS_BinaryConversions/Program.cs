using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB_2324_CS_BinaryConversions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // inputs
            // our input must be between 0 and 65535
            string uInput = "";
            int iInput = 0;
            int tempTotal = 0;

            int[][] digits = new int[2][]; // this is only for binary and octal 
            digits[0] = new int[16];
            digits[1] = new int[6];
            char[] hex = new char[4];

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please input a number between 0 - 65535");
                uInput = Console.ReadLine();

                try
                {
                    iInput = int.Parse(uInput);
                    if (iInput >= 0 && iInput <= 65535)
                        break;
                    else
                    {
                        Console.WriteLine("Please make sure the number is between 0 and 65535");
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("I said a number user... A number...");
                    Console.ReadKey();
                }
            }

            // calculating for the binary
            for (int x = 0; x < digits[0].Length; x++)
            {
                if (iInput >= Math.Pow(2, 15 - x))
                {
                    digits[0][x] = 1;
                    iInput = iInput - (int)Math.Pow(2, (digits[0].Length - 1) - x);
                }
            }

            // for display purposes
            for (int x = 0; x < digits[0].Length; x++)
            {
                Console.Write(digits[0][x]);
                if ((x + 1) % 4 == 0)
                    Console.Write(" ");
            }

            if (digits[0][0] == 1)
                digits[1][0] = 1;
            else
                digits[1][0] = 0;

            // calculating for octal from binary
            for (int x = 1; x < digits[1].Length; x++)
            {
                tempTotal = 0;
                for (int y = 1 + ((x - 1) * 3); y <= 3 + ((x - 1) * 3); y++)
                {
                    // this section will convert binary back to decimal
                    if (digits[0][y] == 1)
                    {
                        tempTotal = tempTotal + (int)Math.Pow(2, 2 - ((y - 1) % 3));
                    }
                }
                digits[1][x] = tempTotal;
            }

            Console.WriteLine();
            for (int x = 0; x < digits[1].Length; x++)
            {
                Console.Write(digits[1][x]);
            }

            // calculating for hex from binary
            for (int x = 0; x < hex.Length; x++)
            {
                tempTotal = 0;
                for (int y = 0 + (x * 4); y < 4 + (x * 4); y++)
                {
                    // this section will convert binary back to decimal
                    if (digits[0][y] == 1)
                    {
                        tempTotal = tempTotal + (int)Math.Pow(2, 3 - (y % 4));
                    }
                }
                #region Hex the long way
                //if(tempTotal == 0)
                //{
                //    hex[x] = '0';
                //}
                //else if (tempTotal == 1)
                //{
                //    hex[x] = '1';
                //}
                //else if (tempTotal == 2)
                //{
                //    hex[x] = '2';
                //}
                //else if (tempTotal == 3)
                //{
                //    hex[x] = '3';
                //}
                //else if (tempTotal == 4)
                //{
                //    hex[x] = '4';
                //}
                //else if (tempTotal == 5)
                //{
                //    hex[x] = '5';
                //}
                //else if (tempTotal == 6)
                //{
                //    hex[x] = '6';
                //}
                //else if (tempTotal == 7)
                //{
                //    hex[x] = '7';
                //}
                //else if (tempTotal == 8)
                //{
                //    hex[x] = '8';
                //}
                //else if (tempTotal == 9)
                //{
                //    hex[x] = '9';
                //}
                //else if (tempTotal == 10)
                //{
                //    hex[x] = 'A';
                //}
                //else if (tempTotal == 11)
                //{
                //    hex[x] = 'B';
                //}
                //else if (tempTotal == 12)
                //{
                //    hex[x] = 'C';
                //}
                //else if (tempTotal == 13)
                //{
                //    hex[x] = 'D';
                //}
                //else if (tempTotal == 14)
                //{
                //    hex[x] = 'E';
                //}
                //else if (tempTotal == 15)
                //{
                //    hex[x] = 'F';
                //} 
                #endregion

                if (tempTotal >= 0 && tempTotal < 10)
                    hex[x] = (char)(tempTotal + 48);
                else if (tempTotal >= 10 && tempTotal < 16)
                    hex[x] = (char)(tempTotal + 55);
            }

            Console.WriteLine();
            for (int x = 0; x < hex.Length; x++)
            {
                Console.Write(hex[x]);
            }


            Console.ReadKey();
        }
    }
}