using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Lab1;


namespace Lab3
{
    public partial class AppForm : Form
    {
        private BookCypher Cypher;
        //private char[][] Key;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();
        public static void AllocateConsole()
        {
            AllocConsole();
            Console.OutputEncoding = Encoding.UTF8;
        }

        public AppForm(BookCypher Cypher)
        {
            this.Cypher = Cypher;
            InitializeComponent();
        }

        private void AppLoad(object sender, EventArgs e)
        {
            keyImportButton.Hide();
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "Text files | *.txt"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            //if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            //{
            String path = dialog.FileName; // get name of file
            using (StreamReader reader = new(
                new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
            {
                textField.Text = reader.ReadToEnd();
                // ...
            }
            //}
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new();
            //dialog.DefaultExt = ".txt";
            dialog.Filter = "Text files | *.txt"; // file types, that will be allowed to upload
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            //if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            //{
            // get selected file
            string filename = dialog.FileName;
            // save text into the file
            System.IO.File.WriteAllText(filename, result.Text);
            MessageBox.Show("File saved");
            //}
        }

        private void cypher_Click(object sender, EventArgs e)
        {
            try
            {
                result.Text = Cypher.Encrypt(textField.Text);

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Unexpected error.\n{exception.Message}");
                return;
            }
        }

        private void decypher_Click(object sender, EventArgs e)
        {
            try
            {
                result.Text = Cypher.Decrypt(textField.Text);

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Unexpected error.\n{exception.Message}");
                return;
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            About About = new();
            About.Show();
        }

        private void keyImportButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "Text files | *.txt"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            //if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            //{
            String path = dialog.FileName; // get name of file
            using (StreamReader reader = new(
                new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
            {
                textField.Text = reader.ReadToEnd();
                // ...
            }
        }

        private void keyInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                keyInput.Text = keyInput.Text.ToLower();
                Cypher.KeyString = keyInput.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Unexpected error.\n{exception.Message}");
            }
        }
    }
}
