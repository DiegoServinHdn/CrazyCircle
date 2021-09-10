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
        Vertice Origen = null;
        Vertice Destino = null;
        List<ElementoDijkstra> vectorDijkstra;
        List<Vertice> vCamino;
        Bitmap pimage;
        DynamicGraph grafo;

        bool grafodetectado = false;
        List<Circle> detectedCircles = new List<Circle>();


        Image particula = Utilities.scaleImageSize(new Size(40, 40), Image.FromFile("..\\..\\assets\\particula.png"));


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


            ofd.Filter = "Archivos de imagen|*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                button3.Enabled = false;
                button4.Enabled = false;
                grafodetectado = false;
                Origen = null;
                Destino = null;

                label6.Text = "";
                label5.Text = "";
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
                button2.Enabled = true;


                detectedCircles.Clear();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            grafo = new DynamicGraph();

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
            //grafo.graficar(imageCopy);


            puntosMasCercanos.Clear();
            button2.Enabled = false;

            grafodetectado = true;
            pimage = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = pimage;
            pictureBox1.BackgroundImage = imageCopy;

        }

        //Click izquierdo
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            if (grafodetectado)
            {
                Color pixel = imageCopy.GetPixel(e.X, e.Y);

                if (pixel.R == pixel.G && pixel.G == pixel.B && pixel.R != 255)
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Left:
                            {
                                //List<Tuple<String, Arista>> tuplaArista = new List<Tuple<string, Arista>>();
                                Vertice verticeLClick = Utilities.BelongsTo(e.X, e.Y, grafo, imageCopy);
                                if (verticeLClick != null)
                                {
                                    label5.Text = verticeLClick.GetId();
                                    Origen = verticeLClick;

                                    pimage = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
                                    pictureBox1.Image = pimage;
                                    Utilities.drawParticule(Origen.GetCoordenada(), pimage, particula);
                                    
                                }
                            }

                            break;
                        case MouseButtons.Right:
                            {
                                Vertice verticeRClick = Utilities.BelongsTo(e.X, e.Y, grafo, imageCopy);
                                if (verticeRClick != null)
                                {
                                    label6.Text = verticeRClick.GetId();
                                    Destino = verticeRClick;
                                }
                            }
                            break;

                    }
                    if ((Origen != null && Destino != null) && (Destino.GetGroup() != Origen.GetGroup()))
                    {
                        vCamino = null;
                        vectorDijkstra = null;
                        button3.Enabled = false;
                        button4.Enabled = false;
                    }
                    else if(Origen!=null && Destino!=null){
                        vectorDijkstra = Utilities.Dijkstra(grafo, Origen);
                        vCamino = Utilities.getVerticesCamino(vectorDijkstra, Destino, Origen);
                        button3.Enabled = true;
                        button4.Enabled = true;
                    }

                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pimage = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = pimage;
            pictureBox1.BackgroundImage = imageCopy;
            Utilities.drawCamino(vCamino, pimage, Color.Red, 10);
            Utilities.drawParticule(Origen.GetCoordenada(), pimage, particula);

        }


        private void button4_Click(object sender, EventArgs e)
        {
            List<List<Point>> bresehnanim = new List<List<Point>>();

            button4.Enabled = false;
            for (int i = 0; vCamino.Count -1 > i; i++)
            {
                foreach (var arista in vCamino[i].GetAristas())
                {
                    if (arista.GetSig() == vCamino[i+1])
                    {
                        bresehnanim.Add(arista.GetCamino());
                        break;
                    }
                }
            }

            foreach (List<Point> camino in bresehnanim)
            {
                foreach (Point coord in camino)
                {
                    pimage = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
                    pictureBox1.Image = pimage;
                    Utilities.drawParticule(coord, pimage, particula);
                    pictureBox1.Refresh();
                    System.Threading.Thread.Sleep(1);
                }

            }
            label5.Text = Destino.GetId();
            Origen = Destino;
            vCamino = Utilities.getVerticesCamino(vectorDijkstra, Destino, Origen);
            button4.Enabled = true;

        }

    }
}