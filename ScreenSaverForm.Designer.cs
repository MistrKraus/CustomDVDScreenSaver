namespace CustomDVDScreenSaver
{
    partial class ScreenSaverForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.toActiveBtn = new System.Windows.Forms.Button();
            this.toListBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.allImageList = new System.Windows.Forms.ListView();
            this.activeImageList = new System.Windows.Forms.ListView();
            this.helpLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(438, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(563, 281);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Image list";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OpenBtn
            // 
            this.OpenBtn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.OpenBtn.Location = new System.Drawing.Point(167, 8);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(29, 23);
            this.OpenBtn.TabIndex = 4;
            this.OpenBtn.Text = "...";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Active images";
            // 
            // toActiveBtn
            // 
            this.toActiveBtn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.toActiveBtn.Location = new System.Drawing.Point(202, 120);
            this.toActiveBtn.Name = "toActiveBtn";
            this.toActiveBtn.Size = new System.Drawing.Size(29, 23);
            this.toActiveBtn.TabIndex = 8;
            this.toActiveBtn.Text = ">>";
            this.toActiveBtn.UseVisualStyleBackColor = true;
            this.toActiveBtn.Click += new System.EventHandler(this.toActiveBtn_Click);
            // 
            // toListBtn
            // 
            this.toListBtn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.toListBtn.Location = new System.Drawing.Point(202, 149);
            this.toListBtn.Name = "toListBtn";
            this.toListBtn.Size = new System.Drawing.Size(29, 23);
            this.toListBtn.TabIndex = 9;
            this.toListBtn.Text = "<<";
            this.toListBtn.UseVisualStyleBackColor = true;
            this.toListBtn.Click += new System.EventHandler(this.removeActiveBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.deleteBtn.Location = new System.Drawing.Point(131, 281);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(65, 23);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "Remove";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // allImageList
            // 
            this.allImageList.HideSelection = false;
            this.allImageList.Location = new System.Drawing.Point(16, 37);
            this.allImageList.Name = "allImageList";
            this.allImageList.Size = new System.Drawing.Size(180, 238);
            this.allImageList.TabIndex = 11;
            this.allImageList.UseCompatibleStateImageBehavior = false;
            this.allImageList.View = System.Windows.Forms.View.List;
            // 
            // activeImageList
            // 
            this.activeImageList.HideSelection = false;
            this.activeImageList.Location = new System.Drawing.Point(235, 39);
            this.activeImageList.Name = "activeImageList";
            this.activeImageList.Size = new System.Drawing.Size(180, 238);
            this.activeImageList.TabIndex = 12;
            this.activeImageList.UseCompatibleStateImageBehavior = false;
            this.activeImageList.View = System.Windows.Forms.View.List;
            // 
            // helpLbl
            // 
            this.helpLbl.AutoSize = true;
            this.helpLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.helpLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.helpLbl.Location = new System.Drawing.Point(625, 9);
            this.helpLbl.Name = "helpLbl";
            this.helpLbl.Size = new System.Drawing.Size(16, 16);
            this.helpLbl.TabIndex = 13;
            this.helpLbl.Text = "?";
            this.helpLbl.Click += new System.EventHandler(this.helpLbl_Click);
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 316);
            this.Controls.Add(this.helpLbl);
            this.Controls.Add(this.activeImageList);
            this.Controls.Add(this.allImageList);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.toListBtn);
            this.Controls.Add(this.toActiveBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ScreenSaverForm";
            this.Text = "Custom screen saver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button toActiveBtn;
        private System.Windows.Forms.Button toListBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ListView allImageList;
        private System.Windows.Forms.ListView activeImageList;
        private System.Windows.Forms.Label helpLbl;
    }
}

