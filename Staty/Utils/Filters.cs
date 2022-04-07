using System;
using System.Collections.Generic;
using System.Linq;
using Staty.Data;

namespace Staty.Utils
{
    //Třída na filtraci záznamů
    internal class Filters
    {
        public static void ContinentFilter()   
        {
            ReadStates.CurrentlyShownStates = new List<State>(ReadStates.AllStates);
            Console.Write("Zadejte první písmeno kontinentu, podle kterého chcete filtrovat: ");
            char input = Console.ReadKey().KeyChar;
            if (!char.IsLetter(input))
                return;
            foreach (State x in ReadStates.CurrentlyShownStates.ToList())
            {
                if (!x.Continent.StartsWith(input.ToString().ToUpper())) 
                    ReadStates.CurrentlyShownStates.Remove(x);
            }
            Paginator.UpdateVariables();
        }

        public static void NameFilter()
        {
            List<State> states = new List<State>(ReadStates.AllStates);
            Console.Write("Zadejte prvních několik písmen názvu státu (popřípadě zkratku), podle kterých chcete filtrovat: ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                return;
            foreach(State x in states.ToList())
            {
                if (!x.Name.ToUpper().StartsWith(input.ToUpper()))
                    states.Remove(x);
            }
            if (input.Length <= 2)  //spustí vyhledávání přes shortcut jen pokud má input 2 a méně znaků
            {
                states.AddRange(ShortcutFilter(input));
                ReadStates.CurrentlyShownStates = states.Distinct().ToList();        //Řeší duplikaci Států
            }else
                ReadStates.CurrentlyShownStates = states;

            Orderers.NameOrder();
            Paginator.UpdateVariables();
        }

        public static List<State> ShortcutFilter(string input)
        {
            List<State> states = new List<State>(ReadStates.AllStates);

            foreach (State x in states.ToList())
            {
                if (!(x.Shortcut.StartsWith(input.ToUpper()) || x.Shortcut == input))
                    states.Remove(x);
            }
            return states;
        }
        public static void ResetAll()
        {
            ReadStates.CurrentlyShownStates = new List<State>(ReadStates.AllStates);
            Paginator.UpdateVariables();
            Orderers.NameOrderAsc();
        }
    }
}
