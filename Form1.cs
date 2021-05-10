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
    public partial class Form1 : Form
    {
        Color White = Color.FromArgb(255, 255, 255, 255);
        int cicleId = 0;
        int whiteError = 1;
        Bitmap imageCopy;
        Bitmap Prim;
        Bitmap Kruskal;
        DynamicGraph grafo;
        List<Tree> ARMPrim;
        List<Tree> ARMKurskal;
        bool grafodetectado = false;
        List<Circle> detectedCircles = new List<Circle>();


        public Form1()
        {
            InitializeComponent();
            pictureBox1.Size = new Size(840, 540);
        }
        //Bubble sort

        public bool isWhite(Color color)
        {
            if (color.R >= 255 - whiteError && color.G >= 255 - whiteError && color.B >= 255 - whiteError){
                return true;
            }
            return false;
        }


        public void detectCircles(int j, int i, Bitmap img)
        {
            int pixelCount = 0, centerx, centery;
            while (!isWhite(img.GetPixel(j, i)) && j != img.Width-1 && i != img.Height-1)
            {
                pixelCount += 1;
                j++;
            }
            if (pixelCount % 2 != 0 && pixelCount != 0)
            {
                pixelCount = ((pixelCount - 1) / 2) + 1;
                centerx = j - pixelCount;
            }
            else
            {
                pixelCount = pixelCount / 2;
                centerx = j - pixelCount - 1;
            }
            pixelCount = 0;
            while (!isWhite(img.GetPixel(centerx, i)) && j != img.Width - 1 && i != img.Height - 1)
            {
                pixelCount += 1;
                i++;
            }
            if (pixelCount % 2 != 0 && pixelCount != 0)
            {
                pixelCount = ((pixelCount - 1) / 2) + 1;
                centery = i - pixelCount;
            }
            else
            {
                pixelCount = pixelCount / 2;
                centery = i - pixelCount - 1;
            }

            Graphics imgg = Graphics.FromImage(img);


            Pen RedPen = new Pen(Color.Red, 8);
            SolidBrush white = new SolidBrush(White);
            imgg.FillEllipse(white, centerx - pixelCount - 1, centery - pixelCount - 1, pixelCount * 2 + 3, pixelCount * 2 + 3);
            //cpyg.DrawEllipse(RedPen, centerx - pixelCount, centery - pixelCount, pixelCount * 2, pixelCount * 2);

            cicleId += 1;
            /*
            String drawString = cicleId.ToString();
            Font drawFont = new Font("Arial", 25);
            SolidBrush drawBrush = new SolidBrush(Color.Yellow);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            cpyg.DrawString(drawString, drawFont, drawBrush, centerx + 8, centery + 8, drawFormat);
            */
            /*
            imageCopy.SetPixel(centerx, centery, Color.Yellow);
            imageCopy.SetPixel(centerx, centery + 1, Color.Yellow);
            imageCopy.SetPixel(centerx - 1, centery, Color.Yellow);
            imageCopy.SetPixel(centerx + 1, centery, Color.Yellow);
            imageCopy.SetPixel(centerx, centery - 1, Color.Yellow);
            */
            if (centery < 0)
            {
                centery = 0;
            }
            Circle circo = new Circle(cicleId, centerx, centery, pixelCount);
            Console.WriteLine(circo.ToString());
            detectedCircles.Add(circo);
            pictureBox1.Image = imageCopy;
        }

        public bool findCircles(Bitmap img, int inicioy = 0)
        {
            Color pixel;
            int h = img.Height;
            bool buscar = true;
            int w = img.Width;
            for (int i = inicioy; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    pixel = img.GetPixel(j, i);
                    if (buscar && pixel.R == pixel.G && pixel.G == pixel.B && pixel.R < 255 - whiteError)
                    {
                        Console.WriteLine(pixel.ToString());
                        detectCircles(j, i, img);
                        return findCircles(img, i);
                    }
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var ofd = new OpenFileDialog();
            grafodetectado = false;

            ofd.Filter = "Archivos de imagen|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                subgen.Text = "";
                PrimG.Text = "";
                Kruskgen.Text = "";
                PrimList.DataSource = null;
                KruskalList.DataSource = null;
                var imga = Image.FromFile(ofd.FileName);
                pictureBox1.Size = new Size(840, 540);
                /*if (imga.Width > pictureBox1.Width || imga.Height > pictureBox1.Height)
                {
                    float scale;
                    float widthScale = (float)pictureBox1.Width / (float)imga.Width;
                    float heightScale = (float)pictureBox1.Height / (float)imga.Height;

                    scale = widthScale > heightScale ? heightScale : widthScale;
                    var newWidth = (int)(imga.Width * scale);
                    var newHeight = (int)(imga.Height * scale);
                    imga = new Bitmap(imga, new Size(newWidth, newHeight));
                }*/
                imga = Utilities.scaleImage(pictureBox1, imga);
                pictureBox1.Image = imga;

                imageCopy = (Bitmap) imga;
                Kruskal = (Bitmap)imageCopy.Clone();
                Prim = (Bitmap)imageCopy.Clone();
                button2.Enabled = true;


                detectedCircles.Clear();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            grafo = new DynamicGraph();
            ARMPrim = new List<Tree>();
            ARMKurskal = new List<Tree>();
            var img = (Bitmap)pictureBox1.Image;
            imageCopy = (Bitmap)img.Clone();
            findCircles((Bitmap)pictureBox1.Image);
            cicleId = 0;

            
            
            foreach (Vertice vertice in Utilities.CalcularVertices(imageCopy, detectedCircles))
            {
                grafo.agregarVertice(vertice);
            }

            Pen puntosCercanosPen = new Pen(Color.Orange, 10);
            Graphics cpyg = Graphics.FromImage(imageCopy);
            List<Circle> puntosMasCercanos = Utilities.getClosestPairPoints(detectedCircles);
            /*
            if (puntosMasCercanos.Count == 2)
            {
                cpyg.DrawLine(puntosCercanosPen, puntosMasCercanos[0].center, puntosMasCercanos[1].center);
            }
            */
            grafo.findSubGraphs();
            grafo.graficar(imageCopy);
            foreach (var sub in grafo.GetSubgraphs())
            {
                var newKruskal = new Tree("K");
                ARMKurskal.Add(Utilities.kruskal(newKruskal, sub));

            }
            foreach(var kruskal in ARMKurskal)
            {
                kruskal.calcularPesoTotal();
                kruskal.drawTree(Kruskal, Color.Green);
            }

            KruskalList.DataSource = null;
            KruskalList.DataSource = ARMKurskal;

            subgen.Text = grafo.GetSubgraphs().Count.ToString();
            Kruskgen.Text = ARMKurskal.Count.ToString();
            PrimG.Text = ARMPrim.Count.ToString();
            puntosMasCercanos.Clear();
            button2.Enabled = false;
            verGrafo.Enabled = false;
            verkruskal.Enabled = true;
            verPrim.Enabled = true;
            grafodetectado = true;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            if (grafodetectado)
            {
                Color pixel = imageCopy.GetPixel(e.X, e.Y);

                if (pixel.R == pixel.G && pixel.G == pixel.B && pixel.R != 255)
                {
                    
                    List<Arista> prometodor = new List<Arista>();
                    List<string> visited = new List<string>();
                    List<Arista> aristaQueue = new List<Arista>();
                    //List<Tuple<String, Arista>> tuplaArista = new List<Tuple<string, Arista>>();
                    Vertice vertice_click = Utilities.BelongsTo(e.X, e.Y, grafo, imageCopy);
                    Tree newPrim = new Tree("P");
                    if (vertice_click != null && !Utilities.isInsideTree(ARMPrim, vertice_click))
                    {
                        foreach (Vertice ver in grafo.GetSubgraphs()[vertice_click.GetGroup() - 1])
                        {
                            var nuevoVertice = new Vertice(ver.GetCoordenada(), ver.GetRadius(), ver.GetArea(), ver.GetId());
                            nuevoVertice.SetGroup(ver.GetGroup());
                            newPrim.addVertice(nuevoVertice);
                        }

                        foreach (Arista arista in vertice_click.GetAristas())
                        {
                            //tuplaArista.Add(new Tuple<String, Arista>(vertice_click.GetId(),arista));
                            aristaQueue.Add(arista);
                        }

                        Arista minArista;
                        visited.Add(vertice_click.GetId());
                        while (aristaQueue.Count > 0)
                        {
                            minArista = Utilities.getMinArtista(aristaQueue);

                            if (!visited.Contains(minArista.GetSig().GetId()))
                            {
                                newPrim.findvertice(minArista.GetVid()).agregarArista(minArista.GetSig(), minArista.GetPeso());
                                prometodor.Add(minArista);
                                visited.Add(minArista.GetSig().GetId());
                                foreach (Arista arista in minArista.GetSig().GetAristas())
                                {
                                    if (!visited.Contains(arista.GetSig().GetId()))
                                    {
                                        aristaQueue.Add(arista);
                                    }
                                }
                            }
                            aristaQueue.Remove(minArista);
                        }
                        newPrim.SetOrdenAristas(prometodor);
                        newPrim.calcularPesoTotal();
                        ARMPrim.Add(newPrim);
                        PrimG.Text = ARMPrim.Count.ToString();
                        PrimList.DataSource = null;
                        PrimList.DataSource = ARMPrim.OrderBy(x=>x.GetVertices()[0].GetGroup()).ToList();
                        newPrim.drawTree(Prim, Color.Yellow);
                        pictureBox1.Image = Prim;
                        verPrim.Enabled = false;
                        verGrafo.Enabled = true;
                        verkruskal.Enabled = true;

                    }

                }

            }

        }

        private void verkruskal_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Kruskal;
            verkruskal.Enabled = false;
            verPrim.Enabled = true;
            verGrafo.Enabled = true;
        }

        private void verPrim_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Prim;
            verkruskal.Enabled = true;
            verPrim.Enabled = false;
            verGrafo.Enabled = true;
        }

        private void verGrafo_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageCopy;
            verkruskal.Enabled = true;
            verPrim.Enabled = true;
            verGrafo.Enabled = false;
        }

    }
}