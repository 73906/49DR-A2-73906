using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Start
{
    class Program
    {
        static int kumulacja;
        static int START = 24;//Kasa na start
        static Random rnd = new Random();//zmienna do losowania

        static void Main(string[] args)
        {
            int pieniadze = START; //wartosc pieniedzy na start
            int dzien = 0;
            do  //pierwsza petla na caly czas
            {
                pieniadze = START;
                dzien = 0;
                ConsoleKey wybor;
                do
                {
                    kumulacja = rnd.Next(2, 50) * 100000;
                    dzien++;
                    int losow = 0;
                    List<int[]> kupon = new List<int[]>();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("DZIEN: {0}", dzien);
                        Console.WriteLine("Do Wygrania dzis {0} zl", kumulacja);
                        Console.WriteLine("\nStan Konta {0}zl", pieniadze);
                        Wyswietlkupon(kupon);
                        //menu
                        if (pieniadze >= 4 && losow < 8)
                        { 
                        Console.WriteLine("1 - Postaw los - 4zl [{0}/8]", losow + 1 );
                        }
                        Console.WriteLine("2 - Losowanie");
                        Console.WriteLine("3 - Zakoncz Gre");
                        //
                        wybor = Console.ReadKey().Key;
                        if (wybor == ConsoleKey.D1 && pieniadze >= 4 && losow < 8)
                        {
                            kupon.Add(PostawLos());
                            pieniadze -= 4;
                            losow++;
                        }
                    } while (wybor == ConsoleKey.D1);
                    Console.Clear();
                    if (kupon.Count > 0) 
                    {
                        int wygrana = Sprawdz(kupon);
                        if (wygrana >0)
                        {
                            Console.WriteLine("Wygrales {0}zł w tym losowaniu", wygrana);
                            pieniadze += wygrana;
                        }
                        else
                        {
                            Console.WriteLine("\nNiestety nie wygrales");
                        }
                    }
                    else
                    {
                        Console.Write("Brak losow");
                    }
                    Console.ReadKey();// czy przeczytal


                } while (pieniadze >= 4 && wybor != ConsoleKey.D3); //d3 klawisz 3 by zakonczyc

                Console.Clear();
                Console.WriteLine("Dzien {0}. \nKoniec gry, twoja wygrana to:{1}zl  ", dzien, pieniadze - START);
            } while (Console.ReadKey().Key == ConsoleKey.Enter);

          
        }

        private static int Sprawdz(List<int[]> kupon)
        {
            int wygrana = 0;
            int[] wylosowane = new int[6];
            for (int i = 0; i < wylosowane.Length; i++)
            {
                int los = rnd.Next(1, 50);
                if (!wylosowane.Contains(los))
                {
                    wylosowane[i] = los;
                }
                else
                {
                    i--;
                }
             }
            Array.Sort(wylosowane);
            Console.WriteLine("Wylosowane liczby : ");

            foreach (int liczba in wylosowane)
            {
                Console.WriteLine(liczba + ", ");
            }
            int[] trafione = SprawdzKupon(kupon, wylosowane);
            int wartosc = 0;
           // int wygrana = 0;

            Console.WriteLine();
            if (trafione[0] > 0)//3 trafienia
            {
                wartosc = trafione[0] * 24; 
                Console.WriteLine("3 Trafione : {0} +{1}zl", trafione[0], wartosc);
                wygrana += wartosc;                          
            }
            if (trafione[1] > 0)//4trafienia
            {
                wartosc = trafione[1] * rnd.Next(150, 300) ;
                Console.WriteLine("4 Trafione : {0} +{1}zl", trafione[1], wartosc);
                wygrana += wartosc;
            }
            if (trafione[2] > 0)//5trafienia
            {
                wartosc = trafione[2] * rnd.Next(5000, 9000);
                Console.WriteLine("5 Trafione : {0} +{1}zl", trafione[2], wartosc);
                wygrana += wartosc;
            }
            if (trafione[3] > 0)//6trafienia
            {
                wartosc = (trafione[3] * kumulacja) / trafione[3] + rnd.Next(0, 5);
                Console.WriteLine("6 Trafione : {0} +{1}zl", trafione[3], wartosc);
                wygrana += wartosc;
            }




            return wygrana;
        }

        private static int[] SprawdzKupon(List<int[]> kupon, int[] wylosowane)
        {
            int[] wygrane = new int[4];
            int i = 0;
            Console.WriteLine("\n\nTwoj kupon: ");
            foreach (int[] los in kupon)
            {
                i++;
                Console.WriteLine(i + ": ");
                int trafien = 0;
                foreach (int liczba in los)
                {
                    if (wylosowane.Contains(liczba))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(liczba + ", ");
                        Console.ResetColor();
                        trafien++;

                    }
                    else
                    {
                        Console.WriteLine(liczba + ", ");
                    }
                }
            switch (trafien)
                {
                    case 3:
                        wygrane[0]++;
                        break;
                    case 4:
                        wygrane[1]++;
                        break;
                    case 5:
                        wygrane[2]++;
                        break;
                    case 6:
                        wygrane[3]++;
                        break;
                }
                Console.WriteLine(" - Trafiono {0}/6", trafien);

            }
                        
           return wygrane;
        }

        
        private static int[] PostawLos()
        {
            int[] liczby = new int[6];
            int liczba = -1;
            for (int i = 0; i < liczby.Length; i++) 
            {
                liczba = -1;
                Console.Clear();
                Console.WriteLine("Postawione liczby: ");
                foreach (int l in liczby)
                {
                    if (l > 0)
                    {
                        Console.WriteLine(l + ", ");
                    }
                }
                Console.WriteLine("\n\nWybierz liczbe od 1 do 49");
                Console.WriteLine("{0}/6: ", i + 1) ;
                bool prawidlowa = int.TryParse(Console.ReadLine(), out liczba); //czy liczba, zakres
                if(prawidlowa && liczba >=1 && liczba <=49 && !liczby.Contains(liczba))
                {
                    liczby[i] = liczba;

                }
                else
                {
                    Console.WriteLine("Bledna liczba");
                    i--;
                    Console.ReadKey();
                }

            }
            Array.Sort(liczby);
            return liczby;
        }

        private static void Wyswietlkupon(List<int[]> kupon)
        {
           if(kupon.Count == 0)
            {
                Console.WriteLine("Nie postwiles nic");
            }
            else
            {
                int i = 0;
                Console.WriteLine("\nTwoj kupon: ");
                foreach (int[] los in kupon)
                {
                    i++;
                    Console.WriteLine(i + ": ");
                    foreach (int liczba in los)
                    {
                        Console.WriteLine(liczba + ", ");
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}
