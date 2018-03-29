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
namespace u2_SummativeEthanR
{
    class spaceship
    {
        Key up;
        Key left;
        Key right;
        double angle = 0;
        Point pos;
        double speed;
        double width = 9;
        double height = 30;
        bool alive = true;
        string link;
        //Constructor
        public spaceship(Point start, Key[] keyarray,double inputspeed,string inputLink)
        {
            link = inputLink;
            this.up = keyarray[0];
            this.left = keyarray[1];
            this.right = keyarray[2];
            pos = start;
            speed = inputspeed;
            
        }
        //Turns the ship and ouputs the angle
        public void turn()
        {
            if (Keyboard.IsKeyDown(this.right))
            {
                angle += 7.5;
            }
            if(Keyboard.IsKeyDown(this.left))
            {
                angle -= 7.5;
            }
            if (angle<0)
            {
                angle +=360;
            }
            if (angle == 360)
            {
                angle = 0;
            }
        }
        // Flys forward in relation to the angle of the ship
        public void fly()
        {
            double radangle = angle * (Math.PI / 180);
            double speedX = Math.Sin(radangle)*speed;
            double speedY = Math.Cos(radangle)*speed;
            if(Keyboard.IsKeyDown(this.up))
            {
                pos.X += speedX;
                pos.Y -= speedY;
                if(pos.X<0)
                {
                    pos.X = 495;
                }
                if (pos.X>495)
                {
                    pos.X = 0;
                }
                if (pos.Y>325)
                {
                    pos.Y = 0;
                }
                if(pos.Y<0)
                {
                    pos.Y = 325;
                }
            }
        }
        //Checks for collisions(kills both)(mwahahahahahahahahahahahaha)
        public void checkcollide(spaceship second)
        {
            Rectangle sec = second.render();
            double x = Canvas.GetLeft(sec);
            double y = Canvas.GetTop(sec);
            if (alive == true && second.alive == true)
            {
                if (((x < pos.X + width && x > pos.X) && (y < pos.Y + height && y > pos.Y))||((x+width<pos.X+width && x+width > pos.X)&&(y+height<pos.Y+height && y+height>pos.Y)))
                {
                    alive = false;
                    second.alive = false;
                }
            }
        }
        //Outputs rectangle to be drawn to screen
        public Rectangle render()
        {
            
            Rectangle ship = new Rectangle();
            ship.Width = width;
            ship.Height = height;
            BitmapImage bi = new BitmapImage(new Uri(Environment.CurrentDirectory + link));
            ship.Fill=new ImageBrush(bi);
            RotateTransform rotate = new RotateTransform(angle,ship.Width/2,ship.Height/2);
            ship.RenderTransform = rotate;
            Canvas.SetLeft(ship, pos.X);
            Canvas.SetTop(ship, pos.Y);
            if(alive == false)
            {
                ship.Visibility = Visibility.Hidden;
            }
            else
            {
                ship.Visibility = Visibility.Visible;
            }
            return (ship);
            
        }
    }
}
