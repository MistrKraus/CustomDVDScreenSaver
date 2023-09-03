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
        private int distance;
        private int angle;

        private PictureBox pic;
        private Image currentImage;

        private System.Timers.Timer timer;

        private Label log;
        private bool locked = false;
        private bool stopFlag = false;

        private Random random = new Random();

        /// <summary>
        /// Constructor - assign all properties
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        /// <param name="lbl"></param>
        public ScreenSaverModel(PictureBox pictureBox, int screenWidth, int screenHeight, Label lbl)
        {
            this.currentImage = ImagesModel.Images[0];

            this.pic = pictureBox;
            this.pic.Image = this.currentImage;

            this.width = screenWidth;
            this.height = screenHeight;

            this.log = lbl;

            this.timer = new System.Timers.Timer();
            this.timer.Interval = 10;
            this.timer.Elapsed += OnTimedEvent;

            this.distance = 5;
            this.angle = 50;
        }

        public void StartAnimation()
        {
            // Count starting move attributes
            double radAngle = (angle * Math.PI) / 180;

            this.moveX = (int)(this.distance * Math.Cos(radAngle));
            this.moveY = (int)(this.distance * Math.Sin(radAngle)) * -1;

            this.stopFlag = false;
            this.timer.Start();
        }

        public void StopAnimation()
        {
            this.stopFlag = true;
            this.timer.Stop();
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

        /// <summary>
        /// Update move directions in there was a colistion detected
        /// </summary>
        /// <param name="colision">Direction of colision</param>
        private void UpdateDirections(CollisionAngle colision)
        {
            switch (colision)
            {
                case CollisionAngle.NONE:
                    return;
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
            }

            double radAngle = (angle * Math.PI) / 180;

            this.moveX = (int)(this.distance * Math.Cos(radAngle));
            this.moveY = (int)(this.distance * Math.Sin(radAngle)) * -1;
        }

        private void ChangeImage()
        {
            if (ImagesModel.Images.Count == 1)
            {
                return;
            }

            this.currentImage = ImagesModel.Images[this.random.Next(ImagesModel.Images.Count)];

            this.pic.Invoke(
                new Action(() =>
                {
                    this.pic.Image = this.currentImage;
                }));
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
                        ChangeImage();
                    }

                    UpdateDirections(colision);

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
