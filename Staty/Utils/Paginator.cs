using System;
using Staty.Data;

namespace Staty.Utils
{
    //Třída na navigaci mezi stránkami
    internal class Paginator
    {
        private static readonly int ItemsPerPage = Console.WindowHeight - 5;
        private static int ActivePageIndex = 0;
        private static int MaxPageIndex = ReadStates.CurrentlyShownStates.Count / ItemsPerPage;
        private static int[] itemsRange = GetStatesRange();

        public Paginator()
        {

        }

        public static int[] GetStatesRange()
        {
            int[] range = new int[2];
            range[0] = ItemsPerPage * ActivePageIndex;

            range[1] = range[0] + ItemsPerPage;
            if (range[1] > ReadStates.CurrentlyShownStates.Count)
                range[1] = ReadStates.CurrentlyShownStates.Count;
            return range;
        }

        public static void UpdateVariables()
        {
            MaxPageIndex = ReadStates.CurrentlyShownStates.Count / ItemsPerPage;
            itemsRange = GetStatesRange();
        }

        public void WriteItemsFromRange()
        {
            Writers.ItemWriter.WriteItem(itemsRange[0], itemsRange[1]);
        }

        public void NextPage()
        {
            if (ActivePageIndex >= MaxPageIndex)
                ChangePage(0);
            else
                ChangePage(1);
        }

        public void PrevPage()
        {
            if (ActivePageIndex <= 0)
                ChangePage(MaxPageIndex);
            else
                ChangePage(-1);
        }

        public void ChangePage(int i)
        {
            if (i == 0)
                ActivePageIndex = 0;
            else if (i == MaxPageIndex)
                ActivePageIndex = MaxPageIndex;
            else if (i == 1)
                ActivePageIndex++;
            else if (i == -1)
                ActivePageIndex--;

            itemsRange = GetStatesRange();
            WriteItemsFromRange();
        }

        public static int GetActivePageIndex() { return ActivePageIndex; }

        public static int GetMaxPageIndex() { return MaxPageIndex; }

        public static int GetItemsPerPage() { return ItemsPerPage; }
    }
}
