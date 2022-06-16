using System;

namespace Generic {

    public interface IList<T> {
        public void Push(T value);
        public void Remove(int index);
        public bool Find(T value);
        public void Print();

        public int Length {
            get;
        }

        public T this[int index] { // indexer (implements get method}
            get;
            set;
        }

    }

    public class Node<T> {
        public T value;
        public Node<T>? next;
        public Node<T>? prev;
        public Node(T value) {
            this.value = value;
        }
    }

    public class LinkedList<T> : IList<T> {
        private Node<T>? head;
        private Node<T>? tail;
        private int len = 0;


        public void Push(T value) {
            Node<T>? node = new Node<T>(value);

            if (len == 0)
                head = node;


            else {
                tail.next = node;
                node.prev = tail;

            }

            tail = node;
            len++;
        }

        public void Remove(int index) {
            if (index >= len || index < 0) {
                Console.WriteLine("Wrong index");
                return;
            }
            if (index == 0)
                head = head.next;


            else if (index == len - 1) {
                tail.prev = tail;
            }

            else {
                Node<T> node = head;
                for (int i = 0; i < index; ++i)
                    node = node.next;

                node.prev.next = node.next;
            }
            len--;
        }



        public bool Find(T value) {
            for (int i = 0; i < len; ++i)
                if (Equals(this[i], value))
                    return true;

            return false;


        }

        public T this[int index] {
            get {
                Node<T>? node = head;
                for (int i = 0; i < index; ++i)
                    node = node.next;

                return node.value;
            }
            set {
                Node<T>? node = head;

                for (int i = 1; i < index; ++i)
                    node = node.next;

                node.value = value;
            }

        }


        public int Length {
            get => len;
        }

        public void Print() {
            Node<T>? curNode = head;

            for (int i = 0; i < len; ++i) {
                Console.WriteLine(curNode.value);
                curNode = curNode.next;
            }

        }
    }

    public class ArrayList<T> : IList<T> {
        T[] array;
        int size, capacity;

        public ArrayList() {

            size = 0;
            capacity = 100;
            Array.Resize(ref array, capacity);
        }

        public void Push(T value) {
            if (size + 1 >= capacity) {
                capacity *= 2;
                Array.Resize(ref array, capacity);
            }

            array[size] = value;
            size++;
        }

        public void Remove(int index) {
            if (index >= size || index < 0) {
                Console.WriteLine("Wrong index");
                return;
            }

            for (int i = index + 1; i < size; ++i)
                array[i - 1] = array[i];
            size--;
        }

        public bool Find(T value) {
            for (int i = 0; i < size; ++i)
                if (Equals(array[i], value))
                    return true;
            return false;
        }

        public int Length {
            get => size;
        }

        public T this[int index] {
            get {
                return array[index];
            }
            set {
                array[index] = value;
            }
        }

        public void Print() {
            for (int i = 0; i < size; ++i)
                Console.WriteLine(array[i]);
        }

    }

    public class Iterator<T> {
        public IList<T> list;
        public int pos = -1;

        public Iterator(IList<T> list) {
            this.list = list;
        }

        public bool MoveNext() {
            return (++pos < list.Length);
        }

        public T? Current() {
            return list[pos];
        }
    }

    class Program {
        static void Main() {
            ArrayList<string> strArray = new ArrayList<string>();
            strArray.Push("Paul McCartney");
            strArray.Push("Ringo Starr");
            strArray.Push("George Harrison");
            strArray.Push("John Lennon");
   

            //Iterator
            Iterator<string> iter = new Iterator<string>(strArray);   
            while (iter.MoveNext())
                Console.WriteLine(iter.Current());

        }
    }
    
}


