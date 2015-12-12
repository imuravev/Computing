using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computing.Classes
{
    public class Matrix
    {
        private readonly Vector[] matrix;

        public Matrix(int rows, int cols, double fillValue)
        {
            matrix = new Vector[rows];
            for (int i = 0; i < rows; i++)
                matrix[i] = new Vector(cols, fillValue);
        }

        public Matrix(int rows, int cols) : this(rows, cols, 0) { }

        public int Rows { get { return matrix.Length; } }
        public int Cols { get { return matrix[0].Size; } }

        public Vector this[int i]
        {
            get { return matrix[i]; }
        }

        public static Matrix E(int size)
        {
            var res = new Matrix(size, size);
            for (int i = 0; i < size; i++)
                res[i][i] = 1;
            return res;
        }
    }
}
