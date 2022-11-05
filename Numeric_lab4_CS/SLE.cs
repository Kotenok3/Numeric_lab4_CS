namespace Numeric_lab4_CS
{
    public class SLE
    {
        public Matrix A ;
        public double[] B = null;

        public SLE(Matrix a, double[] b)
        {
            A = a;
            B = b;
        }

        public int N => B.Length;
    }
}