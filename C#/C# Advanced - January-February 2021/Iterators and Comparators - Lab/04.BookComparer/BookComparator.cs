using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book A, Book B)
        {
            int result = A.Title.CompareTo(B.Title);
            if (result == 0) { result = A.CompareTo(B); }
            return result;
        }
    }
}
