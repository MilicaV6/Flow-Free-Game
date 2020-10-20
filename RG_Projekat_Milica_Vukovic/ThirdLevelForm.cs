using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Imaging;

namespace RG_Projekat_Milica_Vukovic
{
    public partial class ThirdLevelForm : AbstractForm
    {
        int startPosx = 0, startPosY = 0;
        int win = 0;

        RectangleF[,] rectangles = new RectangleF[9, 9];

        bool[] drawnPipes = new bool[10];
        bool[] pipeFound = new bool[10];
        
        int[,] board ={
  {0, 0, 0, 0, 0, 0, 0,0,0}, 
  {0, 3, 6, 1, 0, 0, 0,0,0}, 
  {0, 0, 0, 6, 2, 0, 2,1,0}, 
  {0, 0, 0, 0, 0, 0, 0,7,0}, 
  {0, 4, 0, 4, 3, 0, 0,0,0}, 
  {5, 7, 0, 0, 0, 0, 0,9,8}, 
  {0, 8, 5, 0, 0, 0, 0,0,0}, 
  {0, 9, 0, 0, 0, 0, 0,0,0}, 
 {0, 0, 0, 0, 0, 0, 0,0,0}, 
};

        public ThirdLevelForm()
            : base()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
null, panel1, new object[] { true });

            btnNext.Enabled = false;

        }
        protected override void drawRectangles(Graphics g)
        {

            float width = panel1.Width / 9.0f;
            float height = panel1.Height / 9.0f;


            if (!won)
            {
                for (float i = 0, k = 0; i < width * 9.0f && k < 9; i += width, k += 1)
                    for (float j = 0, l = 0; j < height * 9.0f && l < 9; j += height, l += 1)
                    {

                        rectangles[(int)l, (int)k] = new RectangleF(i, j, width, height);
                        g.DrawPath(new Pen(Brushes.PaleVioletRed, 2.0f), RoundedRect(new RectangleF(i, j, width, height)));


                    }


                for (int i = 0; i < board.GetLength(0); i++)
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] > 0)
                            g.FillEllipse((numberToColor(board[i, j])), rectangles[i, j]);
                        if (board[i, j] < 0)
                        {
                            drawPipes(i, j, g, board, rectangles);
                        }
                        //  g.FillRectangle(numberToColor((Math.Abs(board[i,j]))),new RectangleF( rectangles[i,j].X +rectangles[i,j].Width/5,rectangles[i,j].Y +rectangles[i,j].Height/5,rectangles[i,j].Width/1.5f,rectangles[i,j].Height/1.5f));
                    }


                Brush pipeB = Brushes.Black;
                if (clicked)
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                        {
                            if (rectangles[i, j].Contains((float)(startX), (float)(startY)) && board[i, j] > 0)
                            {

                                pipeB = numberToColor(board[i, j]);
                                startPosx = i;
                                startPosY = j;
                                // selected = true;
                                if (drawnPipes[board[startPosx, startPosY]] && clicked)
                                {
                                    for (int m = 0; m < 9; m++)
                                        for (int n = 0; n < 9; n++)
                                        {
                                            if (board[m, n] == -board[startPosx, startPosY])

                                                board[m, n] = 0;


                                        }
                                    drawnPipes[board[startPosx, startPosY]] = false;
                                    pipeFound[board[startPosx, startPosY]] = false;

                                }
                            }


                        }


                currentPositionFind(rectangles, board, drawnPipes, startPosx, startPosY);




                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (rectangles[i, j].Contains(endX, endY))
                        {
                            endPosX = i;

                            endPosY = j;
                            break;
                        }
                    }
                if (mouseUp)
                {
                    drawnPipes[board[startPosx, startPosY]] = true;
                    if (board[endPosX, endPosY] == board[startPosx, startPosY])
                    {
                        pipeFound[board[startPosx, startPosY]] = true;
                    }
                    mouseUp = false;
                    checkwin(board, drawnPipes, pipeFound);

                }



            }
            else if (won)
            {
                Font font = new Font("Monotype Corsiva", 38, FontStyle.Bold);

                g.DrawString("You Won!", font, Brushes.White, panel1.Width / 2.0f - g.MeasureString("You Won!", font).Width / 2, panel1.Height / 2.0f - g.MeasureString("You Won!", font).Height / 2);
            }
            Refresh();
        }
        protected override void btnReload_Click(object sender, EventArgs e)
        {
            (new ThirdLevelForm()).Show();
            this.Hide();
        }
       
    }
}
