using System;
using System.Windows.Forms;

namespace Playhub
{
    public partial class EnterAnswer : Form
    {
        public string returnString;
        public EnterAnswer()
        {
            InitializeComponent();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            returnString = tAnswer.Text;
        }
    }
}