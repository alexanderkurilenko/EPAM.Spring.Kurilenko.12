using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Logic;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {


        int[][] diagonalMatrixInts =
            {
                new int[3] {1, 0, 0},
                new int[3] {0, 5, 0},
                new int[3] {0, 0, 9},
            };
            SquareMatrix<int> mas1 = new SquareMatrix<int>(diagonalMatrixInts);
           
            SquareMatrix<int> mas2 = new SquareMatrix<int>(diagonalMatrixInts);
            SquareMatrix<int> mas3 = new SquareMatrix<int>(3);
            mas3=(SquareMatrix<int>)mas1.Add(mas2);
            mas3.ToString();
            Console.ReadKey();
        }
    }
}
