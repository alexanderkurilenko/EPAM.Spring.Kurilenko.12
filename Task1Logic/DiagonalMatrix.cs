using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class DiagonalMatrix<T>:AbstractMatrix<T>
    {
        #region Field
        private T[] matrix;
        #endregion
        #region Ctors
        /// <summary>
        /// Ctor with jagged array
        /// </summary>
        /// <param name="arr"></param>
        public DiagonalMatrix(T[][] arr)
        {
            if (!CheckDiagonal(arr))
                throw new ArgumentException("matrix is not diagonal", nameof(matrix));

            Order = arr.Length;
            matrix = new T[Order*Order];

            for (int i = 0; i <arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i == j)
                        matrix[i] = arr[i][j];
                    else
                        matrix[i] = default(T);
                }
            }

        }

        public DiagonalMatrix(T[] diagonal) 
        {
            Order = diagonal.Length;
            matrix = new T[Order];

            for (int i = 0; i < Order; i++)
            {
                matrix[i] = diagonal[i];
            }
        }

        #endregion

        #region ProtectedMethods
        protected override T GetElement(int row, int col)
        {
            return row == col ? matrix[row] : default(T);
        }


        protected override void SetElement(int i, int j, T val)
        {
            if (i < Order || j < Order)
                throw new ArgumentException();
            if (i != j)
                throw new ArgumentException("Not diagonal element");
            else
            {
                matrix[i] = val;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// check if matrix is diagonal
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static bool CheckDiagonal(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix.Where((t, j) => i != j && !matrix[i][j].Equals(default(T))).Any())
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
