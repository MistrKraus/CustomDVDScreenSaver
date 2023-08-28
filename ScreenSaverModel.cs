using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace CustomDVDScreenSaver
{
    enum CollisionAngle
    {
        TOP,
        LEFT,
        BOTTOM,
        RIGHT,
        NONE
    }

    class ScreenSaverModel
    {
        private int width;
        private int height;

        private int moveX;
        private int moveY;
        private int distance = 5;
        private int angle = 50;

        private PictureBox pic;
        private Image currentImage;
        private IList<Image> images = new List<Image>();

        private System.Timers.Timer timer;

        private Label log;
        private bool locked = false;
        private bool stopFlag = false;

        public ScreenSaverModel(PictureBox pictureBox, IList<Image> images, int screenWidth, int screenHeight, Label lbl)
        {
            this.pic = pictureBox;
            this.images = images;

            this.width = screenWidth;
            this.height = screenHeight;

            this.log = lbl;

            this.timer = new System.Timers.Timer();
            this.timer.Interval = 10;
            this.timer.Elapsed += OnTimedEvent;

            double radAngle = (angle * Math.PI) / 180;

            this.moveX = (int)(this.distance * Math.Cos(radAngle));
            this.moveY = (int)(this.distance * Math.Sin(radAngle)) * -1;
        }

        public void StartAnimation()
        {
            this.stopFlag = false;
            this.timer.Start();
            //OnTimedEvent();
        }

        public void StopAnimation()
        {
            this.stopFlag = true;
            this.timer.Stop();
            //GC.Collect();
        }

        /// <summary>
        /// Detect if and/or where the collision happen
        /// </summary>
        /// <returns></returns>
        private CollisionAngle CheckCollision()
        {
            bool left = this.pic.Location.X < 0;
            bool top = this.pic.Location.Y < 0;
            bool right = this.pic.Location.X + this.pic.Width > width;
            bool bottom = this.pic.Location.Y + this.pic.Height > height;

            /*
            if (left)
            {
                if (top)
                {
                    if (-this.pic.Location.X > -this.pic.Location.Y)
                    {
                        return ColisionAngle.LEFT;
                    }
                    else
                    {
                        return ColisionAngle.TOP;
                    }
                }
                
                if (bottom)
                {
                    if (-this.pic.Location.X > (this.pic.Location.Y + this.pic.Height - height))
                    {
                        return ColisionAngle.LEFT;
                    }
                    else
                    {
                        return ColisionAngle.BOTTOM;
                    }
                }
            }

            if (right)
            {
                if (top)
                {
                    if (this.pic.Location.X + this.pic.Width - width > -this.pic.Location.Y)
                    {
                        return ColisionAngle.RIGHT;
                    }
                    else
                    {
                        return ColisionAngle.TOP;
                    }
                }

                if (bottom)
                {
                    if (this.pic.Location.X + this.pic.Width - width > (this.pic.Location.Y + this.pic.Height - height))
                    {
                        return ColisionAngle.RIGHT;
                    }
                    else
                    {
                        return ColisionAngle.BOTTOM;
                    }
                }
            }
            */

            if (top)
            {
                return CollisionAngle.TOP;
            }

            if (left)
            {
                return CollisionAngle.LEFT;
            }

            if (bottom)
            {
                return CollisionAngle.BOTTOM;
            }

            if (right)
            {
                return CollisionAngle.RIGHT;
            }

            return CollisionAngle.NONE;
        }

        private void UpdateDirections(CollisionAngle colision)
        {
            switch (colision)
            {
                case CollisionAngle.TOP:
                    if (angle < 90)
                    {
                        angle = 360 - angle;
                    }
                    else
                    {
                        angle += 2 * (180 - angle);
                    }
                    break;
                case CollisionAngle.LEFT:
                    if  (angle < 180)
                    {
                        angle = 180 - angle;
                    }
                    else
                    {
                        angle += 180 - (2 * angle);
                    }

                    break;
                case CollisionAngle.BOTTOM:
                    if (angle < 270)
                    {
                        angle -= 2 * (angle - 180);
                    }
                    else
                    {
                        angle = 360 - angle;
                    }

                    break;
                case CollisionAngle.RIGHT:
                    if (angle < 90)
                    {
                        angle = 180 - angle;
                    }
                    else
                    {
                        angle -= 2 * (angle - 270);
                    }

                    break;
                case CollisionAngle.NONE:
                    return;
            }

            double radAngle = (angle * Math.PI) / 180;

            this.moveX = (int)(this.distance * Math.Cos(radAngle));
            this.moveY = (int)(this.distance * Math.Sin(radAngle)) * -1;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (!locked)
            {
                locked = true;
                this.timer.Stop();

                try
                {

                    CollisionAngle colision = CheckCollision();

                    if (colision != CollisionAngle.NONE)
                    {
                        UpdateDirections(colision);
                    }

                    this.pic.Invoke(
                        new Action(() =>
                        {
                            this.pic.Location = new Point(this.pic.Location.X + moveX, this.pic.Location.Y + moveY);
                        }));

                    locked = false;

                    // PrintLog(colision);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (!stopFlag)
                {
                    this.timer.Start();
                }
            }
        }

        private void PrintLog(CollisionAngle colision)
        {
            if (!this.log.Visible)
            {
                return;
            }

            StringBuilder print = new StringBuilder();
            print.AppendLine("X: " + this.pic.Location.X);
            print.AppendLine("Y: " + this.pic.Location.Y);
            print.AppendLine("Colision: " + colision);
            print.AppendLine();
            print.AppendLine("Move X: " + this.moveX);
            print.AppendLine("Move Y: " + this.moveY);
            print.AppendLine("Angle: " + this.angle);

            this.log.Invoke(
                new Action(() =>
                {
                    this.log.Text = print.ToString();
                }));
        }

        public void DebugTickCall()
        {
            CollisionAngle colision = CheckCollision();

            if (colision != CollisionAngle.NONE)
            {
                UpdateDirections(colision);
            }

            this.pic.Invoke(
                new Action(() =>
                {
                    this.pic.Location = new Point(this.pic.Location.X + moveX, this.pic.Location.Y + moveY);
                }));

            PrintLog(colision);
        }

    }
}
