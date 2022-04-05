using System;
using System.Collections.Generic;
using System.Linq;
using Staty.Data;

namespace Staty.Utils
{
    //Spíše proof of concept pro mě, že něco takovýho dokážu s tímto designem programu udělat
    internal class SearchBar
    {
        public static void SearchBarInterface(Paginator pg)
        {
            string input = string.Empty;
            Console.Write("Zadejte prvních několik písmen názvu státu (popřípadě zkratku), podle kterých chcete filtrovat: ");
            bool running = true;
            while (running)
            {
                var keyPressed = Console.ReadKey().Key;
                switch (keyPressed)
                {
                    case ConsoleKey.Enter:
                    /*case ConsoleKey.Backspace when input.Length == 0:		WHEN FUNGUJE AŽ OD .NET6
                        running = false;
                        break;*/
                    case ConsoleKey.Backspace:
                        if (input.Length == 0)
                        {
                            running = false;
                            break;
                        }
                        input = input.Remove(input.Length - 1);
                        NameFilter(input);
                        BarWrite(pg, input);
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                    case ConsoleKey.PageUp:
                        pg.NextPage();
                        BarWrite(pg, input);
                        break;
                    case ConsoleKey.PageDown:
                        pg.PrevPage();
                        BarWrite(pg, input);
                        break;
                    default:
                        if (!char.IsLetter((char)keyPressed))
                            break;
                        input += (char)keyPressed;
                        NameFilter(input);
                        BarWrite(pg, input);
                        break;
                }
            }
            Filters.ResetAll();
        }
        public static void NameFilter(string input)
        {
            List<State> states = new List<State>(ReadStates.AllStates);
            foreach (State x in states.ToList())
            {
                if (!x.Name.ToUpper().StartsWith(input.ToUpper()))
                    states.Remove(x);
            }
            if (input.Length <= 2)  //spustí vyhledávání přes shortcut jen pokud má input 2 znaky (Pokud bychom chtěli hledat i z jedné zkratky, tak stačí první =  změnit na <)
            {
                states.AddRange(Filters.ShortcutFilter(input));
                ReadStates.CurrentlyShownStates = new List<State>(states.Distinct().ToList());        //Řeší duplikaci Států
            }
            else
                ReadStates.CurrentlyShownStates = states;
            if(input != string.Empty)                       //Aby bylo správně seřazeno
                Orderers.NameOrder();
            Paginator.UpdateVariables();
        }

        public static void BarWrite(Paginator pg, string input)
        {
            pg.WriteItemsFromRange();
            Console.Write("Zadejte prvních několik písmen názvu státu (popřípadě zkratku), podle kterých chcete filtrovat: " + input);
        }
    }
}
