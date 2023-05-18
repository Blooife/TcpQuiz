using System;
using System.Windows.Forms;

namespace Playhub
{
    public partial class CheckAnswer : Form
    {
        public CheckAnswer()
        {
            InitializeComponent();
        }
        
        public CheckAnswer(string str)
        {
            InitializeComponent();
            tText.Text = str;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        

        
    }
}