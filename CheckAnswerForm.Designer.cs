using System.ComponentModel;

namespace Playhub
{
    partial class CheckAnswer
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
            this.bYes = new System.Windows.Forms.Button();
            this.bNo = new System.Windows.Forms.Button();
            this.lText = new System.Windows.Forms.Label();
            this.tText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // bYes
            // 
            this.bYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bYes.Location = new System.Drawing.Point(158, 175);
            this.bYes.Name = "bYes";
            this.bYes.Size = new System.Drawing.Size(75, 23);
            this.bYes.TabIndex = 0;
            this.bYes.Text = "Yes";
            this.bYes.UseVisualStyleBackColor = true;
            // 
            // bNo
            // 
            this.bNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bNo.Location = new System.Drawing.Point(62, 175);
            this.bNo.Name = "bNo";
            this.bNo.Size = new System.Drawing.Size(75, 23);
            this.bNo.TabIndex = 1;
            this.bNo.Text = "No";
            this.bNo.UseVisualStyleBackColor = true;
            // 
            // lText
            // 
            this.lText.Location = new System.Drawing.Point(77, 73);
            this.lText.Name = "lText";
            this.lText.Size = new System.Drawing.Size(100, 23);
            this.lText.TabIndex = 2;
            // 
            // tText
            // 
            this.tText.Location = new System.Drawing.Point(37, 29);
            this.tText.Name = "tText";
            this.tText.ReadOnly = true;
            this.tText.Size = new System.Drawing.Size(222, 96);
            this.tText.TabIndex = 3;
            this.tText.Text = "";
            // 
            // CheckAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 219);
            this.Controls.Add(this.tText);
            this.Controls.Add(this.lText);
            this.Controls.Add(this.bNo);
            this.Controls.Add(this.bYes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckAnswer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CheckAnswer";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RichTextBox tText;

        private System.Windows.Forms.Button bYes;
        private System.Windows.Forms.Button bNo;
        private System.Windows.Forms.Label lText;

        #endregion
    }
}