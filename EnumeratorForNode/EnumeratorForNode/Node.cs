using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorForNode
{
    public class Node<T>
    {        
        public Node<T> next;
        public T data;

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public Node()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"> Value is copied to the data. </param>
        public Node(T value)
        {
            this.data = value;
            this.next = null;
        }
       
    }
}
