using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string validChars;

        const string small_letters = "qwertyuiopasdfghjklzxcvbnm";
        const string big_letters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        const string numbers = "1234567890";
        const string special_symbols = "!@#$%^&*()";

        StringBuilder password = new StringBuilder();
        Random rnd = new Random();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if
            (
              !(checkBox1.Checked)
              || !(checkBox2.Checked)
              || !(checkBox3.Checked)
              || !(checkBox4.Checked)
            ) MessageBox.Show("Sve opcije trebaju biti uključene");

            else
            {
                // read password length
                int length = Convert.ToInt32(comboBox1.Text);

                // Generate password
                generatePassword(length, password, rnd);

                bool correctPassword = DoesContainBigLetters() &&
                                       DoesContainSmallLetters() &&
                                       DoesContainNumbers() &&
                                       DoesContainSpecialSymbols();

                while (!correctPassword)
                {
                   generatePassword(length, password, rnd);

                   correctPassword = DoesContainBigLetters() &&
                                        DoesContainSmallLetters() &&
                                        DoesContainNumbers() &&
                                        DoesContainSpecialSymbols();
                }

                //show password in the textbox
                textBox1.Text = password.ToString();
            }
        }
        
        public bool DoesContainSmallLetters()
        {
            var does_contain = false;

            for (int i = 0; i < small_letters.Length; i++) if (password.ToString().Contains(small_letters[i])) does_contain = true;
            
            return does_contain;
        }

        public bool DoesContainBigLetters()
        {
            var does_contain = false;

            for (int i = 0; i < big_letters.Length; i++) if (password.ToString().Contains(big_letters[i])) does_contain = true;
            
            return does_contain;
        }

        public bool DoesContainNumbers()
        {
            var does_contain = false;

            for (int i = 0; i < numbers.Length; i++) if (password.ToString().Contains(numbers[i])) does_contain = true;

            return does_contain;
        }

        public bool DoesContainSpecialSymbols()
        {
            var does_contain = false;

            for (int i = 0; i < special_symbols.Length; i++) if (password.ToString().Contains(special_symbols[i])) does_contain = true;
            
            return does_contain;
        }
        
        static void generatePassword(int length, StringBuilder password, Random rnd)
        {
            validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890?!@#$%^&*";
            password.Length = 0;

            // Generate password
            while (0 < length--)
            {
                password.Append(validChars[rnd.Next(validChars.Length)]);
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox1.Text);
            }
        }
    }
}
