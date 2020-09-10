using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAddable
    {
        int AddElement(string item);

        List<string> Collection { get; }

        int Index { get; }
    }
}
