using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LabNet2022.ExtensionExcepcionPrueba;
namespace PruebaUnidadDivision
{
    // Prueba de unidad y casos de prueba correspondientes al Punto 2
    [TestClass]
    public class PruebaDivision
    {
        //Caso de prueba para division exitosa
        [TestMethod]
        public void Div_DivisionExitosa()
        {
            //Arrange
            int dividendo = 100;
            int divisor = 2;
            
            int resultadoEsperado = 50;

            CalcularDivision CalcDiv = new CalcularDivision();

            //Act

            int resultado = CalcDiv.Division(dividendo, divisor);

            //Assert

            Assert.AreEqual(resultadoEsperado, resultado);


        }
        //Caso de prueba para division con parametros 2 resultados positivos y uno negativo
        [TestMethod]
        [DataRow(100,2,50)]
        [DataRow(500,10,50)]
        [DataRow(100,2,40)]
            
        public void Div_DivisionExitosaParametros(int n,int d, int q )
        {
            Assert.AreEqual(q, n / d);

            
        }

        //Caso de prueba para dividir por cero


        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Div_ExcepcionDividirCero()
        {
            //Arrange

            int dividendo = 100;
            int divisor = 0;

            CalcularDivision CalcDiv=new CalcularDivision();
             
            //Act

            CalcDiv.Division(dividendo, divisor);

        }

        //Caso de prueba para valores nulos
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Div_ExcepcionDividirNulos()
        {
            //Arrange

            CalcularDivision CalcDiv = new CalcularDivision();

            //Act

            CalcDiv.Division(null, null);

        }

        
       

        

    }
}
