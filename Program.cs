using System;

namespace DivAddMining
{
    class Program
    {
        // объявление массива
        const int MAX_ITEMS = 10;
        static Point[] arrayOfPoints;

        static void ArrayInit()
        {
            // выделение памяти для указанное количество элементов массива
            arrayOfPoints = new Point[MAX_ITEMS];

            // выделение памяти для каждого элемента массива
            for (int i = 0; i < arrayOfPoints.Length; i++)
                arrayOfPoints[i] = new Point();

            // обнуление значений элементов массива
            for (int i = 0; i < 10; i++)
                arrayOfPoints[i].SetXY(0, 0);
            /*
            // заполнение массива фиксированными значениями
            for (int i = 0; i < arrayOfPoints.Length; i++)
            {
                arrayOfPoints[i].X = i + 7;
                arrayOfPoints[i].Y = i * 2 + 3;
            }
            */

            arrayOfPoints[0].X = 1.95;
            arrayOfPoints[0].Y = 6.1;

            arrayOfPoints[1].X = 2.58;
            arrayOfPoints[1].Y = 8.51;

            arrayOfPoints[2].X = 3.26;
            arrayOfPoints[2].Y = 10.82;

            arrayOfPoints[3].X = 4.51;
            arrayOfPoints[3].Y = 17.92;

            arrayOfPoints[4].X = 5.14;
            arrayOfPoints[4].Y = 24.21;

            arrayOfPoints[5].X = 5.92;
            arrayOfPoints[5].Y = 33.1;

            arrayOfPoints[6].X = 6.81;
            arrayOfPoints[6].Y = 45.51;

            arrayOfPoints[7].X = 7.45;
            arrayOfPoints[7].Y = 61.21;

            arrayOfPoints[8].X = 8.02;
            arrayOfPoints[8].Y = 72.38;

            arrayOfPoints[9].X = 8.75;
            arrayOfPoints[9].Y = 95.24;

        }

        static void Main(string[] args)
        {
            ArrayInit();

            IRegression ER = new ExponentialRegression();
            ER.CalcRegressionRatio(arrayOfPoints); // вычисление коэффициентов регрессии

            if (ER.A0 == 0 && ER.A1 == 0)
              Console.WriteLine("Error");
            else
            {
                Console.WriteLine("R:" + ER.CalcSquareDeviation(arrayOfPoints).ToString());
                Console.WriteLine("A1:" + ER.A1);
                Console.WriteLine("A0:" + ER.A0);
            }
        }
    }
}
