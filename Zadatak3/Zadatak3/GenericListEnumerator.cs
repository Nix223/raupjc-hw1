using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;

namespace Zadatak3
{
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> genericList;
        private int position;

        public GenericListEnumerator(GenericList<X> list)
        {
            genericList = list;
            position = 0;
        }

        public X Current
        {
            get { return genericList.GetElement(position); }
        }

        object IEnumerator.Current
        {
            get => genericList.GetElement(position);
        }

        public bool MoveNext()
        {
            if (position <= genericList.Count)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Dispose()
        {

        }

        public void Reset()
        {

        }


    }
}