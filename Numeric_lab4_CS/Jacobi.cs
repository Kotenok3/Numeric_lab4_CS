using System;
using System.Linq;

namespace Numeric_lab4_CS
{
    public class Jacobi
    {
        public static double[] SearchSolution(SLУ sly,double esp, double[] x)
        {
            double esp1 = (1 - Norm(GetMatrixB(sly.A))) / Norm(GetMatrixB(sly.A)) * esp;

            double norm;
            int count = 0;
            double[] tempX = new double[x.Length];

            do
            {
                for (int i = 0; i < x.Length; i++)
                {
                    tempX[i] = sly.B[i];
                    for (int j = 0; j < x.Length; j++)
                    {
                        if(i != j)
                            tempX[i] -= sly.A[i, j] * x[j];
                    }

                    tempX[i] /= sly.A[i, i];
                }

                norm = Enumerable.Range(0, tempX.Length).Select(i => Math.Abs(tempX[i] - x[i])).Max();
                tempX.CopyTo(x, 0);    
                  
                
                count++;
                
            } while (norm > esp1 && count < 1000);
            Console.WriteLine($"count:{count}, esp:{esp}, esp1:{esp1}");
            return x;
        }

        private static Matrix GetMatrixB(Matrix A)
        {
            var b = new double[A.N, A.M];
            for (int i = 0; i < A.N; i++)
            {
                for (int j = 0; j < A.M; j++)
                {
                    b[i, j] = A[i, j] / A[i, i];
                }
            }

            return new Matrix(b);
        }
        
        public static double Norm(Matrix B)
        {
            double[] norm = new double[B.M];
            for (int j = 0; j < B.M; j++)
            {
                for (int i = 0; i < B.N; i++)
                {
                    norm[j] += B[i, j];
                }
            }

            return norm.Min();
        }
    }
}