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
            for (int i = 0; i < arrayOfPoints.Length; i++)
                arrayOfPoints[i].SetXY(0, 0);


            arrayOfPoints[0].X = 2.21;
            arrayOfPoints[0].Y = 9.63;

            arrayOfPoints[1].X = 17.45;
            arrayOfPoints[1].Y = 25.92;

            arrayOfPoints[2].X = 8.6;
            arrayOfPoints[2].Y = 31.6;

            arrayOfPoints[3].X = 61.05;
            arrayOfPoints[3].Y = 17.71;

            arrayOfPoints[4].X = 5.76;
            arrayOfPoints[4].Y = 14.87;

            arrayOfPoints[5].X = 33.38;
            arrayOfPoints[5].Y = 44.03;

            arrayOfPoints[6].X = 16.22;
            arrayOfPoints[6].Y = 13.7;

            arrayOfPoints[7].X = 3.88;
            arrayOfPoints[7].Y = 9.13;

            arrayOfPoints[8].X = 0.75;
            arrayOfPoints[8].Y = 3.86;

            arrayOfPoints[9].X = 149.3;
            arrayOfPoints[9].Y = 170.45;

        }

        static void Main(string[] args)
        {
            ArrayInit();

            IRegression ER = new ExponentialRegression(arrayOfPoints);

            if (ER.A0 == 0 && ER.A1 == 0)
              Console.WriteLine("Error");
            else
            {
                Console.WriteLine("R:" + ER.CalcSquareDeviation().ToString());
                Console.WriteLine("A1:" + ER.A1);
                Console.WriteLine("A0:" + ER.A0);
            }
        }
    }
}
