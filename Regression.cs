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

        protected double SumLnY()
        {
            double sumLnY = 0;

            for (int i = 0; i < N; i++)
                sumLnY += Ln(arrayOfPoints[i].Y);

            return sumLnY;
        }

        protected double SumXLnY()
        {
            double sumXLnY = 0;

            for (int i = 0; i < N; i++)
                sumXLnY += arrayOfPoints[i].X * Ln(arrayOfPoints[i].Y);

            return sumXLnY;
        }

        protected double SumXSqr()
        {
            double sumXSqr = 0;

            for (int i = 0; i < N; i++)
                sumXSqr += Math.Pow(arrayOfPoints[i].X, 2);

            return sumXSqr;
        }

        protected double AverageY()
        {
            return (SumY() / N);
        }

        public double A0 => a0;

        public double A1 => a1;
    }
}
