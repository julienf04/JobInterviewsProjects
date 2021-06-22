using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplificacion_de_fracciones
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        private static List<int> primeNumbers = new List<int>() { 2, 3 };


        public int Numerator
        {
            get { return numerator; }
        }

        public int Denominator
        {
            get { return denominator; }
        }

        public Fraction()
        {

        }

        public Fraction(int numerator, int denominator)
        {
            numerator = this.numerator;
            denominator = this.denominator;
        }

        public static Fraction InputFraction()
        {
            Fraction fractionToReturn = new Fraction();
            string userInputs;
            string errorMessage = "Su valor ingresado debe ser un numero entero distinto de 0";

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Ingrese el numerador (el numero de arriba o la izquierda):");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("-------- ");
                Console.ForegroundColor = ConsoleColor.Gray;
                userInputs = Console.ReadLine();


                try
                {
                    fractionToReturn.numerator = Convert.ToInt32(userInputs);

                    if (fractionToReturn.numerator == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(errorMessage);
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                }

            } while (fractionToReturn.numerator == 0);


            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Ingrese el denominador (el numero de abajo o la derecha):");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("-------- ");
                Console.ForegroundColor = ConsoleColor.Gray;
                userInputs = Console.ReadLine();

                try
                {
                    fractionToReturn.denominator = Convert.ToInt32(userInputs);

                    if (fractionToReturn.denominator == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(errorMessage);
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                }

            } while (fractionToReturn.denominator == 0);

            Console.ResetColor();
            return fractionToReturn;
        }


        public static Fraction Simplify(Fraction fraction)
        {
            int iteration = 0;
            int minorNumber;
            minorNumber = fraction.numerator < fraction.denominator ? minorNumber = fraction.numerator : minorNumber = fraction.denominator;

            while (true)
            {
                if (fraction.numerator % primeNumbers[iteration] == 0 && fraction.denominator % primeNumbers[iteration] == 0)
                {
                    fraction.numerator /= primeNumbers[iteration];
                    fraction.denominator /= primeNumbers[iteration];
                    minorNumber /= primeNumbers[iteration];
                }
                else if (Math.Abs(minorNumber) > primeNumbers[iteration])
                {
                    iteration++;

                    if (iteration == primeNumbers.Count) primeNumbers.Add(NextPrimeNumber());
                }
                else
                {
                    return fraction;
                }
            }
        }


        static int NextPrimeNumber()
        {
            int newPrimeNumber = primeNumbers[primeNumbers.Count - 1] + 2;
            int sqrtNewPrimeNumber = (int)Math.Sqrt((double)newPrimeNumber);

            int iteration = 0;
            while (sqrtNewPrimeNumber > primeNumbers[iteration])
            {
                if (newPrimeNumber % primeNumbers[iteration] == 0) //Division exacta, no es primo
                {
                    newPrimeNumber += 2;
                    sqrtNewPrimeNumber = (int)Math.Sqrt((double)newPrimeNumber);
                    iteration = 0;
                }
                iteration++;
            }

            primeNumbers.Add(newPrimeNumber);
            return newPrimeNumber;
        }


        public override string ToString()
        {
            return denominator == 1 ? Convert.ToString(numerator) : (denominator == -1) ? Convert.ToString(-numerator) : numerator + "/" + denominator;
        }
    }
}