using System;

namespace Numeric_lab4_CS
{
    public class Jacobi
    {
        public static double[] SearchSolution(SLE sly,double esp, double[] x)
        {
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
                        tempX[i] -= sly.A[i, j] * x[j];
                    }

                    tempX[i] /= sly.A[i, i];
                }

                norm = Math.Abs(x[0] - tempX[0]);
                for (int i = 1; i < x.Length; i++)
                {
                    if (Math.Abs(x[i] - tempX[i]) > norm) norm = Math.Abs(x[i] - tempX[i]);

                    x[i] = tempX[i];
                }

                count++;
                
            } while (norm > esp);
            
            return x;
        }
    }
}