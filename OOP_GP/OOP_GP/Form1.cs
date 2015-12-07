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
using System.Net;
using System.Net.Sockets;

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
            /*Socket comm = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress addr = IPAddress.Parse("172.11.137.159");
            int port = 16127;
            comm.Connect(addr, port);
            if (!comm.Connected)
            {
                throw new Exception("Connection to server failed.");
            }
            comm.Send(Encoding.ASCII.GetBytes("moss " + GlobalVar.GlobalID + "\n"));
            comm.Send(Encoding.ASCII.GetBytes("directory 1\n"));
            comm.Send(Encoding.ASCII.GetBytes("X 0\n"));
            //GET SENSITIVITY
            comm.Send(Encoding.ASCII.GetBytes("maxmatches " + 0.4 + "\n"));
            comm.Send(Encoding.ASCII.GetBytes("show 250\n"));
            comm.Send(Encoding.ASCII.GetBytes("language" + GlobalVar.GlobalLang + "\n"));

            //send base data 
            FileInfo baseData = new FileInfo(BASE_FILE_PATH);
            comm.Send(Encoding.ASCII.GetBytes("file 0 " + GlobalVar.GlobalLang + " " + baseData.Length + " " + " " + baseData.Name + "\n"));
            string line;
            System.IO.StreamReader baseFile = new System.IO.StreamReader(BASE_CODE_FILEPATH);
            while ((line = baseFile.ReadLine()) != null)
            {
                comm.Send(Encoding.ASCII.GetBytes(line));
            }

            //send all files
            int fileCount = 1;
            string mossTemp = Path.GetTempPath() + "Moss Temporary Files";
            NetworkSend(mossTemp, 1);
            
            /*foreach (string dir in (Directory.GetDirectories(Path.GetTempPath() + "Moss Temporary Files"));
            {
                List<string> files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).ToList();
                foreach (string f in Directory.GetFiles(f,"*.*", SearchOption.AllDirectories)
                {

                    System.IO.StreamReader file = new System.IO.StreamReader(f);
                    FileInfo fData = new FileInfo(f);
                    comm.Send(Encoding.ASCII.GetBytes("file " + fileCount + " " + GlobalVar.GlobalLang + " " + fData.Length + " " + " " + fData.Name + "\n"));
                    while ((line = file.ReadLine()) != null)
                    {
                        comm.Send(Encoding.ASCII.GetBytes(line));
                    }
                    fileCount++;
                }
            }
            comm.Send(Encoding.ASCII.GetBytes("query 0\n"));

            //listen to query number
            byte[] recvBuffer = new byte[512];
            comm.Receive(recvBuffer);
            MessageBox.Show("MOSS query received by server.\nQuery #" + Encoding.ASCII.GetString(recvBuffer));
            //list mapping studants to numbers???
            //STUDENT_MAP_LIST;

            comm.Send(Encoding.ASCII.GetBytes("end\n"));
            comm.Shutdown(SocketShutdown.Both);
            comm.Close();
            */
            //deleting the registry entries on program close
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
            //string used for creating a registry entry
            const string userRoot = "HKEY_CURRENT_USER";
            const string subKey = "MossApplicationLanguageFilter";
            const string keyName = userRoot + "\\" + subKey;
             
            OpenFileDialog files = new OpenFileDialog();

            //only shows particular files based on which language has been selected from options
            files.Multiselect = true;
            if ((string)Registry.GetValue(keyName,"","")=="C")
            {
                files.Filter = "C (*.c, *.h)|*.c;*.h|All Files (*.*)|*.*";
            }
            else if ((string)Registry.GetValue(keyName, "", "") == "C++")
            {
                files.Filter = "C++ (*.cc, *.cpp, *.h, *.hpp)|*.cc;*.cpp;*.h,*.hpp|All Files (*.*)|*.*";
            }
            else if ((string)Registry.GetValue(keyName, "", "") == "Python")
            {
                files.Filter = "Python (*.py)|*.py|All Files (*.*)|*.*";
            }
            else if ((string)Registry.GetValue(keyName, "", "") == "C#")
            {
                files.Filter = "C# (*.cs)|*.cs|All Files (*.*)|*.*";
            }       
            files.FilterIndex = 1;
            //needs to be changed to concatonate the files and make them into one temp file
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
       
            //opens folder dialogue and copies all the files in the folder into the temp directory
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
        //lol thanks microsoft
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

        //recursive sending and cool stuff like that
        private static void NetworkSend(string sourceDirName, int fileCount)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] direc = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                System.IO.StreamReader streamSend = new System.IO.StreamReader(file.ToString());
                //comm.Send(Encoding.ASCII.GetBytes("file " + fileCount + " " + GlobalVar.GlobalLang + " " + fData.Length + " " + " " + fData.Name + "\n"));
            }
        }
    }
}
