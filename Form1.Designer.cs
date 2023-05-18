namespace Playhub
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreateGame = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.tWinPoint = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.tNumOfPl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cgamerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cgameName = new System.Windows.Forms.TextBox();
            this.cgamePort = new System.Windows.Forms.TextBox();
            this.cgameIp = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lgameIp = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lgamePort = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lgamerName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(104, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUIZ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreateGame);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.tWinPoint);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.tNumOfPl);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cgamerName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cgameName);
            this.groupBox1.Controls.Add(this.cgamePort);
            this.groupBox1.Controls.Add(this.cgameIp);
            this.groupBox1.Location = new System.Drawing.Point(68, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 281);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create A Game";
            // 
            // btnCreateGame
            // 
            this.btnCreateGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCreateGame.Location = new System.Drawing.Point(6, 233);
            this.btnCreateGame.Name = "btnCreateGame";
            this.btnCreateGame.Size = new System.Drawing.Size(216, 23);
            this.btnCreateGame.TabIndex = 24;
            this.btnCreateGame.Text = "CREATE GAME";
            this.btnCreateGame.UseVisualStyleBackColor = true;
            this.btnCreateGame.Click += new System.EventHandler(this.btnCreateGame_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(30, 191);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 33;
            this.label18.Text = "Win Point";
            // 
            // tWinPoint
            // 
            this.tWinPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tWinPoint.Location = new System.Drawing.Point(9, 207);
            this.tWinPoint.Name = "tWinPoint";
            this.tWinPoint.Size = new System.Drawing.Size(107, 20);
            this.tWinPoint.TabIndex = 32;
            this.tWinPoint.Text = "100";
            this.tWinPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(121, 191);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(92, 13);
            this.label.TabIndex = 25;
            this.label.Text = "Number of players";
            // 
            // tNumOfPl
            // 
            this.tNumOfPl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tNumOfPl.Location = new System.Drawing.Point(127, 207);
            this.tNumOfPl.Name = "tNumOfPl";
            this.tNumOfPl.Size = new System.Drawing.Size(68, 20);
            this.tNumOfPl.TabIndex = 24;
            this.tNumOfPl.Text = "3";
            this.tNumOfPl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(72, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "GAME SETTINGS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(50, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "GAME AREA SETTINGS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Player Name";
            // 
            // cgamerName
            // 
            this.cgamerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cgamerName.Location = new System.Drawing.Point(9, 131);
            this.cgamerName.Name = "cgamerName";
            this.cgamerName.Size = new System.Drawing.Size(216, 20);
            this.cgamerName.TabIndex = 8;
            this.cgamerName.Text = "enter name";
            this.cgamerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "IP Address";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(92, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Game Name";
            // 
            // cgameName
            // 
            this.cgameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cgameName.Location = new System.Drawing.Point(9, 46);
            this.cgameName.Name = "cgameName";
            this.cgameName.Size = new System.Drawing.Size(216, 20);
            this.cgameName.TabIndex = 5;
            this.cgameName.Text = "GameName";
            this.cgameName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cgamePort
            // 
            this.cgamePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cgamePort.Location = new System.Drawing.Point(172, 88);
            this.cgamePort.Name = "cgamePort";
            this.cgamePort.Size = new System.Drawing.Size(53, 20);
            this.cgamePort.TabIndex = 4;
            this.cgamePort.Text = "1710";
            this.cgamePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cgameIp
            // 
            this.cgameIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cgameIp.Location = new System.Drawing.Point(9, 88);
            this.cgameIp.Name = "cgameIp";
            this.cgameIp.Size = new System.Drawing.Size(157, 20);
            this.cgameIp.TabIndex = 3;
            this.cgameIp.Text = "127.0.0.1";
            this.cgameIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(9, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "JOIN GAME";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lgameIp);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lgamePort);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lgamerName);
            this.groupBox2.Location = new System.Drawing.Point(68, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 152);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Join A Game";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(72, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "GAME SETTINGS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(187, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Port";
            // 
            // lgameIp
            // 
            this.lgameIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lgameIp.Location = new System.Drawing.Point(9, 88);
            this.lgameIp.Name = "lgameIp";
            this.lgameIp.Size = new System.Drawing.Size(157, 20);
            this.lgameIp.TabIndex = 17;
            this.lgameIp.Text = "127.0.0.1";
            this.lgameIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "IP Address";
            // 
            // lgamePort
            // 
            this.lgamePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lgamePort.Location = new System.Drawing.Point(172, 88);
            this.lgamePort.Name = "lgamePort";
            this.lgamePort.Size = new System.Drawing.Size(53, 20);
            this.lgamePort.TabIndex = 18;
            this.lgamePort.Text = "1710";
            this.lgamePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(92, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Player Name";
            // 
            // lgamerName
            // 
            this.lgamerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lgamerName.Location = new System.Drawing.Point(9, 46);
            this.lgamerName.Name = "lgamerName";
            this.lgamerName.Size = new System.Drawing.Size(216, 20);
            this.lgamerName.TabIndex = 19;
            this.lgamerName.Text = "enter name";
            this.lgamerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 540);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Welcome";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cgamerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox cgameName;
        private System.Windows.Forms.TextBox cgamePort;
        private System.Windows.Forms.TextBox cgameIp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCreateGame;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox lgameIp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox lgamePort;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox lgamerName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tWinPoint;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox tNumOfPl;
    }
}

