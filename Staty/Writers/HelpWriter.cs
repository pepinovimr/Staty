using System;

namespace Staty.Writers
{
    internal class HelpWriter
    {
        public static void WriteHelp()
        {
            Console.Clear();
            Console.WriteLine("NÁPOVĚDA");
            Console.WriteLine("\nOvládání:");
            Console.WriteLine(
                "F1 - help (nápověda, o programu)" +
                "\nF2 – filtr podle kontinentu"+
                "\nF3 - filtr podle názvu, případně značky"+
                "\nF5 - řazení podle názvu" +
                "\nF6 - řazení podle rozlohy" +
                "\nF7 - řazení podle počtu obyvatel" +
                "\nPgUp - předchozí stránka" +
                "\nPgDown – další stránka" +
                "\nEsc – zruš všechny filtry a seřaď podle jména státu" +
                "\nBackspace - Ukončí program");
            Console.WriteLine("\nKritéria pro filtraci:");
            Console.WriteLine("\nFiltr podle kontinentu načte jen jedno písmeno a podle něj najde státy, jejichž zkratka kontinentu začíná na stejný znak.\n");
            Console.WriteLine("Filtr podle názvu načte zadané znaky a najde všechny státy, které začínají na dané znaky. \nV případě načtení dvou a méně znaků, obdobně vyfiltruje ještě státy podle značky.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPro návrat na aktuální stránku států zmáčkněte kterékoliv tlačítko");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true);
        }
    }
}
