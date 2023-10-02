using System;

namespace Laba_4_V_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber a = new ComplexNumber(-1, 2);
            ComplexNumber b = new ComplexNumber(3, 2.4);
            ComplexNumber c = new ComplexNumber(0, -0.3);
            ComplexNumber d = new ComplexNumber(1, 1);
            Console.WriteLine("a="+a);
            Console.WriteLine("b=" + b);
            Console.WriteLine("c=" + c);
            Console.WriteLine("d=" + d);

            ComplexNumber result = a.GetRootPower(3) - (b + c) / a + b * d;
            Console.WriteLine("r=a^(1/3)-(b+c)+b*d");
            
            if(result is not null)
            {
                Console.WriteLine("r=" + result);
                Console.WriteLine("Модуль числа r = " + result.GetModule());
                Console.WriteLine("r++");
                result++;
                Console.WriteLine("r=" + result);
            }
            else
            {
                Console.WriteLine("Не получилось выполнить операцию и найти r");
            }
        }
    }
}
