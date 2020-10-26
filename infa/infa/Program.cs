using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace infa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Число"); //3A7
            string num = Console.ReadLine();

            Console.WriteLine("Разряд"); //16
            int discharge = Convert.ToInt32(Console.ReadLine());

            num = Convert.ToString(Search10(num,discharge));
            Console.WriteLine(num);




            num = Search(Convert.ToInt32(num));

            num = Rev(num);


            Console.WriteLine(num);
            
           

        }

        static double Search10(string num , int discharge) //перевод 10 
        {
            

            char[] ch = new char[num.Length];

            for(int i = 0;i<num.Length; i++)
            {
                ch[i] = num[i];
            }


            int a = 0;
            double sum=0;

            for (int i = num.Length-1; i>=0; i--)
            {

                if (ch[i] < 58 && ch[i] > 47) 
                    ch[i] -= (char)48;

                if (ch[i] < 91 && ch[i] > 64)
                    ch[i] -= (char)55;

                sum += ch[i] * Math.Pow(discharge, a);
                a += 1;
            }

            return sum;

        }

        static string Search(int num) //перевод в 2
        {
            string numTwo = "";
            while (num != 1)
            {
                numTwo += $"{num % 2}";
                num /= 2;

            }
            numTwo += "1";
            return Search0(numTwo);
            
        }
        static string Search0(string numTwo) // добавка 0
        {

            
            int a = 0;
            for (int i = 1; i < numTwo.Length;)
            {
                i *= 2;
                a = i;
            }

            int b = a - numTwo.Length;

            for (int i = 0; i < b; i++)
            {
                numTwo += "0";
            }
            return numTwo;
        }


        static string Rev(string numTwo) //переворот 1010101
        {
            string res = "";
            for (int i = numTwo.Length - 1; i >= 0; i--)
            {
                res += numTwo[i];
            }
            return res;
        }

    }
}
