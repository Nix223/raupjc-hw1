
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    class Program
    {
        public class GenericList<X> : IGenericList<X>
        {
            private X[] _internalStorage;
            private int pozicija = 0;

            public GenericList()
            {
                _internalStorage = new X[4];
            }

            public GenericList(int InitialSize)
            {
                _internalStorage = new X[InitialSize];
            }


            public void Add(X item)
            {
                if (pozicija >= _internalStorage.Length)
                {
                    Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
                }
                _internalStorage[pozicija] = item;
                pozicija++;
            }

            public bool RemoveAt(int index)
            {
                if (index > _internalStorage.Length)
                {
                    throw new IndexOutOfRangeException("Given index is out of bounds.");
                }
                for (int i = index; i < _internalStorage.Length; i++)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                pozicija--;
                return true;
            }

            public bool Remove(X item)
            {
                if (IndexOf(item) != -1)
                {
                    RemoveAt(IndexOf(item));
                }
                return false;
            }

            public X GetElement(int index)
            {
                if (index <= pozicija)
                {
                    return _internalStorage[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Given index is out of bounds");
                }
            }

            public int IndexOf(X item)
            {
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    if (_internalStorage[i].Equals(item))
                    {
                        return i;
                    }
                }
                return -1;
            }

            public int Count
            {
                get { return pozicija + 1; }
            }

            public void Clear()
            {
                pozicija = 0;
            }

            public bool Contains(X item)
            {
                for (int i = 0; i < _internalStorage.Length; i++)
                {

                    if (_internalStorage[i].Equals(item))
                    {
                        return true;
                    }
                }
                return false;
            }





        }
    }
}