using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet2022.ExtensionExcepcionPrueba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----Punto 1-----");
            Console.WriteLine("\n");
            int divisor;
            Console.WriteLine("Ingrese un valor del divisor:");
            divisor = int.Parse(Console.ReadLine());

            Console.WriteLine(Dividir(divisor));


            Console.WriteLine("-----Fin Punto 1------");
            Console.WriteLine("\n");
            Console.WriteLine("-----Punto 3-----");
            Console.WriteLine("\n");

            //Codigo correspondiente al punto 3
            try
            {
                Logic.AdivinarNumeroAleatorio();
            }
            catch (FormatException fex)
            {
                Console.WriteLine(fex.Message);
                string tipo = fex.GetType().Name.ToString();
                Console.WriteLine($"La Excepcion es del tipo: {tipo}");

            }
            finally
            {
                Console.WriteLine("La operacion ha finalizado");
            }




            Console.ReadKey();


        }


        /*Metodo correspondiente al Punto 1*/
        static int Dividir(int divisor)
        {

            try
            {
                int dividendo = 100;
                int resultado;



                resultado = dividendo / divisor;


                Console.WriteLine("El resultado es:" + resultado);

            }
            /*catch(DivideByZeroException dex)
            {
                Console.WriteLine(dex.Message);
            }*/
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);


            }
            finally
            {
                Console.WriteLine("La operacion a finalizado");


            }

            return 0;

        }
    }
    
}
