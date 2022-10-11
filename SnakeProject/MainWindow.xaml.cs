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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Food food;
        private SnakeClass snake;
        private Random random = new Random();
        private int score = 1;
        private DispatcherTimer timer = new DispatcherTimer();
        
        public MainWindow()
        {
            InitializeComponent();
            snake = new SnakeClass(GenerateCoord().Item1, GenerateCoord().Item2, (int)Canvas.Width, (int)Canvas.Height);
            NewFoodandHead();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            snake.Move();
            if (snake.CheckCrash() == true)
            {
                timer.Stop();
                var mb = MessageBox.Show("Game Over! \n Do you want to restart", "End", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (mb == MessageBoxResult.Yes)
                {
                    Canvas.Children.Clear();
                    snake.ClearSnake();
                    NewFoodandHead();
                    snake.HeadSnake.ChangePosition(GenerateCoord().Item1, GenerateCoord().Item2);
                    timer.Start();
                }

            }
            if (snake.HeadSnake.X == food.X && snake.HeadSnake.Y == food.Y)
            {
                var res = snake.EatFood();
                Canvas.Children.Add(res.Rectangle);
                int xfood, yfood;
                (xfood, yfood) = GenerateCoord();
                food.ChangePosition(xfood, yfood);
                score++;
                Score_TxtBx.Text = "Score = " + score.ToString();
                if (timer.Interval.Milliseconds > 5)
                    timer.Interval = new TimeSpan(0, 0, 0, 0, timer.Interval.Milliseconds - 5);
            }
        }
        public void NewFoodandHead()
        {
            int xfood, yfood;
            (xfood, yfood) = GenerateCoord();
            food = new Food(xfood, yfood);
            Canvas.Children.Add(food.Ellipse);
            Canvas.Children.Add(snake.HeadSnake.Rectangle);
            snake.Direction = Direction.Up;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }
        public (int,int) GenerateCoord()
        {
            int x = random.Next(1, (int)Canvas.Width / 10) * 10;
            int y = random.Next(1, (int)Canvas.Height / 10) * 10;
            return (x, y);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && snake.Direction != Direction.Down)
                snake.Direction = Direction.Up;
            else if (e.Key == Key.Down && snake.Direction != Direction.Up)
                snake.Direction = Direction.Down;
            else if (e.Key == Key.Left && snake.Direction != Direction.Right)
                snake.Direction = Direction.Left;
            else if (e.Key == Key.Right && snake.Direction != Direction.Left)
                snake.Direction = Direction.Right;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            timer.Stop();
        }
         private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
