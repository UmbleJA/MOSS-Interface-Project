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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "000000";
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            GlobalVar.GlobalInt = maskedTextBox1.Text;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVar.GlobalValue = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            toolTip1.ToolTipTitle = "Invalid Input";
            toolTip1.Show("Invalid UserID", maskedTextBox1, maskedTextBox1.Location, 5000);
        }
    }
}
