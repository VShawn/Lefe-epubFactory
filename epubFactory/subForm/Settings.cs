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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }


        private string oldModel = "";
        private void Settings_Load(object sender, EventArgs e)
        {
            tb_MAKER.Text = SofeSetting.Get("[MAKER]");
            tb_SUBJECT.Text = SofeSetting.Get("[SUBJECT]");
            tb_DESCRIPTION.Text = SofeSetting.Get("[DESCRIPTION]");
            tb_SOURCE.Text = SofeSetting.Get("[SOURCE]");
            tb_PUBLISHER.Text = SofeSetting.Get("[PUBLISHER]");
            tb_RIGHT.Text = SofeSetting.Get("[RIGHT]");

            oldModel = SofeSetting.Get("生成模板");
            List<string> models = DefaultModel.SearchModel();
            for (int i =0;i<models.Count;i++)
            {
                cb_Model.Items.Add(models[i]);
            }
            if (cb_Model.Items.IndexOf(oldModel)>0)
                cb_Model.SelectedText = SofeSetting.Get("生成模板");
            else
                cb_Model.SelectedText = SofeSetting.Get(models[0]);
            cb_Model.SelectedItem = cb_Model.Items[cb_Model.Items.IndexOf(oldModel)];
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (_checkEdit())
            {
                DialogResult dr = MessageBox.Show("退出前要保存更改么？", "确认保存", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    _save();
                }
                else if (dr == DialogResult.Cancel)
                    return;
                else
                    SofeSetting.Set("生成模板", oldModel);
            }
            Close();
        }
        private void _save()
        {
            //保存元数据
            SofeSetting.Set("[MAKER]", tb_MAKER.Text);
            SofeSetting.Set("[SUBJECT]", tb_SUBJECT.Text);
            SofeSetting.Set("[DESCRIPTION]", tb_DESCRIPTION.Text);
            SofeSetting.Set("[SOURCE]", tb_SOURCE.Text);
            SofeSetting.Set("[PUBLISHER]", tb_PUBLISHER.Text);
            SofeSetting.Set("[RIGHT]", tb_RIGHT.Text);
            //
            SofeSetting.Set("生成模板", cb_Model.SelectedItem.ToString());
            //保存生成数据
            //SofeSetting.Set("buildCover", cb_cover.Checked.ToString());
            //SofeSetting.Set("buildTitle", cb_title.Checked.ToString());
            //SofeSetting.Set("buildMessage", cb_Message.Checked.ToString());
            //SofeSetting.Set("buildSummary", cb_Summary.Checked.ToString());
            //SofeSetting.Set("buildIll", cb_ill.Checked.ToString());
            //SofeSetting.Set("buildContents", cb_contents.Checked.ToString());
        }
        /// <summary>
        /// 检查数据是否被修改，修改则返回true
        /// </summary>
        /// <returns></returns>
        private bool _checkEdit()
        {
            if (tb_MAKER.Text != SofeSetting.Get("[MAKER]") || 
                tb_SUBJECT.Text != SofeSetting.Get("[SUBJECT]") || 
                tb_DESCRIPTION.Text != SofeSetting.Get("[DESCRIPTION]") ||
                tb_SOURCE.Text != SofeSetting.Get("[SOURCE]") ||
                tb_PUBLISHER.Text != SofeSetting.Get("[PUBLISHER]") ||
                tb_RIGHT.Text != SofeSetting.Get("[RIGHT]") ||
                cb_Model.SelectedItem.ToString() != oldModel
                )
            {
                return true;
            }
            return false;
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("要初始化设定为默认值么？", "初始化", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                tb_MAKER.Text = SofeSetting.GetDefault("[MAKER]");
                tb_SUBJECT.Text = SofeSetting.GetDefault("[SUBJECT]");
                tb_DESCRIPTION.Text = SofeSetting.GetDefault("[DESCRIPTION]");
                tb_SOURCE.Text = SofeSetting.GetDefault("[SOURCE]");
                tb_PUBLISHER.Text = SofeSetting.GetDefault("[PUBLISHER]");
                tb_RIGHT.Text = SofeSetting.GetDefault("[RIGHT]");
                cb_Model.SelectedItem = cb_Model.Items.IndexOf(SofeSetting.GetDefault("生成模板"));
                //_save();
            }
        }

        private void btn_SetModle_Click(object sender, EventArgs e)
        {
            SofeSetting.Set("生成模板", cb_Model.SelectedItem.ToString());
            ModelSettings ms = new ModelSettings();
            ms.ShowDialog();
        }

        private void btn_upadate_Click(object sender, EventArgs e)
        {
            epubFactory.Version.Check(false);
        }

        private void btn_selectTemp_Click(object sender, EventArgs e)
        {
            string model = DefaultModel.SelectModel();
        }
        private void cb_Model_SelectedIndexChanged(object sender, EventArgs e)
        {
            SofeSetting.Set("生成模板", cb_Model.SelectedItem.ToString());
            if (!DefaultModel.CheckModel())
            {
                MessageBox.Show("找不到新设置的模板文件，请先修改该模板！");
                cb_Model.SelectedItem = cb_Model.Items[cb_Model.Items.IndexOf(oldModel)];
                SofeSetting.Set("生成模板", oldModel);
                return;
            }
        }
    }
}
