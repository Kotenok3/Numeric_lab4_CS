using System;
using System.Linq;

namespace Numeric_lab4_CS
{
    public class Jacobi
    {
        public static double[] SearchSolution(SLУ sly,double esp, double[] x)
        {
            double esp1 = Math.Abs(1 - Norm(sly.B)) / Norm(sly.B) * esp;

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

        public static Double Norm(double[] B)
        {
            return Math.Sqrt(Enumerable.Range(0, B.Length).Sum(i => B[i]*B[i]));
        }
    }
}