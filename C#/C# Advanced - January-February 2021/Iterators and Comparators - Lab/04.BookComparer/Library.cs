﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books) 
        {               
            this.books = new List<Book>(books);  this.books.Sort(new BookComparator()); 
        }
        public IEnumerator<Book> GetEnumerator() { return new LibraryIterator(this.books); }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex { get; set; }
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public Book Current => this.books[this.currentIndex];
            object IEnumerator.Current => this.Current;
            public void Dispose() { }
            public bool MoveNext() => ++this.currentIndex < this.books.Count;
            public void Reset() => this.currentIndex = -1;
        }

    }
}
