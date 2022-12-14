using System;
using System.Linq;
using System.Xml.Xsl;

namespace Numeric_lab4_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] t1 =
            {
                { 17, 2, 0, 0, 0, 0 },
                { 1, 18, 4, 0, 0, 0 },
                { 0, -4, 19, 4, 0, 0 },
                { 0, 0, 7, 20, 5, 0 },
                { 0, 0, 0, 5, 21, 3 },
                { 0, 0, 0, 0, 6, 22 }
            };

            double[,] t2 =
            {
                { 17, 2, 0.02, 0.01, 0.01, 0.01 },
                { 1, 18, 4, 0.01, 0.02, 0.01 },
                { 0.01, -4, 19, 4, 0.01, 0.02 },
                { 0.01, 0.02, 7, 20.01, 5, 0.01 },
                { 0.02, 0.01, 0.01, 5, 21, 3 },
                { 0.01, 0.01, 0.01, 0.02, 6, 22 }
            };
            
            double[] b = { 21, 22, 25, 28, 23, 29 };
            var a1 = new Matrix(t1);

            var SLY1 = new SLУ(a1, b);
                
            Console.WriteLine("Метод прямой прогонки");
            Console.WriteLine($"Выполнение условия устойчивости:{Triagonal.CriterStability(SLY1)}");
            var x1 = new Matrix(Triagonal.SearchSolution(SLY1, SLY1.N));
            Console.WriteLine("Корни:\n" + x1);
            

            Console.WriteLine("Метод Якоби");
            var a2 = new Matrix(t2);
            var SLY2 = new SLУ(a2, b);
            var x2 = new Matrix(Jacobi.SearchSolution(SLY2, 0.00001, new double[b.Length]));
            Console.WriteLine("Корни:\n" + x2);

            
            Console.WriteLine("Метод Зейделя");
            var x3 = new Matrix(Seidel.SearchSolution(SLY2, 0.00001, new double[b.Length]));
            Console.WriteLine("Корни:\n" + x3);

            //Console.WriteLine($"Невязка \n"+(new Matrix(b) - a2 * x3));
            

            Console.ReadKey();
        }
    }
}
    
