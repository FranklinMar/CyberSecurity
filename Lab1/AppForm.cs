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

namespace Lab1
{
    public partial class AppForm : Form
    {
        private List<ICypher> Cyphers;
        private List<ICracker> Crackers;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();

        public AppForm(List<ICypher> Cyphers, List<ICracker> Crackers, string Key = null)
        {
            if (Key != null)
            {
                foreach (ICypher cypher in Cyphers)
                {
                    cypher.Key = Key;
                }
            }
            this.Cyphers = Cyphers;
            this.Crackers = Crackers;
            InitializeComponent();
        }

        private void AppLoad(object sender, EventArgs e)
        {
            AscButton.Hide();
            DesButton.Hide();
            alphabet.SelectedItem = null;
            alphabet.SelectedText = "--SELECT--";
            foreach (ICypher cypher in Cyphers)
            {
                alphabet.Items.Add(cypher.Name);
            }
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
            if (alphabet.SelectedItem == null)
            {
                MessageBox.Show("Please, select alphabet to cypher");
                return;
            }
            ICypher cypher = Cyphers.Find(cy => cy.Name.Equals(alphabet.SelectedItem));
            result.Text = cypher.Encrypt(textField.Text);
        }

        private void decypher_Click(object sender, EventArgs e)
        {
            if (alphabet.SelectedItem == null)
            {
                MessageBox.Show("Please, select alphabet to decypher");
                return;
            }
            ICypher cypher = Cyphers.Find(cy => cy.Name.Equals(alphabet.SelectedItem));
            result.Text = cypher.Decrypt(textField.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AscButton.Show();
            DesButton.Show();
            ICypher Cypher = Cyphers.Find(cy => cy.Name.Equals(alphabet.SelectedItem));
            if (Cypher == null)
            {
                MessageBox.Show("Unexpected error.\nCypher not found.");
                return;
            }
            keyInput.Text = Cypher.Key;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            About About = new();
            About.Show();
        }

        private void rawText_Click(object sender, EventArgs e)
        {

        }

        private void crack_Click(object sender, EventArgs e)
        {
            if (alphabet.SelectedItem == null)
            {
                MessageBox.Show("Please, select alphabet to crack");
                return;
            }
            ICracker cracker;
            try
            {
                cracker = Crackers.Find(cy => cy.Cypher.Name.Equals(alphabet.SelectedItem));
                
            } catch (Exception)
            {
                MessageBox.Show("Unexpected error.\nDictionary and cracker for this alphabet is not found.");
                return;
            }
            
            string Key = cracker.Key;
            string cracked = "";
            try
            {
                if (resultText.Text == "")
                {
                    cracked = cracker.Crack(textField.Text);
                } else
                {
                    Key = cracker.Crack(textField.Text, resultText.Text);
                }
            } catch (NotImplementedException)
            {
                Key = cracker.Crack(textField.Text, resultText.Text);
            } catch(Exception exception)
            {
                MessageBox.Show($"Unexpected error.\n{exception.Message}");
                return;
            }
            keyInput.Text = Key;
            if (cracked != "")
            {
                result.Text = cracked;
            }
        }



        private void KeyChanged(object sender, EventArgs e)
        {
            if (alphabet.SelectedItem == null)
            {
                MessageBox.Show("Please, select alphabet to cypher");
                return;
            }
            ICypher Cypher = Cyphers.Find(cy => cy.Name.Equals(alphabet.SelectedItem));
            if (Cypher == null)
            {
                MessageBox.Show("Unexpected error.\nCypher not found.");
                return;
            }
            try
            {
                Cypher.Key = keyInput.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Unexpected error.\n{exception.Message}");
            }
        }

        private void KeyClick(object sender, EventArgs e)
        {
            KeyChanged(sender, e);
        }

        private void AscButton_Click(object sender, EventArgs e)
        {
            if (alphabet.SelectedItem == null)
            {
                MessageBox.Show("Unexpected error.");
                return;
            }
            ICypher Cypher = Cyphers.Find(cy => cy.Name.Equals(alphabet.SelectedItem));
            if (Cypher == null)
            {
                MessageBox.Show("Unexpected error.\nCypher not found.");
                return;
            }
            try
            {
                keyInput.Text = Cypher.Alphabet;
                Cypher.Key = keyInput.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Unexpected error.\n{exception.Message}");
            }
        }

        private void DesButton_Click(object sender, EventArgs e)
        {
            if (alphabet.SelectedItem == null)
            {
                MessageBox.Show("Unexpected error.");
                return;
            }
            ICypher Cypher = Cyphers.Find(cy => cy.Name.Equals(alphabet.SelectedItem));
            if (Cypher == null)
            {
                MessageBox.Show("Unexpected error.\nCypher not found.");
                return;
            }
            try
            {
                keyInput.Text = new string(Cypher.Alphabet.ToCharArray().Reverse().ToArray());
                Cypher.Key = keyInput.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Unexpected error.\n{exception.Message}");
            }
        }
    }
}
