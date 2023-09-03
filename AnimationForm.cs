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

            if (ImagesModel.Images.Count == 0)
            {
                return;
            }

            this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            this.model = new ScreenSaverModel(this.pictureBox, Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height, this.label1);
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
    }
}
