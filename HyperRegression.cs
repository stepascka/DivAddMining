using System;
using System.Collections.Generic;
using System.Text;

namespace DivAddMining
{
    class HyperRegression : Regression
    {
        public HyperRegression(Point[] P) : base(P) { }

        /// <summary>
        ///  Метод для вычисления коэффициентов регрессии
        /// </summary>
        protected override void CalcRegressionRatio()
        {
            try
            {
                a1 = 0;
                a1 = (N * SumYdivX() - Sum1divX() * SumY()) / (N * Sum1divXSqr() - Math.Pow(Sum1divX(), 2));

                a0 = 0;
                a0 = Math.Pow(N, -1) * (SumY() - a1 * Sum1divX());
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
                return a0 + a1 / px;
            }
            catch
            {
                return 0;
            }
            
        }
    }
}
