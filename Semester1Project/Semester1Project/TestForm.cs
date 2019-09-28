using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semester1Project
{
    public partial class TestForm : Form
    {
        //EventHandler CheckButton = new EventHandler();
        private int testsDone = 0;
        private int numberOfTests = 2;
        private string answer = "";
        private TestDataHolder tdh = new TestDataHolder();
        private EventHandler GridButton;
        private EventHandler EraseButton;
        private EventHandler CheckButton;
        public TestForm(string name)
        {
            InitializeComponent();

            this.Text = name;

            GridButton = new EventHandler(this.GridButtonPressed);
            EraseButton = new EventHandler(this.EraseButtonPressed);
            CheckButton = new EventHandler(this.CheckButtonPressed);
            this.button2.Click += EraseButton;
            this.button1.Click += CheckButton;
            this.richTextBox1.Text = $"Вопросов сделано {testsDone}/{numberOfTests}";
            this.richTextBox2.Text = "Площадь треугольника.";
            GenerateButtonGrid();
        }

        private void UpdateTextBoxes()
        {
            this.richTextBox1.Text = $"Вопросов сделано {testsDone}/{numberOfTests}";
            this.richTextBox2.Text = "Площадь треугольника.";
            answer = "";
            this.textBox1.Text = answer;
        }

        private void GenerateButtonGrid()
        {
            var num = tdh.Tokens.Length * 2;

            var top = this.textBox1.Top + this.textBox1.Height;
            var left = 0;
            var width = 2 * this.Width / num;
            var height = 30;
            var j = 0;
            for (int i = 0; i < num; i++)
            {
                var btn = new Button();
                btn.Click += GridButton;
                btn.Width = width;
                btn.Height = height;
                if (i == num / 2)
                {
                    top += height;
                    left = 0;
                }
                btn.Top = top;
                btn.Left = left;
                left += width;
                if (i % 2 == 0)
                {
                    btn.Text = tdh.Tokens[j++];
                }
                else
                {
                    btn.Text = tdh.GetRandomSymbol().ToString();
                }
                this.Controls.Add(btn);
            }
        }

        private void GridButtonPressed(Object sender, EventArgs e)
        {
            answer += ((Button)sender).Text;
            this.textBox1.Text = answer;
        }

        private void EraseButtonPressed(Object sender, EventArgs e)
        {
            //this.BackColor = Color.CadetBlue;
            if (answer.Length > 0)
            {
                answer = answer.Substring(0, answer.Length - 1);
                this.textBox1.Text = answer;
            }
        }

        private void CheckButtonPressed(Object sender, EventArgs e)
        {
            testsDone++;
            // TODO: answer checking
            // TODO: points incrementing
            if (testsDone == numberOfTests)
            {
                FinishTesting();
            }
            UpdateTextBoxes();
            GenerateButtonGrid();
            this.Update();
        }

        private void FinishTesting()
        {
            MessageBox.Show($"Правильных ответов <заглушка>/{numberOfTests}.", "Тест окончен.");
            this.Close();
        }
    }
}
