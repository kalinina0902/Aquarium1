using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium_task3._10_
{
    public interface IStrategy
    {
        void Death(Dweller f);
        void Eating(Dweller f, List<Eat> e);
        void Move(Dweller f, List<Eat> e);
        void Reproduction();
        
    }
}
