using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public interface IVisitor<T>
    {
        void Visit(AbstractMatrix<T> left, AbstractMatrix<T> right);
        
    }
}
