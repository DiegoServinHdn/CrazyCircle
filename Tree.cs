using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyCircle
{
    class Tree
    {
        protected List<Vertice> vertices;
        protected int pesoTotal;
        protected List<Arista> ordenAristas;
        protected string contextID;
        public Tree(string contextID="",List<Vertice> vertices = null)
        {
            if (vertices == null)
            {
                this.vertices = new List<Vertice>();
            }
            this.pesoTotal = 0;
            this.contextID = contextID;
            ordenAristas = new List<Arista>();
        }

        public List<Vertice> GetVertices()
        {
            return vertices;
        }

        public void SetOrdenAristas(List<Arista> aristasOrdenadas)
        {
            ordenAristas = aristasOrdenadas;
        }

        public Vertice findvertice(string id)
        {
            foreach (Vertice vertice in vertices)
            {
                if (vertice.GetId() == id)
                {
                    return vertice;
                }
            }
            return null;
        }
        public void addVertice(Vertice vertice)
        {
            vertices.Add(vertice);
        }

        public void drawTree(Bitmap img, Color vertexColor)
        {
            Graphics g = Graphics.FromImage(img);
            Font drawFont = new Font("Arial", 15);
            Font weightFont = new Font("Arial", 10);
            Font orderFont = new Font("Arial", 15);
            Pen plumaArista = new Pen(Color.Pink, 3);

            SolidBrush drawBrush = new SolidBrush(Color.Purple);
            SolidBrush vertexBrush = new SolidBrush(vertexColor);
            SolidBrush weightBrush = new SolidBrush(Color.Orange);
            SolidBrush orderBrush = new SolidBrush(Color.Red);



            foreach (Vertice vertice in vertices)
            {

                foreach (Arista arista in vertice.GetAristas())
                {
                    g.DrawLine(plumaArista, vertice.GetCoordenada(), arista.GetSig().GetCoordenada());
                    //g.DrawString(arista.GetPeso().ToString(), weightFont, weightBrush, (vertice.GetCoordenada().X + arista.GetSig().GetCoordenada().X)/2, (vertice.GetCoordenada().Y + arista.GetSig().GetCoordenada().Y) / 2);
                }
            }

            foreach (Vertice vertice in vertices)
            {
                vertice.graficarVertice(vertexBrush, img);

                g.DrawString(contextID + vertice.GetGroup().ToString(), drawFont, drawBrush, vertice.GetCoordenada().X - 15, vertice.GetCoordenada().Y - 10);
            }

            int o = 1;
            foreach (Arista arista in ordenAristas)
            {
                Vertice vertice = this.findvertice(arista.GetVid());
                g.DrawString(o.ToString(), orderFont, orderBrush, (vertice.GetCoordenada().X + arista.GetSig().GetCoordenada().X) / 2, (vertice.GetCoordenada().Y + arista.GetSig().GetCoordenada().Y) / 2);
                g.DrawString(arista.GetPeso().ToString(), weightFont, weightBrush, (vertice.GetCoordenada().X- 30 + arista.GetSig().GetCoordenada().X) / 2, (vertice.GetCoordenada().Y - 30 + arista.GetSig().GetCoordenada().Y) / 2);

                o++;
            }
        }

        public void calcularPesoTotal()
        {
            int pesoT = 0;
            foreach (var arista in ordenAristas)
            {
                pesoT += arista.GetPeso();
            }
            this.pesoTotal = pesoT;
        }

        public override string ToString()
        {
            return (string.Format("{0}{1}, Peso = {2}",contextID,vertices[0].GetGroup().ToString(), pesoTotal));
        }



    }
}
