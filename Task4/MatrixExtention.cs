using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class MatrixExtention
    {
        public static AbstractMatrix<T> Sum<T>(this AbstractMatrix<T> matrixA, AbstractMatrix<T> matrixB, Func<T, T, T> sumFunction)
        {
            MatrixAdder<T> visitor = new MatrixAdder<T>(matrixB, sumFunction);

            matrixA.Accept(visitor);

            return visitor.Sum;
        }
    }
}
