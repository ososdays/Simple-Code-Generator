using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int RemainingKeys;
        public Form1()
        {
            InitializeComponent();
            RemainingKeys = 5;
            label1.Text = Convert.ToString(RemainingKeys);
        }
        private Random random = new Random();
        private string GenerateWord(int WordLength)
        {
            string GeneratedWord = "";
            for(short i = 0;i<WordLength;i++)
            {
                GeneratedWord += Convert.ToChar(random.Next('A', 'Z' + 1));
            }
            return GeneratedWord;
        }
        private string GenerateKey(int WordsNumber,string Seperator = "-")
        {
            string Key = "";
            for(short i = 0; i<WordsNumber;i++)
            {
                Key += GenerateWord(4) + Seperator;
            }
            return Key.Substring(0,Key.Length - 1);
        }
        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            if(RemainingKeys <= 0)
            {
                lblGenerateMassage.Text = "No Remaining Keys.";
                lblGenerateMassage.ForeColor = Color.Red;
                await Task.Delay(1000);
                lblGenerateMassage.ForeColor = Color.Black;
                return;
            }
            txtGeneratedKey.Text = GenerateKey(4);
            lblGenerateMassage.ForeColor = Color.Green;
            await Task.Delay(1000);
            lblGenerateMassage.ForeColor = Color.Black;
            RemainingKeys--;
            label1.Text = RemainingKeys.ToString();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            RemainingKeys = 5;
            label1.Text = RemainingKeys.ToString();
        }
    }
}
