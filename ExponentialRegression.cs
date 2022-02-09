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
            //
        }

        /// <summary>
        ///  Метод для получения значения по регрессионной функции
        /// </summary>
        public override double CalcRegressionFunc(double px)
        {
            return 0;
        }
    }
}
