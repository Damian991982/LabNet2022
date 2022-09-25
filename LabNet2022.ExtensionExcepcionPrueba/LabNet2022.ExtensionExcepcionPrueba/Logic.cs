using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet2022.ExtensionExcepcionPrueba
{
    internal class Logic
    {
        public static void AdivinarNumeroAleatorio()
        {

            Random numero=new Random();

            int aleatorio = numero.Next(0, 100);

            int minumero=0;

            int intentos = 0;

            Console.WriteLine("Introduce un numero entre 0 y 100");

            

            do
            {
                intentos++;

                try
                {
                    minumero = int.Parse(Console.ReadLine());
                    if(!(minumero < 0 && minumero > 100))
                    {
                        throw new ExcepcionPersonalizada("El numero esta fuera de rango");
                    }


                  



            }
                catch (FormatException fex)
                {

                    throw fex;
                }

                catch (ExcepcionPersonalizada ex)
                {
                    Console.WriteLine(ex.Message);
                }


                if (minumero > aleatorio) Console.WriteLine("El numero es mas bajo");

                if (minumero < aleatorio) Console.WriteLine("El numero es mas alto");

            } while (aleatorio != minumero);

            Console.WriteLine($"Correcto! Has necesitado {intentos} intentos");

            Console.WriteLine("A partir de esta linea de codigo el programa continuaria");











        }

        public static void ThrowExceocionPersonalizada()
        {
            throw new ExcepcionPersonalizada("El numero es muy grande");
        }


    }
}
