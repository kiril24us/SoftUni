using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : AddCollection, IRemovable
    {       
        public override int AddElement(string item)
        {
            Collection.Insert(Index, item);
            return Index;
        }

        public virtual string RemoveItem()
        {
            if (Collection.Capacity > 0)
            {
                string item = Collection[Collection.Count - 1];
                Collection.RemoveAt(Collection.Count - 1);
                return item;
            }
            return "";
        }
    }
}
