using System.Collections.Generic;
using Models;

namespace Database.Utils
{
    public static class ReaderHelpers
    {
        public static void RemoveAllEmptyItems<TItem, TChild, TParent>(List<TItem> itemsToCheck, TParent itemsContainer)
            where TItem : Model<TChild> where TParent : Model<TItem>
        {
            for (var i = 0; i < itemsToCheck.Count; i++)
            {
                if (itemsToCheck[i].Items.Count != 0) continue;
                
                var emptyItem = itemsToCheck[i];
                    
                itemsContainer.Items.Remove(emptyItem);
                
                emptyItem = null;
                i--;
            }
        }
    }
}
