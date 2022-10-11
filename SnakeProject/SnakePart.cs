using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace SnakeProject
{
    public class SnakePart : GameObject
    {
        private Rectangle rectangle = new Rectangle();
        public SnakePart(int x, int y) : base(x, y)
        {
            rectangle.Width = 10;
            rectangle.Height = 10;
            rectangle.Fill = Brushes.Black;
        }

        public override void ChangePosition(int x, int y)
        {
            base.ChangePosition(x, y);
            rectangle.Margin = new System.Windows.Thickness(x, y, 0, 0);
        }
        public Rectangle Rectangle => rectangle;
    }
}
