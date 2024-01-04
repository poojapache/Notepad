using System;
using System.Linq;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        static bool status = true;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Form1.ActiveForm.Text =  "*Untitled-Notepad";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Text Documents|*.txt";
            if(op.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
                this.Text = op.FileName;
                Form1.ActiveForm.Text = op.FileName + "-Notepad";
            }
            

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text Document(*.txt)|(*.txt)|All files(*.*)|(*.*)";
            if(sv.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.SaveFile(sv.FileName,RichTextBoxStreamType.PlainText);
                this.Text = sv.FileName;
                Form1.ActiveForm.Text = sv.FileName + "-Notepad";
            }
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = (DateTime.Now).ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font=richTextBox1.SelectionFont;
            if(fd.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.Font= fd.Font;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.BackColor = cd.Color;
            }
        }
     

        private void ststusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(status)
            {
                statusStrip1.Visible = false;
                status = false;
            }
            else
            {
                statusStrip1.Visible = true;
                status = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is version 1.0 built by Pooja Pache");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
          
            int lineCount = richTextBox1.Lines.Count();
            int currentIndex = richTextBox1.SelectionStart;
            int Ln = richTextBox1.GetLineFromCharIndex(currentIndex);
            int firstLineCharIndex = richTextBox1.GetFirstCharIndexFromLine(Ln);
           // int c = richTextBox1.Text.Length;calculates total characters
           int c= currentIndex - firstLineCharIndex;
            //this label is added in visual editor using the default name
            toolStripStatusLabel1.Text = string.Format("lin: "+ lineCount+"col: "+c);
            statusStrip1.Refresh();
            
        }

        
    }
}
