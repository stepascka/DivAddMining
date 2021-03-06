using System;
using System.Collections.Generic;
using System.Text;

namespace DivAddMining
{
    class PowerRegression : Regression
    {
        public PowerRegression(Point[] P) : base(P) { }

        /// <summary>
        ///  Метод для вычисления коэффициентов регрессии
        /// </summary>
        protected override void CalcRegressionRatio()
        {
            double lnA0 = 0;

            try
            {
                a1 = 0;
                a1 = (N * SumLnXLnY() - SumLnX() * SumLnY()) / (N * SumLnXSqr() - Math.Pow(SumLnX(), 2));

                a0 = 0;
                lnA0 = (Math.Pow(N, -1) * (SumLnY() - a1 * SumLnX()));
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
            return a0 * Math.Pow(px, a1);
        }
    }
}
