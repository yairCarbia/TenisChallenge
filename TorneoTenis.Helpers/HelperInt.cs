using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TorneoTenis.Helpers
{
    public static class HelperInt
    {

        /// <summary>
        /// Verifica si un numero entero es una potencia de 2.
        /// </summary>
        /// <param name="value">El número entero que se desea verificar.</param>
        /// <returns>
        /// true si el numero es una potencia de 2.De lo contrario false.
        /// </returns>
        public static bool EsPotenciaDeDos(this int value)
        {
            if (value <= 0) return false;
            return (value & (value - 1)) == 0;
        }

    }
}
