using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double[,] A = new double[,] {
                {4, 12, -16},
                {12, 37, -43},
                {-16, -43, 98}
            };
            
            double[] b = new double[] {1, 1, 1};
            double[,] L = Cholesky(A);
            
            foreach (double sol in luEvaluate(L, Transpose(L), b))
            {
                Console.WriteLine("{0}", sol);
            }
        }

        public static double[,] Cholesky(double[,] A)
        {
            int n = (int)Math.Sqrt(A.Length);
            double[,] ret = new double[n, n];
            
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c <= r; c++)
                {
                    if (c == r)
                    {
                        double sum = 0;
                        for (int j = 0; j < c; j++)
                        {
                            sum += ret[c, j] * ret[c, j];
                        }
                        ret[c, c] = Math.Sqrt(A[c, c] - sum);
                    }
                    else
                    {
                        double sum = 0;
                        for (int j = 0; j < c; j++)
                        {
                            sum += ret[r, j] * ret[c, j];
                        }
                        ret[r, c] = 1.0 / ret[c, c] * (A[r, c] - sum);
                    }
                }
            }
            return ret;
        }

        public static double[] luEvaluate(double[,] L, double[,] U, double[] b)
        {
            int n = b.Length;
            double[] x = new double[n];
            double[] y = new double[n];

            // Forward substitution Ly = b
            for (int i = 0; i < n; i++)
            {
                y[i] = b[i];
                for (int j = 0; j < i; j++)
                {
                    y[i] -= L[i, j] * y[j];
                }
                y[i] /= L[i, i];
            }

            // Back substitution Ux = y
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = y[i];
                for (int j = i + 1; j < n; j++)
                {
                    x[i] -= U[i, j] * x[j];
                }
                x[i] /= U[i, i];
            }
            return x;
        }

        public static double[,] Transpose(double[,] A)
        {
            int n = (int)Math.Sqrt(A.Length);
            double[,] T = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    T[i, j] = A[j, i];
                }
            }

            return T;
        }
    }
}
