using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomDVDScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        public ScreenSaverForm()
        {
            InitializeComponent();

            ImagesModel.LoadDefaultImages();
            prepareGui();
        }

        /// <summary>
        /// Add all image paths to the image list
        /// Add all active paths to the active image list
        /// </summary>
        private void prepareGui()
        {
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF";

            this.allImageList.HideSelection = false;
            this.activeImageList.HideSelection = false;

            foreach (string path in ImagesModel.AllImagePaths)
            {
                this.allImageList.Items.Add(path);
            }

            foreach (string path in ImagesModel.ActiveImagePaths)
            {
                this.activeImageList.Items.Add(path);
            }
        }

        /// <summary>
        /// Let user select and open a new image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (string path in this.openFileDialog1.FileNames)
            {
                if (ImagesModel.AddToAllList(path))
                {
                    this.allImageList.Items.Add(path);
                }
            }
        }

        /// <summary>
        /// Add image to active image list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toActiveBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.allImageList.SelectedItems)
            {
                if (ImagesModel.AddToActiveList(item.Text))
                {
                    this.activeImageList.Items.Add(item.Text);
                }
            }
        }

        /// <summary>
        /// Remove image from active image list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeActiveBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.activeImageList.SelectedItems)
            {
                if (ImagesModel.RemoveFromActiveList(item.Text))
                {
                    this.activeImageList.Items.Remove(item);
                }
            }
        }

        /// <summary>
        /// Remove all selected images from the all images list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (this.allImageList.SelectedItems.Count == 0)
            {
                return;
            }

            List<ListViewItem> removedItems = new List<ListViewItem>();

            foreach (ListViewItem item in this.allImageList.SelectedItems)
            {
                if (ImagesModel.RemoveFromAllList(item.Text))
                {
                    removedItems.Add(item);
                }
                else
                {
                    MessageBox.Show("Image can not be removed becase it is in the \"Active images\" list" + Environment.NewLine +
                        "\"" + item.Text + "\"" + Environment.NewLine +
                        "Removing will be stopped", "Not removed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return;
                }
            }

            foreach (ListViewItem item in removedItems)
            {
                this.allImageList.Items.Remove(item);
            }
        }

        /// <summary>
        /// Start the screen saver window and the animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (ImagesModel.activeImagePaths.Count == 0)
            {
                MessageBox.Show("Add an image to the \"Active images\" list to start the animation", "Animation can not be started", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            AnimationForm screenSaver = new AnimationForm();

            screenSaver.Show();
        }

        /// <summary>
        /// Open a help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
