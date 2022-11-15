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
            Console.WriteLine($"count:{count}, esp:{esp}");
            return x;
        }
        

        public static Double Norm(Matrix B)
        {
            return Enumerable.Range(0, B.M).Select(i => Math.Abs(B[0, i])).Max();
        }

    }
}