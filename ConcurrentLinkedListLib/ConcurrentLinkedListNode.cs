using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrentLinkedListLib
{
    public class ConcurrentLinkedListNode<T>
    {
        public T Value { get; set; }

        public ConcurrentLinkedListNode<T> Next { get; set; }

        public ConcurrentLinkedListNode<T> Prev { get; set; }
    }
}
