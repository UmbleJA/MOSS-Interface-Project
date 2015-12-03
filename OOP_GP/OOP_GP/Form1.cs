using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

            files.Multiselect = true;
            if (GlobalVar.GlobalValue == "C")
            {
                files.Filter = "C (*.c, *.h)|*.c;*.h|All Files (*.*)|*.*";
            }
            else if (GlobalVar.GlobalValue == "C++")
            {
                files.Filter = "C++ (*.cc, *.cpp, *.h, *.hpp)|*.cc;*.cpp;*.h,*.hpp|All Files (*.*)|*.*";
            }
            else if (GlobalVar.GlobalValue == "Python")
            {
                files.Filter = "Python (*.py)|*.py|All Files (*.*)|*.*";
            }
            else if (GlobalVar.GlobalValue == "C#")
            {
                files.Filter = "C# (*.cs)|*.cs|All Files (*.*)|*.*";
            }       
            files.FilterIndex = 1;
            if (files.ShowDialog() == DialogResult.OK)
            {
                var fileName = files.FileName;
                string lastFolderName = Path.GetFileName(Path.GetDirectoryName(fileName));
                string holderDirec = Path.Combine(Path.GetTempPath() + "Moss Temporary Files", lastFolderName);
                Directory.CreateDirectory(holderDirec);
                System.IO.File.Copy(fileName, Path.Combine(holderDirec, Path.GetFileName(fileName)));
            }
        }

        private void reviewFilesButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folders = new FolderBrowserDialog();
            if (folders.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(Path.Combine(Path.GetTempPath() + "Moss Temporary Files"));
                string lastFolder = new DirectoryInfo(folders.SelectedPath).Name;
                Directory.CreateDirectory(Path.GetTempPath() + "Moss Temporary Files\\" + GlobalVar.GlobalInt);
                if (GlobalVar.GlobalValue == "C")
                {
                    foreach (string newPath in Directory.GetFiles(folders.SelectedPath, "*.*",SearchOption.AllDirectories)
                        .Where(s=>s.EndsWith(".c")|| s.EndsWith(".h")))
                    {
                        File.Copy(newPath, newPath.Replace(folders.SelectedPath, Path.GetTempPath() + "Moss Temporary Files\\" + GlobalVar.GlobalInt));
                    }
                }
                else if (GlobalVar.GlobalValue == "C++")
                {
                    foreach (string newPath in Directory.GetFiles(folders.SelectedPath, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".cpp") || s.EndsWith(".h") || s.EndsWith(".cc") || s.EndsWith(".hpp")))
                    {
                        File.Copy(newPath, newPath.Replace(folders.SelectedPath, Path.GetTempPath() + "Moss Temporary Files\\" + GlobalVar.GlobalInt));
                    }
                }
                else if (GlobalVar.GlobalValue == "Python")
                {
                    foreach (string newPath in Directory.GetFiles(folders.SelectedPath, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".py")))
                    {
                        File.Copy(newPath, newPath.Replace(folders.SelectedPath, Path.GetTempPath() + "Moss Temporary Files\\" + GlobalVar.GlobalInt));
                    }
                }
                else if (GlobalVar.GlobalValue == "C#")
                {
                    foreach (string newPath in Directory.GetFiles(folders.SelectedPath, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".cs")))
                    {
                        File.Copy(newPath, newPath.Replace(folders.SelectedPath, Path.GetTempPath() + "Moss Temporary Files\\" + GlobalVar.GlobalInt));
                    }
                }
            }
        }

    }
}
