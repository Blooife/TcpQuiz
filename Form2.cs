using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Playhub
{
    public partial class Form2 : Form
    {
        public TableLayoutPanel panel = new TableLayoutPanel();
        public Form2()
        {
            InitializeComponent();
            ProtocolProcess.Players.CollectionChanged += PlayersOnCollectionChanged;
            ProtocolProcess.Messages.CollectionChanged += MessagesOnCollectionChanged;
            ProtocolProcess.Questions.CollectionChanged += QuestionsOnCollectionChanged;
            ProtocolProcess.Buttons.CollectionChanged += ButtonsCollectionChanged;
            ProtocolProcess.OnShowAnswer += ShowAnswer;
            ProtocolProcess.OnHostCheckAnswer += CheckAnswer;
            
            
            if (PlayerSetting.IsHost)
            {
                bStart.Visible = true;
                bAnswer.Visible = false;
            }
        }

        public void CheckAnswer(object sender, AnswerReceivedEvent e)
        {
            ProtocolModel.Answer a = e.ans;
            CheckAnswer chA = new CheckAnswer($"Player's answer /{a.answer}/ \n Right answer /{ProtocolProcess.Questions.Last().Answer}/ \n Is player right?");
            
            if (chA.ShowDialog() == DialogResult.Yes)
            {
                a.IsRight = true;
            }
            else
            {
                a.IsRight = false;
            }
            ProtocolProcess.ResponseHostCheck(a);
        }
        private void ButtonsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var k = e.OldItems[e.OldItems.Count-1];
                this.Invoke((MethodInvoker)(() => panel.Controls.Remove((ProtocolModel.Btn)k)));
            }
        }
        private void ShowAnswer(object sender, EventArgs e)
        {
            var q = ProtocolProcess.Questions.Last();
            tQuestion.Invoke((MethodInvoker)(() => tQuestion.Text = $"{q.Answer}" + Environment.NewLine));
            Thread.Sleep(3000);
            //tQuestion.Visible = false;
            tQuestion.Invoke((MethodInvoker)(() => tQuestion.Visible = false));
        }
        private void QuestionsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            tQuestion.Invoke((MethodInvoker)(() => tQuestion.Visible = true));
            var q = (ProtocolModel.Question)e.NewItems[0];
            tQuestion.Invoke((MethodInvoker)(() => tQuestion.Text = $"{q.Text}" + Environment.NewLine));
        }
        private void MessagesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            tMessages.Invoke((MethodInvoker)(() => tMessages.Text += $"{ProtocolProcess.Messages[e.NewStartingIndex]}" + Environment.NewLine));
        }

        private void PlayersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            tPlayers.Invoke((MethodInvoker)(() => tPlayers.Text = ""));
            foreach (var item in ProtocolProcess.Players)
            {
                tPlayers.Invoke((MethodInvoker)(() => tPlayers.Text += $"{item.Name} ({item.Point})" + Environment.NewLine));
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label9.Text = PlayerSetting.Username;
            ProtocolProcess.RequestGameSettings();
            int[] p;
            int[] ind;
            ProtocolProcess.OnGameSettingsReceivedEvent += delegate (object o, GameSettingsReceivedEvent ev)
            {
                if (ev.GameSettings != null)
                {
                    p = ev.GameSettings.Points;
                    ind = ev.GameSettings.Index;
                    for (int n=0; n<p.Length; n++)
                    {
                        var b = new ProtocolModel.Btn();
                        b.Text = p[n].ToString();
                        b.Index = ind[n];
                        b.Click += Button_Click;
                        b.Margin = new Padding(10);
                        ProtocolProcess.Buttons.Add(b);
                    }
                    var subjects = ev.GameSettings.Subjects;
                    var counts = subjects.GroupBy(x => x)
                        .Select(group => new { Value = group.Key, Count = group.Count() })
                        .ToArray();
                    
                    panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                    panel.ColumnCount = counts.Max(c => c.Count) + 1;
                    panel.Dock = DockStyle.Fill;
                    int i = 0;
                    int j = 0;
                    int bCount = 0;
                    foreach (var el in counts)
                    {
                        this.Invoke((MethodInvoker)(() => panel.Controls.Add(new Label(){Text = el.Value}, i,j)));
                        i++;
                        for (int k = 0; k < el.Count; k++)
                        {
                            this.Invoke((MethodInvoker)(() => panel.Controls.Add(ProtocolProcess.Buttons[bCount], i,j)));
                            bCount++;
                            i++;
                        }
                        i = 0;
                        j++;
                    }
                    this.Invoke((MethodInvoker)(() => pButtons.Controls.Add(panel)));
                }
            };
        }
        
        private void Button_Click(object sender, EventArgs e)
        {
            ProtocolModel.Btn clickedButton = (ProtocolModel.Btn)sender;
            ProtocolProcess.ShowQuestion(clickedButton.Index);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProtocolProcess.SendMessage(textBox3.Text, PlayerSetting.Username);
            textBox3.Text = "";
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            ProtocolProcess.StartGame();
            bStart.Visible = false;
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tMessages.SelectionStart = tMessages.Text.Length;
            tMessages.ScrollToCaret();
        }

        private void bAnswer_Click(object sender, EventArgs e)
        {
            ProtocolProcess.RequestKnowAnswer();
            if (ProtocolProcess.CanAnswer)
            {
                EnterAnswer enter = new EnterAnswer();
                if (enter.ShowDialog() == DialogResult.OK)
                {
                    ProtocolProcess.SendAnswer(enter.returnString);
                    enter.Dispose();
                } 
            }
        }
    }
}
