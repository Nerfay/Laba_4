using System;


namespace Laba_4_V_1
{
    public class ComplexNumber
    {
        private double _realPart;
        private double _imaginaryPart;

        /// <summary>
        /// Свойтво действительной части
        /// </summary>
        private double RealPart
        {
            get => _realPart;
            set => _realPart = value;
        }
        /// <summary>
        /// Свойтво мнимой части
        /// </summary>
        private double ImaginaryPart
        {
            get => _imaginaryPart;
            set => _imaginaryPart = value;
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="realPart"> действительная часть комплексного числа </param>
        /// <param name="imaginaryPart"> мнимая  часть комплексного числа </param>
        public ComplexNumber(double realPart, double imaginaryPart)
        {
            RealPart = realPart;
            ImaginaryPart = imaginaryPart;
        }
        /// <summary>
        /// вычисление модуля комплексного числа
        /// </summary>
        /// <returns></returns>
        public double GetModule()
        {
            return Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);
        }
        /// <summary>
        /// вычисление корня n-ой степени комплексного числа
        /// </summary>
        /// <param name="n">степень корня (натуральное число) ; sqrt(a)=a^1/2 в єтом случае n=2 </param>
        /// <returns>первое комплексное число из множества корней</returns>
        public ComplexNumber GetRootPower(int n)
        {
            if (n > 0)
            {
                double radius = Math.Pow(GetModule(), 1 / n);
                double angelPhi = Math.Atan(ImaginaryPart / RealPart);
                double realNumber = Math.Cos(angelPhi / n) * radius;
                double imaginaryNumber = Math.Sin(angelPhi / n) * radius;
                return new ComplexNumber(realNumber, imaginaryNumber);
            }
            else
            {
                throw new ArgumentException($"Не удалось вычисленить корень n-ой степени комплексного числа={this} :\n n={n}- не натуральное число");
            }
        }
        public static ComplexNumber operator +(ComplexNumber firstComplexNumber, ComplexNumber secondComplexNumber)
        { 
            if(firstComplexNumber is null || secondComplexNumber is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return new ComplexNumber(firstComplexNumber.RealPart + secondComplexNumber.RealPart, firstComplexNumber.ImaginaryPart + secondComplexNumber.ImaginaryPart);
            }
        }

        public static ComplexNumber operator -(ComplexNumber firstComplexNumber, ComplexNumber secondComplexNumber)
        {
            return firstComplexNumber + new ComplexNumber(-secondComplexNumber.RealPart, -secondComplexNumber.ImaginaryPart);
        }
        public static ComplexNumber operator *(ComplexNumber firstComplexNumber, ComplexNumber secondComplexNumber)
        {
            if (firstComplexNumber is null || secondComplexNumber is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                double realNumber = firstComplexNumber.RealPart*secondComplexNumber.RealPart -firstComplexNumber.ImaginaryPart*secondComplexNumber.ImaginaryPart;
                double imaginaryNumber = firstComplexNumber.RealPart * secondComplexNumber.ImaginaryPart + firstComplexNumber.ImaginaryPart * secondComplexNumber.RealPart; ;
                return new ComplexNumber(realNumber, imaginaryNumber);
            }
        }
        public static ComplexNumber operator /(ComplexNumber firstComplexNumber, ComplexNumber secondComplexNumber)
        {
            if (firstComplexNumber is null || secondComplexNumber is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                if(secondComplexNumber.RealPart + secondComplexNumber.ImaginaryPart != 0)
                {
                    double denominator = secondComplexNumber.RealPart * secondComplexNumber.RealPart + secondComplexNumber.ImaginaryPart * secondComplexNumber.ImaginaryPart;
                    double realNumber = (firstComplexNumber.RealPart * secondComplexNumber.RealPart + firstComplexNumber.ImaginaryPart * secondComplexNumber.ImaginaryPart) / denominator;
                    double imaginaryNumber = (secondComplexNumber.RealPart * firstComplexNumber.ImaginaryPart - firstComplexNumber.RealPart * secondComplexNumber.ImaginaryPart) / denominator;
                    return new ComplexNumber(realNumber, imaginaryNumber);
                }
                else
                {
                    throw new DivideByZeroException();
                }
            }
        }

        public static ComplexNumber operator ++(ComplexNumber complexNumber)
        {
            if (complexNumber is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return new ComplexNumber(complexNumber.RealPart +1 , complexNumber.ImaginaryPart +1);
            }
        }

        public override string ToString()
        {
            string realPartStr = RealPart == 0 ? "" : "" + RealPart;
            string imaginePartStr = ImaginaryPart == 0 ? "" : ImaginaryPart + "i";
            string symbol = ImaginaryPart > 0 && (realPartStr !="" || imaginePartStr!="") ? "+" : "";

            return realPartStr+" "+symbol+ imaginePartStr;
        }
    }
}
