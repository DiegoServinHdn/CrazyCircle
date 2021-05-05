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
        public Tree(List<Vertice> vertices=null)
        {
            if (vertices == null)
            {
                this.vertices = new List<Vertice>();
            }
            this.pesoTotal=0;
        }

        public List<Vertice> GetVertices()
        {
            return vertices;
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

        public void drawTree(Bitmap img)
        {
            Graphics g = Graphics.FromImage(img);
            Font drawFont = new Font("Arial", 15);
            Font weightFont = new Font("Arial", 10);
            Pen plumaArista = new Pen(Color.Brown, 3);

            SolidBrush drawBrush = new SolidBrush(Color.Purple);
            SolidBrush vertexBrush = new SolidBrush(Color.Yellow);
            SolidBrush weightBrush = new SolidBrush(Color.Orange);



            foreach (Vertice vertice in vertices)
            {

                foreach (Arista arista in vertice.GetAristas())
                {
                    g.DrawLine(plumaArista, vertice.GetCoordenada(), arista.GetSig().GetCoordenada());
                    g.DrawString(arista.GetPeso().ToString(), weightFont, weightBrush, (vertice.GetCoordenada().X + arista.GetSig().GetCoordenada().X)/2, (vertice.GetCoordenada().Y + arista.GetSig().GetCoordenada().Y) / 2);
                }
            }

            foreach (Vertice vertice in vertices)
            {
                vertice.graficarVertice(vertexBrush, img);

                g.DrawString(vertice.GetId() + " g:" + vertice.GetGroup().ToString(), drawFont, drawBrush, vertice.GetCoordenada().X - 10, vertice.GetCoordenada().Y - 10);
            }
        }

    }
}
