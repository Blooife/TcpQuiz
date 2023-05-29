using System;
using System.Threading;
using System.Windows.Forms;

namespace Playhub
{
    public class TimerThreadExample
    {
        public System.Timers.Timer timer;

        public TimerThreadExample()
        {
            timer = new System.Timers.Timer(500);
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true;
        }

        public void Start()
        {
            timer.Start();
            TimerElapsed(null, null);
        }

        public void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (Form1.GamePanel.prBar.Value < 6000)
                {
                    Form1.GamePanel.prBar.Invoke((MethodInvoker)(() =>Form1.GamePanel.prBar.Value += 500)); 
                }
                else
                {
                    timer.Stop();
                }
                 
            }
            catch (ThreadInterruptedException ex)
            {
                MessageBox.Show(ex.ToString());
                timer.Stop();
            }
        }
    }
}