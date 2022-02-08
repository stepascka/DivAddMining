using System;
using System.Collections.Generic;
using System.Text;

namespace DivAddMining
{
    interface IRegression
    {
        void CalcRegressionRatio(Point[] P);

        double CalcRegressionFunc(double px);

        double CalcSquareDeviation(Point[] P);

        public double A0{get;}

        public double A1{get;}
    }
}
