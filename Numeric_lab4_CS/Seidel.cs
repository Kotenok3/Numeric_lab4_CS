using System;
using System.Linq;

namespace Numeric_lab4_CS
{
    public static class Seidel
    {
        public static double[] SearchSolution(SLУ sly,double esp, double[] x)
        {
            double norm;
            int count = 0;
            var esp2 = Norm(sly.A) * esp;
            double[] tempX = new double[x.Length];

            do
            {
                for (int i = 0; i < x.Length; i++)
                {
                    tempX[i] = sly.B[i];
                    for (int j = 0; j < x.Length; j++)
                    {
                        if(i != j)
                            tempX[i] -= sly.A[i, j] * tempX[j];
                    }

                    tempX[i] /= sly.A[i, i];
                }

                norm = Enumerable.Range(0, tempX.Length).Select(i => Math.Abs(tempX[i] - x[i])).Max();
                tempX.CopyTo(x, 0);    
                  
                
                count++;
                
            } while (norm > esp);
            Console.WriteLine($"count:{count}, esp:{esp}, esp2{esp2}");
            return x;
        }
        

        public static double Norm(Matrix B)
        {
            var B1 = new double[B.N, B.N];
            var B2 = new double[B.N, B.N];

            for (int i = 0; i < B.N; i++)
            {
                for (int j = 0; j < B.M; j++)
                {
                    if (i < j)
                    {
                        B2[i, j] = B[i, j]/B[i,i];
                    }
                    else if (i > j)
                    {
                        B1[i, j] = B[i, j]/B[i,i];
                    }
                }
            }
            
            var normB1 = CalculationNorm(new Matrix(B1));
            var normB2 = CalculationNorm(new Matrix(B2));
            
            return (1 - normB1) / normB2;
        }
        public static double CalculationNorm(Matrix B)
        {
            double[] norm = new double[B.M];
            for (int j = 0; j < B.M; j++)
            {
                for (int i = 0; i < B.N; i++)
                {
                    norm[j] += B[i, j];
                }
            }

            return norm.Max();
        }
        

    }
}