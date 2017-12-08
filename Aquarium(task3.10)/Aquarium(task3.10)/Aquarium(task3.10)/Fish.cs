using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Aquarium_task3._10_
{
   public class Fish : Dweller
    {
       
        
        public Fish(Random rnd, IStrategy s, Graphics g,int x,int y)
        {
            Satiety = 100;
            Kind = "Взрослая";
            X = x;
            Y = y;
            TX = rnd.Next(180,1200);
            TY = rnd.Next(50, 630);
            Width = 150;
            Height = 95;
            this.s = new FishStrategy();
            Pictureliife = new Rectangle(X, Y + 100, Width, 10);
            

        }
        
        //private int satiety;
        //public int Satiety { get { return satiety; } set { satiety = value; } }
        //private string kind;
        //public string Kind { get { return kind; } set { kind = value; } }
        //private double targetX;
        //public double TargetX { get { return targetX; } set { targetX = value; } }
        //private double targetY;
        //public double TargetY { get { return targetY; } set { targetY = value; } }
        //public void Create(int satiety, string kind,Random rnd)
        //{
        //    this.Kind = kind;
        //    this.Satiety = satiety;
        //    this.TargetX = rnd.Next(4);
        //    this.TargetY = rnd.Next(5);
        //}

    }
}
