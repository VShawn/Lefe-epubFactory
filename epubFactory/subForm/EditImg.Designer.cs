namespace epubFactory
{
    partial class EditImg
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
            this.pb_Img = new System.Windows.Forms.PictureBox();
            this.ddl_ImgType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_Illustration = new System.Windows.Forms.NumericUpDown();
            this.lb_illu = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.tb_inBefore = new System.Windows.Forms.TextBox();
            this.lb_in1 = new System.Windows.Forms.Label();
            this.rb_b = new System.Windows.Forms.RadioButton();
            this.rb_a = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Illustration)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Img
            // 
            this.pb_Img.Location = new System.Drawing.Point(12, 12);
            this.pb_Img.Name = "pb_Img";
            this.pb_Img.Size = new System.Drawing.Size(212, 258);
            this.pb_Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Img.TabIndex = 0;
            this.pb_Img.TabStop = false;
            // 
            // ddl_ImgType
            // 
            this.ddl_ImgType.CausesValidation = false;
            this.ddl_ImgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_ImgType.Font = new System.Drawing.Font("宋体", 14F);
            this.ddl_ImgType.FormattingEnabled = true;
            this.ddl_ImgType.Location = new System.Drawing.Point(234, 42);
            this.ddl_ImgType.Name = "ddl_ImgType";
            this.ddl_ImgType.Size = new System.Drawing.Size(246, 27);
            this.ddl_ImgType.TabIndex = 1;
            this.ddl_ImgType.TabStop = false;
            this.ddl_ImgType.SelectedIndexChanged += new System.EventHandler(this.ddl_ImgType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(230, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择图片类型";
            // 
            // nud_Illustration
            // 
            this.nud_Illustration.Font = new System.Drawing.Font("宋体", 12F);
            this.nud_Illustration.Location = new System.Drawing.Point(394, 195);
            this.nud_Illustration.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nud_Illustration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Illustration.Name = "nud_Illustration";
            this.nud_Illustration.Size = new System.Drawing.Size(46, 26);
            this.nud_Illustration.TabIndex = 3;
            this.nud_Illustration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lb_illu
            // 
            this.lb_illu.AutoSize = true;
            this.lb_illu.Font = new System.Drawing.Font("宋体", 14F);
            this.lb_illu.Location = new System.Drawing.Point(240, 202);
            this.lb_illu.Name = "lb_illu";
            this.lb_illu.Size = new System.Drawing.Size(231, 19);
            this.lb_illu.TabIndex = 4;
            this.lb_illu.Text = "彩图排列顺序 第      张";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(400, 272);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // tb_inBefore
            // 
            this.tb_inBefore.Location = new System.Drawing.Point(244, 163);
            this.tb_inBefore.Name = "tb_inBefore";
            this.tb_inBefore.Size = new System.Drawing.Size(227, 21);
            this.tb_inBefore.TabIndex = 0;
            // 
            // lb_in1
            // 
            this.lb_in1.AutoSize = true;
            this.lb_in1.Font = new System.Drawing.Font("宋体", 10F);
            this.lb_in1.Location = new System.Drawing.Point(241, 117);
            this.lb_in1.Name = "lb_in1";
            this.lb_in1.Size = new System.Drawing.Size(49, 14);
            this.lb_in1.TabIndex = 7;
            this.lb_in1.Text = "定位：";
            // 
            // rb_b
            // 
            this.rb_b.AutoSize = true;
            this.rb_b.Location = new System.Drawing.Point(296, 141);
            this.rb_b.Name = "rb_b";
            this.rb_b.Size = new System.Drawing.Size(167, 16);
            this.rb_b.TabIndex = 10;
            this.rb_b.TabStop = true;
            this.rb_b.Text = "该图前一句话包含以下文字";
            this.rb_b.UseVisualStyleBackColor = true;
            // 
            // rb_a
            // 
            this.rb_a.AutoSize = true;
            this.rb_a.Checked = true;
            this.rb_a.Location = new System.Drawing.Point(296, 119);
            this.rb_a.Name = "rb_a";
            this.rb_a.Size = new System.Drawing.Size(167, 16);
            this.rb_a.TabIndex = 10;
            this.rb_a.TabStop = true;
            this.rb_a.Text = "该图后一句话包含以下文字";
            this.rb_a.UseVisualStyleBackColor = true;
            // 
            // EditImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 308);
            this.Controls.Add(this.rb_a);
            this.Controls.Add(this.rb_b);
            this.Controls.Add(this.nud_Illustration);
            this.Controls.Add(this.lb_illu);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lb_in1);
            this.Controls.Add(this.tb_inBefore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddl_ImgType);
            this.Controls.Add(this.pb_Img);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditImg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置图片";
            this.Load += new System.EventHandler(this.EditImg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Illustration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Img;
        private System.Windows.Forms.ComboBox ddl_ImgType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_Illustration;
        private System.Windows.Forms.Label lb_illu;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lb_in1;
        private System.Windows.Forms.TextBox tb_inBefore;
        private System.Windows.Forms.RadioButton rb_b;
        private System.Windows.Forms.RadioButton rb_a;
    }
}