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

    #region 演示协变和逆变
    
    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override string ToString() => $"Width: {Width}, Height: {Height}";
    }

    public class Rectangle : Shape
    {

    }

    public class Variance
    {
        private void Display(Shape o)
        {
            Console.WriteLine(o);
        }
        private Rectangle GetRectangle()
        {
            return new Rectangle { Width = 20, Height = 10 };
        }
        private Shape GetShape()
        {
            return new Shape { Width = 20, Height = 20 };
        }
        public void Test()
        {
            var r = new Rectangle { Width = 10, Height = 20 };
            Display(r);//协变  子类变父类
            Shape shape = GetRectangle();//协变 子类变父类
            //Rectangle rectangle = GetShape(); //编译器报错 因为shape不一定总是rectangle 就是抗变
            Rectangle rectangle = (Rectangle)GetShape();

            IIndex<Rectangle> rectangles = RectangleCollection.GetRectangles();
            IIndex<Shape> shapes = rectangles;// 协变 接口  子类变父类

            IDisplay<Shape> shapeDisplay = new ShapeDisplay();
            IDisplay<Rectangle> recDisplay = shapeDisplay;// 逆变 父类变子类  自动转换

        }

        public interface IIndex<out T>// 用out关键字标注 意味着此接口协变 即子类自动转换父类。
        {
            T this[int index] { get; }
            int Count { get; }
        }

        public class RectangleCollection : IIndex<Rectangle>
        {
            private Rectangle[] data = new Rectangle[3]
            {
                new Rectangle{Width=20,Height=10},
                new Rectangle{Width=20,Height=10},
                new Rectangle{Width=20,Height=10},
            };

            private static RectangleCollection _coll;
            public static RectangleCollection GetRectangles() => _coll ?? (_coll = new RectangleCollection());

            public Rectangle this[int index]
            {
                get
                {
                    if (index < 0 || index > data.Length)
                    {
                        throw new ArgumentOutOfRangeException("index");
                    }
                    return data[index];
                }
            }

            public int Count => data.Length;
        }

        public interface IDisplay<in T>
        {
            void Show(T item);
        }

        public class ShapeDisplay : IDisplay<Shape>
        {
            public void Show(Shape item)
            {
                Console.WriteLine($"{item.GetType().Name} Width: {item.Width} ,Height: {item.Height}");
            }
        }
    }

    #endregion
}
