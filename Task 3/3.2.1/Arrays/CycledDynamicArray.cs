using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3._2._1
{
    class CycledDynamicArray<T> : DynamicArray<T>,IEnumerable<T>
    {
        public CycledDynamicArray() : base() { }

        public CycledDynamicArray(int capacity) : base(capacity) { }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection) { }

        public new IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(this);
        }

        public class CycledDynamicArrayEnumerator<T> : IEnumerator<T>
        {
            private readonly CycledDynamicArray<T> tmpArr;
            int position = -1;

            public CycledDynamicArrayEnumerator(CycledDynamicArray<T> array)
            {
                tmpArr = array;
            }

            public T Current
            {
                get
                {
                    if (position == -1 || position >= tmpArr.Length)
                        position = 0;
                    return tmpArr[position];
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose() { }


            public bool MoveNext()
            {
                if (position <= tmpArr.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    position = 0;
                    return true;
                }
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}
