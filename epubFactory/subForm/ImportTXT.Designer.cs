namespace epubFactory
{
    partial class ImportTXT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_EXIT = new System.Windows.Forms.Button();
            this.tb_TXTPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ImgsFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_SelectTXT = new System.Windows.Forms.Button();
            this.btn_SelectImgs = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_bookNameCH = new System.Windows.Forms.TextBox();
            this.tb_bookNameOR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_author = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_illustration = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(377, 206);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_EXIT
            // 
            this.btn_EXIT.Location = new System.Drawing.Point(12, 206);
            this.btn_EXIT.Name = "btn_EXIT";
            this.btn_EXIT.Size = new System.Drawing.Size(75, 23);
            this.btn_EXIT.TabIndex = 1;
            this.btn_EXIT.Text = "取消";
            this.btn_EXIT.UseVisualStyleBackColor = true;
            this.btn_EXIT.Click += new System.EventHandler(this.btn_EXIT_Click);
            // 
            // tb_TXTPath
            // 
            this.tb_TXTPath.Location = new System.Drawing.Point(102, 55);
            this.tb_TXTPath.Name = "tb_TXTPath";
            this.tb_TXTPath.Size = new System.Drawing.Size(280, 21);
            this.tb_TXTPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "TXT文本地址：";
            // 
            // tb_ImgsFolder
            // 
            this.tb_ImgsFolder.Location = new System.Drawing.Point(103, 82);
            this.tb_ImgsFolder.Name = "tb_ImgsFolder";
            this.tb_ImgsFolder.Size = new System.Drawing.Size(280, 21);
            this.tb_ImgsFolder.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "从TXT文本导入轻小说";
            // 
            // btn_SelectTXT
            // 
            this.btn_SelectTXT.Location = new System.Drawing.Point(377, 54);
            this.btn_SelectTXT.Name = "btn_SelectTXT";
            this.btn_SelectTXT.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectTXT.TabIndex = 6;
            this.btn_SelectTXT.Text = "选择";
            this.btn_SelectTXT.UseVisualStyleBackColor = true;
            this.btn_SelectTXT.Click += new System.EventHandler(this.btn_SelectTXT_Click);
            // 
            // btn_SelectImgs
            // 
            this.btn_SelectImgs.Location = new System.Drawing.Point(377, 81);
            this.btn_SelectImgs.Name = "btn_SelectImgs";
            this.btn_SelectImgs.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectImgs.TabIndex = 7;
            this.btn_SelectImgs.Text = "选择";
            this.btn_SelectImgs.UseVisualStyleBackColor = true;
            this.btn_SelectImgs.Click += new System.EventHandler(this.btn_SelectImgs_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "书名（中文）：";
            // 
            // tb_bookNameCH
            // 
            this.tb_bookNameCH.Location = new System.Drawing.Point(103, 109);
            this.tb_bookNameCH.Name = "tb_bookNameCH";
            this.tb_bookNameCH.Size = new System.Drawing.Size(349, 21);
            this.tb_bookNameCH.TabIndex = 9;
            // 
            // tb_bookNameOR
            // 
            this.tb_bookNameOR.Location = new System.Drawing.Point(103, 136);
            this.tb_bookNameOR.Name = "tb_bookNameOR";
            this.tb_bookNameOR.Size = new System.Drawing.Size(349, 21);
            this.tb_bookNameOR.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "书名（原始）：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "图片文件夹：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "作者：";
            // 
            // tb_author
            // 
            this.tb_author.Location = new System.Drawing.Point(102, 165);
            this.tb_author.Name = "tb_author";
            this.tb_author.Size = new System.Drawing.Size(148, 21);
            this.tb_author.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "插画：";
            // 
            // tb_illustration
            // 
            this.tb_illustration.Location = new System.Drawing.Point(304, 165);
            this.tb_illustration.Name = "tb_illustration";
            this.tb_illustration.Size = new System.Drawing.Size(148, 21);
            this.tb_illustration.TabIndex = 17;
            // 
            // ImportTXT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 241);
            this.Controls.Add(this.tb_illustration);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_author);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_bookNameOR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_bookNameCH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_SelectImgs);
            this.Controls.Add(this.btn_SelectTXT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_ImgsFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_TXTPath);
            this.Controls.Add(this.btn_EXIT);
            this.Controls.Add(this.btn_OK);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImportTXT";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "从TXT导入轻小说";
            this.Load += new System.EventHandler(this.ImportTXT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_EXIT;
        private System.Windows.Forms.TextBox tb_TXTPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ImgsFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_SelectTXT;
        private System.Windows.Forms.Button btn_SelectImgs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_bookNameCH;
        private System.Windows.Forms.TextBox tb_bookNameOR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_author;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_illustration;
    }
}