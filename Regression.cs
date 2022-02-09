using System;
using System.Collections.Generic;
using System.Text;

namespace DivAddMining
{
    abstract class Regression : IRegression
    {
        protected Point[] arrayOfPoints; //массив значений
        protected int N; // количество элементов массива
        protected double a0; // первая неизвестная
        protected double a1; // вторая неизвестная

        public Regression(Point[] P)
        {
            arrayOfPoints = P; // копирование массива
            N = ArrayLength(); // длина массива
            CalcRegressionRatio(); // вычисление коэффициентов
        }

        /// <summary>
        ///  Метод для вычисления коэффициентов регрессии
        /// </summary>
        protected abstract void CalcRegressionRatio();

        /// <summary>
        ///  Метод для получения значения по регрессионной функции
        /// </summary>
        public abstract double CalcRegressionFunc(double px);

        /// <summary>
        ///  Метод для вычисления индекса кореляции
        /// </summary>
        public double CalcSquareDeviation()
        {
            double divisible = 0;
            double divider = 0;

            for (int i = 0; i < N; i++)
            {
                divisible += Math.Pow((arrayOfPoints[i].Y - CalcRegressionFunc(arrayOfPoints[i].X)), 2);
                divider += Math.Pow((arrayOfPoints[i].Y - AverageY()), 2);
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

        protected int ArrayLength()
        {
            return arrayOfPoints.Length;
        }

        protected double SumX()
        {
            double sumX = 0;

            for (int i = 0; i < N; i++)
                sumX += arrayOfPoints[i].X;

            return sumX;
        }

        protected double SumY()
        {
            double sumY = 0;

            for (int i = 0; i < N; i++)
                sumY += arrayOfPoints[i].Y;

            return sumY;
        }

        protected double Ln(double a)
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

        protected double SumLnX()
        {
            double sumLnX = 0;

            for (int i = 0; i < N; i++)
                sumLnX += Ln(arrayOfPoints[i].X);

            return sumLnX;
        }

        protected double SumLnY()
        {
            double sumLnY = 0;

            for (int i = 0; i < N; i++)
                sumLnY += Ln(arrayOfPoints[i].Y);

            return sumLnY;
        }

        protected double SumLnXY()
        {
            double sumLnXY = 0;

            for (int i = 0; i < N; i++)
                sumLnXY += arrayOfPoints[i].Y * Ln(arrayOfPoints[i].X);

            return sumLnXY;
        }

        protected double SumXLnY()
        {
            double sumXLnY = 0;

            for (int i = 0; i < N; i++)
                sumXLnY += arrayOfPoints[i].X * Ln(arrayOfPoints[i].Y);

            return sumXLnY;
        }

        protected double SumLnXLnY()
        {
            double sumLnXLnY = 0;

            for (int i = 0; i < N; i++)
                sumLnXLnY += Ln(arrayOfPoints[i].X) * Ln(arrayOfPoints[i].Y);

            return sumLnXLnY;
        }

        protected double SumXSqr()
        {
            double sumXSqr = 0;

            for (int i = 0; i < N; i++)
                sumXSqr += Math.Pow(arrayOfPoints[i].X, 2);

            return sumXSqr;
        }

        protected double SumLnXSqr()
        {
            double sumLnXSqr = 0;

            for (int i = 0; i < N; i++)
                sumLnXSqr += Math.Pow(Ln(arrayOfPoints[i].X), 2);

            return sumLnXSqr;
        }

        protected double SumYdivX()
        {
            double sumYdivX = 0;

            try
            {
                for (int i = 0; i < N; i++)
                    sumYdivX += arrayOfPoints[i].Y / arrayOfPoints[i].X;

                return sumYdivX;
            }
            catch
            {
                return 0;
            }
        }

        protected double Sum1divX()
        {
            double sum1divX = 0;

            try
            {
                for (int i = 0; i < N; i++)
                    sum1divX += 1 / arrayOfPoints[i].X;

                return sum1divX;
            }
            catch
            {
                return 0;
            }
        }

        protected double Sum1divY()
        {
            double sum1divY = 0;

            try
            {
                for (int i = 0; i < N; i++)
                    sum1divY += 1 / arrayOfPoints[i].Y;

                return sum1divY;
            }
            catch
            {
                return 0;
            }
        }

        protected double Sum1divYand1divX()
        {
            double sum1divYand1divX = 0;

            try
            {
                for (int i = 0; i < N; i++)
                    sum1divYand1divX += (1 / arrayOfPoints[i].Y) * (1 / arrayOfPoints[i].X);

                return sum1divYand1divX;
            }
            catch
            {
                return 0;
            }
        }

        protected double Sum1divXSqr()
        {
            double sum1divXSqr = 0;

            try
            {
                for (int i = 0; i < N; i++)
                    sum1divXSqr += 1 / Math.Pow(arrayOfPoints[i].X, 2);

                return sum1divXSqr;
            }
            catch
            {
                return 0;
            }
        }

        protected double AverageY()
        {
            return (SumY() / N);
        }

        public double A0 => a0;

        public double A1 => a1;
    }
}
