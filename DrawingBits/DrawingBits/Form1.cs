using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace DrawingBits
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Render();
        }
        void Render()
        {
            
            using (var bmp = (Bitmap)pbPicture.Image?.Clone() ?? new Bitmap(pbPicture.Width, pbPicture.Height))
            using (var gfx = Graphics.FromImage(bmp))
            using (var pen = new Pen(Color.DeepPink))
            {
                // draw/write the value from textbox tbValue
                string firstText = tbValue.Text;
                PointF firstLocation = new PointF(Convert.ToInt32(tbX.Text), Convert.ToInt32(tbY.Text));
                using (Graphics graphics = Graphics.FromImage(bmp))
                {
                    using (Font arialFont = new Font("Arial", 12))
                    {
                        graphics.DrawString(firstText, arialFont, Brushes.DeepPink, firstLocation);
                    }

                }

                System.Drawing.Rectangle rect = new System.Drawing.Rectangle();
                rect.X = Convert.ToInt32(tbX.Text);
                rect.Y = Convert.ToInt32(tbY.Text);
                rect.Width = 20;
                rect.Height = 20;
                gfx.DrawEllipse(pen, rect);
               
                // copy the bitmap to the picturebox
                pbPicture.Image?.Dispose();
                pbPicture.Image = (Bitmap)bmp.Clone();
            }
        }

    }
}

//string firstText = "Hello";
//string secondText = "World";

//PointF firstLocation = new PointF(10f, 10f);
//PointF secondLocation = new PointF(10f, 50f);

//string imageFilePath = @"path\picture.bmp"
//Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file

//using (Graphics graphics = Graphics.FromImage(bitmap))
//{
//    using (Font arialFont = new Font("Arial", 10))
//    {
//        graphics.DrawString(firstText, arialFont, Brushes.Blue, firstLocation);
//        graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
//    }
//}

//bitmap.Save(imageFilePath);//save the image file