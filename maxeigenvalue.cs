using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // int n = 3;
            // double[,] A = {
            //     {1, 2, 3},
            //     {4, 5, 6},
            //     {7, 8, 9}
            // };
            // double[] b = {1, 1, 1};

            Console.WriteLine("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int eps = 1000;
            double[,] A = new double[n, n];
            double[] b = new double[n];
            double[] tmp = new double[n];
            double norm_sq, norm = 0;

            Console.WriteLine("Enter the matrix: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i,j] = Convert.ToDouble(Console.ReadLine());
                }
                b[i] = 1;
            }

            for (int e = 0; e < eps; e++)
            {
                // вычисление A*b
                for (int i = 0; i < n; i++)
                {
                    tmp[i] = 0;
                    for (int j = 0; j < n; j++)
                    {
                        // скалярное произведение A[i] и b
                        tmp[i] += A[i,j] * b[j];
                    }
                }

                // вычисление длины результирующего вектора
                norm_sq = 0;
                for (int k = 0; k < n; k++)
                {
                    norm_sq += tmp[k] * tmp[k];
                }
                norm = Math.Sqrt(norm_sq);

                // нормализация b для следующей итерации
                for (int i = 0; i < n; i++)
                {
                    b[i] = tmp[i] / norm;
                }
            }

            Console.WriteLine("Max eigenvalue: {0}", norm);
            Console.ReadKey();
        }
    }
}
