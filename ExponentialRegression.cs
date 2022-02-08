using System;
using System.Collections.Generic;
using System.Text;

namespace DivAddMining
{
    class ExponentialRegression : IRegression
    {
        int N; // количество элементов массива
        double a0; // первая неизвестная
        double a1; // вторая неизвестная

        public void CalcRegressionRatio(Point[] P) // вычисление коэффициентов регрессии
        {
            double lnA1 = 0;
            double lnA0 = 0;
            N = ArrayLength(P);

            try
            {
                a1 = 0;
                lnA1 = (N * SumXLnY(P) - SumX(P) * SumLnY(P)) / (N * SumXSqr(P) - Math.Pow(SumX(P), 2));
                a1 = Math.Pow(Math.E, lnA1);

                a0 = 0;
                lnA0 = (Math.Pow(N, -1) * SumLnY(P)) - (Math.Pow(N, -1) * lnA1 * SumX(P));
                a0 = Math.Pow(Math.E, lnA0);
            }
            catch
            {
               a1 = 0;
               a0 = 0;
            }
        }

        public double CalcRegressionFunc(double px) // получение значение по регрессионной функции
        {
            //return Math.Pow(Math.E, (a0 + a1 * px));
            return a0 * Math.Pow(a1, px);
        }

        public double CalcSquareDeviation(Point[] P) // вычисление индекса корреляции
        {
            double divisible = 0;
            double divider = 0;

            for (int i = 0; i < P.Length; i++)
            {
                divisible += Math.Pow((P[i].Y - CalcRegressionFunc(P[i].X)), 2);
                divider += Math.Pow((P[i].Y - AverageY(P)), 2);

                Console.WriteLine(CalcRegressionFunc(P[i].X));
            }

            try
            {
                return Math.Sqrt(1 - (divisible / divider));
            }
            catch
            {
                return -1;
            }
        }

        //

        int ArrayLength(Point[] P)
        {
            return P.Length;
        }

        double SumX(Point[] P)
        {
            double sumX = 0;

            for (int i = 0; i < P.Length; i++)
                sumX += P[i].X;

            return sumX;
        }

        double SumY(Point[] P)
        {
            double sumY = 0;

            for (int i = 0; i < P.Length; i++)
                sumY += P[i].Y;

            return sumY;
        }

        double Ln(double a)
        {
            if (a == 0) return -9999999999;

            try
            {
                return Math.Log(a);
            }
            catch
            {
                return 0;
            }
        }

        double SumLnY(Point[] P)
        {
            double sumLnY = 0;

            for (int i = 0; i < P.Length; i++)
                sumLnY += Ln(P[i].Y);
            
            return sumLnY;
        }

        double SumXLnY(Point[] P)
        {
            double sumXLnY = 0;

            for (int i = 0; i < P.Length; i++)
                sumXLnY += P[i].X * Ln(P[i].Y);

            return sumXLnY;
        }

        double SumXSqr(Point[] P)
        {
            double sumXSqr = 0;

            for (int i = 0; i < P.Length; i++)
                sumXSqr += Math.Pow(P[i].X, 2);

            return sumXSqr;
        }

        double AverageY(Point[] P)
        {
            return (SumY(P) / N); 
        }

        public double A0
        {
            get { return a0; }
        }

        public double A1
        {
            get { return a1; }
        }
    }
}
