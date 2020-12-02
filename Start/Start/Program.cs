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
            throw new NotImplementedException();
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
