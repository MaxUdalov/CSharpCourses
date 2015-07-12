using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Collections_Generics
{
    public class MyLinkedList : IList
    {
       LinkedList<object> _list = new LinkedList<object>();
       int _count = 0;

       public int Add(object value)
       {           
           _list.AddLast(value);
           _count++;
           return (_count - 1);
       }

       public void Clear()
       {
           _list.Clear();
       }

       public bool Contains(object value)
       {
           LinkedListNode<object> node = _list.Find(value);
           return (node != null);

       }

       public int IndexOf(object value)
       {         
           LinkedListNode<object> node = _list.Find(value);
           for(int i = 0 ; i < _list.Count; i++)
               if (node.Value.Equals(value))
                   return i;
           return -1;
       }

       public void Insert(int index, object value)
       {
           LinkedListNode<object> node = _list.First;
           if (index == 0)
           {
               _list.AddFirst(value);
               _count++;
               return;
           }
           for(int i = 0; i < index - 1; i++)
           {
                node = node.Next;
           }
           _list.AddAfter(node, value);
           _count++;
       }

       public bool IsFixedSize
       {
           get { return false; }
       }

       public bool IsReadOnly
       {
           get { return false; }
       }

       private LinkedListNode<object> GetValue(int index)
       {
           LinkedListNode<object> node = _list.First; ;
           for (int i = 0; i < index ; i++)
           {
               node = node.Next;
           }
           return node;
       }
       public void Remove(object value)
       {
           _list.Remove(value);
       }

       public void RemoveAt(int index)
       {
           if (index >= 0 && index < Count)
           {
               _list.Remove(GetValue(index).Value);
           }

       }

       public object this[int index]
       {
           get
           {

               return GetValue(index).Value;
           }
           set
           {
               GetValue(index).Value = value;
           }
       }

       public void CopyTo(Array array, int index)
       {
           int j = index;
           LinkedListNode<object> node = _list.First;
           for (int i = 0; i < Count; i++)
           {
               array.SetValue(node.Value, j);
               node = node.Next;
               j++;
           }
       }

       public int Count
       {
           get { return _count; }
       }

       public bool IsSynchronized
       {
           get { return false; }
       }

       public object SyncRoot
       {
           get { return this; }
       }

       public IEnumerator GetEnumerator()
       {
           return GetMyLinkedListEnumerator();
       }
       private IEnumerator GetMyLinkedListEnumerator()
       {
           LinkedListNode<object> node = _list.First;
           for (int i = 0; i < Count; i++)
           {
               yield return node.Value;
               node = node.Next;
           }
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList list = new MyLinkedList();
            for (int i = 0; i < 10; i++)
                list.Add(i + 1);
            foreach(var ss in list)
                Console.WriteLine(ss);
            
            Console.ReadKey();
            
        }
    }
}
