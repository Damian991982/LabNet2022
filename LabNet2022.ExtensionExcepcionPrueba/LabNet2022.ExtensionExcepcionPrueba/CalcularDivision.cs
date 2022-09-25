using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNet2022.ExtensionExcepcionPrueba
{
    
    public class CalcularDivision
    {
        public int Division(int? dividendo,int? divisor)
        {
            if (dividendo == null)
            {
                throw new ArgumentNullException(nameof(dividendo));
            }
            if (divisor == null)
            {
                throw new ArgumentNullException(nameof(divisor));
            }

            
            return dividendo.Value / divisor.Value;
        }
    }
}
