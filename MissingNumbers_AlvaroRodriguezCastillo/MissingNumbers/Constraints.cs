using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MissingNumbers
{
    public class Constraints
    {
        #region Constraints

        /// <summary>
        /// Metodo que verifica si la lista cumple con el tamaño requerido.       
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static bool VerificarTamanoLista(IList<int?> lst)
        {
            // Constraint: 1 <= n,m, <= 2 * 10⁵

            // obtenemos el tamaño maximo que puede tener la lista
            double MaxSizeList = 2 * Math.Pow(10, 5);
            // realizamos la comparación correspondiente
            if (lst.Count >= 1 && lst.Count <= MaxSizeList)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Metodo que compara el tamaño entre listas 
        /// </summary>
        /// <param name="firstlist"></param>
        /// <param name="secondlist"></param>
        /// <returns></returns>
        public static bool CompararTamanoEntreListas(IList<int?> firstlist, IList<int?> secondlist)
        {
            // Constraint: n <= m
            if (secondlist.Count >= firstlist.Count)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Metodo que verifica los valores dentro de la lista
        /// </summary>
        /// <param name="secondlist"></param>
        /// <returns></returns>
        public static bool VerificarValoresLista(IList<int?> secondlist)
        {
            bool bResult = false;
            // Constraint: 1 <= x <= 10⁴, x ε B
            double MaxValorPermitido = Math.Pow(10, 4);
            foreach (int x in secondlist)
            {
                if (x >= 1 && x <= MaxValorPermitido)
                    bResult = true;
                else
                {
                    bResult = false;
                    break;
                }
            }

            return bResult;
        }

        /// <summary>
        /// The difference between maximum and minimum number in B is less than or equal to 100.
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static bool VerificarMaxAndMin(IList<int?> lst)
        {
            // Xmax - Xmin < 101
            int iMax = lst.Max(r => r.Value);
            int iMin = lst.Min(r => r.Value);

            if ((iMax - iMin) > 100)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Metodo que verifica si la cadena contiene un número válido
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        public static bool VerificaNumero(String strNumero)
        {
            Regex objNotIntPattern = new Regex("[^0-9-]");
            Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return !objNotIntPattern.IsMatch(strNumero) &&
            objIntPattern.IsMatch(strNumero);
        }
        #endregion        
    }
}
