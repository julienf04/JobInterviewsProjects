using System;

namespace validacion_de_nombres
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Utilities.InputName();

            Console.WriteLine(Utilities.ValidateName(name));
        }
    }
}
