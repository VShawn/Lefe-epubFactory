namespace epubFactory
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_importTXT = new System.Windows.Forms.Button();
            this.btn_output = new System.Windows.Forms.Button();
            this.btn_About = new System.Windows.Forms.Button();
            this.btn_set = new System.Windows.Forms.Button();
            this.btn_hekp = new System.Windows.Forms.Button();
            this.btn_comm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_importTXT
            // 
            this.btn_importTXT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_importTXT.Location = new System.Drawing.Point(12, 12);
            this.btn_importTXT.Name = "btn_importTXT";
            this.btn_importTXT.Size = new System.Drawing.Size(75, 23);
            this.btn_importTXT.TabIndex = 13;
            this.btn_importTXT.Text = "TXT向导";
            this.btn_importTXT.UseVisualStyleBackColor = true;
            this.btn_importTXT.Click += new System.EventHandler(this.btn_importTXT_Click);
            // 
            // btn_output
            // 
            this.btn_output.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_output.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_output.Location = new System.Drawing.Point(93, 12);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(75, 23);
            this.btn_output.TabIndex = 16;
            this.btn_output.Text = "导出epub";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // btn_About
            // 
            this.btn_About.Cursor = System.Windows.Forms.Cursors.Help;
            this.btn_About.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_About.Location = new System.Drawing.Point(174, 41);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(75, 23);
            this.btn_About.TabIndex = 17;
            this.btn_About.Text = "About";
            this.btn_About.UseVisualStyleBackColor = true;
            this.btn_About.Click += new System.EventHandler(this.btn_About_Click);
            // 
            // btn_set
            // 
            this.btn_set.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btn_set.Location = new System.Drawing.Point(174, 12);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(75, 23);
            this.btn_set.TabIndex = 20;
            this.btn_set.Text = "软件设置";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // btn_hekp
            // 
            this.btn_hekp.ForeColor = System.Drawing.Color.Red;
            this.btn_hekp.Location = new System.Drawing.Point(12, 41);
            this.btn_hekp.Name = "btn_hekp";
            this.btn_hekp.Size = new System.Drawing.Size(75, 23);
            this.btn_hekp.TabIndex = 21;
            this.btn_hekp.Text = "使用说明";
            this.btn_hekp.UseVisualStyleBackColor = true;
            this.btn_hekp.Click += new System.EventHandler(this.btn_hekp_Click);
            // 
            // btn_comm
            // 
            this.btn_comm.ForeColor = System.Drawing.Color.Red;
            this.btn_comm.Location = new System.Drawing.Point(93, 41);
            this.btn_comm.Name = "btn_comm";
            this.btn_comm.Size = new System.Drawing.Size(75, 23);
            this.btn_comm.TabIndex = 22;
            this.btn_comm.Text = "意见建议";
            this.btn_comm.UseVisualStyleBackColor = true;
            this.btn_comm.Click += new System.EventHandler(this.btn_comm_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 74);
            this.Controls.Add(this.btn_comm);
            this.Controls.Add(this.btn_hekp);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.btn_About);
            this.Controls.Add(this.btn_output);
            this.Controls.Add(this.btn_importTXT);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lefe - epub快速生成";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_importTXT;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.Button btn_About;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.Button btn_hekp;
        private System.Windows.Forms.Button btn_comm;


    }
}