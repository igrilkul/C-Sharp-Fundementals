using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
//23:45
namespace Stack
{
    class Stack<T> : IEnumerable<T>
    {
        private Node<T> top;

        public Stack()
        {
            this.top = null;
        }

        private class Node<T>
        {
            public Node(T element)
            {
                this.element = element;
                this.prev = null;
            }

            public T element { get; set; }
            public Node<T> prev { get; set; }
        }

        public void Push(T element)
        {
            Node<T> curNode = new Node<T>(element);

            if(this.top==null)
            {
                this.top = curNode;
            }
            else
            {
                Node<T> saveCurTop = this.top;
                this.top = curNode;
                this.top.prev = saveCurTop;
            }
        }

        

        public T Pop()
        {
            if(this.top==null)
            {
                throw new InvalidOperationException("No elements");
            }

            Node<T> current = this.top;
            T toReturn = this.top.element;
            this.top = this.top.prev;
            current = null;
            return toReturn;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.top;

            while(current!=null)
            {
                yield return current.element;

                current = current.prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
