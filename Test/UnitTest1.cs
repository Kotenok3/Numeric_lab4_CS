using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using Numeric_lab4_CS;

namespace Test
{
    [TestFixture]
    public class TestsSLY
    {
        [Test]
        public void Triagonal()
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

            double[] ansewr = { 1.1339, 0.8611, 1.3411, 0.7405, 0.7602, 1.1108 };
            var a = new Matrix(t);
            var SLY = new SLE(a, b);
            var x = Numeric_lab4_CS.Triagonal.SearchSolution(SLY, SLY.N);

            for (int i = 0; i < x.Length; i++)
            {
                Assert.AreEqual(x[i],ansewr[i],1e-3);
            }

        }
        


    }
}