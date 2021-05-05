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
        protected List<Vertice> vertices;
        protected int numVertices;
        private int numSubGraphs;
        private List<List<Vertice>> subgraphs;


        public DynamicGraph()
        {
            this.vertices = new List<Vertice>();
            this.numVertices = 0;
            this.numSubGraphs = 1;
        }

        public void agregarVertice(Vertice vertice)
        {
            vertice.SetId("V" + this.numVertices.ToString());
            foreach (Arista arista in vertice.GetAristas())
            {
                arista.SetVid(vertice.GetId());
            }
            vertices.Add(vertice);
            this.numVertices += 1;
        }

       public List<Vertice> GetVertices()
        {
            return this.vertices;
        }
        public int GetNumVertices()
        {
            return numVertices;
        }

        public List<List<Vertice>> GetSubgraphs()
        {
            return subgraphs;
        }
        public void findSubGraphs() {
            this.numSubGraphs = 0;
            List<Vertice> verticeQueue = new List<Vertice>();
            foreach (Vertice vertice in vertices) 
            {
                if (vertice.GetGroup() == 0)
                {
                    verticeQueue.Add(vertice);
                    this.numSubGraphs++;
                    vertice.SetGroup(numSubGraphs);
                    while (verticeQueue.Count > 0)
                    {
                        if (verticeQueue[0].GetGroup() == 0)
                        {
                            verticeQueue[0].SetGroup(numSubGraphs);
                        }
                        foreach (Arista arista in verticeQueue[0].GetAristas())
                        {
                            if (arista.GetSig().GetGroup() == 0)
                            {
                                verticeQueue.Add(arista.GetSig());
                            }

                        }


                        verticeQueue.RemoveAt(0);
                    }
                }
            }

            subgraphs = new List<List<Vertice>>();

            for (int i = 0; i < numSubGraphs; i++)
            {
                subgraphs.Add(new List<Vertice>());
            }
            foreach (Vertice vertice in vertices)
            {
                subgraphs[vertice.GetGroup() - 1].Add(vertice);
            }
            String hola = "";

            foreach (var sub in subgraphs)
            {
                foreach (var v in sub)
                {
                    hola += v.GetId()+ ',';
                }
                hola += "\n";
            }
           
            Console.WriteLine(hola);
            
        }

        public void graficar(Bitmap imagen)
        {
            Graphics g = Graphics.FromImage(imagen);
            Font drawFont = new Font("Arial", 15);
            Font weightFont = new Font("Arial", 10); 
            Pen plumaArista= new Pen(Color.Aqua, 3);

            SolidBrush drawBrush = new SolidBrush(Color.Red);
            SolidBrush vertexBrush = new SolidBrush(Color.Black);
            SolidBrush weightBrush = new SolidBrush(Color.Orange);



            foreach (Vertice vertice in vertices)
            {

                foreach(Arista arista in vertice.GetAristas())
                {
                    g.DrawLine(plumaArista, vertice.GetCoordenada(), arista.GetSig().GetCoordenada());
                    g.DrawString(arista.GetPeso().ToString(), weightFont, weightBrush, (vertice.GetCoordenada().X + arista.GetSig().GetCoordenada().X)/2, (vertice.GetCoordenada().Y + arista.GetSig().GetCoordenada().Y) / 2);
                }
            }

            foreach (Vertice vertice in vertices)
            {
                //vertice.graficarVertice(vertexBrush, imagen);
                g.DrawString(vertice.GetId() + " g:"+ vertice.GetGroup().ToString(), drawFont, drawBrush, vertice.GetCoordenada().X - 10, vertice.GetCoordenada().Y - 10);
            }

        }
        /* 
        public List<Arista> GetAristas()
        {
            foreach (Vertice vertice in vertices)
            {
                foreach(Arista arista in vertice.GetAristas())
                {
                    aristas.Add(arista);
                }
            }
            return aristas;
        }
       */

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
        private int group;
        private int radius;
        private double area;

        public Vertice(Point coordenada, int radius, double area, string id="" )
        {
            this.aristas = new List<Arista>();
            this.group = 0;
            this.coordenada = coordenada;
            this.radius = radius;
            this.area = area;
            this.id = id;
        }
        public void agregarArista(Vertice vertice, int peso, String vid="")
        {
            this.aristas.Add(new Arista(vertice, peso, vid));
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
        public int GetRadius()
        {
            return this.radius;
        }
        public int GetGroup()
        {
            return this.group;
        }
        public void SetGroup(int group)
        {
            this.group = group;
        }
        public double GetArea()
        {
            return this.area;
        }
        public void graficarVertice(Brush brush, Bitmap img)
        {
            Graphics g = Graphics.FromImage(img);
            g.FillEllipse(brush, this.coordenada.X - this.radius, this.coordenada.Y - this.radius, this.radius * 2, this.radius * 2);
        }


    }

    class Arista
    {
        private Vertice sig;
        
        private string vid;
        private int peso;
        public Arista(Vertice vertice, int peso, String vid="")
        {
            sig = vertice;
            this.peso = peso;
            this.vid = vid;
        }
        public Vertice GetSig()
        {
            return sig;
        }
        public String GetVid()
        {
            return this.vid;
        }
        public void SetVid(String vid)
        {
            this.vid = vid;
        }

        public int GetPeso()
        {
            return peso;
        }
    }
    
}
