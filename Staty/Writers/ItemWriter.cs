using System;
using Staty.Data;

namespace Staty.Writers
{
    internal class ItemWriter
    {
        //Vypíše všechny státy podle v určitém rozmezí podle jejich indexu -> využito na stránkování
        public static void WriteItem(int startNumber, int endNumber)
        {
            UiWriter.WriteHeader();
            for (int i = startNumber; i < endNumber; i++)
            {
                Console.WriteLine("{0,"+UiWriter.alignNumber[0]+ "}{1," + UiWriter.alignNumber[1] + "}{2," + UiWriter.alignNumber[2] + "}{3," + UiWriter.alignNumber[3] + "}{4," + UiWriter.alignNumber[4] + "}{5," + UiWriter.alignNumber[5] + "}{6," + UiWriter.alignNumber[6] + "}", ReadStates.CurrentlyShownStates[i].Name, ReadStates.CurrentlyShownStates[i].Continent, ReadStates.CurrentlyShownStates[i].Shortcut, ReadStates.CurrentlyShownStates[i].StateSystem, ReadStates.CurrentlyShownStates[i].Capital, ReadStates.CurrentlyShownStates[i].Population, ReadStates.CurrentlyShownStates[i].Area);
            }
            if (endNumber == 0)
            {
                Console.WriteLine("Nenalezen žádný záznam!");
            }
            UiWriter.WriteFooter();
        }
    }
}
