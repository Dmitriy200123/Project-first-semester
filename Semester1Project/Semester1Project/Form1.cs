using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semester1Project
{
    public enum Components
    {
        Subject = 1,
        Section = 2,
        Formula = 3,
        None = 4
    }

    public partial class Form1 : Form
    {
        private const double BUTTON_SCALE = 0.1;
        private DataHolder dh;
        public EventHandler SubjectFieldHandler;
        public EventHandler SectionFieldHandler;
        public EventHandler FormulaFieldHandler;
        public EventHandler AddDialogHandler;
        public FormClosedEventHandler DialogFinished;
        public EventHandler TestDialogHandler;

        private GroupBox[] GroupBoxes;
        private int[] groupBoxesRatios = new[] { 4, 4, 2 };

        //private Form AddDialog = new Form();
        private DialogForm Dialog;
        private TestForm Test;
        private ExerciseForm Exercise;
        private string dialogBuffer = "";
        private Components AddTo = Components.None;
        private string[] tree = new string[3];
        private string[] dialogMessages = new[] { "Введите название предмета.", "Введите название раздела.", "Введите название формулы.", "Введите формулу.", "Введите описание формулы." };

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dh = new DataHolder();
            SubjectFieldHandler = new EventHandler(this.SubjectFieldPressed);
            SectionFieldHandler = new EventHandler(this.SectionFieldPressed);
            FormulaFieldHandler = new EventHandler(this.FormulaFieldPressed);
            AddDialogHandler    = new EventHandler(this.DialogButtonPressed);
            DialogFinished      = new FormClosedEventHandler(this.DialogWindowClosed);
            TestDialogHandler = new EventHandler(this.TestDialogButtonPressed);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGroupBoxes(3, groupBoxesRatios);
        }
        private void InitializeGroupBoxes(int number, int[] ratios)
        {
            GroupBoxes = new GroupBox[number];
            var left = 0;
            for (int i = 0; i < number; i++)
            {
                GroupBoxes[i] = new GroupBox();
                GroupBoxes[i].BackColor = Color.Azure;
                GroupBoxes[i].Left = left;
                GroupBoxes[i].Top = this.menuStrip1.Top + this.menuStrip1.Height;
                GroupBoxes[i].Width = this.Width / groupBoxesRatios[i];
                left += GroupBoxes[i].Width;
                GroupBoxes[i].Height = this.Height - GroupBoxes[i].Top;
                this.Controls.Add(GroupBoxes[i]);
            }
        }
        private void CreateButtonGrid(List<string> names, Control parent, EventHandler handler)
        {
            var top = 0;
            foreach (var name in names)
            {
                var btn = new Button();
                parent.Controls.Add(btn);
                btn.Name = name;
                btn.Text = name;
                btn.Top = top;
                btn.Left = 0;
                btn.Width = parent.Width;
                btn.Height = (int)(parent.Height * BUTTON_SCALE);
                btn.Visible = true;
                btn.Click += handler;
                top += btn.Height;
            }
        }
        private void ResizeCheckBoxes()
        {
            var mult = 0;
            for (int i = 0; i < GroupBoxes.Length; i++)
            {
                var c = GroupBoxes[i];
                if (c != null)
                {
                    c.Width = this.Width / groupBoxesRatios[i];
                    c.Left = mult;
                    mult += c.Width;
                    c.Height = this.Height - c.Top;
                    var top = c.Top - 25;
                    foreach (Object b in c.Controls)
                    {
                        if (b.GetType() == typeof(Button))
                        {
                            ((Button)b).Top = top;
                            ((Button)b).Width = c.Width;
                            ((Button)b).Height = (int)(c.Height * BUTTON_SCALE);
                            top += ((Button)b).Height;
                        }
                        else if (b.GetType() == typeof(RichTextBox))
                        {
                            ((RichTextBox)b).Top = top;
                            ((RichTextBox)b).Width = c.Width;
                            ((RichTextBox)b).Height = c.Height / 2;
                            top += ((RichTextBox)b).Height;
                        }

                    }
                }
            }
        }
        private void DisposeControls(Control parent)
        {
            if (parent != null)
            {
                parent.Controls.Clear();
            }
        }

        private void scienceFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateButtonGrid(dh.GetSubjects(), GroupBoxes[0], SubjectFieldHandler);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeCheckBoxes();
        }
        private void SubjectFieldPressed(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Violet;
            foreach (var cntrl in GroupBoxes[0].Controls)
            {
                if (cntrl != sender)
                {
                    ((Button)cntrl).BackColor = Color.Empty;
                }
            }
            tree[0] = ((Button)sender).Name;
            tree[1] = null;
            tree[2] = null;
            DisposeControls(GroupBoxes[1]);
            DisposeControls(GroupBoxes[2]);
            CreateButtonGrid(dh.GetSections(tree[0]), GroupBoxes[1], SectionFieldHandler);
        }
        private void SectionFieldPressed(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Aquamarine;
            var name = ((Button)sender).Name;
            var height = ((Button)sender).Height;
            DisposeControls(GroupBoxes[1]);
            tree[1] = ((Button)sender).Name;
            CreateButtonGrid(dh.GetFormulas(tree[0], tree[1]), GroupBoxes[1], FormulaFieldHandler);
        }
        private void FormulaFieldPressed(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.DarkCyan;
            foreach (var cntrl in GroupBoxes[1].Controls)
            {
                if (cntrl != sender)
                {
                    ((Button)cntrl).BackColor = Color.Empty;
                }
            }
            DisposeControls(GroupBoxes[2]);
            var name = ((Button)sender).Name;
            tree[2] = name;
            var textBox = new RichTextBox();
            textBox.Top = 0;
            textBox.Left = 0;
            textBox.Visible = true;
            textBox.Enabled = false;
            textBox.Width = GroupBoxes[2].Width;
            textBox.Height = GroupBoxes[2].Height / 2;
            foreach (var str in dh.GetFormulaDescrption(tree[0], tree[1], tree[2]))
            {
                textBox.Text += str + "\n\n";
            }
            GroupBoxes[2].Controls.Add(textBox);
        }
        private void RefreshSubjects()
        {
            DisposeControls(GroupBoxes[0]);
            DisposeControls(GroupBoxes[1]);
            DisposeControls(GroupBoxes[2]);
            //CreateButtonGrid(dh.FieldNames, GroupBoxes[0], SubjectFieldHandler);
        }
        private void FieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog = new DialogForm("Добавить предмет.", 1, AddDialogHandler, DialogFinished, dialogMessages[0]);
            Dialog.Show();
            AddTo = Components.Subject;
        }
        private void DialogWindowClosed(Object sender, FormClosedEventArgs e)
        {
            if (string.IsNullOrEmpty(dialogBuffer)) AddTo = Components.None;
            switch ((int)AddTo)
            {
                case (1):
                    dh.AddSubject(dialogBuffer);
                    break;
                case (2):
                    dh.AddSection(dialogBuffer);
                    break;
                case (3):
                    dh.AddFormula(dialogBuffer);
                    break;
                default:
                    break;
            }
            AddTo = Components.None;
            dialogBuffer = "";
            RefreshSubjects();
            this.Refresh();
        }
        private void DialogButtonPressed(Object sender, EventArgs e)
        {
            foreach (var cntrl in Dialog.Controls)
            {
                if (cntrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)cntrl).BackColor = Color.Yellow;
                    if (string.IsNullOrEmpty(((TextBox)cntrl).Text))
                    {
                        AddTo = Components.None;
                        continue;
                    }
                    dialogBuffer += ((TextBox)cntrl).Text + "\n";
                    Debug.WriteLine(((TextBox)cntrl).Text);
                }
            }
            Dialog.Close();
        }
        private void GroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog = new DialogForm("Добавить раздел.", 2, AddDialogHandler, DialogFinished, dialogMessages[0], dialogMessages[1]);
            Dialog.Show();
            AddTo = Components.Section;
        }
        private void FormulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog = new DialogForm("Добавить формулу.", 5, AddDialogHandler, DialogFinished, dialogMessages[0], 
                                                                         dialogMessages[1], 
                                                                         dialogMessages[2], 
                                                                         dialogMessages[3], 
                                                                         dialogMessages[4]);
            Dialog.Show();
            AddTo = Components.Formula;
        }

        private void RunGroupTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog = new DialogForm("Запустить тест раздела.", 2, TestDialogHandler, null, dialogMessages[0], dialogMessages[1]);
            Dialog.Show();
        }

        private void TestDialogButtonPressed(Object sender, EventArgs e)
        {
            foreach (var cntrl in Dialog.Controls)
            {
                if (cntrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)cntrl).BackColor = Color.Yellow;
                    if (string.IsNullOrEmpty(((TextBox)cntrl).Text))
                    {
                        AddTo = Components.None;
                        continue;
                    }
                    dialogBuffer += ((TextBox)cntrl).Text + "\n";
                    Debug.WriteLine(((TextBox)cntrl).Text);
                }
            }
            Dialog.Close();
            Test = new TestForm("Тест раздела.");
            Test.Show();
        }

        private void CreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exercise = new ExerciseForm();
            Exercise.Show();
        }
    }
 }  