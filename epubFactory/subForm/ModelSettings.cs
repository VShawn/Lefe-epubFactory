using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LeFe.Model;

namespace epubFactory
{
    public partial class ModelSettings : Form
    {
        private bool hasBeenEdit = false;
        public ModelSettings()
        {
            InitializeComponent();
            DefaultModel.Destroy();
            string modelname = SofeSetting.Get("生成模板");
            if (!DefaultModel.CheckModel(modelname))
            {
                MessageBox.Show("模板文件不存在！请重新选择模板。");
                Close();
            }
        }
        public ModelSettings(string modelname)
        {
            InitializeComponent();
            if (!DefaultModel.CheckModel(modelname))
            {
                MessageBox.Show("模板文件不存在！请重新选择模板。");
                Close();
            }
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            ddl_footnootPos.SelectedItem = ddl_footnootPos.Items[0];
            lb_tilte.Text = "模板:【" + SofeSetting.Get("生成模板") +"】设置";
            tb_pic_whith_text.Text = DefaultModel.GetSetting("插图后带字");
            tb_pic_whithout_text.Text = DefaultModel.GetSetting("插图后不带字");
            tb_note_up.Text = DefaultModel.GetSetting("上注");
            tb_note_down.Text = DefaultModel.GetSetting("下注");
            tb_note_foot1.Text = DefaultModel.GetSetting("尾注1");
            tb_note_foot2.Text = DefaultModel.GetSetting("尾注2");
            if (DefaultModel.GetSetting("尾注2位置") == "0" || DefaultModel.GetSetting("尾注2位置") == "1")
            {
                ddl_footnootPos.SelectedItem = ddl_footnootPos.Items[int.Parse(DefaultModel.GetSetting("尾注2位置"))];
            }
            tb_message_row.Text = DefaultModel.GetSetting("制作信息行");
            tb_summary_row.Text = DefaultModel.GetSetting("简介行");
            tb_contents_row.Text = DefaultModel.GetSetting("目录行");
            tb_capater_row.Text = DefaultModel.GetSetting("正文行");
            tb_capater_title.Text = DefaultModel.GetSetting("正文标题");

            //cb_EnableFootNote.Checked = DefaultModel.GetSetting("尾注开关") == "1" ? true : false;
            //if (cb_EnableFootNote.Checked)
            //    gb_footnote.Visible = true;
            //else
            //    gb_footnote.Visible = false;
            cb_EnableFootNote.Visible = false;
            cb_EnableFootNote.Checked = gb_footnote.Visible = true;



            //添加动作事件，实现编辑过才弹出保存确认
            tb_pic_whith_text.TextChanged += text_TextChanged;
            tb_pic_whithout_text.TextChanged += text_TextChanged;
            tb_note_up.TextChanged += text_TextChanged;
            tb_note_down.TextChanged += text_TextChanged;
            tb_note_foot1.TextChanged += text_TextChanged;
            tb_note_foot2.TextChanged += text_TextChanged;
            tb_message_row.TextChanged += text_TextChanged;
            tb_summary_row.TextChanged += text_TextChanged;
            tb_contents_row.TextChanged += text_TextChanged;
            tb_capater_row.TextChanged += text_TextChanged;
            tb_capater_title.TextChanged += text_TextChanged;
            ddl_footnootPos.SelectedValueChanged += text_TextChanged;
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (hasBeenEdit)
            {
                DialogResult dr = MessageBox.Show("退出前要保存模板修改么？", "确认保存", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    _save();
                }
                else if (dr == DialogResult.Cancel)
                    return;
            }
            DefaultModel.Destroy();
            Close();
        }
        private void _save()
        {
            DefaultModel.SetSetting("插图后带字", tb_pic_whith_text.Text);
            DefaultModel.SetSetting("插图后不带字", tb_pic_whithout_text.Text);
            DefaultModel.SetSetting("上注", tb_note_up.Text);
            DefaultModel.SetSetting("下注", tb_note_down.Text);
            DefaultModel.SetSetting("尾注开关", cb_EnableFootNote.Checked?"1":"0");
            DefaultModel.SetSetting("尾注1", tb_note_foot1.Text);
            DefaultModel.SetSetting("尾注2", tb_note_foot2.Text);
            DefaultModel.SetSetting("尾注2位置", ddl_footnootPos.SelectedIndex.ToString());
            DefaultModel.SetSetting("制作信息行", tb_message_row.Text);
            DefaultModel.SetSetting("简介行", tb_summary_row.Text);
            DefaultModel.SetSetting("目录行", tb_contents_row.Text);
            DefaultModel.SetSetting("正文行", tb_capater_row.Text);
            DefaultModel.SetSetting("正文标题", tb_capater_title.Text);
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("要重置设定为默认值么？", "重置", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                tb_pic_whith_text.Text = DefaultModel.GetDefault("插图后带字");
                tb_pic_whithout_text.Text = DefaultModel.GetDefault("插图后不带字");
                tb_note_up.Text = DefaultModel.GetDefault("上注");
                tb_note_down.Text = DefaultModel.GetDefault("下注");
                cb_EnableFootNote.Checked = DefaultModel.GetDefault("尾注开关") == "1" ? true : false;
                if (cb_EnableFootNote.Checked)
                    gb_footnote.Visible = true;
                else
                    gb_footnote.Visible = false;
                tb_note_foot1.Text = DefaultModel.GetDefault("尾注1");
                tb_note_foot2.Text = DefaultModel.GetDefault("尾注2");
                tb_message_row.Text = DefaultModel.GetDefault("制作信息行");
                tb_summary_row.Text = DefaultModel.GetDefault("简介行");
                tb_contents_row.Text = DefaultModel.GetDefault("目录行");
                tb_capater_row.Text = DefaultModel.GetDefault("正文行");
                tb_capater_title.Text = DefaultModel.GetDefault("正文标题");
            }
        }
        private void cb_EnableFootNote_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_EnableFootNote.Checked)
            {
                gb_footnote.Visible = true;
            }
            else
            {
                gb_footnote.Visible = false;
            }
        }

        private void text_TextChanged(object sender, EventArgs e)
        {
            hasBeenEdit = true;
        }
    }
}
