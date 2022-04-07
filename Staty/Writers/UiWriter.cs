using System;
using Staty.Data;
using Staty.Utils;

namespace Staty.Writers
{
    //Třída na výpis UI
    internal class UiWriter
    {
        public static readonly int[] alignNumber = { -32, -20, -9, -26, -31, -15, -13 }; //číslo pro zarovnání v konzoli
        public static void WriteHeader()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < Console.WindowWidth-1; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.CursorTop);
            Console.WriteLine("STATY");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            //Console.WriteLine("{0,"+State.alignNumber[0]+ "}{1," + State.alignNumber[1] + "}{2," + State.alignNumber[2] + "}{3," + State.alignNumber[3] + "}{4," + State.alignNumber[4] + "}{5," + State.alignNumber[5] + "}{6," + State.alignNumber[6] + "}", Data.ReadStates.UiNames[0], Data.ReadStates.UiNames[1], Data.ReadStates.UiNames[2], Data.ReadStates.UiNames[3], Data.ReadStates.UiNames[4], Data.ReadStates.UiNames[5], Data.ReadStates.UiNames[6]);
            for (int i = 0; i < alignNumber.Length; i++)        //Toto mi přijde jako elegantnější způsob výpisu
            {
                Console.Write("{0,"+alignNumber[i]+"}", ReadStates.ColumnNames[i]);
            }
            Console.Write("\n");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public static void WriteFooter()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("F1 - Nápověda                       PgUp - Další stránka                     PgDown - Předchozí stránka                 Backspace - Ukončit program");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            int shownRecordLowerLimit = Utils.Paginator.GetStatesRange()[0] + 1;
            if (ReadStates.CurrentlyShownStates.Count <= 0)
                shownRecordLowerLimit--;

            Console.WriteLine("Nalezeno {0} záznamů, zobrazeny záznamy {1} - {2}, strana {3} z {4}", ReadStates.CurrentlyShownStates.Count, shownRecordLowerLimit, Paginator.GetStatesRange()[1], Paginator.GetActivePageIndex()+1, Paginator.GetMaxPageIndex()+1);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
