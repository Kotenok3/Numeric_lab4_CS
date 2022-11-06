namespace Numeric_lab4_CS
{
    public class SLУ
    {
        public Matrix A ;
        public double[] B = null;

        public SLУ(Matrix a, double[] b)
        {
            A = a;
            B = b;
        }

        public int N => B.Length;
    }
}