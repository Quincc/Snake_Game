using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    public abstract class GameObject
    {
        protected int x;
        protected int y;
        public GameObject(int x, int y)
        {
            ChangePosition(x, y);
        }
        public virtual void ChangePosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X => x;
        public int Y => y;
    }
}
