using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public abstract class AbstractMatrix<T> : IEnumerable<T>
    {

        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged = delegate {};

        public int Size { get; protected set; }

        public abstract T this[int i, int j] { get; set; }

        protected virtual void OnElementChanged(object sender, ElementChangedEventArgs<T> e)
        {
            ElementChanged(sender, e);
        }

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }

    public class ElementChangedEventArgs<T> : EventArgs
    {
        public int Row { get; }

        public int Column { get; }

        public T OldValue { get; }

        public T NewValue { get; }

        public ElementChangedEventArgs(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;    
        }
    }
}
