namespace epubFactory
{
    partial class SetTitle
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.rtb_titles = new System.Windows.Forms.RichTextBox();
            this.rtb_rules = new System.Windows.Forms.RichTextBox();
            this.btn_retry = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label1.Location = new System.Drawing.Point(351, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(110, 16);
            label1.TabIndex = 7;
            label1.Text = "自动识别标题";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label2.Location = new System.Drawing.Point(12, 113);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(244, 150);
            label2.TabIndex = 8;
            label2.Text = "识别关键词根据需要自行修改\r\n\r\n规则：\r\n数字用?代替\r\n例如 第一节/第1节 可写为第?节\r\n\r\n※特殊情况\r\n标题如  R1 故事的开始\r\n可以设置识别关键" +
                "字为R1或故事\r\n的开始";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(739, 331);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "下一步";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(12, 331);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 23);
            this.btn_back.TabIndex = 4;
            this.btn_back.Text = "上一步";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Exit.ForeColor = System.Drawing.Color.Red;
            this.btn_Exit.Location = new System.Drawing.Point(785, 12);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(25, 25);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.Text = "X";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // rtb_titles
            // 
            this.rtb_titles.Location = new System.Drawing.Point(459, 68);
            this.rtb_titles.Name = "rtb_titles";
            this.rtb_titles.Size = new System.Drawing.Size(351, 257);
            this.rtb_titles.TabIndex = 6;
            this.rtb_titles.Text = "";
            // 
            // rtb_rules
            // 
            this.rtb_rules.Location = new System.Drawing.Point(269, 68);
            this.rtb_rules.Name = "rtb_rules";
            this.rtb_rules.Size = new System.Drawing.Size(184, 255);
            this.rtb_rules.TabIndex = 9;
            this.rtb_rules.Text = "初章\n初始之章\n序章\n终章\n第?章\n?章\n第?节\n第?话\n后记";
            // 
            // btn_retry
            // 
            this.btn_retry.BackColor = System.Drawing.Color.Crimson;
            this.btn_retry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_retry.ForeColor = System.Drawing.Color.Cornsilk;
            this.btn_retry.Location = new System.Drawing.Point(459, 331);
            this.btn_retry.Name = "btn_retry";
            this.btn_retry.Size = new System.Drawing.Size(97, 23);
            this.btn_retry.TabIndex = 10;
            this.btn_retry.Text = "点击重新识别";
            this.btn_retry.UseVisualStyleBackColor = false;
            this.btn_retry.Click += new System.EventHandler(this.btn_retry_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "标题识别结果";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "识别关键词";
            // 
            // SetTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 363);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_retry);
            this.Controls.Add(this.rtb_rules);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.rtb_titles);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SetTitle";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "setBookInfo";
            this.Load += new System.EventHandler(this.SetBookInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.RichTextBox rtb_titles;
        private System.Windows.Forms.RichTextBox rtb_rules;
        private System.Windows.Forms.Button btn_retry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}