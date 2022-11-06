using System;
using System.Linq;

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
                        if(i != j)
                            tempX[i] -= sly.A[i, j] * x[j];
                    }

                    tempX[i] /= sly.A[i, i];
                }

                int k = 0;
                norm = tempX.Select(z => Math.Abs(z-x[k++])).Max();
                k = 0;
                tempX.CopyTo(x, 0);    
                  
                
                count++;
                
            } while (norm > esp);
            Console.WriteLine($"count:{count}, esp:{esp}");
            return x;
        }
    }
}