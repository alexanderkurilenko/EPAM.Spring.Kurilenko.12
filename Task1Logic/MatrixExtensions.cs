using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public static class MatrixExtensions
    {
        /// <summary>
        /// Summ of all types of matrix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mt1"></param>
        /// <param name="mt2"></param>
        /// <returns></returns>
        public static AbstractMatrix<T> Add<T>(this AbstractMatrix<T> mt1, AbstractMatrix<T> mt2)
        {
            var visitor = new SumVisitor<T>();
            mt1.Accept(visitor, mt2);
            return visitor.Result;
        }

        /// <summary>
        /// compare with jagged array for unit testing
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="arrayMatrix"></param>
        /// <returns></returns>
        public static bool CompareToJaggedArray<T>(this AbstractMatrix<T> matrix, T[][] arrayMatrix)
        {
            if (arrayMatrix == null || (arrayMatrix.Length != matrix.Order || arrayMatrix[0].Length != matrix.Order))
                return false;

            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    if (!matrix[i, j].Equals(arrayMatrix[i][j]))
                        return false;
                }
            }

            return true;
        }

    }
}
