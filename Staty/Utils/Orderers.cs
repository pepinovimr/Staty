using System;
using Staty.Data;
namespace Staty.Utils
{
    //Třída na řazení elementů v Listu
    internal class Orderers 
    { 
        public static void NameOrder()
        {
            
            ReadStates.CurrentlyShownStates.Sort((x, y) => x.Name.CompareTo(y.Name));  //Dokáže rozpoznat a zařadit i Ch
            //ReadStates.StatesList.Sort((x, y) => y.Name.CompareTo(x.Name));    //seřadí sestupně
        }

        public static void AreaOrder()
        {
            ReadStates.CurrentlyShownStates.Sort((x, y) => x.Area.CompareTo(y.Area));    //Sort setřídí List podle daného komparátoru, zde je v pohodě využít lambdu, protože je to jednoduchý porovnání
            //ReadStates.StatesList.Sort((x, y) => y.Area.CompareTo(x.Area));  //Seřadí sestupně
        }

        public static void PopulationOrder()
        {
            ReadStates.CurrentlyShownStates.Sort((x, y) => x.Population.CompareTo(y.Population));
            //ReadStates.StatesList.Sort((x, y) => y.Population.CompareTo(x.Population));  //Seřadí sestupně
        }
    }
}
