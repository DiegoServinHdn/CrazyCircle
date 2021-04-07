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
            Graphics g = Graphics.FromImage(imagen);
            Font drawFont = new Font("Arial", 20);
            Pen plumaArista= new Pen(Color.Aqua, 3);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            //vertices[0].agregarArista(vertices[1]);
            //vertices[0].agregarArista(vertices[2]);
            //vertices[2].agregarArista(vertices[3]);
            foreach (Vertice vertice in vertices)
            {

                // Draw string to screen.
                g.DrawString("V", drawFont, drawBrush, vertice.GetCoordenada().X, vertice.GetCoordenada().Y);
                foreach(Arista arista in vertice.GetAristas())
                {
                    g.DrawLine(plumaArista, vertice.GetCoordenada(), arista.GetSig().GetCoordenada());
                }
                
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
        public Point GetCoordenada()
        {
            return coordenada;
        }
        public List<Arista> GetAristas()
        {
            return aristas;
        }


    }

    class Arista
    {
        private Vertice sig;
        private int peso;
        public Arista(Vertice vertice)
        {
            sig = vertice;
            peso = 0;
        }
        public Vertice GetSig()
        {
            return sig;
        }
    }
}
