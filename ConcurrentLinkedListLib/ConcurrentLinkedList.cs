using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;

namespace ConcurrentLinkedListLib
{
    public class ConcurrentLinkedList<T> : IEnumerable<T>
    {
        public ConcurrentLinkedListNode<T> _root;

        public ConcurrentLinkedList(IEnumerable<T> collection)
        {
            foreach(var item in collection)
            {
                this.AddFirst(item);
            }
        }

        public ConcurrentLinkedList() 
        { }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly { get; private set; } = false;

        public ConcurrentLinkedListNode<T> First { get; private set; }

        public ConcurrentLinkedListNode<T> Last { get; private set; }

        public ConcurrentLinkedListNode<T> AddBefore(ConcurrentLinkedListNode<T> node, T item)
        {
            if (_root == null)
                throw new Exception("The linked list isn't contains nodes");

            var newNode = new ConcurrentLinkedListNode<T>() { Value = item };

            SetNewNodeBeforeTargetNode(node, newNode);

            return newNode;
        }

        public void AddBefore(ConcurrentLinkedListNode<T> node, ConcurrentLinkedListNode<T> item)
        {
            if (_root == null)
                throw new Exception("The linked list isn't contains nodes");

            SetNewNodeBeforeTargetNode(node, item);
        }

        public (ConcurrentLinkedListNode<T>, bool) TryAddBefore(ConcurrentLinkedListNode<T> node, T item, TimeSpan timeCallBack)
        {
            throw new NotImplementedException();
        }

        public (ConcurrentLinkedListNode<T>, bool) TryAddBefore(ConcurrentLinkedListNode<T> node, ConcurrentLinkedListNode<T> item, TimeSpan timeCallBack)
        {
            throw new NotImplementedException();
        }

        public ConcurrentLinkedListNode<T> AddAfter(ConcurrentLinkedListNode<T> node, T item)
        {
            if(_root == null)
                throw new Exception("The linked list isn't contains nodes");

            var newNode = new ConcurrentLinkedListNode<T>() { Value = item };

            SetNewNodeAfterTargetNode(node, newNode);

            return newNode;
        }

        public void AddAfter(ConcurrentLinkedListNode<T> node, ConcurrentLinkedListNode<T> item)
        {
            if (_root == null)
                throw new Exception("The linked list isn't contains nodes");

            SetNewNodeAfterTargetNode(node, item);
        }

        public ConcurrentLinkedListNode<T> TryAddAfter(ConcurrentLinkedListNode<T> node, T item, TimeSpan timeCallBack)
        {
            throw new NotImplementedException();
        }

        public ConcurrentLinkedListNode<T> TryAddAfter(ConcurrentLinkedListNode<T> node, ConcurrentLinkedListNode<T> item, TimeSpan timeCallBack)
        {
            throw new NotImplementedException();
        }

        public ConcurrentLinkedListNode<T> AddFirst(T item)
        {
            var newNode = new ConcurrentLinkedListNode<T>() { Value = item };

            if(_root == null)
            {
                InitializeRootNode(newNode);
            }
            else
            {
                First.Prev = newNode;
                newNode.Next = First;
                First = newNode;
            }

            return newNode;
        }

        public void AddFirst(ConcurrentLinkedListNode<T> item)
        {
            if(_root == null)
            {
                InitializeRootNode(item);
            }
            else
            {
                First.Prev = item;
                item.Next = First;
                First = item;
            }
        }

        public ConcurrentLinkedListNode<T> AddLast(T item)
        {
            var newNode = new ConcurrentLinkedListNode<T>() { Value = item };
            
            if(_root == null)
            {
                InitializeRootNode(newNode);
            }
            else
            {
                Last.Next = newNode;
                newNode.Prev = Last;
                Last = newNode;
            }

            return newNode;
        }

        public void AddLast(ConcurrentLinkedListNode<T> item)
        {
            if(_root == null)
            {
                InitializeRootNode(item);
            }
            else
            {
                Last.Next = item;
                item.Prev = Last;
                Last = item;
            }
        }

        public bool TryAddFirst(T item, TimeSpan timeCallback)
        {
            throw new NotImplementedException();
        }

        public bool TryAddFirst(ConcurrentLinkedListNode<T> item, TimeSpan timeCallback)
        {
            throw new NotImplementedException();
        }

        public bool TryAddLast(T item, TimeSpan timeCallBack)
        {
            throw new NotImplementedException();
        }

        public bool TryAddLast(ConcurrentLinkedListNode<T> item, TimeSpan timeCallBack)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool TryClear(TimeSpan timeCallBack)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void InitializeRootNode(ConcurrentLinkedListNode<T> item)
        {
            _root = item;
            First = _root;
            Last = _root;
        }

        private void SetNewNodeBeforeTargetNode(ConcurrentLinkedListNode<T> targetNode, ConcurrentLinkedListNode<T> newNode)
        {
            var pointer = _root;

            while (pointer != null)
            {
                if (pointer != targetNode)
                {
                    pointer = pointer.Next;
                }
                else
                {
                    break;
                }
            }

            if (pointer == null)
            {
                AddFirst(newNode);
            }
            else
            {
                var prevNode = pointer.Prev;
                pointer.Prev = newNode;
                newNode.Next = pointer;
                newNode.Prev = prevNode;

                if (prevNode != null)
                {
                    prevNode.Next = newNode;
                }
                else
                {
                    First = newNode;
                }
            }
        }

        private void SetNewNodeAfterTargetNode(ConcurrentLinkedListNode<T> targetNode, ConcurrentLinkedListNode<T> newNode)
        {
            var pointer = _root;

            while (pointer != null)
            {
                if (pointer != targetNode)
                {
                    pointer = pointer.Next;
                }
                else
                {
                    break;
                }
            }

            if (pointer == null)
            {
                AddLast(newNode);
            }
            else
            {
                var nextNode = pointer.Next;
                pointer.Next = newNode;
                newNode.Prev = pointer;
                newNode.Next = nextNode;

                if (nextNode != null)
                {
                    nextNode.Prev = newNode;
                }
                else
                {
                    Last = newNode;
                }
            }
        }

        public class ConcurrentLinkedListEnumerator : IEnumerator<T>
        {
            public T Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
