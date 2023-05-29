using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Playhub
{
    public partial class Form1 : Form
    {
        public static Form2 GamePanel;
        public static bool host = true;
        public static string pathPack;
        public Form1()
        {
            InitializeComponent();
            rbWith.Checked = true;
        }
        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            ProtocolProcess.SetSettings( host,int.Parse(tNumOfPl.Text));
            ProtocolProcess.CreateGame(cgameIp.Text, int.Parse(cgamePort.Text), cgameName.Text, pathPack);
            ProtocolProcess.StartServer();
            ProtocolProcess.CreatePlayer(lgameIp.Text, int.Parse(lgamePort.Text));
            ProtocolProcess.StartClient();
            PlayerSetting.Username = cgamerName.Text;
            PlayerSetting.IsHost = true;
            PlayerSetting.IsPlayer = !host;
            ProtocolProcess.JoinGame(PlayerSetting.Username);
            this.Hide();
            if (GamePanel == null)
            {
                GamePanel = new Form2();
                GamePanel.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProtocolProcess.CreatePlayer(lgameIp.Text, int.Parse(lgamePort.Text));
            ProtocolProcess.StartClient();
            PlayerSetting.Username = lgamerName.Text;
            ProtocolProcess.JoinGame(PlayerSetting.Username);
            this.Hide();
            if (GamePanel == null)
            {
                GamePanel = new Form2();
                GamePanel.Show();
            }
        }

        private void rbWithout_CheckedChanged(object sender, EventArgs e)
        {
            rbWith.Checked = false;
            host = false;
        }

        private void rbWith_CheckedChanged(object sender, EventArgs e)
        {
            rbWithout.Checked = false;
            host = true;
        }

        private void rbWith_Enter(object sender, EventArgs e)
        {
            rbWith.Checked = true;
            rbWithout.Checked = false;
            host = true;
        }

        private void rbWithout_Enter(object sender, EventArgs e)
        {
            rbWith.Checked = false;
            rbWithout.Checked = true;
            host = false;
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolderPath = folderBrowserDialog.SelectedPath;
                string[] s = Directory.GetFiles(selectedFolderPath);
                bool found = false;
                foreach (var path in s)
                {
                    if (selectedFolderPath + @"\allQ.txt" == path)
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Something wrong with your pack");
                }
                else
                {
                    pathPack = selectedFolderPath;
                    label5.Text = "Pack was loaded successfully";
                }
            }
        }
    }
}
