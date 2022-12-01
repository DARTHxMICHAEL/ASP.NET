using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class Program
    {
        //pusta zmienna, słowo do odwrócenia
        static string slowo = String.Empty;

        /// <summary>
        /// Główna funkcja
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //wprowadzenie danych (slowo)
            Console.Write("Wprowadź słowo do odwrócenia: ");
            slowo = Console.ReadLine();

            //odpowiedź i wywołanie funkcji [CharInversion]
            Console.WriteLine("Odwrócone słowo: "+CharInversion(slowo).ToString());
            Test(); Console.ReadKey(); Console.ReadKey();
        }

        /// <summary>
        /// Funkcja do odwracania ciągu znaków
        /// </summary>
        /// <param name="tekstDoOdwrocenia">tekst do odwrócenia</param>
        public static string CharInversion(String tekstDoOdwrocenia)
        {
            //inicjalizacja pustych zmiennych
            string tekstOdwrocony = String.Empty;

            //kopiujemy znaki w odwróconej kolejności
            for (int i = tekstDoOdwrocenia.Length - 1; i >= 0; i--)
            {
                if (tekstDoOdwrocenia[i] >= 'A' && tekstDoOdwrocenia[i] <= 'Z' && i != (tekstDoOdwrocenia.Length - 1))
                {
                    //zamieniamy duże litery na małe
                    tekstOdwrocony += (char)(tekstDoOdwrocenia[i] - 'A' + 'a');
                }
                else if(tekstDoOdwrocenia[i] >= 'a' && tekstDoOdwrocenia[i] <= 'z' && i == (tekstDoOdwrocenia.Length - 1))
                {
                    //ostatnią-pierwszą literę zamieniamy na dużą
                    tekstOdwrocony += (char)(tekstDoOdwrocenia[i] - 'a' + 'A');
                }
                else
                {
                    //resztę zwyczajnie kopiujemy
                    tekstOdwrocony += tekstDoOdwrocenia[i];
                }    
            }
            return tekstOdwrocony;
        }

        /// <summary>
        /// Test [CharInversion]
        /// </summary>
        /// <returns></returns>
        public static void Test()
        {
            if (CharInversion("Polonez") == "Zenolop" && CharInversion("POLONEZ") == "Zenolop"
                && CharInversion("poloneZ") == "Zenolop" && CharInversion("pOlOneZ") == "Zenolop")
                Console.WriteLine("passed");
            else
                Console.WriteLine("failed");
        }

    }
}
