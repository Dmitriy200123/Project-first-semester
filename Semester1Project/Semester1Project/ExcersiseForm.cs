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
    public partial class ExerciseForm : Form
    {
        private ExerciseDataHolder edh = new ExerciseDataHolder();
        private const double BUTTON_SCALE = 0.1;
        private EventHandler SubjectHandler;
        private EventHandler ReturnHandler;
        private EventHandler ExerciseHandler;
        private EventHandler HintHandler;
        private string hints = "";
        private string[] path = new string[2];
        private Exercise currentExercise;
        public ExerciseForm()
        {
            InitializeComponent();
            
            this.Text = "Задачи.";
            SubjectHandler = new EventHandler(this.SubjectButtonPressed);
            ReturnHandler = new EventHandler(this.ReturnToSubjects);
            ExerciseHandler = new EventHandler(this.ExerciseButtonPressed);
            HintHandler = new EventHandler(this.GetHint);
            this.button1.Click += HintHandler;
            this.button3.Click += ReturnHandler;
            InitializeSubjetcs();
        }

        private void InitializeSubjetcs()
        {
            CreateButtonGrid(edh.GetSubjects(), this.groupBox1, SubjectHandler);
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

        // TODO: create public method for list button grid

        private void SubjectButtonPressed(Object sender, EventArgs e)
        {
            var name = ((Button)sender).Name;
            path[0] = name;
            DisposeControls(this.groupBox1);
            CreateButtonGrid(edh.GetExerciseList(name), this.groupBox1, ExerciseHandler);
        }

        private void DisposeControls(Control parent)
        {
            if (parent != null)
            {
                parent.Controls.Clear();
            }
        }

        private void ReturnToSubjects(Object sender, EventArgs e)
        {
            path[0] = null;
            path[1] = null;
            DisposeControls(this.groupBox1);
            ClearTextBoxes();
            InitializeSubjetcs();
        }

        private void ExerciseButtonPressed(Object sender, EventArgs e)
        {
            path[1] = ((Button)sender).Name;
            currentExercise = edh.GetExercise(path[0], path[1]);
            this.richTextBox1.Text = currentExercise.Text;
            this.richTextBox4.Text = currentExercise.TextComment;
        }

        private void ClearTextBoxes()
        {
            foreach (var cntrl in this.Controls)
            {
                if (cntrl.GetType() == typeof(RichTextBox))
                {
                    ((RichTextBox)cntrl).Text = "";
                }
                else if (cntrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)cntrl).Text = "";
                }
            }
            hints = "";
        }

        private void GetHint(Object sender, EventArgs e)
        {
            if (!currentExercise.Equals(null) && currentExercise.usedHints < 3)
            {
                hints += currentExercise.Hints[currentExercise.usedHints++] + "\n";
                this.richTextBox3.Text = hints;
            }
        }
    }
}
