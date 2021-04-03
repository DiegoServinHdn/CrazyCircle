using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrazyCircle
{
    public class Utilities
    {
    public static void exchange(List<Circle> circulos, int m, int n)
    {
        Circle temporary;

        temporary = circulos[m];
        circulos[m] = circulos[n];
        circulos[n] = temporary;
    }
    public static List<Circle> orderBySize(List<Circle> orderedCircles)
    {   //Bubble Sort
        int i, j;
        int N = orderedCircles.Count;

        for (j = N - 1; j > 0; j--)
        {
            for (i = 0; i < j; i++)
            {
                if (orderedCircles[i].area < orderedCircles[i + 1].area)
                    exchange(orderedCircles, i, i + 1);
            }
        }

            return orderedCircles;
    }

    public static int Min(List<Circle> circulo, int start)
    {
        int minPos = start;
        for (int pos = start + 1; pos < circulo.Count; pos++)
            if (circulo[pos].centerX < circulo[minPos].centerX)
                minPos = pos;
        return minPos;
    }
    public static List<Circle> orderByX(List<Circle> orderedCicles)
    {
        //Selection Sort
        int i;
        int N = orderedCicles.Count;

        for (i = 0; i < N - 1; i++)
        {
            int k = Min(orderedCicles, i);
            if (i != k)
                exchange(orderedCicles, i, k);
        }

            return orderedCicles;
    }

    public static List<Circle> orderByY(List<Circle> orderedCicles)
    {   //Insertion sort
        int i, j;
        int N = orderedCicles.Count;

        for (j = 1; j < N; j++)
        {
            for (i = j; i > 0 && orderedCicles[i].centerY < orderedCicles[i - 1].centerY; i--)
            {
                exchange(orderedCicles, i, i - 1);
            }
        }
            return orderedCicles;
    }


















    }


}
