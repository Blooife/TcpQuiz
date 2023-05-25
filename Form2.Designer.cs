namespace Playhub
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bSend = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tMessages = new System.Windows.Forms.TextBox();
            this.tPlayers = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tQuestion = new System.Windows.Forms.RichTextBox();
            this.pButtons = new System.Windows.Forms.Panel();
            this.prBar = new System.Windows.Forms.ProgressBar();
            this.bAnswer = new System.Windows.Forms.Button();
            this.pButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bStart.Location = new System.Drawing.Point(628, 32);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 29;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Visible = false;
            this.bStart.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(217, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Game Name";
            // 
            // bSend
            // 
            this.bSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bSend.Location = new System.Drawing.Point(502, 509);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(81, 21);
            this.bSend.TabIndex = 25;
            this.bSend.Text = "SEND";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(32, 510);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(457, 20);
            this.textBox3.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(32, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "MESSAGES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(66, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "PLAYERS";
            // 
            // tMessages
            // 
            this.tMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tMessages.Location = new System.Drawing.Point(32, 392);
            this.tMessages.Multiline = true;
            this.tMessages.Name = "tMessages";
            this.tMessages.ReadOnly = true;
            this.tMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tMessages.Size = new System.Drawing.Size(551, 102);
            this.tMessages.TabIndex = 21;
            this.tMessages.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tPlayers
            // 
            this.tPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tPlayers.Location = new System.Drawing.Point(12, 65);
            this.tPlayers.Multiline = true;
            this.tPlayers.Name = "tPlayers";
            this.tPlayers.ReadOnly = true;
            this.tPlayers.Size = new System.Drawing.Size(183, 267);
            this.tPlayers.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(66, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "PlayerName";
            // 
            // tQuestion
            // 
            this.tQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tQuestion.Location = new System.Drawing.Point(0, -1);
            this.tQuestion.Name = "tQuestion";
            this.tQuestion.ReadOnly = true;
            this.tQuestion.Size = new System.Drawing.Size(483, 267);
            this.tQuestion.TabIndex = 44;
            this.tQuestion.Text = "";
            this.tQuestion.Visible = false;
            // 
            // pButtons
            // 
            this.pButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pButtons.Controls.Add(this.prBar);
            this.pButtons.Controls.Add(this.tQuestion);
            this.pButtons.Location = new System.Drawing.Point(217, 65);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(483, 267);
            this.pButtons.TabIndex = 45;
            // 
            // prBar
            // 
            this.prBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.prBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.prBar.ForeColor = System.Drawing.Color.DimGray;
            this.prBar.Location = new System.Drawing.Point(0, 248);
            this.prBar.Maximum = 15000;
            this.prBar.Name = "prBar";
            this.prBar.Size = new System.Drawing.Size(483, 19);
            this.prBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prBar.TabIndex = 47;
            // 
            // bAnswer
            // 
            this.bAnswer.BackColor = System.Drawing.Color.Maroon;
            this.bAnswer.Location = new System.Drawing.Point(628, 338);
            this.bAnswer.Name = "bAnswer";
            this.bAnswer.Size = new System.Drawing.Size(75, 23);
            this.bAnswer.TabIndex = 46;
            this.bAnswer.UseVisualStyleBackColor = false;
            this.bAnswer.Click += new System.EventHandler(this.bAnswer_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(764, 542);
            this.Controls.Add(this.bAnswer);
            this.Controls.Add(this.pButtons);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tMessages);
            this.Controls.Add(this.tPlayers);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Activated += new System.EventHandler(this.Form2_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.pButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public System.Windows.Forms.ProgressBar prBar;

        private System.Windows.Forms.Button bAnswer;

        private System.Windows.Forms.Panel pButtons;

        private System.Windows.Forms.RichTextBox tQuestion;

        private System.Windows.Forms.Button bStart;

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tMessages;
        private System.Windows.Forms.TextBox tPlayers;
        private System.Windows.Forms.Label label9;
    }
}