using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task1Logic
{
    public class SquareMatrix<T> :AbstractMatrix<T>
    {
        #region Field
        private readonly T[] matrix;
        #endregion

        #region Ctors
        public SquareMatrix()
        {
            matrix = new T[1];
        }

        public SquareMatrix(int order)
        {
            this.Order = order;
            matrix = new T[Order * Order];
        }

        /// <summary>
        /// Ctor with jagged array param
        /// </summary>
        /// <param name="arr"></param>
        public SquareMatrix(T[][] arr)
        {
            if (arr == null)
                throw new NullReferenceException();
            if (!CheckSquare(arr))
                throw new ArgumentException();
            Order = arr.Length;
            matrix = new T[Order * Order];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int rowOffset = Order * i;
                for (int j = 0; j <arr[i].Length; j++)
                {
                    matrix[rowOffset + j] = arr[i][j];
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check if matrix is square
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static bool CheckSquare(T[][] matrix)
        {
            int order = matrix.Length;
            for (int i = 0; i < order; i++)
            {
                if (matrix[i].Length != order)
                    return false;
            }
            return true;
        } 

        protected override void SetElement(int i, int j, T val)
        {
            if (i > Order || j > Order)
                throw new ArgumentException();
            matrix[i * Order + j] = val;
        }

        protected override T GetElement(int i, int j)
        {
            if (i > Order || j > Order)
                throw new ArgumentException();
            return matrix[i * Order + j];
        }
        #endregion

    }
}
