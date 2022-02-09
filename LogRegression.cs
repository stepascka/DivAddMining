using System;
using System.Collections.Generic;
using System.Text;

namespace DivAddMining
{
    class LogRegression : Regression
    {
        public LogRegression(Point[] P) : base(P) { }

        /// <summary>
        ///  Метод для вычисления коэффициентов регрессии
        /// </summary>
        protected override void CalcRegressionRatio()
        {
            try
            {
                a1 = 0;
                a1 = (N * SumLnXY() - SumLnX() * SumY()) / (N * SumLnXSqr() - Math.Pow(SumLnX(), 2));

                a0 = 0;
                a0 = Math.Pow(N, -1) * (SumY() - a1 * SumLnX());
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
            return a0 + a1 * Ln(px);
        }
    }
}
