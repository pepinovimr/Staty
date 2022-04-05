using System;
using Staty.Data;
using System.Linq;
namespace Staty.Utils
{
    //Třída na řazení elementů v Listu
    internal class Orderers 
    { 
        public static void NameOrder()
        {
            if (!ReadStates.CurrentlyShownStates.SequenceEqual(ReadStates.CurrentlyShownStates.OrderBy(x => x.Name))) //Zjistí, jestli je List seřazen, pokud ne, seřadí ho vzestupně, pokud ano, seřadí ho sestupně
                ReadStates.CurrentlyShownStates.Sort((x, y) => x.Name.CompareTo(y.Name));  //Dokáže rozpoznat a zařadit i Ch
            else
                ReadStates.CurrentlyShownStates.Sort((x, y) => y.Name.CompareTo(x.Name));    //seřadí sestupně
        }
        public static void NameOrderAsc()
        {
            ReadStates.CurrentlyShownStates.Sort((x, y) => x.Name.CompareTo(y.Name));
        }

        public static void AreaOrder()
        {
            if (!ReadStates.CurrentlyShownStates.SequenceEqual(ReadStates.CurrentlyShownStates.OrderBy(x => x.Area)))   //SequenceEqual zjišťuje
                ReadStates.CurrentlyShownStates.Sort((x, y) => x.Area.CompareTo(y.Area));    //Sort setřídí List podle daného komparátoru, zde je v pohodě využít lambdu, protože je to jednoduchý porovnání
            else
                ReadStates.CurrentlyShownStates.Sort((x, y) => y.Area.CompareTo(x.Area));  //Seřadí sestupně
        }

        public static void PopulationOrder()
        {
            if (!ReadStates.CurrentlyShownStates.SequenceEqual(ReadStates.CurrentlyShownStates.OrderBy(x => x.Population))) 
                ReadStates.CurrentlyShownStates.Sort((x, y) => x.Population.CompareTo(y.Population));
            else
                ReadStates.CurrentlyShownStates.Sort((x, y) => y.Population.CompareTo(x.Population));  //Seřadí sestupně
        }
    }
}