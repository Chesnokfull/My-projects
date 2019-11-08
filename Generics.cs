using System;
using System.Collections;

namespace Generics
{
    public class MyList<T> : IEnumerable, IEnumerator
    {
        public T Value { get; }
        private MyList<T> Next { set; get; }
        int position;

        public MyList(T userVal) : this()
        {
            Value = userVal;
        }

        MyList()
        {
            position = -1;
            Next = null;
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public object Current
        {
            get
            {
                try
                {
                    return this[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < this.Amount);
        }

        public void Reset()
        {
            position = 0;
        }

        public int Amount
        {
            get
            {
                int result = 1;
                MyList<T> temp = this;
                while (temp.Next != null)
                {
                    result++;
                    temp = temp.Next;
                }
                return result;
            }
        }


        public void AddElement(T newValue)
        {
            MyList<T> newEl = new MyList<T>(newValue);
            MyList<T> temp = this;

            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newEl;

        }

        public void ShowList()
        {
            MyList<T> temp = this;

            while (temp.Next != null)
            {
                Console.WriteLine(temp.Value);
                temp = temp.Next;
            }
            Console.WriteLine(temp.Value);
        }



        public MyList<T> this[int index]
        {
            get
            {
                MyList<T> temp = this;
                for (int i = 0; i < this.Amount; i++)
                    if (i == index)
                        return temp;
                    else
                        temp = temp.Next;
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>(8);


            myList.AddElement(5);
            myList.AddElement(6);
            myList.AddElement(2);

            foreach (MyList<int> a in myList)
            {
                Console.WriteLine(a.Value);
            }

            myList.ShowList();
        }
    }
}
