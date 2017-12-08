using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Aquarium_task3._10_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        Aquarium h2o;
        Bitmap bmp;
        Draw draw;
        Graphics g;
        int x, y;
        bool fishFlag, foodFlag;
        int t;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.Location.ToString();
        }

        private void Startwork_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Width, Height);
            g = Graphics.FromImage(bmp);
            g.DrawImage(Image.FromFile("back.png"), 0, 0);
            BackgroundImage = bmp;
            h2o = new Aquarium();
            h2o.Light = true;
            draw = new Draw();
            t = temperature.Value;
            foodFlag = true;
   
            timer1.Enabled = true;


        }

        private void temperature_Scroll(object sender, EventArgs e)
        {
            t = (int)temperature.Value;
            lab.Text = "Температура : " + t.ToString() + " °C";
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
    

        private void timer1_Tick(object sender, EventArgs e)
        {
            h2o.IsHungry();
            h2o.Move();
            if (h2o.Feed.Count != 0)
            {
                h2o.FallFood();
                h2o.RemoveFood();
            }
            BackgroundImage = draw.DrawAll(h2o);
     

        }

        private void добавитьРыбуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //g.DrawImage(Image.FromFile("back.png"), 0, 0);
            fishFlag = true;
            temp.Enabled = true;
           

        }

        private void temp_Tick(object sender, EventArgs e)
        {
            if (h2o.Temper >= 21 && h2o.Light)
            {
                temp.Interval = 1000;
                timer1.Interval = 3;
            }
            else if(h2o.Temper < 21 && h2o.Light)
            {
                temp.Interval = 200;
                timer1.Interval = 15;
            }
            else if (!h2o.Light&&h2o.Temper>=21)
            {
                temp.Interval = 450;
                timer1.Interval = 30;
            }
            else
            {
                temp.Interval = 100;
                timer1.Interval = 50;
            }
            h2o.MinesSatiety();
            
        }

        private void on_CheckedChanged(object sender, EventArgs e)
        {
            h2o.Light = true;
        }

        private void off_CheckedChanged(object sender, EventArgs e)
        {
            h2o.Light = false;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            x = MousePosition.X;
            y = MousePosition.Y;
            if (y <= 650)
            {
                if (!fishFlag && foodFlag)
                {
                    h2o.CreateFood(x, y);
                    h2o.IsHungry();
                }
                if (fishFlag)
                {
                    g.DrawImage(Image.FromFile("back.png"), 0, 0);
                    CreatorDweller creator;
                    creator = new CreatorFish();
                    IStrategy fs = new FishStrategy();
                    Dweller f = creator.Create(rnd, fs, g,x,y);
                    h2o.AllFish.Add(f);
                    BackgroundImage = bmp;
                    fishFlag = false;
                }
            }
            
        }

        private void добавитьУлиткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatorDweller creator;
           // creator = new CreatorSnail();
            IStrategy fs = new SnailStrategy();
           // Dweller f = creator.Create(rnd, fs, g);
            //g.DrawImage(Image.FromFile("snailleft.png"),)
            g.DrawImage(Image.FromFile("back.png"), 0, 0);
            BackgroundImage = bmp;
          //  h2o.AllSnail.Add(f);
          
        }
    }
}
