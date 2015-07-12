namespace epubFactory
{
    partial class SetNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetNote));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.pictureBox_Help = new System.Windows.Forms.PictureBox();
            this.LBTN_Help = new System.Windows.Forms.LinkLabel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_FastEdit = new System.Windows.Forms.Button();
            this.listViewMain = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGrd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderFoot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Help)).BeginInit();
            this.SuspendLayout();
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
            // pictureBox_Help
            // 
            this.pictureBox_Help.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Help.Image")));
            this.pictureBox_Help.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_Help.Name = "pictureBox_Help";
            this.pictureBox_Help.Size = new System.Drawing.Size(232, 68);
            this.pictureBox_Help.TabIndex = 7;
            this.pictureBox_Help.TabStop = false;
            // 
            // LBTN_Help
            // 
            this.LBTN_Help.AutoSize = true;
            this.LBTN_Help.Location = new System.Drawing.Point(13, 58);
            this.LBTN_Help.Name = "LBTN_Help";
            this.LBTN_Help.Size = new System.Drawing.Size(53, 12);
            this.LBTN_Help.TabIndex = 8;
            this.LBTN_Help.TabStop = true;
            this.LBTN_Help.Text = "查看示例";
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(735, 43);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 10;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_FastEdit
            // 
            this.btn_FastEdit.Location = new System.Drawing.Point(654, 43);
            this.btn_FastEdit.Name = "btn_FastEdit";
            this.btn_FastEdit.Size = new System.Drawing.Size(75, 23);
            this.btn_FastEdit.TabIndex = 11;
            this.btn_FastEdit.Text = "快速添加";
            this.btn_FastEdit.UseVisualStyleBackColor = true;
            this.btn_FastEdit.Click += new System.EventHandler(this.btn_FastEdit_Click);
            // 
            // listViewMain
            // 
            this.listViewMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderGrd,
            this.columnHeaderAdr,
            this.ColumnHeaderFoot});
            this.listViewMain.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.GridLines = true;
            this.listViewMain.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewMain.Location = new System.Drawing.Point(12, 73);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(798, 252);
            this.listViewMain.TabIndex = 9;
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "需注释文字";
            this.columnHeaderName.Width = 159;
            // 
            // columnHeaderGrd
            // 
            this.columnHeaderGrd.Text = "上注";
            this.columnHeaderGrd.Width = 100;
            // 
            // columnHeaderAdr
            // 
            this.columnHeaderAdr.Text = "下注";
            this.columnHeaderAdr.Width = 227;
            // 
            // ColumnHeaderFoot
            // 
            this.ColumnHeaderFoot.Text = "尾注";
            this.ColumnHeaderFoot.Width = 384;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(327, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "双击进行修改";
            // 
            // SetNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 363);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_FastEdit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.listViewMain);
            this.Controls.Add(this.LBTN_Help);
            this.Controls.Add(this.pictureBox_Help);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SetNote";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "setBookInfo";
            this.Load += new System.EventHandler(this.SetBookInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Help)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.PictureBox pictureBox_Help;
        private System.Windows.Forms.LinkLabel LBTN_Help;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderGrd;
        private System.Windows.Forms.ColumnHeader columnHeaderAdr;
        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_FastEdit;
        private System.Windows.Forms.ColumnHeader ColumnHeaderFoot;
        private System.Windows.Forms.Label label1;
    }
}