using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лапа2Б
{
    public partial class Form2 : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Form2()
        {
            this.MouseDown += new MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(this.Form1_MouseUp);

            InitializeComponent();
            this.ClientSize = new Size(400, 400);
            this.Text = "Красный теугольник";
            SetFormToTriangle();
            this.Paint += new PaintEventHandler(MainForm_Paint);

        }
        private void SetFormToTriangle()
        {
            GraphicsPath path = new GraphicsPath();
            Point[] points = {
            new Point(ClientSize.Width / 2, 0),
            new Point(0, ClientSize.Height),
            new Point(ClientSize.Width, ClientSize.Height)
        };
            path.AddPolygon(points);
            this.Region = new Region(path);
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = Brushes.Red;
            Point[] points = {
            new Point(ClientSize.Width / 2, 0),
            new Point(0, ClientSize.Height),
            new Point(ClientSize.Width, ClientSize.Height)
            };
            g.FillPolygon(brush, points);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
