using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class DiagonalMatrix<T>: AbstractMatrix<T>
    {

        private T[] container;

        public DiagonalMatrix(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Size = array.Length;

            container = new T[array.Length];

            for (int i = 0; i < Size; i++)
                container[i] = array[i];
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i > Size || j > Size || i <= 0 || j <= 0)
                    throw new IndexOutOfRangeException();
                if (i == j)
                {
                    return container[--i];
                }
                return default(T);
            }
            set
            {
                if (i > Size || j > Size || i <= 0 || j <= 0)
                    throw new IndexOutOfRangeException();
                if (i == j)
                {
                    container[--i] = value;
                }

                OnElementChanged(this, new ElementChangedEventArgs<T>(i, --j));
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    yield return (i == j) ? container[i] : default(T);
                }
            }
        }
    }
}
