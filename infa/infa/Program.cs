using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Channels;
using System.Xml.XPath;

namespace infa
{
    class Program
    {
        static void Main(string[] args)//Выберете задание: \n1)Перевод целых чисел из любой системы счисления в любую другую. \n2)Перевод целых чисел в римскую систему счисления. \n3)Перевод вещественных чисел
        {
           // Console.WriteLine("1)Перевод целых чисел из любой системы счисления в любую другую.");
           // StartOneJobs();

            // Console.WriteLine("2)Перевод целых чисел в римскую систему счисления.");
           //  RSS();

           Console.WriteLine("3)Перевод вещественных чисел.");
           RealNumber();

        }

        static void StartOneJobs()
        {
           

            Console.WriteLine("Число"); //3A7
            string num = Console.ReadLine();

            Console.WriteLine("Разряд от 0 до 50"); //16
            int raz1 = Convert.ToInt32(Console.ReadLine());
            if (raz1 > 50)
                Console.WriteLine("Фу таким быть, вы всё сломали перезапускайте программу");


            if (check(num, raz1))
            {
                Console.WriteLine("Разраяд не подходит");
                return;
            }

            Console.WriteLine("Желаемый разряд  от 0 до 50"); //16
            int raz2 = Convert.ToInt32(Console.ReadLine());
            if (raz2>50)
                Console.WriteLine("Фу таким быть, вы всё сломали перезапускайте программу");

            num = Convert.ToString(Search10(num, raz1));
            
            num = Transformation(Convert.ToInt32(num), raz2);

            Console.WriteLine($"\nОтвет: {num}");

        }

        static bool check(string num, int raz1)
        {
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] > 65 + raz1 - 10) 
                    return true;
            }

            return false;
        }


        static double Search10(string num , int raz1) //перевод в 10 
        {
            Console.WriteLine("\nПеревод в 10 систему счисления");

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

                Console.WriteLine($"{sum} + {Convert.ToInt32(ch[i])} * {raz1}^{a} = {ch[i] * Math.Pow(raz1, a)} ");

                sum += ch[i] * Math.Pow(raz1, a);
                a += 1;
            }
            Console.WriteLine($"{num} в 10 ричной системе : {sum}\n");
            return sum;

        }

        static string Transformation(int num,int raz2) // Jooooooobs
        {
            Console.WriteLine($"\nПеревод в {raz2} систему счисления");

            int a = 1;

            for (int i = num; i > raz2; i/=raz2)
            {
                a++;
            }


            char[] numTwo = new char[a];

            string st = "";

            for (int i = 0; num > raz2; i++)
            {
                int x = num % raz2;

                if (x >= 10)
                    x += 55;

                if (x <= 9)
                    x += 48;

                numTwo[i] = (char)x;


                Console.WriteLine($"{num} / {raz2} =  {num / raz2} | остаток {num % raz2}");
                num /= raz2;
                st += Convert.ToString(numTwo[i]);
            }
            st += num;
            Console.WriteLine($"{num} / {raz2} = {0} | остаток {num}");

            Console.WriteLine($"Получаем {st} и переворачиваем её");

            return Rev(st);

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

      

        static void RSS()
        {

            int[] rim = { 5000, 4000, 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] arab = { "(!V)",  "(!IV)", "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};

            Console.WriteLine("Введите число от 0 до 5999");
            int input = Convert.ToInt32(Console.ReadLine());
            int i;
            i = 0;
            string output = "";
            while (input > 0)
            {
                if (rim[i] <= input)
                {
                    Console.WriteLine($"\n{input} - {rim[i]} = {input - rim[i]}");
                    Console.WriteLine($"{output} + {arab[i]} = {output + arab[i]}\n");

                    input = input - rim[i];
                    output = output + arab[i];
                }
                else i++;

            }

            Console.Write($"{input} в РСС = {output}");
            Console.ReadKey();

        }

        static void RealNumber()
        {
            Console.WriteLine("Введите дробное число");
            string input=Console.ReadLine();
            string[] num = input.Split('.', ',');

            char ch = ' ';
            if (input[0] == '-')
                ch = input[0];
            else
                ch = '+';


            string oneNum = num[0];
            string twoNum = num[1];

            twoNum = SearchTwoSysNull(oneNum, input, oneNum.Length);
            oneNum = SearchTwoSys(oneNum);
            Console.WriteLine($"Получаем {oneNum}");

            Console.WriteLine($"\nСоединяем части дроби получаем {oneNum + twoNum}");

            string newOneNum = "";
            if (ch == '+' && oneNum[0] == '1')
            {
                newOneNum += 0;
                for (int i = 1; i < oneNum.Length; i++)
                    newOneNum += oneNum[i];
            }
            else
                newOneNum = oneNum;

            Console.WriteLine("\nЕсли дробь была отрицательной, то первый символ меняем на еденицу");
            Console.WriteLine($"После изменений если они были: {newOneNum},{twoNum}");

            Console.WriteLine($"\nПередвигаем запятую к 1 сиволу и считаем на сколько сиволов мы перенесли 1\nПеренсли запятую на {newOneNum.Length - 1} символов"); ;


            Console.WriteLine($"\nНаходим смещённый порядок (чтоб найти порядок надо 127 ){127+newOneNum.Length - 1} и переводим в двоичную систему\n");
            int ordo = 127 + newOneNum.Length - 1;
            string stOrdo = Convert.ToString(ordo);
            stOrdo = SearchTwoSys(stOrdo);


            string jons = newOneNum + twoNum;

            string output = "";
            output += jons[0];

            output += stOrdo;

            for (int i = 1; i < 30 - stOrdo.Length; i++)
            {
                output += jons[i];
            }

            Console.WriteLine($"\n\nОтвет сокращаем до 31 символа : {output}");

        }

        static string SearchTwoSys(string oneNum) //перевод в 2
        {
            Console.WriteLine($"Переводим {oneNum} в двоичную систему");

            int num = Convert.ToInt32(oneNum);
            string output = "";
            
            if (num != 0)
            {
                while (num != 1)
                {
                    Console.WriteLine($"{num} / 2 =  {num / 2} | остаток {num % 2}");
                    output += $"{num % 2}";
                    num /= 2;
                }
                Console.WriteLine("Добавляем 1 и переворачиваем");
                output += "1";
                return Rev(output);
            }
            return "0";
        }

        static string SearchTwoSysNull(string oneNum,string twoNum, int lengthOneNum)
        {
            double num = Convert.ToDouble(twoNum)-Convert.ToDouble(oneNum);

            Console.WriteLine($"Переводим {Math.Round(num, 2)} в двоичную систему") ;

            string output = "";
            

            for(int i = 0; i< 31-lengthOneNum; i++)
            {
                Console.Write($"{Math.Round(num, 2)} * 2 = {Math.Round(num*2, 2)}");
                num *= 2;

                
                    if (num >= 1)
                    {
                        output += 1;
                        num -= 1;
                    }
                    else
                        output += 0;
                
                Console.WriteLine($"");
            }
            Console.WriteLine($"\nДробная часть в двоичном в виде: {output} \n");
            return output ;

        }
    }
}
