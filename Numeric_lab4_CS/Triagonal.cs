using System;

namespace Numeric_lab4_CS
{
    public static class Triagonal
    {
        public static double[] SearchSolution(SLE sly, int n)
        {
            double[] A = new double[n];
            double[] B = new double[n];
            double[] X = new double[n];
            
            A[0] = -sly.A[0, 1] / sly.A[0, 0];
            B[0] = sly.B[0] / sly.A[0, 0];

            for (int i = 1; i < sly.N; i++)
            {
                var z = sly.A[i, i] + A[i - 1] * sly.A[i, i - 1];
                A[i] = i < sly.N - 1 ? -sly.A[i, i + 1] / z : 0;
                B[i] = (sly.B[i] - sly.A[i, i - 1] * B[i - 1]) / z;
            }

            X[n - 1] = B[n - 1];

            for (int i = n-2; i >= 0; i--)
            {
                X[i] = A[i] * X[i + 1] + B[i];
            }

            return X;
        }
        
        public static bool CriterStability(SLE sly)
        {
            for (int i = 1; i < sly.N-1; i++)
            {
                if (Math.Abs(sly.A[i, i]) < Math.Abs(sly.A[i, i - 1]) + Math.Abs(sly.A[i, i + 1]))
                    return false;
            }

            return true;
        }

    }
}