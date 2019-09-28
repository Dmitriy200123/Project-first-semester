using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semester1Project
{
    public class DialogForm : Form
    {
        private TextBox[] Fields;
        private RichTextBox[] FieldDescriptions;
        private EventHandler ButtonHandler;
        private FormClosedEventHandler CloseHandler;
        private const int SIZE = 360;

        public DialogForm(string name, int numberOfFileds, EventHandler btnHandler, FormClosedEventHandler closeHandler, params string[] descriptions)
        {
            this.Text = name;
            this.BackColor = Color.NavajoWhite;
            Fields = new TextBox[numberOfFileds];
            FieldDescriptions = new RichTextBox[numberOfFileds];
            for (int i = 0; i < numberOfFileds; i++)
            {
                Fields[i] = new TextBox();
                FieldDescriptions[i] = new RichTextBox();
                FieldDescriptions[i].Text = descriptions[i];
            }
            ButtonHandler = btnHandler;
            CloseHandler  = closeHandler;
            Initialize();
        }

        private void Initialize()
        {
            this.Width = SIZE;
            this.Height = SIZE;
            this.FormClosed += CloseHandler;

            var top = 10;
            var fieldLeft = this.Width / 2 - 60;
            var descriptionLeft = fieldLeft - 40;
            var descriptionWidth = 170;
            var descriptionHeight = 30;

            var btn = new Button();
            btn.Width = 50;
            btn.Height = 25;
            btn.Left = this.Width / 2 - 30;
            btn.Top = this.Height - 70;
            btn.Text = "OK";
            btn.Visible = true;
            btn.Click += ButtonHandler;
            this.Controls.Add(btn);

            for (int i = 0; i < Fields.Length; i++)
            {
                FieldDescriptions[i].Top = top;
                FieldDescriptions[i].Left = descriptionLeft;
                FieldDescriptions[i].Width = descriptionWidth;
                FieldDescriptions[i].Height = descriptionHeight;
                FieldDescriptions[i].Visible = true;
                FieldDescriptions[i].Enabled = false;
                top += FieldDescriptions[i].Height + 3;

                Fields[i].Top = top;
                Fields[i].Left = fieldLeft;
                Fields[i].Visible = true;
                top += Fields[i].Height + 3;

                this.Controls.Add(Fields[i]);
                this.Controls.Add(FieldDescriptions[i]);
            }
        }
    }
}
