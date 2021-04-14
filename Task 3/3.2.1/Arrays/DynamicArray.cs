using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._2._1
{
    class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        private T[] _arr;

        public int Capacity => _arr.Length;
        public int Length { get; private set; } //count
        public DynamicArray()
        {
            _arr = new T[8];
            Length = 0;
        }

        public DynamicArray(int capacity)
        {
            _arr = new T[capacity];
            Length = 0;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            if (collection is not null)
            {
                _arr = new T[collection.Count()];    ///////
                foreach (var item in collection)
                {
                    Add(item);
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0)
                {
                    return _arr[index];
                }
                else
                {
                    return _arr[index + Capacity];
                }
            }
            set
            {
                if (index >= 0)
                {
                    _arr[index] = value;
                }
                else
                {
                    _arr[index + Capacity] = value;
                }
            }
        }

        public void Add(T item)
        {
            if (this.Length >= this.Capacity)
            {
                Array.Resize(ref _arr, Capacity * 2);
            }
            _arr[Length++] = item;
        }

        public void AddRange(IEnumerable<T> otherCollection)
        {
            if (otherCollection.Count() > (Capacity - Length))
            {
                Array.Resize(ref _arr, (Capacity + (otherCollection.Count() - (Capacity - Length))));
            }
            foreach(var item in otherCollection)
            {
                Add(item);
            }
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Length))
            {
                for (int i = index; i < Length-1 ; i++)
                {
                    _arr[i] = _arr[i + 1];
                }
                Array.Copy(_arr,  _arr,  Length - 1);
                Length--;
            }

            else
            {
                throw new ArgumentException(message: "Index must be at range from 0 to length");
            }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_arr[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;

        }

        public bool Insert(int index, T item)
        {
            if (index > Length || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            try
            {
                if (this.Length >= Capacity)
                {
                    Array.Resize(ref _arr, Capacity * 2);
                }

                Array.Copy(_arr, index, _arr, index + 1, Length - index);

                _arr[index] = item;

                Length++;
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(this);
        }

        public object Clone()
        {
            return new DynamicArray<T>(this);
        }

        public T[] ToArray()
        {
            var array = new T[Length];
            Array.Copy(_arr, array, Length);
            return array;
        }
        public void ChangeCapacity(int newCapacity)
        {
            if (newCapacity != 0)
            {
                var tmp = Length - newCapacity;

                for (int i = newCapacity; i < _arr.Length; i++)
                {
                    RemoveAt(tmp--);
                }
            }
            else throw new ArgumentException(message: "Capacity can't be 0");
           
        }
        public class DynamicArrayEnumerator<T> : IEnumerator<T>
        {
            private readonly DynamicArray<T> _tmpArr;
            int position = -1;

            public DynamicArrayEnumerator(DynamicArray<T> array)
            {
                _tmpArr = array;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return _tmpArr[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose() { }


            public bool MoveNext()
            {
                position++;
                return (position < _tmpArr.Length);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}
