using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class SimmetricMatrix<T>:AbstractMatrix<T>
    {
        #region field
        private T[] matrix;
        #endregion

        #region Ctor
        public SimmetricMatrix() 
        {
            matrix = new T[1];
        }

        /// <summary>
        /// Ctor with jagged array parameter
        /// </summary>
        /// <param name="arr"></param>
        public SimmetricMatrix(T[][] arr)
        {
           
            if (!CheckTranspose(arr))
                throw new ArgumentException("matrix is not symmetric", nameof(matrix));
            Order = arr.Length;
            int size = (int)((Math.Pow(Order, 2) + Order) / 2);
            matrix = new T[size];
            int offset = 0;

            for (int i = 0; i < Order; i++, offset += i)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[j + offset] = arr[i][j];
                }
            }
        }
        #endregion

        #region Methods
        protected override void SetElement(int i, int j, T val)
        {
            if (i < Order|| j < Order)
                throw new ArgumentException();
            matrix[i * Order + j] = val;
            matrix[j * Order + i] = val;
        }

        protected override T GetElement(int i, int j)
        {
            if (i < Order || j < Order)
                throw new ArgumentException();
            return matrix[i * Order + j];
        }

        #endregion
        #region Private Methods
        /// <summary>
        /// Check if the  matrix is the same when was transposed
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static bool CheckTranspose(T[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix.Where((t, j) => !matrix[i][j].Equals(t[i])).Any())
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

    }
}
