using System;
using System.Collections;
using System.Collections.Generic;

namespace EnumeratorForNode
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;

        /// <summary>
        /// Insert any node at the front in the list.
        /// </summary>
        /// <param name="data"> A new node data. </param>
        public void AddFirst(T data)
        {
            var newnode = new Node<T>(data);           
            newnode.next = head;
            head = newnode;
        }

        /// <summary>
        /// Insert any node at the end in the list.
        /// </summary>
        /// <param name="data"> A new node data </param>
        public void AddLast(T data)
        {
            var newnode = new Node<T>(data);
            if (head == null)
            {  
                head = newnode;
            }
            else
            {                
                Node<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newnode;
            }
        }

        /// <summary>
        /// Check if a value in the list
        /// </summary>
        /// <returns> True if the value is found, otherwise false. </returns>
        public bool Contains(T value)
        {
            foreach (var item in this)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Print our list
        /// </summary>
        public void Print()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// IEnumerable<T> allowing a LinkedList to be used in a foreach statement.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnum<T>(head); 
        }   

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class LinkedListEnum<T> : IEnumerator<T>
    {
        private Node<T> current;
        private Node<T> head;
        private bool first;
       
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="head"> A new node </param>
        public LinkedListEnum(Node<T> head)
        {
            this.head = head;
            this.current = null;
            this.first = true;
        }

        public object Current => this.current.data;

        T IEnumerator<T>.Current => this.current.data;   // Gets the data at the current node.        
                
        public void Dispose()
        {            
        }

        /// <summary>
        /// Go to the next element of the collection.
        /// </summary>
        /// <returns> True if the enumerator was successfully went to the next element. 
        ///           False if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            if (first)
            {
                first = false;
                this.current = head;
                return true;
            }
            else
            {                
                this.current = this.current.next;
                return current != null;
            }
        }

        /// <summary>
        /// Sets the enumerator to its initial position.
        /// </summary>
        public void Reset()
        {
           this.current = head;
        }
    }
}
