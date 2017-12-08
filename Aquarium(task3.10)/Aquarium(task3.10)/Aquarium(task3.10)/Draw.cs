using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Aquarium_task3._10_
{
    class Draw
    {
        Bitmap bmp = new Bitmap(Image.FromFile("back.png"));
        Graphics g;
        Image leftfish = Image.FromFile("fishleft.png");
        Image rightfish = Image.FromFile("fishright.png");
        Image back = Image.FromFile("black.png");
        Image back2 = Image.FromFile("back.png");
        Image leftsnail = Image.FromFile("snailleft.png");
        Image rightsnail = Image.FromFile("snailleft.png");
        Image leftdie = Image.FromFile("fishleft.png");
        Image rightdie = Image.FromFile("fishright.png");



        public Draw()
        {
           // rightfish.RotateFlip(RotateFlipType.RotateNoneFlipX);
            //rightsnail.RotateFlip(RotateFlipType.RotateNoneFlipX);

            rightdie.RotateFlip(RotateFlipType.RotateNoneFlipX);
            rightdie.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            leftdie.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            //leftsnail.RotateFlip(RotateFlipType.RotateNoneFlipX);
            // leftdiesnail.RotateFlip(RotateFlipType.RotateNoneFlipX);
            //leftdiesnail.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            // rightdiesnail.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }

        public Bitmap DrawAll(Aquarium h2o)
        {
            
            bmp.Dispose();
            if (h2o.Light)
            {
                bmp = new Bitmap(back2);
            }

            else
            {
                bmp = new Bitmap(back);
            }
            g = Graphics.FromImage(bmp);
            DrawMove(h2o.AllFish);
            if (h2o.Feed.Count != 0)
                DrawFood(h2o.Feed);
            return bmp;
        }

        private void DrawMove(List<Dweller> swimmers)
        {
            for (int i = 0; i < swimmers.Count; i++)
            {
                if (swimmers.ElementAt(i).die)
                {
                    
                    swimmers.RemoveAt(i);
                    continue;
                }
                if (swimmers.ElementAt(i).Y < 800)
                    DrawFish(swimmers.ElementAt(i));
                /*else
                    DrawSnail(swimmers.ElementAt(i));*/
                DrawSatiety(swimmers.ElementAt(i).Pictureliife, swimmers.ElementAt(i).Satiety);
            }
        }

        private void DrawFish(Dweller fish)
        {
            if (fish.turn)
            {
                if (fish.Satiety != 0)
                {
                    g.DrawImage(rightfish, fish.X, fish.Y, fish.Width, fish.Height);
                    fish.turn = false;
                }
               else
                {
                    g.DrawImage(rightdie, fish.X, fish.Y, fish.Width, fish.Height);
                }
            }
            else
            {
                if (fish.Satiety != 0)
                {
                    g.DrawImage(leftfish, fish.X, fish.Y, fish.Width, fish.Height);
                }
               else
                {
                    g.DrawImage(leftdie, fish.X, fish.Y, fish.Width, fish.Height);
                }
            }
        }
        private void DrawSnail(Dweller snail)
        {
            if (snail.turn)
            {
                if (snail.Satiety != 0)
                {
                    g.DrawImage(rightsnail, snail.X, snail.Y, 100, 50);
                    snail.turn = false;
                }
              
            }
            else
            {
                if (snail.Satiety != 0)
                {
                    g.DrawImage(leftsnail, snail.X, snail.Y, 100, 50);
                }
               
            }
        }

        /* private void DrawSnail(Dweller snail)
         {
             if (snail.turn)
             {
                 if (snail.health != 0)
                 {
                     g.DrawImage(rightsnail, snail.X, snail.Y, snail.Width, snail.Height);
                     snail.turn = false;
                 }
                 else
                 {
                     g.DrawImage(rightdiesnail, snail.X, snail.Y, snail.Width, snail.Height);
                 }
             }
             else
             {
                 if (snail.health != 0)
                 {
                     g.DrawImage(leftsnail, snail.X, snail.Y, 150, 95);
                 }
                 else
                 {
                     g.DrawImage(leftdiesnail, snail.X, snail.Y, snail.Width, snail.Height);
                 }
             }
         }
         */

        private void DrawSatiety(Rectangle rec, int satiety)
        {
            if (satiety > 0)
            {
                Font myFont = new Font("Times New Roman", 13, FontStyle.Bold);
                int R = (int)(0 + 4.18 * (100 - satiety));
                int G = 209;
                if (R > 207)
                {
                    G = (int)(209 - 4.18 * (50 - satiety));
                    R = 209;
                }
                int B = 0;
                SolidBrush brush = new SolidBrush(Color.FromArgb(R, G, B));
                g.FillRectangle(brush, rec.X, rec.Y, rec.Width * satiety / 100, rec.Height);
                g.DrawRectangle(Pens.Black, rec);
                g.DrawString(satiety.ToString(), myFont, Brushes.Black, rec.Location.X + rec.Size.Width / 2 - 10, rec.Location.Y - rec.Size.Height / 2);
            }
        }

        public void DrawFood(List<Eat> eda)
        {
            //foreach (Objects.Food food in eda)
            for (int i = 0; i < eda.Count(); i++)
            {
                for (int j = 0; j < eda[i].Korm.Count(); j++)
                {
                    Pen p = new Pen(Color.Black);
                    SolidBrush b = new SolidBrush(Color.Brown);
                    g.DrawEllipse(p, eda[i].Korm[j].x, eda[i].Korm[j].y, 7, 7);
                    g.FillEllipse(b, eda[i].Korm[j].x, eda[i].Korm[j].y, 7, 7);
                }
            }
        }
    
}
}
