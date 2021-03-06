using System;
using System.Collections;
using System.Collections.Generic;

namespace Enumerators
{
    class Universities : IEnumerable<University>
    {
        private List<University> universities = new List<University>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="universities"> Univerities list </param>
        public Universities(List<University> universities)
        {
            foreach (var university in universities)
            {
                this.universities.Add(university);
            }
        }

        /// <summary>
        /// Implementation for the GetEnumerator method for generic.
        /// </summary>
        /// <returns> Returns an enumerator that iterates through a collection.</returns>
        public IEnumerator<University> GetEnumerator()
        {
            return new UniversityEnum(universities);
        }

        /// <summary>
        /// Implementation for the GetEnumerator method for non-generic.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       
    }
    class UniversityEnum : IEnumerator<University>
    {
        private List<University> universities;
        int position = -1; // Enumerators are positioned before the first element.

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="universities">Universities list</param>
        public UniversityEnum(List<University> universities)
        {
            this.universities = universities;
        }

        object IEnumerator.Current => this.Current; // Gets the element at the current position of the enumerator.

        public University Current
        {
            get
            {
                try
                {
                    return this.universities[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Go to the next element of the collection.
        /// </summary>
        /// <returns> True if the enumerator was successfully went to the next element. 
        ///           False if the enumerator has passed the end of the collection.
        /// </returns>
        public bool MoveNext()
        {
            position++;
            if (position < universities.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the enumerator to its initial position.
        /// </summary>
        public void Reset()
        {
            position = -1;
        }

        /// <summary>
        /// To close or release unmanaged resources
        /// </summary>
        public void Dispose()
        {
            this.position = -1;
        }
    }
}
