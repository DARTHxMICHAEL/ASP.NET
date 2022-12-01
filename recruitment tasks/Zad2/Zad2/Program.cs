using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    class Program
    {
        //do testów
        static string debug;

        static int[,] matrixA = new int[5, 5] 
          { { 1, 2, 2, 2, 1 }, 
            { 3, 1, 2, 1, 5 }, 
            { 3, 3, 1, 5, 5 }, 
            { 3, 1, 4, 1, 5 }, 
            { 1, 4, 4, 4, 1 } };

        static int[,] matrixB = new int[4, 4]
        {
            { 1, 2, 2, 1 },
            { 3, 1, 1, 5 },
            { 3, 1, 1, 5 },
            { 1, 4, 4, 1 },
        };

        /// <summary>
        /// Główna funkcja
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MatrixCalculate(matrixA);
            MatrixCalculate(matrixB);
        }

        /// <summary>
        /// Kalkulator pól macierzy
        /// </summary>
        /// <param name="matrixWejsciowy"> macierz wejściowa </param>
        public static void MatrixCalculate(int[,] matrixWejsciowy)
        {
            //zmienne pomocnicze
            int k = 1; int j = 1;
            //pobierz rozmiar macierzy
            int n = matrixWejsciowy.GetLength(0);
            //wyznacz srodek macierzy
            int srodek = matrixWejsciowy.GetLength(0) / 2; 

            //macierz wyjściowa
            int[,] matrixWyjsciowy = new int[2, 2];

            //pole (górne i lewe)
            for (int i = 0; i < (srodek); i++)
            {
                while(j < (n - k))
                {
                    matrixWyjsciowy[0, 0] += matrixWejsciowy[i,j]; //góra
                    //debug += matrixWejsciowy[i, j].ToString();
                    matrixWyjsciowy[0, 1] += matrixWejsciowy[j, i]; //lewo
                    //debug += matrixWejsciowy[j, i].ToString();
                    j++; 
                }
                k++; j = srodek;
            }

            k = 1; j = 1;
            //pole (dolne i prawe)
            for (int i = n - 1; i >= 0; i--)
            {
                while (j < (n - k))
                {
                    matrixWyjsciowy[1, 0] += matrixWejsciowy[i, j]; //dół
                    //debug += matrixWejsciowy[i, j].ToString();
                    matrixWyjsciowy[1, 1] += matrixWejsciowy[j, i]; //prawo
                    //debug += matrixWejsciowy[j, i].ToString();
                    j++;
                }
                k++; j = srodek;
            }

            //wyświetlenie rezultatów
            Console.WriteLine(debug+ "\n\n"+"Rezultat:");
            Console.WriteLine(matrixWyjsciowy[0, 0]+ ", " + matrixWyjsciowy[0, 1]);
            Console.WriteLine(matrixWyjsciowy[1, 0]+ ", " + matrixWyjsciowy[1, 1]);
        }


    }
}
