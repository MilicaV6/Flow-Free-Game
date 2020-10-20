using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RG_Projekat_Milica_Vukovic
{
    public partial class Form1 : Form
    {
       static Form1 instance;
        Image backImage;
        public static Form1 GetInstance()
        {
            if (instance == null)
                instance = new Form1();
            return instance;
        }
        private Form1()
        {
            InitializeComponent();
            Icon = Properties.Resources.flowicon_3m2_icon;
        Image   image = Image.FromFile(@"..\..\Pictures\flowicon_3m2_icon.ico");
            backImage=image.GetThumbnailImage(panel1.Width, panel1.Height, null, new IntPtr());
            panel1.BackgroundImage = backImage;
            MaximumSize = Size;
            MinimumSize = Size;
        }

        private void btn9_Click(object sender, EventArgs e)
        {

        }

        private void btn7_Enter(object sender, EventArgs e)
        {
            
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Image image = Properties.Resources.look1;


            panel1.BackgroundImage = image.GetThumbnailImage(panel1.Width, panel1.Height, null, new IntPtr());
            Cursor = Cursors.Hand;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackgroundImage = backImage;
            Cursor = Cursors.Arrow;
        }

        private void lbl8_MouseEnter(object sender, EventArgs e)
        {
            Image image = Properties.Resources.look2;


            panel1.BackgroundImage = image.GetThumbnailImage(panel1.Width, panel1.Height, null, new IntPtr());
            Cursor = Cursors.Hand;
        }

        private void lbl8_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackgroundImage = backImage;
            Cursor = Cursors.Arrow;
        }

        private void lbl9_MouseEnter(object sender, EventArgs e)
        {
            Image image = Properties.Resources.look3;
            


            panel1.BackgroundImage = image.GetThumbnailImage(panel1.Width, panel1.Height, null, new IntPtr());
            Cursor = Cursors.Hand;
        }

        private void lbl9_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackgroundImage = backImage;
            Cursor = Cursors.Arrow;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FirstLevelForm firstLevelForm = new FirstLevelForm();
            firstLevelForm.Show();
            this.Hide();
        }

        private void lbl8_Click(object sender, EventArgs e)
        {
            SecondLevelForm secondLevelForm = new SecondLevelForm();
            secondLevelForm.Show();
            this.Hide();
        }

        private void lbl9_Click(object sender, EventArgs e)
        {
            ThirdLevelForm thirdLevelForm = new ThirdLevelForm();
            thirdLevelForm.Show();
            this.Hide();
        }
    }
}
