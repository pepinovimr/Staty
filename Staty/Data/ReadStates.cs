using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Staty.Data
{
    //Třída získává a ukládá data z .csv souboru
    internal class ReadStates
    {
        public static readonly List<State> AllStates = GetAllStates(); //List se všemi státy, neměnící se -> proto readonly
        public static List<State> CurrentlyShownStates = AllStates;         //List s aktuálně zobrazovanými státy
        public static string[] ColumnNames = GetColumnNames();    //Stringové pole s názvy jednotlivých sloupců

        private static string[] GetColumnNames()       //Získá jen první řádku ze souboru a vrátí ve stringovém poli
        {
            string pathStates = "Data/staty_sveta.csv";
            if (File.Exists(pathStates))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(pathStates, Encoding.UTF8))
                    {
                        string namesLn = sr.ReadLine();
                        string[] names = namesLn.Split(';');
                        return names;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Chyba při načítání dat ze souboru\nUkončuji program");
                    System.Threading.Thread.Sleep(3000);
                    Environment.Exit(0);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Chyba! Cesta k souboru nenalezena!");
                return null;
            }
        }

            //Nějak jsem při psaní zapomněl vynechat kolonku státní zřízení.
            //Teď už jí tam nechám, ale kdybych jí měl vynechat, tak jen vynechám values[3] a pokračuji dál s values[4].
            //Samozřejmě by se podle toho musel i upravit objekt State a všechny výpisy...
        private static List<State> GetAllStates()  //Získá vše, kromě první řádky ze souboru do State a vrátí v Listu
        {
            string pathStates = "Data/staty_sveta.csv";
            if (File.Exists(pathStates))
            {
                List<State> st = new List<State>();
                try
                {
                    using (StreamReader sr = new StreamReader(pathStates, Encoding.UTF8))
                    {
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();               //var - veme si typ proměné podle toho, co je do něj zapsáno jako první
                            var values = line.Split(';');           //může být i pole, nebo například List
                            st.Add(new State(values[0], values[1], values[2], values[3], values[4], uint.Parse(values[5]), int.Parse(values[6])));
                        }
                        return st;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Chyba při načítání dat ze souboru\nUkončuji program");
                    System.Threading.Thread.Sleep(3000);
                    Environment.Exit(0);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Chyba! Cesta k souboru nenalezena!");
                return null;
           }
        }
    }
}