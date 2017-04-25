using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SymmetricMatrix<T>: AbstractMatrix<T>
    {

        private readonly T[][] matrix;

        public SymmetricMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            Size = array.Length;

            matrix = new T[Size][];

            for (int i = 0; i < array.Length; i++)
            {
                matrix[i] = new T[i + 1];
                for (int j = 0; j < array[i].Length && j <= i; j++)
                    matrix[i][j] = array[i][j];
            }
        }

        public override T this[int i, int j]
        {
            get {
                if (i > Size || j > Size || i <= 0 || j <= 0)
                    throw new IndexOutOfRangeException();

                i--; j--;
                return (j <= i) ? matrix[i][j] : matrix[j][i];
            }
            set
            {
                if (i > Size || j > Size || i <= 0 || j <= 0)
                    throw new IndexOutOfRangeException();

                i--; j--;
                if (j <= i)
                    matrix[i][j] = value;
                else
                    matrix[j][i] = value;

                OnElementChanged(this, new ElementChangedEventArgs<T>(++i, ++j));
            }
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return (j <= i) ? matrix[i][j] : matrix[j][i];
        }
    }
}
