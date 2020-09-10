using System;

namespace CollectionHierarchy
{
    class StartUp
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split();
            int numberOfRemoveOperations = int.Parse(Console.ReadLine());
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();
            AddToCollection(words, addCollection);
            AddToCollection(words, addRemoveCollection);
            AddToCollection(words, myList);

            RemoveToCollection(numberOfRemoveOperations, addRemoveCollection);
            RemoveToCollection(numberOfRemoveOperations, myList);
        }

        private static void RemoveToCollection(int numberOfRemoveOperations, IRemovable collection)
        {
            for (int i = 0; i < numberOfRemoveOperations; i++)
            {
                string item = collection.RemoveItem();
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private static void AddToCollection(string[] words, IAddable collection)
        {
            for (int i = 0; i < words.Length; i++)
            {
                int index = collection.AddElement(words[i]);
                Console.Write(index + " ");
            }
            Console.WriteLine();
        }
    }
}
