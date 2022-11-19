using System.Runtime.CompilerServices;

namespace Numeric_lab4_CS
{
    public class Matrix
    {
        private double[,] A;

        public Matrix(double[,] a)
        {
            A = a;
        }

        public Matrix(double[] a)
        {
            A = new double[1, a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                A[0, i] = a[i];
            }
        }
        public Matrix(int n, int m)
        {
            A = new double[n,m];
        }
        public Matrix(int n)
        {
            A = new double[n,n];
        }

        public int M => A.GetLength(1);
        public int N => A.GetLength(0);


        public double this[int i, int j]
        {
            get => A[i, j];

            set
            {
                A[i, j] = value;
            }
        }
        
        #region operator
        public override string ToString()
        {
            var s = "";
            
            if(N > 1)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        s += this[i, j] + "\t";
                    }

                    s += "\n";
                }
            }
            else
            {
                for (int i = 0; i < M; i++)
                {
                    s += this[0, i] + "\n";
                }
            }

            return s;
        }


        public static Matrix operator +(Matrix A, Matrix B)
        {
            var C = new Matrix(A.N,A.M);

            for (int i = 0; i < A.N; i++)
            {
                for (int j = 0; j < A.N; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C;
        }
        
        public static Matrix operator -(Matrix A, Matrix B)
        {
            var C = new Matrix(A.N,A.M);

            for (int i = 0; i < A.N; i++)
            {
                for (int j = 0; j < A.N; j++)
                {
                    C[i, j] = A[i, j] - B[i, j];
                }
            }
            return C;
        }
        public static Matrix operator -(Matrix A, double[] b)
        {
            var C = new Matrix(A.N,A.M);

            for (int i = 0; i < A.N; i++)
            {
                for (int j = 0; j < A.N; j++)
                {
                    C[i, j] = A[i, j] - b[i];
                }
            }
            return C;
        }
        
        public static Matrix operator *(Matrix A, Matrix B)
        {
            var C = new Matrix(A.N,A.M);
            
            for (int i = 0; i < A.N; i++)
            {
                for (int j = 0; j < B.M; j++)
                {
                    for (int k = 0; k < B.N; k++)
                    {
                        C[i,j] += A[i,k] * B[k,j];
                    }
                }
            }

            return C;
        }
        
        public static Matrix operator *(Matrix A, double[] b)
        {
            var C = new Matrix(A.N,A.M);

            for (int i = 0; i < A.N; i++)
            {
                for (int j = 0; j < A.N; j++)
                {
                    C[i, j] = A[i, j] * b[i];
                }
            }
            return C;
        }
        
        public static Matrix operator *(Matrix A, double c)
        {
            var C = new Matrix(A.N,A.M);

            for (int i = 0; i < A.N; i++)
            {
                for (int j = 0; j < A.N; j++)
                {
                    C[i, j] = A[i, j] * c;
                }
            }

            return C;
        }
        #endregion
        
    }
}