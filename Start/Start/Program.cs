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
                        Console.WriteLine("1 - Postaw los - 4zl [{0}/8", losow + 1 );
                        }
                        Console.WriteLine("2 - Losowanie");
                        Console.WriteLine("3 Zakoncz Gre");
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

                    }
                    else
                    {
                        Console.Write("Brak losow");
                    }
                    Console.ReadKey();


                } while (pieniadze >= 4 && wybor != ConsoleKey.D3); //d3 klawisz 3 by zakonczyc

                Console.Clear();
                Console.WriteLine("Dzien {0}. \nKoniec gry, twoja wygrana to:{1}zl  ", dzien, pieniadze - START);
            } while (Console.ReadKey().Key == ConsoleKey.Enter);

          
        }

        private static int[] PostawLos()
        {
            throw new NotImplementedException();
        }

        private static void Wyswietlkupon(List<int[]> kupon)
        {
            throw new NotImplementedException();
        }
    }
}
