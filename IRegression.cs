using System;
using System.Collections.Generic;
using System.Text;

namespace DivAddMining
{
    interface IRegression
    {
        /// <summary>
        ///  Метод для получения значения по регрессионной функции
        /// </summary>
        double CalcRegressionFunc(double px);

        /// <summary>
        ///  Метод для вычисления индекса кореляции
        /// </summary>
        double CalcSquareDeviation();

        public double A0{get;}

        public double A1{get;}
    }
}
