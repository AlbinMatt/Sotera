using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp23
{
    class Program
    {
       

        
            static void BubbleSort(List<int> lista)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    for (int j = 0; j < lista.Count - 1 - i; j++)
                    {
                        if (lista[j] < lista[j + 1])
                        {
                            int temp = lista[j];
                            lista[j] = lista[j + 1];
                            lista[j + 1] = temp;
                        }
                    }
                }
            }
            static void InsertionSort(List<int> lista)
            {
                int i, n, temp;
                int lenght = lista.Count; if (lenght < 2) return;

                for (n = 1; n < lenght; n++)
                {
                    temp = lista[n];
                    i = n - 1;
                    while (i >= 0 && lista[i] > temp)
                    {
                        lista[i + 1] = lista[i];
                        i--;
                    }
                    lista[i + 1] = temp;
                }
            }
            static void SelectionSort(List<int> lista)
            {
                for (int i = 0; i < lista.Count - 1; i++)
                {
                    int smallest = i;
                    for (int j = i + 1; j < lista.Count; j++)
                    {
                        if (lista[j] < lista[smallest])
                            smallest = j;
                    }
                    int temp = lista[smallest];
                    lista[smallest] = lista[i];
                    lista[i] = temp;
                }
            }
            private static List<int> MergeSort(List<int> lista)
            {
                if (lista.Count <= 1)
                    return lista;

                List<int> left = new List<int>();
                List<int> right = new List<int>();

                int middle = lista.Count / 2;
                for (int i = 0; i < middle; i++)
                {
                    left.Add(lista[i]);
                }
                for (int i = middle; i < lista.Count; i++)
                {
                    right.Add(lista[i]);
                }

                left = MergeSort(left);
                right = MergeSort(right);
                return Merge(left, right);
            }

            private static List<int> Merge(List<int> left, List<int> right)
            {
                List<int> result = new List<int>();

                while (left.Count > 0 || right.Count > 0)
                {
                    if (left.Count > 0 && right.Count > 0)
                    {
                        if (left.First() <= right.First())
                        {
                            result.Add(left.First());
                            left.Remove(left.First());
                        }
                        else
                        {
                            result.Add(right.First());
                            right.Remove(right.First());
                        }
                    }
                    else if (left.Count > 0)
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else if (right.Count > 0)
                    {
                        result.Add(right.First());

                        right.Remove(right.First());
                    }
                }
                return result;
            }
            static List<int> QuickSort(List<int> lista)
            {
                if (lista.Count <= 1)
                    return lista;
                int pivotIndex = lista.Count / 2;
                int pivot = lista[pivotIndex];
                List<int> left = new List<int>();
                List<int> right = new List<int>();

                for (int i = 0; i < lista.Count; i++)
                {
                    if (i == pivotIndex) continue;

                    if (lista[i] <= pivot)
                    {
                        left.Add(lista[i]);
                    }
                    else
                    {
                        right.Add(lista[i]);
                    }
                }

                List<int> sorted = QuickSort(left);
                sorted.Add(pivot);
                sorted.AddRange(QuickSort(right));
                return sorted;
            }

            static void Main(string[] args)
            {
            Console.Write("Hur många tal vill du sotera? ");

            int antaltal = Convert.ToInt32(Console.ReadLine());


                var tid = new Stopwatch();
                var tidd = new Stopwatch();
                var tiddd = new Stopwatch();
                var tidddd = new Stopwatch();
                var tiddddd = new Stopwatch();

                List<int> tallista1 = new List<int>();
                List<int> tallista2 = new List<int>();
                List<int> tallista3 = new List<int>();
                List<int> tallista4 = new List<int>();
                List<int> tallista5 = new List<int>();

                Random slump = new Random();

                Console.WriteLine("Sorterar " + antaltal + " tal chilla lite . . . ." + "\n");

                for (int i = 0; i < antaltal; i++)
                {
                    tallista1.Add(slump.Next(1000000));
                    tallista2.Add(slump.Next(1000000));
                    tallista3.Add(slump.Next(1000000));
                    tallista4.Add(slump.Next(1000000));
                    tallista5.Add(slump.Next(1000000));
                }

                tid.Start();
                BubbleSort(tallista1);
                tid.Stop();

                tidd.Start();
                InsertionSort(tallista2);
                tidd.Stop();

                tiddd.Start();
                SelectionSort(tallista3);
                tiddd.Stop();

                tidddd.Start();
                MergeSort(tallista4);
                tidddd.Stop();

                tiddddd.Start();
                QuickSort(tallista5);
                tiddddd.Stop();

                double tid2 = tid.ElapsedMilliseconds / 1000.0;
                double tid3 = tidd.ElapsedMilliseconds / 1000.0;
                double tid4 = tiddd.ElapsedMilliseconds / 1000.0;
                double tid5 = tidddd.ElapsedMilliseconds / 1000.0;
                double tid6 = tiddddd.ElapsedMilliseconds / 1000.0;

                int minuter1 = Convert.ToInt32(tid2) / 60;
                int minuter2 = Convert.ToInt32(tid3) / 60;
                int minuter3 = Convert.ToInt32(tid4) / 60;
                int minuter4 = Convert.ToInt32(tid5) / 60;
                int minuter5 = Convert.ToInt32(tid6) / 60;

                double sekunder1 = Convert.ToDouble(tid2) - minuter1 * 60;
                double sekunder2 = Convert.ToDouble(tid3) - minuter2 * 60;
                double sekunder3 = Convert.ToDouble(tid4) - minuter3 * 60;
                double sekunder4 = Convert.ToDouble(tid5) - minuter4 * 60;
                double sekunder5 = Convert.ToDouble(tid6) - minuter5 * 60;

                Console.WriteLine("Bubble sort: " + "\n" + "Tid: " + tid2 + "s" + "\n" + minuter1 + " minut(er)" + "\n" + sekunder1 + " sekunder" + "\n");
                Console.WriteLine("Insertion sort: " + "\n" + "Tid: " + tid3 + "s" + "\n" + minuter2 + " minut(er)" + "\n" + sekunder2 + " sekunder" + "\n");
                Console.WriteLine("Selection sort: " + "\n" + "Tid: " + tid4 + "s" + "\n" + minuter3 + " minut(er)" + "\n" + sekunder3 + " sekunder" + "\n");
                Console.WriteLine("Merge sort: " + "\n" + "Tid: " + tid5 + "s" + "\n" + minuter4 + " minut(er)" + "\n" + sekunder4 + " sekunder" + "\n");
                Console.WriteLine("Quick sort: " + "\n" + "Tid: " + tid6 + "s" + "\n" + minuter5 + " minut(er)" + "\n" + sekunder5 + " sekunder" + "\n");
            }

        


    }
}

