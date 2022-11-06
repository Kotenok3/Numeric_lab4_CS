using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using Numeric_lab4_CS;

namespace Test
{
    [TestFixture]
    public class TestsSLY
    {
        
        [Test]
        public void TriagonalTest()
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
            double[] ansewrSLY1 = { 1.1339787, 0.861181053, 1.341190586, 0.740525769, 0.760230102, 1.110846336 };
            

            var a = new Matrix(t);
            var SLY = new SLУ(a, b);
            var x = Triagonal.SearchSolution(SLY, SLY.N);

            for (int i = 0; i < x.Length; i++)
            {
                Assert.AreEqual(x[i],ansewrSLY1[i],1e-5);
            }

        }
        
        [Test]
        public void JakobiTest()
        {
            double[,] t =
            {
                { 17, 2, 0.02, 0.01, 0.01, 0.01 },
                { 1, 18, 4, 0.01, 0.02, 0.01 },
                { 0.01, -4, 19, 4, 0.01, 0.02 },
                { 0.01, 0.02, 7, 20.01, 5, 0.01 },
                { 0.02, 0.01, 0.01, 5, 21, 3 },
                { 0.01, 0.01, 0.01, 0.02, 6, 22 }
            };
            double[] b = { 21, 22, 25, 28, 23, 29 };
            double[] ansewrSLY2 = { 1.131013724, 0.859957788, 1.339022255, 0.739332473, 0.758640239, 1.109094181 };
            
            var a = new Matrix(t);
            var SLY = new SLУ(a, b);
            var x = Jacobi.SearchSolution(SLY, 1e-5,new double[b.Length]);

            for (int i = 0; i < x.Length; i++)
            {
                Assert.AreEqual(x[i],ansewrSLY2[i],1e-5);
            }

        }
        
        [Test]
        public void SeidelTest()
        {
            double[,] t =
            {
                { 17, 2, 0.02, 0.01, 0.01, 0.01 },
                { 1, 18, 4, 0.01, 0.02, 0.01 },
                { 0.01, -4, 19, 4, 0.01, 0.02 },
                { 0.01, 0.02, 7, 20.01, 5, 0.01 },
                { 0.02, 0.01, 0.01, 5, 21, 3 },
                { 0.01, 0.01, 0.01, 0.02, 6, 22 }
            };
            double[] b = { 21, 22, 25, 28, 23, 29 };
            double[] ansewrSLY2 = { 1.131013724, 0.859957788, 1.339022255, 0.739332473, 0.758640239, 1.109094181 };
            
            var a = new Matrix(t);
            var SLY = new SLУ(a, b);
            var x = Seidel.SearchSolution(SLY, 1e-5,new double[b.Length]);

            for (int i = 0; i < x.Length; i++)
            {
                Assert.AreEqual(x[i],ansewrSLY2[i],1e-5);
            }

        }
        


    }
}