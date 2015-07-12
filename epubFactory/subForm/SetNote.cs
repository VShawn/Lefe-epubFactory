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
    public partial class SetNote : Form
    {
        public List<Note> listNotes = new List<Note>();
        public SetNote()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            if (Program.newBook.notes != null )
            {
                listNotes = Program.newBook.notes;
            }
        }
        private void SetBookInfo_Load(object sender, EventArgs e)
        {
            pictureBox_Help.Visible = false;
            LBTN_Help.Visible = true;
            LBTN_Help.MouseHover +=new EventHandler(LBTN_Help_MouseHover);
            pictureBox_Help.MouseLeave +=new EventHandler(pictureBox_Help_MouseLeave);
            pictureBox_Help.BringToFront();
            updata_ListView();

            listViewMain.MouseDoubleClick +=new MouseEventHandler(listViewMain_MouseDoubleClick);
        }
        private void listViewMain_MouseDoubleClick(object o,EventArgs e)
        {
            if (this.listViewMain.SelectedItems.Count == 0)
                return;
            EditNote ei = new EditNote(listNotes[listViewMain.FocusedItem.Index]);
            ei.ShowDialog(this);
            updata_ListView();
        }
        private void LBTN_Help_MouseHover(object o,EventArgs e)
        {
            pictureBox_Help.Visible = true;
            LBTN_Help.Visible = false;
        }
        private void pictureBox_Help_MouseLeave(object o,EventArgs e)
        {
            pictureBox_Help.Visible = false;
            LBTN_Help.Visible = true;
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            Program.newBook.notes = listNotes;
            //NotesManager.setNotes(Program.newBook);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void updata_ListView()
        {
            listViewMain.Items.Clear();
            foreach (var note in listNotes)
            {
                ListViewItem lvi = new ListViewItem(note.word);
                lvi.SubItems.Add(note.up);
                lvi.SubItems.Add(note.down);
                lvi.SubItems.Add(note.foot);
                listViewMain.Items.Add(lvi);
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            EditNote ed = new EditNote(null);
            ed.ShowDialog(this);
            updata_ListView();
        }
        private void btn_FastEdit_Click(object sender, EventArgs e)
        {
            FastNote fn = new FastNote();
            fn.ShowDialog(this);
            updata_ListView();
        }
    }
}
