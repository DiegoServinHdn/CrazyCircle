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
        Bitmap imageCopy;
        DynamicGraph grafo;
        bool grafodetectado = false;
        List<Circle> detectedCircles = new List<Circle>();

        public Form1()
        {
            InitializeComponent();
        }
        //Bubble sort


        public void detectCircles(int j, int i, Bitmap img)
        {
            int pixelCount = 0, centerx, centery;
            while (img.GetPixel(j, i) != White && j != img.Width-1 && i != img.Height-1)
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
            while (img.GetPixel(centerx, i) != White && j != img.Width - 1 && i != img.Height - 1)
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
            Graphics cpyg = Graphics.FromImage(imageCopy);

            Pen RedPen = new Pen(Color.Red, 8);
            SolidBrush white = new SolidBrush(White);
            imgg.FillEllipse(white, centerx - pixelCount - 2, centery - pixelCount - 1, pixelCount * 2 + 4, pixelCount * 2 + 4);
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
            Circle circo = new Circle(cicleId, centerx, centery, pixelCount);
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
                    if (buscar && pixel.R ==  pixel.G && pixel.G == pixel.B && pixel.R != 255)
                    {
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
                var imga = Image.FromFile(ofd.FileName);
                pictureBox1.Size = new Size(840, 540);
                if (imga.Width > pictureBox1.Width || imga.Height > pictureBox1.Height)
                {
                    float scale;
                    float widthScale = (float)pictureBox1.Width / (float)imga.Width;
                    float heightScale = (float)pictureBox1.Height / (float)imga.Height;

                    scale = widthScale > heightScale ? heightScale : widthScale;
                    var newWidth = (int)(imga.Width * scale);
                    var newHeight = (int)(imga.Height * scale);
                    imga = new Bitmap(imga, new Size(newWidth, newHeight));
                }
                pictureBox1.Image = imga;
                imageCopy = (Bitmap) imga;
                button2.Enabled = true;

                detectedCircles.Clear();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            grafo = new DynamicGraph();
            dataGridView1.Columns.Clear();
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
            if (puntosMasCercanos.Count == 2)
            {
                cpyg.DrawLine(puntosCercanosPen, puntosMasCercanos[0].center, puntosMasCercanos[1].center);
            }
            grafo.graficarGrafo(imageCopy);

            grafo.adjacencyMatrix(dataGridView1);

            puntosMasCercanos.Clear();
            button2.Enabled = false;
            grafodetectado = true;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (grafodetectado){
                Graphics g = Graphics.FromImage(imageCopy);
                Color pixel = imageCopy.GetPixel(e.X, e.Y);
                if (pixel.R == pixel.G && pixel.G == pixel.B && pixel.R != 255)
                {
                    Vertice vertice_click = Utilities.BelongsTo(e.X, e.Y, grafo, imageCopy);
                    if (vertice_click != null)
                    {
                        MessageBox.Show(vertice_click.GetId());
                    }
                    else
                    {
                        MessageBox.Show("vertice no encontrado");
                    }
                    
                }

            }

        }

    }
}