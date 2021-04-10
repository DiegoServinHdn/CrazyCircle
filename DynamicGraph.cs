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
        private int numVertices;

        public DynamicGraph()
        {
            this.vertices = new List<Vertice>();
            this.numVertices = 0;
        }

        public void agregarVertice(Vertice vertice)
        {
            vertice.SetId("V" + this.numVertices.ToString());
            vertices.Add(vertice);
            this.numVertices += 1;
        }
        public void graficarGrafo(Bitmap imagen)
        {
            Graphics g = Graphics.FromImage(imagen);
            Font drawFont = new Font("Arial", 20);
            Pen plumaArista= new Pen(Color.Aqua, 3);
            SolidBrush drawBrush = new SolidBrush(Color.Red);

            foreach (Vertice vertice in vertices)
            {
                g.DrawString(vertice.GetId(), drawFont, drawBrush, vertice.GetCoordenada().X, vertice.GetCoordenada().Y);
                foreach(Arista arista in vertice.GetAristas())
                {
                    g.DrawLine(plumaArista, vertice.GetCoordenada(), arista.GetSig().GetCoordenada());
                }
                
            }
        }

        public void adjacencyMatrix(DataGridView table)
        {

            int i = 0;
            foreach(Vertice vertice in this.vertices)
            {
                table.Columns.Add(vertice.GetId(), vertice.GetId());
                table.Columns[i].Width = 24;
                table.Rows.Add();
                table.Rows[i].HeaderCell.Value = vertice.GetId();
                i++;
            }
            i = 0;
            foreach (Vertice vertice in this.vertices)
            {
                for (int j=0;j<table.Columns.Count;j++)
                {
                    table.Rows[i].Cells[j].Value = 0;
                }
                foreach (Arista arista in vertice.GetAristas())
                {
                    table.Rows[i].Cells[table.Columns[arista.GetSig().GetId()].Index].Value = 1;
                }
                i++;
            }
        }

    }
    class Vertice
    {
        private List<Arista> aristas;
        private Point coordenada;
        private string id;

        public Vertice(Point coordenada)
        {
            this.aristas = new List<Arista>();
            this.coordenada = coordenada;
            this.id = "";
        }
        public void agregarArista(Vertice vertice)
        {
            this.aristas.Add(new Arista(vertice));
        }
        public Point GetCoordenada()
        {
            return coordenada;
        }
        public string GetId()
        {
            return id;
        }
        public void SetId(string id)
        {
            this.id = id;
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
