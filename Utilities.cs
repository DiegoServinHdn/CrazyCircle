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
    class Utilities
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
            if (circulo[pos].center.X < circulo[minPos].center.X)
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
            for (i = j; i > 0 && orderedCicles[i].center.Y < orderedCicles[i - 1].center.Y; i--)
            {
                exchange(orderedCicles, i, i - 1);
            }
        }
            return orderedCicles;
    }

        public static List<Circle> getClosestPairPoints(List<Circle> puntos)
        {
            if (puntos.Count < 2)
            {
                return new List<Circle>();
            }
            // Lista que almacena los dos puntos mas cercanos
            List<Circle> puntosMasCercanos = new List<Circle>();
            // añadimos los primeros puntos para comparar calcular su distancia y compararla
            puntosMasCercanos.Add(puntos[0]);
            puntosMasCercanos.Add(puntos[1]);
            // Calculamos la distancia y entre los dos primeros puntos y la definimos como la mas corta hasta el momento
            double distanciaMinima = calcularDistancia(puntosMasCercanos[0].center, puntosMasCercanos[1].center);


            // iteramos por cada circulo
            for(int i=0; i<puntos.Count;i++)
            {
                // iteramos por cada excluyendo el circulo i
                for(int j = i+1; j < puntos.Count; j++)
                {
                    if(distanciaMinima > calcularDistancia(puntos[i].center, puntos[j].center))
                    {
                        puntosMasCercanos[0] = puntos[i];
                        puntosMasCercanos[1] = puntos[j];
                        distanciaMinima = calcularDistancia(puntos[i].center, puntos[j].center);
                    }
                }

            }


            return puntosMasCercanos;
        }
    public static double calcularDistancia(Point p1, Point p2)
        {
            float deltaX = p2.X - p1.X;
            float deltaY = p2.Y - p1.Y;
            return Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
        }

    public static bool detectarObstaculos(Bitmap bresen, Circle circ1, Circle circ2)
        {
            Graphics g = Graphics.FromImage(bresen);
            SolidBrush white = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
            Color pixel;
            g.FillEllipse(white, circ1.center.X - circ1.radius - 2, circ1.center.Y - circ1.radius - 1, circ1.radius * 2 + 4, circ1.radius * 2 + 4);
            g.FillEllipse(white, circ2.center.X - circ2.radius - 2, circ2.center.Y - circ2.radius - 1, circ2.radius * 2 + 4, circ2.radius * 2 + 4);
            int x0 = circ1.center.X, y0 = circ1.center.Y, x1 = circ2.center.X, y1 = circ2.center.Y;
            bool obstacle = false;
            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2, e2;
            while (true)
            {
                pixel = bresen.GetPixel(x0, y0);
                if (pixel.R != 255 || pixel.G != 255 || pixel.B != 255)
                {
                    obstacle = true;
                }
                if (x0 == x1 && y0 == y1) break;
                e2 = err;
                if (e2 > -dx) { 
                    err -= dy; 
                    x0 += sx; 
                }
                if (e2 < dy) { 
                    err += dx; 
                    y0 += sy;
                }
            }
            return obstacle;
        }

    public static List<Vertice> CalcularVertices(Bitmap imagen, List<Circle> Circulos)
        {

            List<Vertice> verticesNuevos = new List<Vertice>();
            foreach (Circle circulo in Circulos)
            {
                verticesNuevos.Add(new Vertice(circulo.center));    
            }
            for (int i = 0; i < Circulos.Count; i++)
            {
                //for (int j = i + 1 < Circulos.Count;j++) para grafo con direccion
                for (int j = 0; j < Circulos.Count; j++)
                {
                    if (i != j)
                    {
                        if (!detectarObstaculos((Bitmap)imagen.Clone(), Circulos[i], Circulos[j]))
                        {
                            verticesNuevos[i].agregarArista(verticesNuevos[j]);
                        }
                    }

                    
                }

            }
            return verticesNuevos;
        }


















    }


}
