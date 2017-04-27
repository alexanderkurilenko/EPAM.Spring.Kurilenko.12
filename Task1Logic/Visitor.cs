using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    class SumVisitor<T>:IVisitor<T>
    {

        public AbstractMatrix<T> Result { get; private set; }


        public void Visit(AbstractMatrix<T> lhs, AbstractMatrix<T> rhs)
        {

            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            if (lhs.Order!= rhs.Order)
                throw new ArgumentException();

            Result = new SquareMatrix<T>(rhs.Order);

            for (int i = 0; i < lhs.Order; i++)
            {
                for (int j = 0; j < rhs.Order ; j++)
                {
                    Result[i, j] = (T)((dynamic)lhs[i, j] + rhs[i, j]);   
                }
            }
        }
    }
}
