using System;
using System.Linq;

namespace Simplificacion_de_fracciones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   Programa para simplificar fracciones");
            Console.WriteLine();

            Fraction f = Fraction.InputFraction();

            Console.WriteLine(Fraction.Simplify(f));
        }
    }
}