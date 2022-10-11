using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace SnakeProject
{
    public class Food : GameObject
    {
        private Ellipse ellipse = new Ellipse();
        public Food(int x, int y) : base(x, y)
        {
            ellipse.Width = 10;
            ellipse.Height = 10;
            ellipse.Fill = Brushes.Red;
        }

        public override void ChangePosition(int x, int y)
        {
            base.ChangePosition(x, y);
            ellipse.Margin = new System.Windows.Thickness(x, y, 0, 0);
        }
        public Ellipse Ellipse => ellipse;
    }
}
