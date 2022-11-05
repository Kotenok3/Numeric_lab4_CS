using System;
using System.Xml.Xsl;

namespace Numeric_lab4_CS
{
    class Program
    {
        public static double[] TridiagonalAlg(SLE sly, int n)
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

        public static bool CriterStabilityTridiagonalAlg(SLE sly)
        {
            for (int i = 1; i < sly.N-1; i++)
            {
                if (Math.Abs(sly.A[i, i]) < Math.Abs(sly.A[i, i - 1]) + Math.Abs(sly.A[i, i + 1]))
                    return false;
            }

            return true;
        }
        
        
        
        
        
        static void Main(string[] args)
        {
            double[,] t =
            {
                { 17, 2, 0, 0, 0, 0 },
                { 1, 18, 4, 0, 0, 0 },
                { 0, -4, 19, 4, 0, 0 },
                { 0, 0, 7, 20, 5, 0 },
                { 0, 0, 0, 5, 21, 3 },
                { 0, 0, 0, 0, 6, 22 }
            };
            double[] b = { 21, 22, 25, 28, 23, 29 };

            var a = new Matrix(t);

            var SLY1 = new SLE(a, b);

            Console.WriteLine($"Выполнение условия устойчивости:{CriterStabilityTridiagonalAlg(SLY1)}");
            
            
            var x = TridiagonalAlg(SLY1, SLY1.N);

            var X = new Matrix(x);

            Console.WriteLine("Корни:\n" + X);

            Console.WriteLine($"Невязка \n"+(new Matrix(b) - a * X));



            Console.ReadKey();
        }
    }
}
    
