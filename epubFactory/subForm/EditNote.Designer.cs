namespace epubFactory
{
    partial class EditNote
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
            this.btn_delete = new System.Windows.Forms.Button();
            this.tb_word = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_up = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_down = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_foot = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Red;
            this.btn_delete.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_delete.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_delete.Location = new System.Drawing.Point(12, 273);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "删除本条";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // tb_word
            // 
            this.tb_word.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_word.Location = new System.Drawing.Point(141, 62);
            this.tb_word.Name = "tb_word";
            this.tb_word.Size = new System.Drawing.Size(321, 26);
            this.tb_word.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "需注释的文字";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(88, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "上注";
            // 
            // tb_up
            // 
            this.tb_up.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_up.Location = new System.Drawing.Point(141, 114);
            this.tb_up.Name = "tb_up";
            this.tb_up.Size = new System.Drawing.Size(321, 26);
            this.tb_up.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(88, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "下注";
            // 
            // tb_down
            // 
            this.tb_down.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_down.Location = new System.Drawing.Point(141, 159);
            this.tb_down.Name = "tb_down";
            this.tb_down.Size = new System.Drawing.Size(321, 26);
            this.tb_down.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(88, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "尾注";
            // 
            // tb_foot
            // 
            this.tb_foot.Font = new System.Drawing.Font("宋体", 12F);
            this.tb_foot.Location = new System.Drawing.Point(141, 205);
            this.tb_foot.Name = "tb_foot";
            this.tb_foot.Size = new System.Drawing.Size(321, 26);
            this.tb_foot.TabIndex = 14;
            // 
            // EditNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 308);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_foot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_down);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_up);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_word);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置注释";
            this.Load += new System.EventHandler(this.EditImg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox tb_word;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_up;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_down;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_foot;
    }
}