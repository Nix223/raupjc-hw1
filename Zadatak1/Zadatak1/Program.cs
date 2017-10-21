using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    class Program
    {
        public class IntegerList :IIntegerList
        {
            private int[] _internalStorage;
            private int pozicija = 0;

            public IntegerList()
            {
                _internalStorage = new int[4];
            }

            public IntegerList(int initialSize)
            {
                _internalStorage = new int[initialSize];
            }

            public void Add(int item)
            {
                if(pozicija>=_internalStorage.Length)
                {
                   /* Array.Copy(_internalStorage, _internalStorage, _internalStorage.Length*2);*/
                    Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
                }
                _internalStorage[pozicija] = item;
                pozicija++;
            }

            public bool RemoveAt(int index)
            {
                if (index > _internalStorage.Length)
                {
                    throw new IndexOutOfRangeException("Uneseni index je izvan polja");
                }
                for (int i = index; i < _internalStorage.Length - 1; i++)
                {
                    _internalStorage[i] = _internalStorage[i+1];
                }
                return true;
            }

            public bool Remove(int item)
            {
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    if (_internalStorage[i] == item)
                    {
                        return RemoveAt(i);
                    }

                }
                throw new IndexOutOfRangeException("Broj se ne nalazi u polju");
            }

            public int GetElement(int index)
            {
               if(index>_internalStorage.Length)
                {
                   throw new IndexOutOfRangeException("Uneseni index se ne nalazi u polju");
                } else
                {
                    return _internalStorage[index];
                }
            }

            public int IndexOf(int item)
            {
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    if (_internalStorage[i] == item)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public int Count
            {
                get {
                    return pozicija + 1;
                }
                
            }
            
            public void Clear()
            {
                Array.Clear(_internalStorage,0,_internalStorage.Length);
            }

            public bool Contains(int item)
            {
                for(int i=0;i<_internalStorage.Length;i++)
                {
                    if (_internalStorage[i] == item)
                    {
                        return true;
                    }
                }
                return false;
            }

            
        }
    }
}
