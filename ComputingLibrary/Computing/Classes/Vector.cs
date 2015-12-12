using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computing.Classes
{
    public class Vector
    {
        #region private
        private readonly double[] vector;
        #endregion

        #region public
        public Vector(int size):this(size, 0.0)
        { 
        }
        public Vector(int size, double fillValue)
        {
            vector = new double[size];
            for (int i = 0; i < size; i++)
                vector[i] = fillValue;
        }


        public double Length
        {
            get 
            {
                double res = 0;
                for (int i = 0; i < Size; i++)
                    res += vector[i] * vector[i];
                return Math.Sqrt(res);
            }
        }
        public int Size { get { return vector.Length; } }
        public double this[int index]
        {
            get { return vector[index]; }
            set { vector[index] = value; }
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            var result = new Vector(v1.Size);
            for(int i = 0 ; i < v1.Size; i++)
                result[i] = v1[i] + v2[i];
            return result;
        }
        public static double operator *(Vector v1, Vector v2)
        {
            var result = 0.0;
            for (int i = 0; i < v1.Size; i++)
                result+= v1[i]*v2[i];
            return result;
        }
        public static Vector operator *(double val, Vector v1)
        {
            var result = new Vector(v1.Size);
            for (int i = 0; i < v1.Size; i++)
                result[i] = val*v1[i];
            return result;
        }
        public static Vector operator *(Vector v1,double val)
        {
            return val * v1;
        }

        public static Vector Normalization(Vector v)
        {
            double len = v.Length;
            var result = new Vector(v.Size);
            for (int i = 0; i < result.Size; i++)
            {
                result[i] = v[i] / len;
            }
            return result;
        }
        #endregion


    }
}
