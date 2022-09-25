using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet2022.ExtensionExcepcionPrueba
{
    internal class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada(string mensaje) : base("Mensaje de error de Excepcion Personalizada")
        {
           this.Mensaje = mensaje;
        }

        public string Mensaje { get; set; }
    }
}
