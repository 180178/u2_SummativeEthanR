//Ethan Ross
//March 26,2018
//Unit 2 Summative Spaceships
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
namespace u2_SummativeEthanR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Random rand = new Random();
        static Point start = new Point(100, 100);
        static Point start2 = new Point(150, 100);
        static Point start3 = new Point(200, 100);
        static Point start4 = new Point(250, 100);
        static Key[] keys = { Key.Up, Key.Left, Key.Right };
        static Key[] keys2 = { Key.W, Key.A, Key.D };
        static Key[] keys3 = { Key.T ,Key.F, Key.H };
        static Key[] keys4 = { Key.I, Key.J, Key.L };
        spaceship spaceship = new spaceship(start, keys, 10.0, "\\spaceship1.png");
        spaceship spaceship2 = new spaceship(start2, keys2, 10.0, "\\spaceship2.png");
        spaceship spaceship3 = new spaceship(start3, keys3, 10.0, "\\spaceship3.png");
        spaceship spaceship4 = new spaceship(start4, keys4, 10.0, "//spaceship4.png");

        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            Point start = new Point(rand.Next(0, 500),rand.Next(0,500));
            Point start2 = new Point(rand.Next(0, 500), rand.Next(0, 500));
            InitializeComponent();
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\back.png"));
            canvas.Background = ib;
            timer.Interval= new TimeSpan(170000);
            timer.Tick += tick;
            timer.Start();
        }
        public void tick(object sender,EventArgs e)
        {
            for (int i = canvas.Children.Count - 1; i >= 0; i--)
            {
                canvas.Children.RemoveAt(i);
            }
            spaceship.turn();
            spaceship.fly();
            canvas.Children.Add(spaceship.render());
            spaceship.checkcollide(spaceship2);
            spaceship.checkcollide(spaceship3);
            spaceship.checkcollide(spaceship4);
            spaceship2.turn();
            spaceship2.fly();
            canvas.Children.Add(spaceship2.render());
            spaceship2.checkcollide(spaceship);
            spaceship2.checkcollide(spaceship3);
            spaceship2.checkcollide(spaceship4);
            spaceship3.turn();
            spaceship3.fly();
            canvas.Children.Add(spaceship3.render());
            spaceship3.checkcollide(spaceship);
            spaceship3.checkcollide(spaceship2);
            spaceship3.checkcollide(spaceship4);
            spaceship4.turn();
            spaceship4.fly();
            canvas.Children.Add(spaceship4.render());
            spaceship4.checkcollide(spaceship);
            spaceship4.checkcollide(spaceship2);
            spaceship4.checkcollide(spaceship3);
        }
    }
}
