using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNativeMethods
{
    class Genetic
    {
        #region 泛型和非泛型性能比较
        void Collection()
        {
            var list = new ArrayList();
            list.Add(44); // boxing

            int i1 = (int)list[0]; // unboxing

            foreach (int item in list)
            {
                Console.WriteLine(item);// unboxing
            }
        }
        void Generic()
        {
            var list = new List<int>();
            list.Add(44); //no boxing
            foreach (var item in list)
            {
                Console.WriteLine(item);//no boxing
            }
        }
        #endregion

        #region 安全
        void Collection2()
        {
            var list = new ArrayList();
            list.Add(44);
            list.Add("hello");
            foreach (int item in list)//当不能将类型转换为int时就会发生异常
            {
                Console.WriteLine(item);
            }
        }
#if !DEBUG
        void Generic()
        {
            var list = new List<int>();
            list.Add(66);
            list.Add("hello");// 编译器报错
        }
#endif
        #endregion
    }

    #region 自定义非泛型的链表
    public class LinkedListNode
    {
        public LinkedListNode(object value)
        {
            Value = value;
        }

        public object Value { get; set; }

        public LinkedListNode Next { get; set; }
        public LinkedListNode Prev { get; set; }
    }
    public class LinkedList : IEnumerable
    {
        public LinkedListNode First { get;private set; }
        public LinkedListNode Last { get;private set; }

        public LinkedListNode AddLast(object node)
        {
            var newNode = new LinkedListNode(node);
            if (First==null)
            {
                First = Last= newNode;
            }
            else
            {
                LinkedListNode previous = Last;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }
        public IEnumerator GetEnumerator()
        {
            LinkedListNode current = First;
            while (current!=null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

    }
    #endregion

    #region 泛型链表
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Prev { get; set; }
    }
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> First { get; private set; }
        public LinkedListNode<T> Last { get; private set; }

        public LinkedListNode<T> AddLast(T node)
        {
            var newNode = new LinkedListNode<T>(node);
            if (First==null)
            {
                First = Last = newNode;
            }
            else
            {
                LinkedListNode<T> previous = Last;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = First;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    #endregion
}
