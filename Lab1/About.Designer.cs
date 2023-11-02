
namespace Lab1
{
    partial class About
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
            this.rawText = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rawText
            // 
            this.rawText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawText.AutoSize = true;
            this.rawText.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rawText.ForeColor = System.Drawing.Color.White;
            this.rawText.Location = new System.Drawing.Point(60, 80);
            this.rawText.MaximumSize = new System.Drawing.Size(800, 0);
            this.rawText.Name = "rawText";
            this.rawText.Size = new System.Drawing.Size(795, 46);
            this.rawText.TabIndex = 9;
            this.rawText.Text = "\"Cesar cryptographer\" is a crypting software created by Denys Berezniuk for a NTU" +
    "U \"KPI\" University course, of Software Cybesecurity.";
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.header.ForeColor = System.Drawing.Color.Snow;
            this.header.Location = new System.Drawing.Point(454, 30);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(92, 33);
            this.header.TabIndex = 8;
            this.header.Text = "About";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.rawText);
            this.Controls.Add(this.header);
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rawText;
        private System.Windows.Forms.Label header;
    }
}