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
            Socket comm = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
            comm.Send(Encoding.ASCII.GetBytes("maxmatches " + SENSITIVITY + "\n"));
            comm.Send(Encoding.ASCII.GetBytes("show 250\n"));
            comm.Send(Encoding.ASCII.GetBytes("language" + GlobalVar.GlobalLang + "\n"));

            //send base data 
            FileInfo baseData = new FileInfo(BASE_CODE_FILEPATH);
            comm.Send(Encoding.ASCII.GetBytes("file 0 " + GlobalVar.GlobalLang + " " + baseData.Length + " " + " " + baseData.Name + "\n"));
            string line;
            System.IO.StreamReader baseFile = new System.IO.StreamReader(BASE_CODE_FILEPATH);
            while ((line = baseFile.ReadLine()) != null)
            {
                comm.Send(Encoding.ASCII.GetBytes(line));
            }
            
            //send all files
            int fileCount = 1;
            List<string> directories = Directory.GetDirectories(FILEPATH);
            foreach(string dir in directories){
                List<string> files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).ToList();
                foreach (string f in files)
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
            STUDENT_MAP_LIST;

            comm.Send(Encoding.ASCII.GetBytes("end\n"));
            comm.Shutdown(SocketShutdown.Both);
            comm.Close();
            this.Close();

        }

        private void baseFilesButton_Click(object sender, EventArgs e)
        {
             
            OpenFileDialog files = new OpenFileDialog();

            files.Multiselect = true;
            if (GlobalVar.GlobalLang == "C")
            {
                files.Filter = "C (*.c, *.h)|*.c;*.h|All Files (*.*)|*.*";
            }
            else if (GlobalVar.GlobalLang == "C++")
            {
                files.Filter = "C++ (*.cc, *.cpp, *.h, *.hpp)|*.cc;*.cpp;*.h,*.hpp|All Files (*.*)|*.*";
            }
            else if (GlobalVar.GlobalLang == "Python")
            {
                files.Filter = "Python (*.py)|*.py|All Files (*.*)|*.*";
            }
            else if (GlobalVar.GlobalLang == "C#")
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
                Directory.CreateDirectory(Path.GetTempPath() + "Moss Temporary Files\\" + GlobalVar.GlobalID);
                if (GlobalVar.GlobalLang == "C")
                {
                    foreach (string newPath in Directory.GetFiles(folders.SelectedPath, "*.*",SearchOption.AllDirectories)
                        .Where(s=>s.EndsWith(".c")|| s.EndsWith(".h")))
                    {
                        File.Copy(newPath, newPath.Replace(folders.SelectedPath, Path.GetTempPath() + "Moss Temporary Files\\" + GlobalVar.GlobalID));
                    }
                }
                else if (GlobalVar.GlobalLang == "C++")
                {
                    foreach (string newPath in Directory.GetFiles(folders.SelectedPath, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".cpp") || s.EndsWith(".h") || s.EndsWith(".cc") || s.EndsWith(".hpp")))
                    {
                        File.Copy(newPath, newPath.Replace(folders.SelectedPath, Path.GetTempPath() + "Moss Temporary Files\\" + GlobalVar.GlobalID));
                    }
                }
                else if (GlobalVar.GlobalLang == "Python")
                {
                    foreach (string newPath in Directory.GetFiles(folders.SelectedPath, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".py")))
                    {
                        File.Copy(newPath, newPath.Replace(folders.SelectedPath, Path.GetTempPath() + "Moss Temporary Files\\" + GlobalVar.GlobalID));
                    }
                }
                else if (GlobalVar.GlobalLang == "C#")
                {
                    foreach (string newPath in Directory.GetFiles(folders.SelectedPath, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".cs")))
                    {
                        File.Copy(newPath, newPath.Replace(folders.SelectedPath, Path.GetTempPath() + "Moss Temporary Files\\" + GlobalVar.GlobalID));
                    }
                }
            }
        }

    }
}
