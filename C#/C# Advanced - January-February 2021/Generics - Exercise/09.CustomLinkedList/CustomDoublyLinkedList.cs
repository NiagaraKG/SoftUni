using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T>
    {       
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        public int Count { get; private set; }
        public void AddFirst(T element)
        {
            if (this.Count == 0) { this.Head = this.Tail = new Node<T>(element); }
            else
            {
                var newHead = new Node<T>(element);
                newHead.Next = this.Head;
                this.Head.Previous = newHead;
                this.Head = newHead;
            }
            this.Count++;
        }
        public void AddLast(T element)
        {
            if (this.Count == 0) { this.Head = this.Tail = new Node<T>(element); }
            else
            {
                var newTail = new Node<T>(element);
                newTail.Previous = this.Tail;
                this.Tail.Next = newTail;
                this.Tail = newTail;
            }
            this.Count++;
        }
        public T RemoveFirst()
        {
            if (this.Count == 0) { throw new InvalidOperationException("The list is empty"); }
            var first = this.Head.Value;
            this.Head = this.Head.Next;
            if(this.Head != null) { this.Head.Previous = null; }
            else { this.Tail = null; }
            this.Count--;
            return first;
        }
        public T RemoveLast()
        {
            if(this.Count == 0) { throw new InvalidOperationException("The list is empty"); }
            var last = this.Tail.Value;
            this.Tail = this.Tail.Previous;
            if(this.Tail != null) { this.Tail.Next = null; }
            else { this.Head = null; }
            this.Count--;
            return last;
        }
        public void ForEach(Action<T> action)
        {
            var current = this.Head;
            while(current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            int counter = 0;
            var currentNode = this.Head;
            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.Next;
                counter++;
            }
            return array;
        }
    }
}