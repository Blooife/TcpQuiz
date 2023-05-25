using System.ComponentModel;

namespace Playhub
{
    partial class EnterAnswer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.tAnswer = new System.Windows.Forms.TextBox();
            this.bOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tAnswer
            // 
            this.tAnswer.Location = new System.Drawing.Point(83, 67);
            this.tAnswer.Name = "tAnswer";
            this.tAnswer.Size = new System.Drawing.Size(100, 20);
            this.tAnswer.TabIndex = 0;
            // 
            // bOk
            // 
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(95, 116);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 36);
            this.bOk.TabIndex = 1;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // EnterAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 187);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.tAnswer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterAnswer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EnterAnswer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox tAnswer;
        private System.Windows.Forms.Button bOk;

        #endregion
    }
}