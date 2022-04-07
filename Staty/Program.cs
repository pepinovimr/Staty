using System;
using Staty.Utils;
using Staty.Writers;

namespace Staty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(GetWindowWidth(), 40);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.ForegroundColor = ConsoleColor.White;                       //defaultně není text v konzoli bílý, ale je to nějaká hodně světlá šedobílá
            Paginator paginator = new Paginator();
            Orderers.NameOrder();   //Dokáže rozpoznat a zařadit i CH na správné místo po H
            bool running = true;
            do
            {
                paginator.WriteItemsFromRange();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.PageUp: paginator.NextPage(); break;
                    case ConsoleKey.PageDown: paginator.PrevPage(); break;
                    case ConsoleKey.Backspace: running = false; break;
                    case ConsoleKey.Escape: Filters.ResetAll(); break;
                    case ConsoleKey.F1: HelpWriter.WriteHelp(); break;
                    case ConsoleKey.F2: Filters.ContinentFilter(); break;
                    case ConsoleKey.F3: Filters.NameFilter(); break;
                    case ConsoleKey.F4: SearchBar.SearchBarInterface(paginator); break;
                    case ConsoleKey.F5: Orderers.NameOrder(); break;
                    case ConsoleKey.F6: Orderers.AreaOrder(); break;
                    case ConsoleKey.F7: Orderers.PopulationOrder(); break;
                }

            } while (running);
        }

        private static int GetWindowWidth()                     //Vrací potřebnou velikost okna, podle velikosti všech zarovnání
        {
            int width = 0;

            for (int i = 0; i < UiWriter.alignNumber.Length; i++)
            {
                width += UiWriter.alignNumber[i];
            }

            return width*-1 + 1;
        }
    }
}
