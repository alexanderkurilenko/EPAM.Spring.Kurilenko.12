using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class MatrixEventArgs : EventArgs
    {
        private readonly string message;

        public MatrixEventArgs(string msg)
        {
            if (msg == null)
                throw new ArgumentNullException();
            message = msg;
        }
 
        public string Message
        {
            get { return message; }
        }
    }
}
