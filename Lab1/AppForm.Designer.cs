
namespace Lab1
{
    partial class AppForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Label();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.labelFile = new System.Windows.Forms.Label();
            this.toolPanel = new System.Windows.Forms.Panel();
            this.DesButton = new System.Windows.Forms.Button();
            this.AscButton = new System.Windows.Forms.Button();
            this.keyInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.crack = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.alphabet = new System.Windows.Forms.ComboBox();
            this.decypher = new System.Windows.Forms.Button();
            this.cypher = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.labelFileSave = new System.Windows.Forms.Label();
            this.textField = new System.Windows.Forms.RichTextBox();
            this.resultText = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.TextBox();
            this.rawText = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.toolPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.header.ForeColor = System.Drawing.Color.Snow;
            this.header.Location = new System.Drawing.Point(362, 30);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(198, 33);
            this.header.TabIndex = 0;
            this.header.Text = "Сryptographer";
            this.header.Click += new System.EventHandler(this.label1_Click);
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(110, 101);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(75, 23);
            this.loadFileButton.TabIndex = 1;
            this.loadFileButton.Text = "Browse";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFile.ForeColor = System.Drawing.Color.Snow;
            this.labelFile.Location = new System.Drawing.Point(6, 101);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(98, 23);
            this.labelFile.TabIndex = 2;
            this.labelFile.Text = "Select File";
            this.labelFile.Click += new System.EventHandler(this.labelFile_Click);
            // 
            // toolPanel
            // 
            this.toolPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolPanel.Controls.Add(this.DesButton);
            this.toolPanel.Controls.Add(this.AscButton);
            this.toolPanel.Controls.Add(this.keyInput);
            this.toolPanel.Controls.Add(this.label2);
            this.toolPanel.Controls.Add(this.crack);
            this.toolPanel.Controls.Add(this.aboutButton);
            this.toolPanel.Controls.Add(this.label1);
            this.toolPanel.Controls.Add(this.alphabet);
            this.toolPanel.Controls.Add(this.decypher);
            this.toolPanel.Controls.Add(this.cypher);
            this.toolPanel.Controls.Add(this.saveFileButton);
            this.toolPanel.Controls.Add(this.labelFileSave);
            this.toolPanel.Controls.Add(this.loadFileButton);
            this.toolPanel.Controls.Add(this.labelFile);
            this.toolPanel.Location = new System.Drawing.Point(762, 0);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(223, 565);
            this.toolPanel.TabIndex = 3;
            // 
            // DesButton
            // 
            this.DesButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.DesButton.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DesButton.ForeColor = System.Drawing.Color.White;
            this.DesButton.Location = new System.Drawing.Point(110, 247);
            this.DesButton.Name = "DesButton";
            this.DesButton.Size = new System.Drawing.Size(98, 29);
            this.DesButton.TabIndex = 13;
            this.DesButton.Text = "Descending";
            this.DesButton.UseVisualStyleBackColor = false;
            this.DesButton.Click += new System.EventHandler(this.DesButton_Click);
            // 
            // AscButton
            // 
            this.AscButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.AscButton.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AscButton.ForeColor = System.Drawing.Color.White;
            this.AscButton.Location = new System.Drawing.Point(6, 247);
            this.AscButton.Name = "AscButton";
            this.AscButton.Size = new System.Drawing.Size(98, 29);
            this.AscButton.TabIndex = 11;
            this.AscButton.Text = "Ascending";
            this.AscButton.UseVisualStyleBackColor = false;
            this.AscButton.Click += new System.EventHandler(this.AscButton_Click);
            // 
            // keyInput
            // 
            this.keyInput.Location = new System.Drawing.Point(85, 221);
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(100, 23);
            this.keyInput.TabIndex = 12;
            this.keyInput.Click += new System.EventHandler(this.KeyClick);
            this.keyInput.TextChanged += new System.EventHandler(this.KeyChanged);
            this.keyInput.Leave += new System.EventHandler(this.KeyChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(6, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Key";
            // 
            // crack
            // 
            this.crack.BackColor = System.Drawing.SystemColors.Desktop;
            this.crack.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crack.ForeColor = System.Drawing.Color.White;
            this.crack.Location = new System.Drawing.Point(48, 292);
            this.crack.Name = "crack";
            this.crack.Size = new System.Drawing.Size(110, 70);
            this.crack.TabIndex = 10;
            this.crack.Text = "Crack";
            this.crack.UseVisualStyleBackColor = false;
            this.crack.Click += new System.EventHandler(this.crack_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(6, 12);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(190, 25);
            this.aboutButton.TabIndex = 9;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(6, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alphabet";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // alphabet
            // 
            this.alphabet.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.alphabet.FormattingEnabled = true;
            this.alphabet.Location = new System.Drawing.Point(98, 185);
            this.alphabet.Name = "alphabet";
            this.alphabet.Size = new System.Drawing.Size(87, 22);
            this.alphabet.TabIndex = 7;
            this.alphabet.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // decypher
            // 
            this.decypher.BackColor = System.Drawing.SystemColors.Desktop;
            this.decypher.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.decypher.ForeColor = System.Drawing.Color.White;
            this.decypher.Location = new System.Drawing.Point(48, 469);
            this.decypher.Name = "decypher";
            this.decypher.Size = new System.Drawing.Size(110, 70);
            this.decypher.TabIndex = 6;
            this.decypher.Text = "Decipher";
            this.decypher.UseVisualStyleBackColor = false;
            this.decypher.Click += new System.EventHandler(this.decypher_Click);
            // 
            // cypher
            // 
            this.cypher.BackColor = System.Drawing.SystemColors.Desktop;
            this.cypher.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cypher.ForeColor = System.Drawing.Color.White;
            this.cypher.Location = new System.Drawing.Point(48, 379);
            this.cypher.Name = "cypher";
            this.cypher.Size = new System.Drawing.Size(110, 70);
            this.cypher.TabIndex = 5;
            this.cypher.Text = "Cipher";
            this.cypher.UseVisualStyleBackColor = false;
            this.cypher.Click += new System.EventHandler(this.cypher_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(110, 134);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(75, 23);
            this.saveFileButton.TabIndex = 4;
            this.saveFileButton.Text = "Save";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // labelFileSave
            // 
            this.labelFileSave.AutoSize = true;
            this.labelFileSave.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFileSave.ForeColor = System.Drawing.Color.Snow;
            this.labelFileSave.Location = new System.Drawing.Point(6, 134);
            this.labelFileSave.Name = "labelFileSave";
            this.labelFileSave.Size = new System.Drawing.Size(86, 23);
            this.labelFileSave.TabIndex = 3;
            this.labelFileSave.Text = "Save File";
            // 
            // textField
            // 
            this.textField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textField.Location = new System.Drawing.Point(30, 100);
            this.textField.Name = "textField";
            this.textField.Size = new System.Drawing.Size(700, 188);
            this.textField.TabIndex = 4;
            this.textField.Text = "";
            this.textField.TextChanged += new System.EventHandler(this.textField_TextChanged);
            // 
            // resultText
            // 
            this.resultText.AutoSize = true;
            this.resultText.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resultText.ForeColor = System.Drawing.Color.White;
            this.resultText.Location = new System.Drawing.Point(30, 318);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(120, 23);
            this.resultText.TabIndex = 5;
            this.resultText.Text = "Result Text:";
            // 
            // result
            // 
            this.result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.result.Location = new System.Drawing.Point(30, 344);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(700, 188);
            this.result.TabIndex = 6;
            this.result.TextChanged += new System.EventHandler(this.result_TextChanged);
            // 
            // rawText
            // 
            this.rawText.AutoSize = true;
            this.rawText.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rawText.ForeColor = System.Drawing.Color.White;
            this.rawText.Location = new System.Drawing.Point(30, 74);
            this.rawText.Name = "rawText";
            this.rawText.Size = new System.Drawing.Size(108, 23);
            this.rawText.TabIndex = 7;
            this.rawText.Text = "Plain Text:";
            this.rawText.Click += new System.EventHandler(this.rawText_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(785, 560);
            this.mainPanel.TabIndex = 8;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.rawText);
            this.Controls.Add(this.result);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.textField);
            this.Controls.Add(this.toolPanel);
            this.Controls.Add(this.header);
            this.Controls.Add(this.mainPanel);
            this.Name = "AppForm";
            this.Text = "Cyphering";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Panel toolPanel;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Label labelFileSave;
        private System.Windows.Forms.RichTextBox textField;
        private System.Windows.Forms.Button decypher;
        private System.Windows.Forms.Button cypher;
        private System.Windows.Forms.Label resultText;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Label rawText;
        private System.Windows.Forms.ComboBox alphabet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button crack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox keyInput;
        private System.Windows.Forms.Button DesButton;
        private System.Windows.Forms.Button AscButton;
    }
}

