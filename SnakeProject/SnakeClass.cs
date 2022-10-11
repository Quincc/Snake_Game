using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeProject
{
    public class SnakeClass
    {
        private List<SnakePart> snakeList = new List<SnakePart>();
        public Direction Direction { get; set; }
        private BordersofWindow window;
        public SnakeClass(int x, int y, int width, int height)
        {
            window = new BordersofWindow(width, height);
            snakeList.Add(new SnakePart(x, y));
        }
        public SnakePart HeadSnake => snakeList[0];
        public void ClearSnake()
        {
            snakeList.RemoveRange(1, snakeList.Count - 1);
        }
        public void Move()
        {
            if (snakeList.Count > 1)
            {
                for (int i = snakeList.Count - 1; i > 0; i--)
                    snakeList[i].ChangePosition(snakeList[i - 1].X, snakeList[i - 1].Y);
            }
            int x = HeadSnake.X;
            int y = HeadSnake.Y;
            switch (Direction)
            {
                case Direction.Left:
                    x -= 10;
                    break;
                case Direction.Right:
                    x += 10;
                    break;
                case Direction.Up:
                    y -= 10;
                    break;
                case Direction.Down:
                    y += 10;
                    break;
                default:
                    break;
            }
            snakeList[0].ChangePosition(x, y);
        }
        public SnakePart EatFood()
        {   
                int lastX = snakeList.Last().X;
                int lastY = snakeList.Last().Y;
                switch (Direction)
                {
                    case Direction.Left:
                        lastX++;
                        break;
                    case Direction.Right:
                        lastX--;
                        break;
                    case Direction.Up:
                        lastY--;
                        break;
                    case Direction.Down:
                        lastY++;
                        break;
                    default:
                        break;
                }
                SnakePart part = new SnakePart(lastX, lastY);
                snakeList.Add(part);
            return part;
        }
        public bool CheckCrash()
        {
            if (snakeList[0].X >= window.Width || snakeList[0].X < 0 || snakeList[0].Y >= window.Height || snakeList[0].Y < 0)
                return true;
            for (int i = 2; i < snakeList.Count; i++)
            {
                if (snakeList[0].X == snakeList[i].X && snakeList[0].Y == snakeList[i].Y)
                    return true;
            }
            return false;
        }
    }
}
