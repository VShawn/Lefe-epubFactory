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
    public partial class FastNote : Form
    {
        public FastNote()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }
        private void EditImg_Load(object sender, EventArgs e)
        {
            SetNote sn = (SetNote)this.Owner;
            if (sn.listNotes != null && sn.listNotes.Count > 0)
            {
                rtb_FastNote.Text = "";
                foreach (Note note in sn.listNotes)
                {
                    rtb_FastNote.Text += note.word + "|" + note.up + "|" + note.down;
                    if (note != sn.listNotes[sn.listNotes.Count-1])
                    {
                        rtb_FastNote.Text += "\r\n";
                    }
                }
            }
            //this.DialogResult = DialogResult.Cancel;
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            List<Note> ln = new List<Note>();
            foreach (string line in rtb_FastNote.Lines)
            {
                if(line.Trim() == "")
                    continue;
                
                string[] onnote = line.Split('|');
                if (onnote.Length >= 2)
                {
                    Note note = new Note();
                    note.word = onnote[0];
                    note.up = onnote[1];
                    if (onnote.Length >= 3)
                        note.down = onnote[2];
                    if (onnote.Length >= 4)
                        note.foot = onnote[3];
                    ln.Add(note);
                }
                
            }
            SetNote sn = (SetNote)this.Owner;
            sn.listNotes = ln;
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
