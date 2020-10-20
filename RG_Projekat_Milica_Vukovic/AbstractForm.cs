using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Threading;
using System.Drawing.Imaging;

namespace RG_Projekat_Milica_Vukovic
{
    public partial class AbstractForm : Form
    {
        bool scrSh = false;
        Thread thread1;
        Graphics g;
        protected Boolean clicked, left, right, top, bottom, won, mouseUp;
        protected int startX, currentX, endX;
        protected int startY, currentY, endY;
        protected int curPosX, curPosY, endPosX, endPosY;
        protected static int scrNum = 0;

        public AbstractForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.flowicon_3m2_icon;

            btnBack.BackgroundImage = Properties.Resources.icons8_reply_arrow_64.GetThumbnailImage(btnBack.Width, btnBack.Height, null, new IntPtr());
            btnNext.BackgroundImage = Properties.Resources.icons8_forward_arrow_64.GetThumbnailImage(btnNext.Width, btnNext.Height, null, new IntPtr());
            btnScreenShot.BackgroundImage = Properties.Resources.icons8_screenshot_100.GetThumbnailImage(btnScreenShot.Width, btnScreenShot.Height, null, new IntPtr());
            btnReload.BackgroundImage = Properties.Resources.icons8_refresh_40.GetThumbnailImage(btnReload.Width, btnReload.Height, null, new IntPtr());


            panel1.BackColor = Color.Black;
            BackColor = Color.Black;
        }

        private void AbstractForm_Load(object sender, EventArgs e)
        {

        }

        protected virtual void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1.GetInstance().Show();
            this.Hide();
        }

        protected virtual void btnNext_Click(object sender, EventArgs e)
        {

        }

        protected void panel1_Paint(object sender, PaintEventArgs e)
        {

            g = e.Graphics;
            Image bitmap = new Bitmap(panel1.Width, panel1.Height);

            drawRectangles(g);
           

            // Refresh();

        }
        protected virtual void drawRectangles(Graphics g)
        { }
        protected GraphicsPath RoundedRect(RectangleF bounds)
        {
            float radius = 10f;
            float diameter = radius * 2f;
            SizeF size = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

          
            path.AddArc(arc, 180, 90);

           
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

           
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

           
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void AbstractForm_Move(object sender, EventArgs e)
        {

        }

        private void AbstractForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        protected virtual void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            startX = e.X;
            startY = e.Y;

            clicked = true;
        }
        protected Brush numberToColor(int num)
        {
            Brush color;

            switch (num)
            {
                case 1:
                    return color = Brushes.Blue;
                case 2:
                    return color = Brushes.Orange;
                case 3:
                    return color = Brushes.Red;
                case 4:
                    return color = Brushes.Green;
                case 5:
                    return color = Brushes.Yellow;
                case 6:
                    return color = Brushes.LightBlue;
                case 7:
                    return color = Brushes.Pink;
                case 8:
                    return color = Brushes.Purple;
                case 9:
                    return color = Brushes.DarkRed;
                default: return Brushes.Black;
            }

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            currentX = e.X;
            currentY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            //currentX = 0;
            //currentY = 0;
            clicked = false;

            endX = e.X;
            endY = e.Y;
            mouseUp = true;


        }
        protected void checkwin(int[,] board, bool[] drawnPipes, bool[] pipeFound)
        {
            won = true;
            int win = 0;
            for (int i = 0; i < drawnPipes.Length; i++)
            {
                if (drawnPipes[i] == true && pipeFound[i] == true)
                { win++; }
            }
            int tabTrue = 0;
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != 0)
                        tabTrue++;
                }
            if (tabTrue == board.Length && win == drawnPipes.Length - 1)
                won = true;
            else
                won = false;
        }
        protected void drawPipes(int i, int j, Graphics g, int[,] board, RectangleF[,] rectangles)
        {
            Boolean left = false, right = false, above = false, below = false;
            if (i > 0 && Math.Abs(board[i, j]) == Math.Abs(board[i - 1, j])) above = true;
            if (j > 0 && Math.Abs(board[i, j]) == Math.Abs(board[i, j - 1])) left = true;
            if (i < board.GetLength(0) - 1 && Math.Abs(board[i, j]) == Math.Abs(board[i + 1, j])) below = true;
            if (j < board.GetLength(1) - 1 && Math.Abs(board[i, j]) == Math.Abs(board[i, j + 1])) right = true;
           
            Brush pipe = numberToColor(Math.Abs(board[i, j]));
           
            if (above || left || below || right)
                g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
            if (above && below) 
            {
                g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
                g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y, rectangles[i, j].Width / 2, rectangles[i, j].Height);
            }
            if (left && right) 
            {
                g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
                g.FillRectangle(pipe, rectangles[i, j].X, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width, rectangles[i, j].Height / 2);
            }
            if (above && left)
            {
               // g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
               
                g.FillRectangle(pipe, rectangles[i, j].X, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
               
                g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
            }
            if (above && right)
            {
               // g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
               
                g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 2, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
               
                g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
            }
            if (below && left)
            {
               // g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
               
                g.FillRectangle(pipe, rectangles[i, j].X, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
               
                g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y + rectangles[i, j].Height / 2, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
            }
            if (below && right)
            {
                //g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
               
                g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 2, rectangles[i, j].Y + rectangles[i, j].Height / 4, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
               
                g.FillRectangle(pipe, rectangles[i, j].X + rectangles[i, j].Width / 4, rectangles[i, j].Y + rectangles[i, j].Height / 2, rectangles[i, j].Width / 2, rectangles[i, j].Height / 2);
            }



        }
        protected void currentPositionFind(RectangleF[,] rectangles, int[,] board, bool[] drawnPipes, int startPosx, int startPosY)
        {
            if (currentX != startX && currentY != startY)
                for (int i = 0; i < board.GetLength(0); i++)
                    for (int j = 0; j < board.GetLength(1); j++)
                    {

                        if (rectangles[i, j].Contains((float)(currentX), (float)(currentY)) && board[i, j] == 0 && clicked == true && !drawnPipes[board[i, j]])
                        {

                            curPosX = i;
                            curPosY = j;
                            board[i, j] = -board[startPosx, startPosY];


                        }

                    }
        }

        protected virtual void btnScreenShot_Click(object sender, EventArgs e)
        {
            
            var frm = Form.ActiveForm;
            using (var bmp = new Bitmap(frm.Width, frm.Height))
            {
                frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save("..//..//Pictures//Scrinshot" + Properties.Settings.Default.screenshotNumber + ".jpeg", ImageFormat.Jpeg);
                Properties.Settings.Default.Save();
            }
           

        }
    }
}
    
