using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SquareMatrix<T>: AbstractMatrix<T>
    {

        private readonly T[,] matrix;

        public SquareMatrix(int size)
        {
            Size = size;
            matrix = new T[Size, Size];
        }

        public SquareMatrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Size = array.GetLength(0) >= array.GetLength(1) ? array.GetLength(0) : array.GetLength(1);

            matrix = new T[Size, Size];

            for (int i = 0; i < array.GetLength(0); i++)
            for (int j = 0; j < array.GetLength(1); j++)
                matrix[i, j] = array[i, j];
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i > Size || j > Size || i <= 0 || j <= 0)
                    throw new ArgumentOutOfRangeException();
                return matrix[--i, --j];
                
            }
            set
            {
                if (i > Size || j > Size || i <= 0 || j <= 0)
                    throw new IndexOutOfRangeException();

                OnElementChanged(this, new ElementChangedEventArgs<T>(i, j));

                matrix[i, j] = value;
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var item in matrix)
            {
                yield return item;
            }
        }
    }
}
