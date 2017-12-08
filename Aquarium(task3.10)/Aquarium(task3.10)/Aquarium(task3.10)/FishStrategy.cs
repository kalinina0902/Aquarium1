using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_task3._10_
{
    class FishStrategy : IStrategy
    {
        public void Move(Dweller f, List<Eat> food)
        {
           
            int dx = f.X - f.TX;
            int dy = f.Y - f.TY;
            int stepX = 3;
            int stepY = 4;
             if (dx < 0)
                {
                    f.X += stepX;
                 f.turn = true;
                
                }
                else if (dx == 0)
                {
                    f.X += 0;
                
                }
                else
                {
                    f.X -= stepX;
                }
            
            if (dy < 0)
                {
                    f.Y += stepY;
                }
                else if (dy == 0)
                {
                    f.Y += 0;
                }
                else
                {
                    f.Y -= stepY;
                }
            f.Pictureliife.X = f.X;
            f.Pictureliife.Y = f.Y;
            

        }

        public void Death(Dweller f)
        {
            if (f.Y > 25)
                f.Y -= 7;
            else f.die = true;
               
        }
        public void Reproduction()
        {
            Fry a = new Fry(1, "a");
        }
        public void Eating(Dweller f, List<Eat> Feed)
        {
            if (Feed.Count != 0)
            {
                double min = 5000;
                int indexI = -1;
                int indj = -1;
                double distance;
                for (int j = 0; j < Feed.Count; j++)
                {
                    for (int k = 0; k < Feed[j].Korm.Count; k++)
                    {
                        distance = Math.Sqrt((f.X - Feed[j].Korm.ElementAt(k).x) * (f.X - Feed[j].Korm.ElementAt(k).x) + (f.Y - Feed[j].Korm.ElementAt(k).y) * (f.Y - Feed[j].Korm.ElementAt(k).y));
                        if (distance < min)
                        {
                            min = distance;
                            indexI = k;
                            indj = j;
                        }
                    }
                }
                if (min <= 35)
                {
                    Feed[indj].Korm.RemoveAt(indexI);
                    f.Satiety += 40;
                    return;
                }
                if (indexI > -1 && indj >-1)
                {
                    f.TX = Feed[indj].Korm.ElementAt(indexI).x;
                    f.TY = Feed[indj].Korm.ElementAt(indexI).y;
                }
            }
        }
       
    } }
