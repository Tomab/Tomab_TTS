using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Speech;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Tomabs_Text_to_Speech
{
    public partial class Form1 : Form
    {
        private SpeechSynthesizer SpeechEngine;
        private string LastText;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SpeechEngine = new SpeechSynthesizer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeakStuff();
        }

        private void SpeakStuff()
        {
            SpeechEngine.SpeakAsync(textBox1.Text);
            LastText = textBox1.Text;
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.KeyChar = ' ';
                SpeakStuff();
            }
            else if (e.KeyChar == (char)Keys.Up)
            {
                textBox1.Text = LastText;
            }
        }
    }
}
