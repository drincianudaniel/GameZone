using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GenericCollection<T>
    {
        private readonly int maxSize;
        private int index;
        private T[] items;

        public GenericCollection(int maxSize = 10)
        {
            this.maxSize = maxSize;
            this.items = new T[maxSize];
            this.index = 0;
        }

        public void SetItemAtIndex(T item, int index)
        {
            if(index >= maxSize) 
            { 
                throw new InvalidOperationException("Cannot insert item at this index"); 
            }
            items[index] = item;
        }

        public T GetItemAtIndex(int index)
        {
            if(index < 0 || index >= maxSize)
            {
                throw new InvalidOperationException("Index out of bounds"); 
            }
            else
            {
                return items[index];
            }

        }

        //item swap
        public void Swap(ref T item1, ref T item2)
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }

        //index swap
        public void Swap(int index1, int index2)
        {
            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }

        //index and item swap
        public void Swap(int index1, ref T item2)
        {
            int index2 = Array.IndexOf(items, item2);
            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }
     
    }
}
