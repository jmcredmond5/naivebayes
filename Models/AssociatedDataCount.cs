using System;

namespace NaiveBayes.Models
{
    public class AssociatedDataCount<T> where T: Enum
    {
        public T dataValue { get; set; }
        public int Count { get; set; }
    }
}
