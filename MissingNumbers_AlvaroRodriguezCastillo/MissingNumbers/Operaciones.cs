using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingNumbers
{
    public class Operaciones
    {
        #region Missing Numbers
        public static IList<int?> ExtraerPrimeraLista(string[] ANumbers)
        {
            IList<int?> A = new List<int?>();
            for (int i = 0; i < ANumbers.Length; i++)
            {
                if (Constraints.VerificaNumero(ANumbers[i]))
                    A.Add(int.Parse(ANumbers[i]));
            }
            //sort the A List
            A.OrderBy(x => x.Value);

            return A;
        }

        public static IList<int?> ExtraerSegundaLista(string[] BNumbers)
        {
            IList<int?> B = new List<int?>();
            for (int i = 0; i < BNumbers.Length; i++)
            {
                if (Constraints.VerificaNumero(BNumbers[i]))
                    B.Add(int.Parse(BNumbers[i]));
            }
            //sort the A List
            B.OrderBy(x => x.Value);

            return B;
        }

        public static List<int?> ObtenerListaNumerosPerdidos(IList<int?> A, IList<int?> B)
        {
            List<int?> ListaNumerosPerdidos = new List<int?>();

            int k = 0, j = 0;
            while (k < B.Count)
            {
                if (j < A.Count)
                {
                    int numB = B[k].Value;
                    int numA = A[j].Value;
                    if (numA == numB)
                    {
                        k++;
                        j++;
                    }
                    else
                    {
                        if (!ListaNumerosPerdidos.Contains(numB))
                        {
                            ListaNumerosPerdidos.Add(numB);
                        }
                        k++;
                    }
                }
                else
                {
                    if (!ListaNumerosPerdidos.Contains(B[k]))
                    {
                        ListaNumerosPerdidos.Add(B[k]);
                    }
                    k++;
                }

            }

            ListaNumerosPerdidos.Sort();

            return ListaNumerosPerdidos;
        }

        public static void ImprimirNumerosPerdidos(List<int?> ListaNumerosPerdidos)
        {
            foreach (int? num in ListaNumerosPerdidos)
            {
                Console.Write(num + " ");
            }
        }

        #endregion
    }
}
