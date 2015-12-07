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
using Microsoft.Win32;

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
            if (Registry.CurrentUser.OpenSubKey("MossApplicationUserID") == null)
            {

            }
            else
            {
                Registry.CurrentUser.DeleteSubKey("MossApplicationUserID");
            }
            if (Registry.CurrentUser.OpenSubKey("MossApplicationLanguageFilter") == null)
            {

            }
            else
            {
                Registry.CurrentUser.DeleteSubKey("MossApplicationLanguageFilter");
            }
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
            //making sure the registry key exists
            const string userRoot = "HKEY_CURRENT_USER";
            const string subKey = "MossApplicationUserID";
            const string keyName = userRoot + "\\" + subKey;
       

            FolderBrowserDialog folders = new FolderBrowserDialog();
            if (folders.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(Path.Combine(Path.GetTempPath() + "Moss Temporary Files"));
                string lastFolder = new DirectoryInfo(folders.SelectedPath).Name;
                string sourDirectory = new DirectoryInfo(folders.SelectedPath).ToString();
                Directory.CreateDirectory(Path.GetTempPath() + "Moss Temporary Files\\" + ((string)Registry.GetValue(keyName, "", "Default")));
                string targetDirectory = Path.GetTempPath() + "Moss Temporary Files\\" + ((string)Registry.GetValue(keyName, "", "Default"));
                DirectoryCopy(sourDirectory, targetDirectory, true);
            }
        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subKey = "MossApplicationLanguageFilter";
            const string keyName = userRoot + "\\" + subKey;
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            if ((string)Registry.GetValue(keyName, "", "Default") == "C")
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Extension == ".c" || file.Extension == ".h")
                    {
                        string temppath = Path.Combine(destDirName, file.Name);
                        file.CopyTo(temppath, true);
                    }
                }
            }
            else if ((string)Registry.GetValue(keyName, "", "Default") == "C++")
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Extension == ".cpp" || file.Extension == ".h" || file.Extension == ".cc" || file.Extension == ".hpp")
                    {
                        string temppath = Path.Combine(destDirName, file.Name);
                        file.CopyTo(temppath, true);
                    }
                }
            }
            else if ((string)Registry.GetValue(keyName, "", "Default") == "Python")
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Extension == ".py")
                    {
                        string temppath = Path.Combine(destDirName, file.Name);
                        file.CopyTo(temppath, true);
                    }
                }
            }
            else if ((string)Registry.GetValue(keyName, "", "Default") == "C#")
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Extension == ".cs" || file.Extension == ".h")
                    {
                        string temppath = Path.Combine(destDirName, file.Name);
                        file.CopyTo(temppath, true);
                    }
                }
            }
            // Get the files in the directory and copy them to the new location.
            

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = destDirName;
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

    }
}
