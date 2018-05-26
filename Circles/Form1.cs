﻿using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;


namespace Circles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            LoadForm temp = new LoadForm();
            temp.ShowDialog();
            temp.Close();
            InitializeComponent();
            gr = CreateGraphics();
            gr.Clear(Color.White);
        }
        private Circle circle;
        private Color backgroundColor = Color.White;
        private Color color = Color.Black;
        static Graphics gr;
        private int sizeofround = 100;
        

        private  void drawButton_Click(object sender, EventArgs e)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            int x, y;
            
            for (int i = -20; i < 10; i++)
            {
                x = random.Next(-500, 500);
                y = random.Next(-500, 500);
                draw(x, y);
            }

        }

        private void draw(int x, int y)
        {
            for (int i = 0; i < sizeofround; i++)
            {
                circle = new Circle(ClientSize.Width, ClientSize.Height, i);
                circle.X = x;
                circle.Y = y;

                circle.Draw(gr, color);
                if (checkBox1.Checked)
                {
                    Thread.Sleep(10);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(backgroundColor);
        }

        private void drawOnClick(object sender, MouseEventArgs e)
        {
            for(int i = 0;i < sizeofround; i++)
            {
                circle = new Circle(ClientSize.Width, ClientSize.Height, i);
                circle.X = e.X - 450;
                circle.Y = e.Y - 250;
                circle.Draw(gr, color);         
                if (checkBox1.Checked)
                {
                    Thread.Sleep(10);
                }
            }
        }

        private void изменитьЦветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                backgroundColor = dialog.Color;
            }
        }

        private void поменятьЦветToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                color = dialog.Color;
            }
        }

        private void изменитьДиаметрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SizeForm sizeform = new SizeForm();
            sizeform.ShowDialog();
            sizeofround = sizeform.sizeOfPenAttr;
        }

        private void сохранитьВФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileUtil.PutInWordFile(new string[] { " cirlce x: " + circle.X, ", circle y: " + circle.Y, ", radius: " + sizeofround, ", " + color.ToString() });

        }

        private void сохранитьВExcelфайлToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            FileUtil.PutInExcelFile(new string[] { " cirlce x: " + circle.X, ", circle y: " + circle.Y, ", radius: " + sizeofround, ", " + color.ToString() });
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm form = new HelpForm();
            form.ShowDialog();
        }
    }
}
