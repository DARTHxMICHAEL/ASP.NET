using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

public partial class Sortowanie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {  }

    //inicjalizacja tablic do przechowywania liczb 
    int[] randTablicaOne = new int[LICZBY];
    int[] randTablicaTwo = new int[LICZBY];

    //liczby losowe
    Random rnd = new Random();

    //ilość liczb do posortowania/wylosowania
    public const int LICZBY = 30000;

  
    /// <summary>
    /// przygotowanie losowych danych z zakresu 1-9
    /// </summary>
    void PrzygotowanieDanych()
    {
        //generowanie <LICZBY> liczb losowych
        for (int i = 0; i < LICZBY; i++)
        {
            int temp = rnd.Next(1, 10); //liczba losowa z zakresu 1-9
            randTablicaOne[i] = temp;
            randTablicaTwo[i] = temp;
        }

        ////test
        //TextBox1.Text += randTablicaOne[10].ToString();
        //TextBox1.Text += randTablicaTwo[10].ToString();
    }


    /// <summary>
    /// sortowanie bąbelkowe O(n^2)
    /// </summary>
    /// <param name="tablica">tablica z wcześniej utworzonymi liczbami losowymi</param>
    void BubbleSort(int[] tablica)
    {
        //sprawdzenie długości tablicy
        int n = tablica.Length;

        for(int i=0; i < n-1; i++)
        {
            for(int j=0; j < n-i-1; j++)
            {
                //sortowanie rosnące
                if(tablica[j]>tablica[j+1])
                {
                    int temp = tablica[j];
                    tablica[j] = tablica[j+1];
                    tablica[j+1] = temp;
                }
            }
        }

        ////test
        //TextBox1.Text += randTablicaOne[10].ToString();
    }

    /// <summary>
    /// sortowanie przez scalanie, główna funkcja O(nlogn)
    /// </summary>
    /// <param name="tablica">tablica z liczbami losowymi</param>
    /// <param name="l">index skrajnego lewego elementu</param>
    /// <param name="r">index skrajnego prawego elementu</param>
    void MergeSort(int[] tablica, int l, int r)
    {
        if (r <= l)
            return;

        //środkowy index
        int m = l + (r - l) / 2;

        //sortujemy lewą i prawą część
        MergeSort(tablica, l, m);
        MergeSort(tablica, m + 1, r);

        //łączymy posortowane tablice
        Merge(tablica, l, m, r);

    }


    /// <summary>
    /// sortowanie przez scalanie, funkcja pomocnicza (łączenie 2 tablic)
    /// </summary>
    /// <param name="tablica">tablica z liczbami losowymi</param>
    /// <param name="l">index skrajnego lewego elementu</param>
    /// <param name="r">index skrajnego prawego elementu</param>
    /// <param name="m">index dzielącego elementu</param>
    void Merge(int[] tablica, int l, int m, int r)
    {
        //rozmiary tablic do scalenia
        int n1 = m - l + 1; //0,1,..
        int n2 = r - m;

        //inicjacja tymczasowych tablic
        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;

        //kopiujemy dane do tymczasowych tablic
        for (i = 0; i < n1; ++i)
            L[i] = tablica[l + i];

        for (j = 0; j < n2; ++j)
            R[j] = tablica[m + 1 + j];

        //sortowanie i łaczenie podtablic

        //index początkowy podtablic
        int k = l;
        i = 0;
        j = 0;

        while (i < n1 && j < n2)
        {
            //porównujemy i zapisujemy
            if (L[i] <= R[j])
            {
                tablica[k] = L[i];
                i++;
            }
            else
            {
                tablica[k] = R[j];
                j++;
            }
            k++;
        }

        //resztę L[]kopiujemy
        //o ile cokolowiek zostało
        while (i < n1)
        {
            tablica[k] = L[i];
            i++;
            k++;
        }

        //resztę R[]kopiujemy
        //o ile cokolowiek zostało
        while (j < n2)
        {
            tablica[k] = R[j];
            j++;
            k++;
        }

    }


    /// <summary>
    /// GŁÓWNA FUNKCJA (wywołanie przycisku)
    /// </summary>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //ui-info
        TextBox1.Text += "Losowanie " + LICZBY + " liczb \n\n";
        //liczby losowe
        PrzygotowanieDanych();
        //inicjalizacja zegarów
        Stopwatch sw = new Stopwatch();
        Stopwatch sw2 = new Stopwatch();

        //ui-info
        TextBox1.Text += "Sortowanie bąbelkowe O(N^2): \n";
        //początek pomiaru czasu
        sw.Start();
        //sortowanie bąbelkowe
        BubbleSort(randTablicaOne);
        //koniec pomiaru czasu
        sw.Stop();
        //ui-info
        TextBox1.Text += "CZAS: " + sw.Elapsed.ToString() + "\n";

        //ui-info
        TextBox1.Text += "Sortowanie przez scalanie O(NlogN): \n";
        //początek pomiaru czasu
        sw2.Start();
        //sortowanie przez scalanie
        MergeSort(randTablicaTwo, 0, randTablicaTwo.Length - 1);
        //koniec pomiaru czasu
        sw.Stop();
        //ui-info
        TextBox1.Text += "CZAS: " + sw2.Elapsed.ToString() + "\n \n\n";

        //test
        //TextBox1.Text += randTablicaTwo[10].ToString();
    }

}
