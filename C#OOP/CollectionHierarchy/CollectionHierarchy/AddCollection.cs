using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{   
    public class AddCollection : IAddable
    {
        public AddCollection()
        {
            Collection = new List<string>(100);
        }

        public List<string> Collection { get; private set; }

        public int Index { get; private set; } 

        public virtual int AddElement(string item)
        {
            Collection.Add(item);        
            return Index++;
        }
        
    }
}
