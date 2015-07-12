using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LeFe.Model;

namespace epubFactory
{
    public partial class EditNote : Form
    {
        private Note onote;
        private Note note;
        public EditNote(Note _note)
        {
            note = _note;
            onote = note;
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }
        private void EditImg_Load(object sender, EventArgs e)
        {
            if (note == null)
            {
                note = new Note();
                btn_delete.Visible = false;
            }
            else
            {
                tb_word.Text = note.word;
                tb_up.Text = note.up;
                tb_down.Text = note.down;
                tb_foot.Text = note.foot;
            }
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            SetNote sn = (SetNote)this.Owner;
            note.word = tb_word.Text;
            note.up = tb_up.Text;
            note.down = tb_down.Text;
            note.foot = tb_foot.Text;
            if (note.word != "")
            {
                if (onote != null)
                {
                    for (int i = 0; i < sn.listNotes.Count; i++)
                    {
                        if (onote == sn.listNotes[i])
                        {
                            sn.listNotes[i] = note;
                        }
                    }
                }
                else
                {
                    sn.listNotes.Add(note);
                }
            }
            Close();
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除本条吗？","确认删除",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                DialogResult = DialogResult.No;
                SetNote sn = (SetNote)this.Owner;
                List<Note> nln = new List<Note>();
                foreach (var note in sn.listNotes)
                {
                    if (onote != note)
                    {
                        nln.Add(note);
                    }
                }
                sn.listNotes = nln;
            }
            Close();
        }
    }
}
