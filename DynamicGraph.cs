using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CrazyCircle
{
    class DynamicGraph
    {
        private List<Vertice> vertices;

        public DynamicGraph()
        {
            this.vertices = new List<Vertice>();
        }

        public void agregarVertice(Vertice vertice)
        {
            vertices.Add(vertice);
        }
        public Bitmap graficarGrafo(Bitmap imagen)
        {
            Pen GreenPen = new Pen(Color.Green, 10);
            foreach (Vertice vertice in vertices)
            {
                Graphics g = Graphics.FromImage(imagen);
            }
            return imagen;
        }
    }
    class Vertice
    {
        private List<Arista> aristas;
        private Point coordenada;

        public Vertice(Point coordenada)
        {
            this.aristas = new List<Arista>();
            this.coordenada = coordenada;
        }
        public void agregarArista(Vertice vertice)
        {
            this.aristas.Add(new Arista(vertice));
        }


    }

    class Arista
    {
        Vertice sig;
        int peso;
        public Arista(Vertice vertice)
        {
            sig = vertice;
            peso = 0;
        }
    }
}
