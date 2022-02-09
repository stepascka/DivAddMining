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

            arrayOfPoints[0].X = 0.96;
            arrayOfPoints[0].Y = 1.95;

            arrayOfPoints[1].X = 0.75;
            arrayOfPoints[1].Y = 2.6;

            arrayOfPoints[2].X = 0.64;
            arrayOfPoints[2].Y = 4.28;

            arrayOfPoints[3].X = 0.55;
            arrayOfPoints[3].Y = 6.52;

            arrayOfPoints[4].X = 0.68;
            arrayOfPoints[4].Y = 4.55;

            arrayOfPoints[5].X = 0.71;
            arrayOfPoints[5].Y = 2.91;

            arrayOfPoints[6].X = 0.95;
            arrayOfPoints[6].Y = 1.81;

            arrayOfPoints[7].X = 0.45;
            arrayOfPoints[7].Y = 8.21;

            arrayOfPoints[8].X = 0.71;
            arrayOfPoints[8].Y = 2.84;

            arrayOfPoints[9].X = 0.63;
            arrayOfPoints[9].Y = 4.38;

        }

        static void Main(string[] args)
        {
            ArrayInit();

            IRegression ER = new PowerRegression(arrayOfPoints);

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
