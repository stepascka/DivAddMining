using System;
using System.Collections.Generic;
using System.Text;

namespace DivAddMining
{
    class ExponentialRegression : Regression
    {
        public ExponentialRegression(Point[] P) : base(P) {}

        /// <summary>
        ///  Метод для вычисления коэффициентов регрессии
        /// </summary>
        protected override void CalcRegressionRatio() 
        {
            double lnA1 = 0;
            double lnA0 = 0;

            try
            {
                a1 = 0;
                lnA1 = (N * SumXLnY() - SumX() * SumLnY()) / (N * SumXSqr() - Math.Pow(SumX(), 2));
                a1 = Math.Pow(Math.E, lnA1);

                a0 = 0;
                lnA0 = (Math.Pow(N, -1) * SumLnY()) - (Math.Pow(N, -1) * lnA1 * SumX());
                a0 = Math.Pow(Math.E, lnA0);
            }
            catch
            {
               a1 = 0;
               a0 = 0;
            }
        }

        /// <summary>
        ///  Метод для получения значения по регрессионной функции
        /// </summary>
        public override double CalcRegressionFunc(double px)
        {
            //return Math.Pow(Math.E, (a0 + a1 * px));
            return a0 * Math.Pow(a1, px);
        }
    }
}
