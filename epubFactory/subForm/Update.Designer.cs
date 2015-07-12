namespace epubFactory
{
    partial class Update
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
            this.lb_download = new System.Windows.Forms.LinkLabel();
            this.lb_date = new System.Windows.Forms.Label();
            this.lb_info = new System.Windows.Forms.Label();
            this.lb_version = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_ignor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_download
            // 
            this.lb_download.AutoSize = true;
            this.lb_download.Font = new System.Drawing.Font("黑体", 16F);
            this.lb_download.Location = new System.Drawing.Point(412, 52);
            this.lb_download.Name = "lb_download";
            this.lb_download.Size = new System.Drawing.Size(98, 22);
            this.lb_download.TabIndex = 9;
            this.lb_download.TabStop = true;
            this.lb_download.Text = "点击下载";
            this.lb_download.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_download_LinkClicked);
            // 
            // lb_date
            // 
            this.lb_date.AutoSize = true;
            this.lb_date.Font = new System.Drawing.Font("宋体", 12F);
            this.lb_date.Location = new System.Drawing.Point(207, 52);
            this.lb_date.Name = "lb_date";
            this.lb_date.Size = new System.Drawing.Size(88, 16);
            this.lb_date.TabIndex = 8;
            this.lb_date.Text = "更新时间：";
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Font = new System.Drawing.Font("宋体", 12F);
            this.lb_info.Location = new System.Drawing.Point(51, 86);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(88, 16);
            this.lb_info.TabIndex = 7;
            this.lb_info.Text = "更新内容：";
            // 
            // lb_version
            // 
            this.lb_version.AutoSize = true;
            this.lb_version.Font = new System.Drawing.Font("宋体", 12F);
            this.lb_version.Location = new System.Drawing.Point(51, 52);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(72, 16);
            this.lb_version.TabIndex = 6;
            this.lb_version.Text = "版本号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 13F);
            this.label1.Location = new System.Drawing.Point(129, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "发现了程序的新版本，是否需要更新？";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(474, 226);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 10;
            this.btn_exit.Text = "关闭";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_ignor
            // 
            this.btn_ignor.Location = new System.Drawing.Point(332, 226);
            this.btn_ignor.Name = "btn_ignor";
            this.btn_ignor.Size = new System.Drawing.Size(124, 23);
            this.btn_ignor.TabIndex = 11;
            this.btn_ignor.Text = "不再提示本次更新";
            this.btn_ignor.UseVisualStyleBackColor = true;
            this.btn_ignor.Visible = false;
            this.btn_ignor.Click += new System.EventHandler(this.btn_ignor_Click);
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 261);
            this.Controls.Add(this.btn_ignor);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lb_download);
            this.Controls.Add(this.lb_date);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.lb_version);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件更新";
            this.Load += new System.EventHandler(this.Update_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lb_download;
        private System.Windows.Forms.Label lb_date;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_ignor;

    }
}