﻿
    namespace EmploymentContractMaker
    {
        partial class ImageForm
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.SuspendLayout();
                // 
                // pictureBox1
                // 
                this.pictureBox1.Location = new System.Drawing.Point(0, 0);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(100, 50);
                this.pictureBox1.TabIndex = 0;
                this.pictureBox1.TabStop = false;
                this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
                this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
                // 
                // ImageForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 261);
                this.Controls.Add(this.pictureBox1);
                this.Name = "ImageForm";
                this.Text = "圖片瀏覽器";
                this.Load += new System.EventHandler(this.ImageForm_Load);
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.PictureBox pictureBox1;
        }
    }