using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace obrabotka
{

    public partial class Form1 : Form
    {
  
        private Point start, end, center;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(70, 244, 66, 66));
        private List<int[,]> templates = new List<int[,]>
        {
           new int[,] {{ -3, -3, 5 }, { -3, 0, 5 }, { -3, -3, 5 } },
           new int[,] {{ -3, 5, 5 }, { -3, 0, 5 }, { -3, -3, -3 } },
           new int[,] {{ 5, 5, 5 }, { -3, 0, -3 }, { -3, -3, -3 } },
           new int[,] {{ 5, 5, -3 }, { 5, 0, -3 }, { -3, -3, -3 } },
           new int[,] {{ 5, -3, -3 }, { 5, 0, -3 }, { 5, -3, -3 } },
           new int[,] {{ -3, -3, -3 }, { 5, 0, -3 }, { 5, 5, -3 } },
           new int[,] {{ -3, -3, -3 }, { -3, 0, -3 }, { 5, 5, 5 } },
           new int[,] {{ -3, -3, -3 }, { -3, 0, 5 }, { -3, 5, 5 } }
        };

        public Form1()
        {
            //изначальные параметры элементов
            InitializeComponent();
            PixelBar.Hide();
            PixelBar_value.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Hide();
            numericUpDown1.Hide();
            numericUpDown2.Hide();
            axis.SelectedItem = "Центр";
            ScailingConst.Text = "1";
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            Bitmap image;
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(open_dialog.FileName);
                Bitmap bmp = new Bitmap(image, new Size(250, 250 * image.Size.Height / image.Size.Width));
                image_mass = new byte[bmp.Width, bmp.Height];
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color color = bmp.GetPixel(x, y);
                        image_mass[x, y] = (byte)(0.3 * color.R + 0.59 * color.G + 0.11 * color.B);
                    }
                }
                BasicImage.Image = bmp;
                //gen_graph(image_mass);
                BasicImage.Invalidate();
            }
        }

        string flag;
        byte[,] image_mass;

        private void PixelBar_Scroll(object sender, EventArgs e)
        {
            PixelBar_value.Text = String.Format("Текущее значение: {0}", PixelBar.Value);
            if (flag == "Enlightenment") { Enlightenment_Click(sender, e); }
            else if (flag == "Binarization") { Binarization_Click(sender, e); }
            else if (flag == "Binarization_two") { Binarization_two_Click(sender, e); }
            else if (flag == "Gamma") { Gamma_Click(sender, e); }
            else if (flag == "Quantization") { Quantization_Click(sender, e); }
            else if (flag == "High frequency") { High_frequency_Click(sender, e); }
            else if (flag == "Rotation") { Rotation_Click(sender, e); }
        }

        private void Enlightenment_Click(object sender, EventArgs e)
        {
            //параметры элементов
            PixelBar.Show();
            PixelBar_value.Show();
            PixelBar.Maximum = 255;
            PixelBar.Minimum = -255;
            PixelBar_value.Text = String.Format("Текущее значение: {0}", PixelBar.Value);
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Hide();

            //код фильтра
            flag = "Enlightenment";

            Bitmap new_image = new Bitmap(BasicImage.Image.Width, BasicImage.Image.Height);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            for (int i = 0; i < BasicImage.Image.Width; i++)
            {
                for (int j = 0; j < BasicImage.Image.Height; j++)
                {
                    Color color = old_image.GetPixel(i, j);
                    int R = color.R + PixelBar.Value;
                    int G = color.G + PixelBar.Value;
                    int B = color.B + PixelBar.Value;
                    if (R > 255) { R = 255; }
                    if (R < 0) { R = 0; }
                    if (G > 255) { G = 255; }
                    if (G < 0) { G = 0; }
                    if (B > 255) { B = 255; }
                    if (B < 0) { B = 0; }
                    new_image.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }

            newImage.Image = new_image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
                Coloring_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = colorDialog1.Color;
                Coloring_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = colorDialog1.Color;
                Coloring_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button4.BackColor = colorDialog1.Color;
                Coloring_Click(sender, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button5.BackColor = colorDialog1.Color;
                Coloring_Click(sender, e);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button6.BackColor = colorDialog1.Color;
                Coloring_Click(sender, e);
            }
        }

        private void Coloring_Click(object sender, EventArgs e)
        {
            //параметры элементов
            PixelBar.Hide();
            PixelBar_value.Hide();
            button1.Show();
            button2.Show();
            button3.Show();
            button4.Show();
            button5.Show();
            button6.Show();
            axis.Hide();
            ScailingConst.Hide();

            //код фильтра
            flag = "Coloring";

            Bitmap new_image = new Bitmap(BasicImage.Image.Width, BasicImage.Image.Height);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            for (int i = 0; i < BasicImage.Image.Width; i++)
            {
                for (int j = 0; j < BasicImage.Image.Height; j++)
                {
                    if (old_image.GetPixel(i, j).GetBrightness() <= 0.16)
                    {
                        new_image.SetPixel(i, j, button1.BackColor);
                    }
                    else if (old_image.GetPixel(i, j).GetBrightness() <= 0.33)
                    {
                        new_image.SetPixel(i, j, button2.BackColor);
                    }
                    else if (old_image.GetPixel(i, j).GetBrightness() <= 0.49)
                    {
                        new_image.SetPixel(i, j, button3.BackColor);
                    }
                    else if (old_image.GetPixel(i, j).GetBrightness() <= 0.66)
                    {
                        new_image.SetPixel(i, j, button4.BackColor);
                    }
                    else if (old_image.GetPixel(i, j).GetBrightness() <= 0.82)
                    {
                        new_image.SetPixel(i, j, button5.BackColor);
                    }
                    else
                    {
                        new_image.SetPixel(i, j, button6.BackColor);
                    }
                }

                newImage.Image = new_image;
            }
        }

        //Бинаризация на основе яркости
        private void Binarization_Click(object sender, EventArgs e)
        {
            //параметры элементов
            PixelBar.Minimum = 0;
            PixelBar.Maximum = 100;
            PixelBar_value.Text = String.Format("Текущее значение: {0}", (double)PixelBar.Value / 100.0);
            PixelBar.Show();
            PixelBar_value.Show();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Hide();

            //код фильтров
            flag = "Binarization";

            double n = (double)PixelBar.Value / 100.0;

            Bitmap new_image = new Bitmap(BasicImage.Image.Width, BasicImage.Image.Height);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            for (int i = 0; i < BasicImage.Image.Width; i++)
            {
                for (int j = 0; j < BasicImage.Image.Height; j++)
                {
                    new_image.SetPixel(i, j, old_image.GetPixel(i, j).GetBrightness() < n ? Color.Black : Color.White);

                }
            }

            newImage.Image = new_image;
        }

        //Бинаризация на основе интенсивности
        private void Binarization_two_Click(object sender, EventArgs e)
        {
            //параметры элементов
            PixelBar.Minimum = 0;
            PixelBar.Maximum = 255;
            PixelBar_value.Text = String.Format("Текущее значение: {0}", (double)PixelBar.Value);
            PixelBar.Show();
            PixelBar_value.Show();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Hide();

            //код фильтра
            flag = "Binarization_two";

            Bitmap new_image = new Bitmap(BasicImage.Image.Width, BasicImage.Image.Height);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            for (int i = 0; i < BasicImage.Image.Width; i++)
            {
                for (int j = 0; j < BasicImage.Image.Height; j++)
                {
                    new_image.SetPixel(i, j, image_mass[i, j] < PixelBar.Value ? Color.Black : Color.White);
                }
            }

            newImage.Image = new_image;
        }

        private void Gamma_Click(object sender, EventArgs e)
        {
            //параметры элементов
            flag = "Gamma";
            PixelBar.Minimum = 0;
            PixelBar.Maximum = 500;
            PixelBar_value.Text = String.Format("Текущее значение: {0}", (double)PixelBar.Value / 100.0);
            PixelBar.Show();
            PixelBar_value.Show();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Hide();

            //код фильтра
            double Gamma = 1 / (Math.Max(0.1, Math.Min(5.0, PixelBar.Value / 100.0))); //главное значение гаммы
            byte[] table = new byte[256]; 

            for (int i = 0; i < 256; i++)
            {
                table[i] = (byte)Math.Min(255, (int)(Math.Pow(i / 255.0, Gamma) * 255 + 0.5));
            }

            Bitmap new_image = new Bitmap(BasicImage.Image.Width, BasicImage.Image.Height);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            for (int i = 0; i < BasicImage.Image.Width; i++)
            {
                for (int j = 0; j < BasicImage.Image.Height; j++)
                {
                    Color color = old_image.GetPixel(i, j);
                    int R = table[color.R];
                    int G = table[color.G];
                    int B = table[color.B];
                    new_image.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }

            newImage.Image = new_image;
        }

        private void Quantization_Click(object sender, EventArgs e)
        {
            //параметры элементов
            flag = "Quantization";
            PixelBar.Show();
            PixelBar_value.Show();
            PixelBar.Minimum = 2;
            PixelBar.Maximum = 100;
            PixelBar_value.Text = String.Format("Текущее значение: {0}", (double)PixelBar.Value);
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Hide();

            //код фильтра
            byte[] palette = new byte[PixelBar.Value];

            Bitmap new_image = new Bitmap(BasicImage.Image.Width, BasicImage.Image.Height);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            for (int i = 0; i < PixelBar.Value; i++)
            {
                palette[i] = (byte)(i * (256 / PixelBar.Value));
            }
            for (int x = 0; x < old_image.Width; x++)
            {
                for (int y = 0; y < old_image.Height; y++)
                {
                    for (int j = 1; j < PixelBar.Value; j++)
                    {
                        if ((palette[j - 1] <= image_mass[x, y]) && (image_mass[x, y] < palette[j]))
                        {

                            new_image.SetPixel(x, y, Color.FromArgb(palette[j - 1], palette[j - 1], palette[j - 1]));
                        }
                    }
                }
            }
            newImage.Image = new_image;
        }

        private void High_frequency_Click(object sender, EventArgs e)
        {
            //Параметры элементов
            flag = "High frequency";
            PixelBar.Hide();
            PixelBar_value.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Hide();

            //код фильтра
            Bitmap new_image = new Bitmap(BasicImage.Image.Width, BasicImage.Image.Height);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            int R = 0;
            int G = 0;
            int B = 0;
            for (int i = 1; i < BasicImage.Image.Width - 1; i++)
            {
                for (int j = 1; j < BasicImage.Image.Height - 1; j++)
                {
                    Color color = old_image.GetPixel(i, j);

                    R = -old_image.GetPixel(i - 1, j - 1).R - old_image.GetPixel(i - 1, j).R - old_image.GetPixel(i - 1, j + 1).R - old_image.GetPixel(i, j - 1).R + 9 * old_image.GetPixel(i, j).R - old_image.GetPixel(i, j + 1).R - old_image.GetPixel(i + 1, j - 1).R - old_image.GetPixel(i + 1, j).R - old_image.GetPixel(i + 1, j + 1).R;
                    G = -old_image.GetPixel(i - 1, j - 1).G - old_image.GetPixel(i - 1, j).G - old_image.GetPixel(i - 1, j + 1).G - old_image.GetPixel(i, j - 1).G + 9 * old_image.GetPixel(i, j).G - old_image.GetPixel(i, j + 1).G - old_image.GetPixel(i + 1, j - 1).G - old_image.GetPixel(i + 1, j).G - old_image.GetPixel(i + 1, j + 1).G;
                    B = -old_image.GetPixel(i - 1, j - 1).B - old_image.GetPixel(i - 1, j).B - old_image.GetPixel(i - 1, j + 1).B - old_image.GetPixel(i, j - 1).B + 9 * old_image.GetPixel(i, j).B - old_image.GetPixel(i, j + 1).B - old_image.GetPixel(i + 1, j - 1).B - old_image.GetPixel(i + 1, j).B - old_image.GetPixel(i + 1, j + 1).B;

                    if (R < 0) { R = 0; }
                    if (G < 0) { G = 0; }
                    if (B < 0) { B = 0; }
                    if (R > 255) { R = 255; }
                    if (G > 255) { G = 255; }
                    if (B > 255) { B = 255; }
                    new_image.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            newImage.Image = new_image;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (newImage.Image != null) 
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        newImage.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            BasicImage.Image = newImage.Image;
            BasicImage.Invalidate();
        }

        private void BasicImage_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (flag == "Rotation" || flag == "Scaling")
            {
                 if ((e.Button == MouseButtons.Right && (axis.SelectedItem.ToString() == "Произвольная точка")))
                 {
                    center = e.Location;
                 }
                 else if (e.Button == MouseButtons.Left)
                 {
                    end = e.Location;
                }
            }
           

        }

        private void BasicImage_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (flag == "Rotation" || flag == "Scaling")
            {
                if (e.Button != MouseButtons.Left)
                    return;
                end = e.Location;
                Rect.Location = new Point(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y));
                Rect.Size = new Size(Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                BasicImage.Invalidate();
            }

        }

        private void BasicImage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (flag == "Rotation" || flag == "Scaling")
            {
                if (BasicImage.Image != null)
                {
                    if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                    {
                        e.Graphics.FillRectangle(selectionBrush, Rect);
                    }
                }
            }
        }

        private void ScailingConst_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private double determinant(List<double> matrix)
        {
            double deter = matrix[0] * matrix[4] * matrix[8] -
                matrix[0] * matrix[7] * matrix[5] +
                matrix[1] * matrix[5] * matrix[6] -
                matrix[1] * matrix[8] * matrix[3] +
                matrix[2] * matrix[3] * matrix[7] -
                matrix[2] * matrix[6] * matrix[4];
            return deter;
        }

        private double parabola(double x1,double y1, double x2, double y2,
            double x3, double y3, double x)
        {
            List<double> mat = new List<double>() { x1 * x1, x1, 1, x2 * x2, x2, 1, x3 * x3, x3, 1 };
            List<double> mat1 = new List<double>() { y1, x1, 1, y2, x2, 1, y3, x3, 1 };
            List<double> mat2 = new List<double>() { x1 * x1, y1, 1, x2 * x2, y2, 1, x3 * x3, y3, 1 };
            List<double> mat3 = new List<double>() { x1 * x1, x1, y1, x2 * x2, x2, y2, x3 * x3, x3, y3 };

            double det = determinant(mat);
            double det1 = determinant(mat1);
            double det2 = determinant(mat2);
            double det3 = determinant(mat3);

            double a = det1 / det;
            double b = det2 / det;
            double c = det3 / det;

            return (a * x * x + b * x + c);
        }

        private void Scaling_Click(object sender, EventArgs e)
        {
            //Параметры элементов
            flag = "Scaling";
            PixelBar.Hide();
            PixelBar_value.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Show();
            numericUpDown1.Hide();
            numericUpDown2.Hide();

            if (Rect.Width == 0 || Rect.Height == 0) {
                return;
            }

            //код фильтра
            double ScConst = Convert.ToDouble(ScailingConst.Text);
            int newHeight = (int)(Rect.Height * ScConst);
            int newWidth = (int)(Rect.Width * ScConst);

            Bitmap new_image = new Bitmap(newWidth, newHeight);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    double scaledX = start.X + x / ScConst;
                    double scaledY = start.Y + y / ScConst;
                    int flooredX = (int)(scaledX);
                    int flooredY = (int)(scaledY);

                    List<double> iter = new List<double>()
                        {
                            parabola(flooredX, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX)), Math.Min(old_image.Height-1,Math.Max(0,flooredY-1))).R,
                            flooredX+1, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+1)), Math.Min(old_image.Height-1,Math.Max(0,flooredY-1))).R,
                            flooredX+2, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+2)), Math.Min(old_image.Height-1,Math.Max(0,flooredY-1))).R, scaledX),

                            parabola(flooredX, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX)), Math.Min(old_image.Height-1,Math.Max(0,flooredY))).R,
                            flooredX+1, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+1)), Math.Min(old_image.Height-1,Math.Max(0,flooredY))).R,
                            flooredX+2, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+2)), Math.Min(old_image.Height-1,Math.Max(0,flooredY))).R, scaledX),

                            parabola(flooredX, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX)), Math.Min(old_image.Height-1,Math.Max(0,flooredY+1))).R,
                            flooredX+1, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+1)), Math.Min(old_image.Height-1,Math.Max(0,flooredY+1))).R,
                            flooredX+2, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+2)), Math.Min(old_image.Height-1,Math.Max(0,flooredY+1))).R, scaledX),

                            parabola(flooredX, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX)), Math.Min(old_image.Height-1,Math.Max(0,flooredY-1))).G,
                            flooredX+1, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+1)), Math.Min(old_image.Height-1,Math.Max(0,flooredY-1))).G,
                            flooredX+2, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+2)), Math.Min(old_image.Height-1,Math.Max(0,flooredY-1))).G, scaledX),

                            parabola(flooredX, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX)), Math.Min(old_image.Height-1,Math.Max(0,flooredY))).G,
                            flooredX+1, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+1)), Math.Min(old_image.Height-1,Math.Max(0,flooredY))).G,
                            flooredX+2, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+2)), Math.Min(old_image.Height-1,Math.Max(0,flooredY))).G, scaledX),

                            parabola(flooredX, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX)), Math.Min(old_image.Height-1,Math.Max(0,flooredY+1))).G,
                            flooredX+1, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+1)), Math.Min(old_image.Height-1,Math.Max(0,flooredY+1))).G,
                            flooredX+2, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+2)), Math.Min(old_image.Height-1,Math.Max(0,flooredY+1))).G, scaledX),

                            parabola(flooredX, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX)), Math.Min(old_image.Height-1,Math.Max(0,flooredY-1))).B,
                            flooredX+1, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+1)), Math.Min(old_image.Height-1,Math.Max(0,flooredY-1))).B,
                            flooredX+2, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+2)), Math.Min(old_image.Height-1,Math.Max(0,flooredY-1))).B, scaledX),

                            parabola(flooredX, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX)), Math.Min(old_image.Height-1,Math.Max(0,flooredY))).B,
                            flooredX+1, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+1)), Math.Min(old_image.Height-1,Math.Max(0,flooredY))).B,
                            flooredX+2, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+2)), Math.Min(old_image.Height-1,Math.Max(0,flooredY))).B, scaledX),

                            parabola(flooredX, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX)), Math.Min(old_image.Height-1,Math.Max(0,flooredY+1))).B,
                            flooredX+1, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+1)), Math.Min(old_image.Height-1,Math.Max(0,flooredY+1))).B,
                            flooredX+2, old_image.GetPixel(Math.Min(old_image.Width-1,Math.Max(0,flooredX+2)), Math.Min(old_image.Height-1,Math.Max(0,flooredY+1))).B, scaledX)
                        };
                    Color c = new Color();

                    byte R = (byte)(parabola(flooredY, iter[0], flooredY + 1, iter[1], flooredY + 2, iter[2], scaledY));

                    if (R < 0)
                    {
                        R = 0;
                    }
                    else if (R > 255)
                    {
                        R = 255;
                    }

                    byte G = (byte)(parabola(flooredY, iter[3], flooredY + 1, iter[4], flooredY + 2, iter[5], scaledY));

                    if (G < 0)
                    {
                        G = 0;
                    }
                    else if (G > 255)
                    {
                        G = 255;
                    }


                    byte B = (byte)(parabola(flooredY, iter[6], flooredY + 1, iter[7], flooredY + 2, iter[8], scaledY));

                    if (B < 0)
                    {
                        B = 0;
                    }
                    else if (B > 255)
                    {
                        B = 255;
                    }

                    c = Color.FromArgb(R, G, B);
                    new_image.SetPixel(x, y, c);
                }
            }
            newImage.Image = new_image;
        }

        private int getD(int cr, int cl, int cu, int cd, int cld, int clu, int cru, int crd, int[,] matrix)
        {
            return Math.Abs(matrix[0, 0] * clu + matrix[0, 1] * cu + matrix[0, 2] * cru
               + matrix[1, 0] * cl + matrix[1, 2] * cr
                  + matrix[2, 0] * cld + matrix[2, 1] * cd + matrix[2, 2] * crd);
        }

        private int getMD(int cr, int cl, int cu, int cd, int cld, int clu, int cru, int crd)
        {
            int max = int.MinValue;
            for (int i = 0; i < templates.Count; i++)
            {
                int newVal = getD(cr, cl, cu, cd, cld, clu, cru, crd, templates[i]);
                if (newVal > max)
                    max = newVal;
            }
            return max;
        }

        private void Kirsh_Click(object sender, EventArgs e)
        {
            flag = "Kirsh";
            PixelBar.Hide();
            PixelBar_value.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Hide();
            numericUpDown1.Hide();
            numericUpDown2.Hide();

            Bitmap new_image = new Bitmap(BasicImage.Image.Width, BasicImage.Image.Height);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            for (int x = 1; x < BasicImage.Image.Width - 1; x++)
            {
                for (int y = 1; y < BasicImage.Image.Height - 1; y++)
                {
                    Color cr = old_image.GetPixel(x + 1, y);
                    Color cl = old_image.GetPixel(x - 1, y);
                    Color cu = old_image.GetPixel(x, y - 1);
                    Color cd = old_image.GetPixel(x, y + 1);
                    Color cld = old_image.GetPixel(x - 1, y + 1);
                    Color clu = old_image.GetPixel(x - 1, y - 1);
                    Color crd = old_image.GetPixel(x + 1, y + 1);
                    Color cru = old_image.GetPixel(x + 1, y - 1);
                    int p = getMD(cr.R, cl.R, cu.R, cd.R, cld.R, clu.R, cru.R, crd.R);
                    if (p > 255) { p = 255; }
                    new_image.SetPixel(x, y, Color.FromArgb(p, p, p));
                }
            }
            newImage.Image = new_image;
        }

        private void Binar_Click(object sender, EventArgs e)
        {
            flag = "Binar";
            PixelBar.Hide();
            PixelBar_value.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Hide();
            numericUpDown1.Show();
            numericUpDown2.Show();

            int mat = (int)numericUpDown1.Value;
            int min = 255;
            int max = 0;
            int len = (mat - 1) / 2;
            int threshold = (int)numericUpDown2.Value;
            Bitmap new_image = new Bitmap(BasicImage.Image.Width, BasicImage.Image.Height);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            for (int x = 0; x < old_image.Width; x++)
            {
                for (int y = 0; y < old_image.Height; y++)
                {
                    for (int k = -len; k <= len; k++)
                    {
                        for (int m = -len; m <= len; m++)
                        {
                            if ((x + k) >= 0 && (y + m) >= 0 && (y + m) < old_image.Height && (x + k) < old_image.Width)
                            {
                                if (image_mass[x + k, y + m] > max)
                                {
                                    max = image_mass[x + k, y + m];
                                }
                                else if (image_mass[x + k, y + m] < min)
                                {
                                    min = image_mass[x + k, y + m];
                                }
                            }
                        }
                    }
                    if (min > 255) { min = 255; }
                    else if (min < 0) { min = 0; }
                    if (max > 255) { max = 255; }
                    else if (max < 0) {max = 0; }
                    new_image.SetPixel(x, y, image_mass[x, y] >= (max + min) / 2 - threshold ? Color.White : Color.Black);
                    min = 255;
                    max = 0;
                }
            }
            newImage.Image = new_image;
        }

        private void findLine_Click(object sender, EventArgs e)
        {
            flag = "Line";
            PixelBar.Hide();
            PixelBar_value.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Hide();
            ScailingConst.Hide();
            numericUpDown1.Hide();
            numericUpDown2.Hide();

            label1.Text = "start";

            Bitmap new_image = (Bitmap)BasicImage.Image;
            Bitmap old_image = (Bitmap)BasicImage.Image;
            int halfHoughWidth = (int)Math.Sqrt(old_image.Width/2 * old_image.Width / 2 + old_image.Height / 2 * old_image.Height / 2);
            int houghWidth = halfHoughWidth * 2;
            int[,] houghMap = new int[181, houghWidth]; 
            for (int i = 0; i < 181; i++)
            {
                for (int j = 0; j < houghWidth; j++)
                {
                    houghMap[i, j] = 0;
                }
            }

            for (int x = 0; x < old_image.Width; x++)
            {
                for (int y = 0; y < old_image.Height; y++)
                {
                    Color c = old_image.GetPixel(x, y);
                    if (c.R == 255 && c.B == 255 && c.G == 255)
                    {
                        for (int theta = 0; theta <= 180; theta++)
                        {
                            int radius = (int)Math.Round(Math.Cos(theta) * x + y * Math.Sin(theta));
                            if ((radius < 0) || (radius >= houghWidth))
                                continue;
                            houghMap[theta, radius]++;
                        }
                    }
                }
            }
            int max_el = houghMap[0, 0];
            int max_rad = 0;
            int max_theta = 0;
            for (int i = 0; i < 181; i++)
            {
                for (int j = 0; j < houghWidth; j++)
                {
                    if (max_el < houghMap[i, j]) {
                        max_el = houghMap[i, j];
                        max_theta = i;
                        max_rad = j;
                    }
                }
            }
            int first_x = 0;
            int first_y = (int)(((-Math.Cos(max_theta) / Math.Sin(max_theta)) * first_x) + (max_rad / Math.Sin(max_theta)));
            int sec_x = old_image.Width;
            int sec_y = (int)(((-Math.Cos(max_theta) / Math.Sin(max_theta)) * sec_x) + (max_rad / Math.Sin(max_theta)));
            int second_y = 0;
            int second_x = (int)(((-Math.Sin(max_theta) / Math.Cos(max_theta)) * second_y) + (max_rad / Math.Cos(max_theta)));
            Graphics line = Graphics.FromImage(new_image);
            Pen col = new Pen(Color.Red, 5);label1.Text = $"{first_x}";
            label2.Text = $"{first_y}";
            label3.Text = $"{sec_x}";
            label4.Text = $"{sec_y}";
            line.DrawLine(col, first_x, first_y, sec_x, sec_y);
            newImage.Image = new_image;
            char fy = (char)(first_y);
            char fx = (char)(first_x);
            char sx = (char)(second_x);
            char sy = (char)(second_y);
            
        }

        private void Money_Click(object sender, EventArgs e)
        {
            Bitmap new_image = (Bitmap)BasicImage.Image;
            Bitmap old_image = (Bitmap)BasicImage.Image;
            int[,,] houghMap = new int[81,new_image.Width+1,new_image.Height+1];

            for (int r = 55; r<80; r++)
            {
                for (int a = 0; a < new_image.Width; a++)
                {
                    for (int b = 0; b < new_image.Height; b++)
                    {
                        houghMap[r, a, b] = 0;
                    }
                }
            }


            for (int x = 0; x < new_image.Width; x++)
            {
                for (int y=0; y < new_image.Height; y++)
                {
                    for (int radius = 55; radius < 80; radius++)
                    {
                        for (int theta = 0; theta < 360; theta++)
                        {
                            Color pix_col = old_image.GetPixel(x, y);
                            if (pix_col.R == 255 && pix_col.G == 255 && pix_col.B == 255)
                            {
                                int a = (int)Math.Round(x - radius* Math.Cos(theta * Math.PI / 180)); 
                                int b = (int)Math.Round(y - radius* Math.Sin(theta * Math.PI/ 180));
                                if (a > radius && b > radius && a < new_image.Width - radius && b < new_image.Height - radius)
                                {
                                    label1.Text = $"{a}";
                                    label2.Text = $"{b}";
                                    label3.Text = $"{radius}";
                                    houghMap[radius, a, b]++;
                                }
                            }
                        }
                    }
                }
            }

            int max_el = houghMap[55, 0, 0];
            int max_a = 0;
            int max_b = 0;
            int max_r = 55;
            for (int r = 55; r < 80; r++)
            {
                for (int a = 0; a < new_image.Width; a++)
                {
                    for (int b = 0; b < new_image.Height; b++)
                    {
                        if (max_el < houghMap[r,a,b])
                        {
                            max_el = houghMap[r, a, b];
                            max_a = a;
                            max_b = b;
                            max_r = r;
                        }
                    }
                }
            }

            label1.Text = $"{max_a}";
            label2.Text = $"{max_b}";
            label3.Text = $"{max_r}";

            int coord_x = max_a - max_r;
            int coord_y = max_b - max_r;
            Graphics circle = Graphics.FromImage(new_image);
            Pen col = new Pen(Color.Red, 5);
            circle.DrawEllipse(col, coord_x, coord_y, max_r * 2, max_r * 2);
        }

        private void BasicImage_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (flag == "Rotation" || flag == "Scaling")
            {
                if (e.Button == MouseButtons.Left)
                {
                    start = e.Location;
                    Invalidate();
                }
            }
        }

        private void Rotation_Click(object sender, EventArgs e)
        {
            //параметры элементов
            flag = "Rotation";
            PixelBar.Show();
            PixelBar_value.Show();
            PixelBar.Minimum = -360;
            PixelBar.Maximum = 360;
            PixelBar_value.Text = String.Format("Текущее значение: {0}", (double)PixelBar.Value);
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            axis.Show();
            ScailingConst.Hide();
            numericUpDown1.Hide();
            numericUpDown2.Hide();

            if (Rect.Width == 0 || Rect.Height == 0)
            {
                return;
            } 

            if (axis.SelectedItem.ToString() == "Центр")
            {
                center.X = start.X + (int)(Rect.Width / 2);
                center.Y = start.Y + (int)(Rect.Height / 2);
            }

            Bitmap new_image = new Bitmap(BasicImage.Image);
            Bitmap old_image = (Bitmap)BasicImage.Image;

            double angle = (double)PixelBar.Value * 0.01745;

            for (int y = 0; y <= old_image.Height; ++y)
            {
                for (int x = 0; x <= old_image.Width; ++x)
                {
                    int newX = (int)Math.Round(center.X + 
                        (x - center.X) * Math.Cos(angle) - 
                        (y - center.Y) * Math.Sin(angle));
                    int newY = (int)Math.Round(center.Y + 
                        (x - center.X) * Math.Sin(angle) + 
                        (y - center.Y) * Math.Cos(angle));

                    if ((start.X <= newX) && (end.X >= newX) && (newY >= start.Y) && (newY <= end.Y))
                    {
                        new_image.SetPixel(Math.Min(old_image.Width - 1, Math.Max(0, x)), Math.Min(old_image.Height - 1, Math.Max(0, y)), 
                            old_image.GetPixel(Math.Min(old_image.Width - 1, Math.Max(0, newX)), Math.Min(old_image.Height - 1, Math.Max(0, newY))));
                    }
                }
            }
            newImage.Image = new_image;
        }


    }
}