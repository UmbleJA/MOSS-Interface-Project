using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_GP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            Form2 options = new Form2();
            options.ShowDialog(this);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void baseFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog files = new OpenFileDialog();
            files.Title = "Select base files.";
            files.ShowDialog(this);
        }

        private void reviewFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog files = new OpenFileDialog();
            files.Title = "Select files to review.";
            files.ShowDialog(this);
        }

    }
}
