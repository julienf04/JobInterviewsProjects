using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace validacion_de_nombres
{
    static class Utilities
    {
        public static bool ValidateName(string name)
        {
            string[] namesSplitted = Regex.Split(name, " ");

            if ((namesSplitted.Length == 2 || namesSplitted.Length == 3) && !namesSplitted.Contains(""))
            {
                foreach (string name2 in namesSplitted)
                {
                    if (!Regex.IsMatch(name2[0].ToString(), "[A-Z]") || Regex.IsMatch(name2.Remove(0), "[A-Z]")) return false;
                }

                if (!namesSplitted[namesSplitted.Length - 1].Contains('.') && namesSplitted[namesSplitted.Length - 1].Length >= 2)
                {
                    if (ValidateOnlyNames(namesSplitted)) return true;
                }
            }

            return false;
        }
        public static string InputName()
        {
            Console.WriteLine("  Coloque aquí un nombre válido por favor", Console.ForegroundColor = ConsoleColor.Green);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("#TIP: Un nombre válido pueden ser: ");
            Console.WriteLine("Su primer nombre y apellido completos");
            Console.WriteLine("Su primer nombre abreviado y su apellido completo");
            Console.WriteLine("Su primer y segundo nombre, y su apellido completos");
            Console.WriteLine("Su primer y segundo nombre abreviados, y su apellido completos");
            Console.WriteLine("Su primer nombre completo, su segundo nombre abreviado, y su apellido completos");

            Console.ResetColor();

            Console.Write("----- ");


            return Console.ReadLine();
        }

        static bool ValidateOnlyNames(string[] names)
        {
            const byte INVALID_CASE = 2;

            byte possibleCombinations = 0;

            byte icombination = (byte)(names.Length - 1);
            for (int i = 0; i < names.Length - 1; i++)
            {
                bool nameContainsPoint = names[i].Contains('.');

                if (names[i].Length < 2 || (nameContainsPoint && names[i].Length > 2)) return false;
                else if (nameContainsPoint && names[i].Length == 2) possibleCombinations += icombination;

                icombination--;
            }

            return possibleCombinations == INVALID_CASE ? false : true;
        }
    }
}
