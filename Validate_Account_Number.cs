/*
 * Author : Nhlakanipho Michael Mqadi
 * Email  : nhlaka.id@gmail.com
 * Cell   : 073 561 5140 / 079 905 0821
 */

using System;

namespace UseCaseTwo
{
    class Program
    {
        static string msg = "Enter Account Number";
        static void Main(string[] args)
        {
        

            //run an automatic test (from the provided test data)
            AutoTest(TestData());

            //OR
            //uncomment ManualTest method to manually input account numbers
            //ManualTest();
            
            Console.ReadKey();

        }

        static void ManualTest()
        {
            EnterA:
            Console.WriteLine(msg);
            string accno = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(accno) || !(accno.Length == 10))
            {
                msg = "Please enter an Account number";
                goto EnterA;
            }

            Console.WriteLine("\n\nAccount Number: {0} \nResult: {1}", accno, accno);
        }

        //return whether the account number is Valid or Invalid 
        static string Validate(string accno)
        {
            int numbers = 00000000;

            //validate if account number is a valid format

            if (!accno.Substring(0, 2).ToLower().Equals("cf"))
            {
                return msg = "Invalid";
                
            }
            else if (!int.TryParse(accno.Substring(2, 8), out numbers))
            {
                return msg = "Invalid";
            }

            //calculate the weighting of 3 to 9
            char[] arr = accno.Substring(2, 7).ToCharArray();

            int[] numbersArray = new int[7];

            for (int x = 0; x < arr.Length; x++)
            {
                numbersArray[x] = int.Parse(arr[x].ToString());
            }

            //calculate the sum of character 3 to 9
            int checkTotal = 0;

            for (int x = 0; x < numbersArray.Length; x++)
            {
                checkTotal += CalcProduct(x, numbersArray[x]);
            }

            //check if the 10th value is valid 

            if (int.Parse(accno.Substring(9,1)) == Calc10th(checkTotal))
            {
                return msg = "Valid";
            }
            else
            {
                return msg = "Invalid";
            }

        }


        //Calculate the 10th value
        static int Calc10th(int sum)
        {
            return 10 - (sum % 10);
        }


        //calculate the product of each number by it Weighting
        static int CalcProduct(int position, int number)
        {
            int tot = 0;

            switch (position)
            {
                case 0:
                    tot = number * 1;
                    break;
                case 1:
                    tot = number * 3;
                    break;
                case 2:
                    tot = number * 7;
                    break;
                case 3:
                    tot = number * 1;
                    break;
                case 4:
                    tot = number * 3;
                    break;
                case 5:
                    tot = number * 7;
                    break;
                case 6:
                    tot = number * 1;
                    break;
            }

            return tot;
        }

        //provided test data
        static string[] TestData()
        {
             string[] test = {
                "CF00000019",
                "CF00000176",
                "CF00000242",
                "CF00000439",
                "CF00000532",
                "CF00000017",
                "CF00000240",
                "CF00000277",
                "CF00000383",
                "CF00000538" };

            return test;
        }

        //run an automatic test
        static void AutoTest(string[] testArr)
        {
            for(int i = 0; i < testArr.Length; i++)
            {
                Console.WriteLine("\n\nAccount Number: {0} \nResult: {1}", testArr[i], Validate(testArr[i]));
            }
        }
    }
}
