using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;

namespace CustomDVDScreenSaver
{
    public partial class AnimationForm : Form
    {
        private bool isRunning = false;

        private ScreenSaverModel model;

        public AnimationForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.label1.Visible = false;

            Image img = LoadImage();

            if (img == null)
            {
                return;
            }

            this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox.Image = img;

            this.model = new ScreenSaverModel(this.pictureBox, new List<Image>() { img }, Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height, this.label1);
        }

        /// <summary>
        /// Load and resize image
        /// </summary>
        /// <returns></returns>
        private Image LoadImage()
        {
            try
            {
                Image img = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), "../../resources/khaleesi.jpg"));
                double ratio = img.Width / (double)img.Height;

                int height = Screen.FromControl(this).Bounds.Height / 6;
                int width = (int)(height * ratio);
                
                return new Bitmap(img, width, height);
            }
            catch (FileNotFoundException e)
            {
                this.label1.Visible = true;
                this.label1.Text = e.Message;
            }

            return null;
        }

        /// <summary>
        /// On first key press start the animation
        /// On second key press stop and close the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                if (!isRunning)
                {
                    this.model.StartAnimation();
                    //this.modelBackgroundWorker.RunWorkerAsync();
                    isRunning = true;
                }
                else
                {
                    this.model.StopAnimation();

                    isRunning = false;
                }

                return;
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                if (isRunning)
                {
                    this.model.StopAnimation();

                    isRunning = false;

                    return;
                }

                this.Close();
            }
        }

        /*
        private bool AbortWorker()
        {
            if (!this.modelBackgroundWorker.IsBusy)
            {
                return true;
            }

            try
            {
                this.modelBackgroundWorker.Abort();
                this.modelBackgroundWorker.Dispose();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return false;
        }

        private void modelBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.model.StartAnimation();
        }
        */
    }
}
