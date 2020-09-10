using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    /// <summary>
    /// дали да наследи AddRemoveCollection или интерфейс
    /// </summary>
    public class MyList : AddRemoveCollection
    {       
        public int Used { get; private set; } = 0;

        public override int AddElement(string item)
        {
            Collection.Insert(Index, item);
            Used++;
            return Index;
        }

        
        public override string RemoveItem()
        {
            if (Collection.Capacity > 0)
            {
                string item = Collection[0];
                Collection.RemoveAt(0);
                Used--;
                return item;
            }
            return "";
        }
    }
}
