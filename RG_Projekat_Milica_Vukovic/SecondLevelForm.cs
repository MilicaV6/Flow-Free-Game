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
    public partial class SecondLevelForm : AbstractForm
    {
        int startPosx = 0, startPosY = 0;
        int win = 0;

        RectangleF[,] rectangles = new RectangleF[8, 8];

        bool[] drawnPipes = new bool[8];
        bool[] pipeFound = new bool[8];
        
        int[,] board ={
  {0, 0, 0, 0, 3, 0, 0,0}, 
  {0, 0, 0, 0, 6, 0, 4,5}, 
  {0, 0, 0, 0, 4, 5, 0,6}, 
  {0, 0, 0, 2, 1, 0, 0,0}, 
  {0, 0, 0, 0, 2, 0, 0,0}, 
  {0, 0, 0, 0, 1, 0, 0,0}, 
  {0, 0, 0, 0, 0, 0, 0,0}, 
  {0, 3, 0, 0, 0, 0, 0,0}, 
 
};

        public SecondLevelForm():base()
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
null, panel1, new object[] { true });
            InitializeComponent();
        }
        protected override void drawRectangles(Graphics g)
        {
            drawnPipes[7] = true;
            pipeFound[7] = true;

            float width = panel1.Width / 8.0f;
            float height = panel1.Height / 8.0f;

            if (!won)
            {
                for (float i = 0, k = 0; i < width * 8.0f && k < 8; i += width, k += 1)
                    for (float j = 0, l = 0; j < height * 8.0f && l < 8; j += height, l += 1)
                    {

                        rectangles[(int)l, (int)k] = new RectangleF(i, j, width, height);
                        g.DrawPath(new Pen(Brushes.Azure, 2.0f), RoundedRect(rectangles[(int)l, (int)k]));


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
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++)
                        {
                            if (rectangles[i, j].Contains((float)(startX), (float)(startY)) && board[i, j] > 0)
                            {

                                pipeB = numberToColor(board[i, j]);
                                startPosx = i;
                                startPosY = j;
                               // selected = true;
                                if (drawnPipes[board[startPosx, startPosY]] && clicked)
                                {
                                    for (int m = 0; m < 8; m++)
                                        for (int n = 0; n < 8; n++)
                                        {
                                            if (board[m, n] == -board[startPosx, startPosY])

                                                board[m, n] = 0;


                                        }
                                    drawnPipes[board[startPosx, startPosY]] = false;
                                    pipeFound[board[startPosx, startPosY]] = false;

                                }
                            }


                        }

             
                currentPositionFind( rectangles,  board, drawnPipes,  startPosx,  startPosY);




                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
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
        protected override void btnNext_Click(object sender, EventArgs e)
        {
            ThirdLevelForm thirdLevelForm = new ThirdLevelForm();
            thirdLevelForm.Show();
            this.Hide();
        }
        protected override void btnReload_Click(object sender, EventArgs e)
        {
            (new SecondLevelForm()).Show();
            this.Hide();
        }
        protected override void btnScreenShot_Click(object sender, EventArgs e)
        {
            base.btnScreenShot_Click(sender, e);
            }
        }
        }
    

