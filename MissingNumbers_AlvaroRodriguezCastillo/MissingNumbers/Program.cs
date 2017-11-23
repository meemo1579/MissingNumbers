using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MissingNumbers
{
    class Program
    {
        #region Metodo Principal
        static void Main()
        {
            try
            {
                // Capturamos los datos por pantalla. En este caso se debe ingresar una cadena de valores separados por espacios en blanco.
                Console.Write("Ingrese los números lista A:");
                string[] ANumbers = Console.ReadLine().ToString().Split(' ');

                Console.Write("Ingrese los números lista B:");
                string[] BNumbers = Console.ReadLine().ToString().Split(' ');

                // Obtenemos las listas con los datos depurados
                IList<int?> A = Operaciones.ExtraerPrimeraLista(ANumbers);
                IList<int?> B = Operaciones.ExtraerSegundaLista(BNumbers);

                // iniciamos las validaciones correspondientes.

                // 1. Constraint: 1 <= n,m, <= 2 * 10⁵
                if (Constraints.VerificarTamanoLista(A))
                {
                    if (Constraints.VerificarTamanoLista(B))
                    {
                        // 2. Constraint: n <= m
                        if (Constraints.CompararTamanoEntreListas(A, B))
                        {
                            // 3. Constraint: 1 <= x <= 10⁴, x ε B
                            if (Constraints.VerificarValoresLista(B))
                            {
                                // 4. Constraint: Xmax - Xmin < 101
                                if (Constraints.VerificarMaxAndMin(A))
                                {
                                    if (Constraints.VerificarMaxAndMin(B))
                                    {
                                        // Luego de cumplir con todos las validaciones, procedemos a obtener la lista con los numeros perdidos
                                        List<int?> ListaNumerosPerdidos = Operaciones.ObtenerListaNumerosPerdidos(A, B);
                                        // En caso que no existan numeros perdidos, imprimimos por pantalla un mensaje descriptivo
                                        if (ListaNumerosPerdidos.Count > 0)
                                            Operaciones.ImprimirNumerosPerdidos(ListaNumerosPerdidos);
                                        else
                                            Console.WriteLine("No se encontraron numeros perdidos");
                                    }
                                    else
                                        Console.WriteLine("La lista B no cumple con el Constraint: Xmax - Xmin < 101");
                                }
                                else
                                    Console.WriteLine("La lista A no cumple con el Constraint: Xmax - Xmin < 101");
                            }
                            else
                                Console.WriteLine("La lista B no cumple con el Constraint: 1 <= x <= 10⁴, x ε B");
                        }
                        else
                            Console.WriteLine("Las listas no cumplen con el Constraint: n <= m");
                    }
                    else
                        Console.WriteLine("La lista A no cumple con el Constraint: 1 <= n,m, <= 2 * 10⁵");
                }
                else
                    Console.WriteLine("La lista A no cumple con el Constraint: 1 <= n,m, <= 2 * 10⁵");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Presione cualquier tecla para terminar...");
                Console.ReadKey();                                  
            }

        }
        #endregion        
    }
}
