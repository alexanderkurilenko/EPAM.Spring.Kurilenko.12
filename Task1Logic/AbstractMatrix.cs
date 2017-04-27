using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public abstract class AbstractMatrix<T>
    {
        #region Props
        public int Order { get; protected set; }
        #endregion

        #region Events
        public event EventHandler<MatrixEventArgs> ChangeElement = delegate { };
        #endregion

        #region PublicMethods
        /// <summary>
        /// For visitor pattern
        /// </summary>
        /// <param name="visitor"></param>
        /// <param name="other"></param>
        public virtual void Accept(IVisitor<T> visitor, AbstractMatrix<T> other)
        {
            visitor.Visit((dynamic)this, (dynamic)other);
        }

        /// <summary>
        /// usual indexator
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public virtual T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i > Order || j >Order)
                    throw new ArgumentException();
                return GetElement(i, j);
            }
            set
            {
                if (i < 0 || j < 0 || i > Order || j >Order)
                    throw new ArgumentException();
                SetElement(i, j, value);
                OnNewMail(new MatrixEventArgs(string.Format(" i={0}, j={1} element is changed for {2} now ", i, j, value)));
            }
        }
        #endregion 

        protected virtual void OnNewMail(MatrixEventArgs e)
        {
            EventHandler<MatrixEventArgs> temp = ChangeElement;

            if (!ReferenceEquals(temp, null))
            {
                temp(this, e);
            }
        }
        
        /// <summary>
        /// absract method for overriding
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="val"></param>
        protected abstract void SetElement(int i, int j, T val);

        protected abstract T GetElement(int i, int j);

    }
}
