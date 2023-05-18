using System;
using System.Windows.Forms;

namespace Playhub
{
    public partial class Form1 : Form
    {
        private static Form2 GamePanel;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            ProtocolProcess.SetSettings( int.Parse(tWinPoint.Text), int.Parse(tNumOfPl.Text));
            ProtocolProcess.CreateGame(cgameIp.Text, int.Parse(cgamePort.Text), cgameName.Text);
            ProtocolProcess.StartServer();
            ProtocolProcess.CreatePlayer(lgameIp.Text, int.Parse(lgamePort.Text));
            ProtocolProcess.StartClient();
            PlayerSetting.Username = cgamerName.Text;
            PlayerSetting.IsHost = true;
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
    }
}
