using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Collections_Generics
{
    public class MyLinkedList : IList
    {
        private object[] _list = new object[100];
        private int _count = 0;
  
        public int Add(object value)
        {
            if (_count < _list.Length)
            {
                _list[_count] = value;
                return _count++;
            }
            else 
                return -1;
        }

        public void Clear()
        {
            _list = new object[100];
        }

        public bool Contains(object value)
        {
            foreach (var s in _list)
            {
                if (s == value)
                    return true;
            }
            return false;
        }

        public int IndexOf(object value)
        {
            int count = 0;
            for (int i = 0; i < Count;i++ )
            {
                if (_list[i] == value)
                    return count;
                count++;
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if (index < _list.Length && _list[99] == null)
            {
                for (int i = Count; i > index; i--)
                    _list[i + 1] = _list[i];
                _list[index] = value;
            }
            else throw new NotImplementedException();
        }

        public bool IsFixedSize
        {
            get { return true; }
        }

        public bool IsReadOnly
        {
            get
            { return false; }
        }

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index <= Count)
            {
                for (int i = index; i <= Count; i++)
                    _list[i] = _list[i + 1];
                _count--;
            }
            else 
                throw new NotImplementedException();
        }

        public object this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get{ return _count;}
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList linked = new MyLinkedList();
            for (int i = 0; i < 10; i++)
                linked.Add(i + 1);
                linked.Remove(4);
            foreach(var s in linked)
            Console.WriteLine(s);
            Console.ReadKey();
            
        }
    }
}
