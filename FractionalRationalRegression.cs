using System;
using System.Collections.Generic;
using System.Text;

namespace DivAddMining
{
    class FractionalRationalRegression : Regression
    {
        public FractionalRationalRegression(Point[] P) : base(P) { }

        /// <summary>
        ///  Метод для вычисления коэффициентов регрессии
        /// </summary>
        protected override void CalcRegressionRatio()
        {
            try
            {
                a0 = 0;
                a0 = (N / Sum1divYand1divX() - Sum1divY() * Sum1divX()) / (N * Sum1divXSqr() - Math.Pow(Sum1divX(), 2));

                a1 = 0;
                a1 = Math.Pow(N, -1) * (Sum1divY() - a1 * Sum1divX());
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
            try
            {
                return px / (a0 * px + a1);
            }
            catch
            {
                return 0;
            }
        }
    }
}
