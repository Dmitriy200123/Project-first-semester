namespace Semester1Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scienceFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runGroupTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runFieldTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runMixedTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.авторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.optionsToolStripMenuItem.Text = "Настройки";
            // 
            // scienceFieldToolStripMenuItem
            // 
            this.scienceFieldToolStripMenuItem.Name = "scienceFieldToolStripMenuItem";
            this.scienceFieldToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.scienceFieldToolStripMenuItem.Text = "Справочник";
            this.scienceFieldToolStripMenuItem.Click += new System.EventHandler(this.scienceFieldToolStripMenuItem_Click);
            // 
            // testsToolStripMenuItem
            // 
            this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runGroupTestToolStripMenuItem,
            this.runFieldTestToolStripMenuItem,
            this.runMixedTestToolStripMenuItem});
            this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            this.testsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.testsToolStripMenuItem.Text = "Тесты";
            // 
            // runGroupTestToolStripMenuItem
            // 
            this.runGroupTestToolStripMenuItem.Name = "runGroupTestToolStripMenuItem";
            this.runGroupTestToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.runGroupTestToolStripMenuItem.Text = "Запустить тест раздела";
            this.runGroupTestToolStripMenuItem.Click += new System.EventHandler(this.RunGroupTestToolStripMenuItem_Click);
            // 
            // runFieldTestToolStripMenuItem
            // 
            this.runFieldTestToolStripMenuItem.Name = "runFieldTestToolStripMenuItem";
            this.runFieldTestToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.runFieldTestToolStripMenuItem.Text = "Запустить тест предмета";
            // 
            // runMixedTestToolStripMenuItem
            // 
            this.runMixedTestToolStripMenuItem.Name = "runMixedTestToolStripMenuItem";
            this.runMixedTestToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.runMixedTestToolStripMenuItem.Text = "Запустить смешанный тест";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fieldToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.formulaToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.addToolStripMenuItem.Text = "Добавить";
            // 
            // fieldToolStripMenuItem
            // 
            this.fieldToolStripMenuItem.Name = "fieldToolStripMenuItem";
            this.fieldToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fieldToolStripMenuItem.Text = "Предмет";
            this.fieldToolStripMenuItem.Click += new System.EventHandler(this.FieldToolStripMenuItem_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.groupToolStripMenuItem.Text = "Раздел";
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.GroupToolStripMenuItem_Click);
            // 
            // formulaToolStripMenuItem
            // 
            this.formulaToolStripMenuItem.Name = "formulaToolStripMenuItem";
            this.formulaToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.formulaToolStripMenuItem.Text = "Формулу";
            this.formulaToolStripMenuItem.Click += new System.EventHandler(this.FormulaToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.creditsToolStripMenuItem.Text = "Задачи";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.CreditsToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.scienceFieldToolStripMenuItem,
            this.testsToolStripMenuItem,
            this.addToolStripMenuItem,
            this.creditsToolStripMenuItem,
            this.авторыToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // авторыToolStripMenuItem
            // 
            this.авторыToolStripMenuItem.Name = "авторыToolStripMenuItem";
            this.авторыToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.авторыToolStripMenuItem.Text = "Авторы";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 441);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Обучающее приложение";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scienceFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runGroupTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runFieldTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runMixedTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formulaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem авторыToolStripMenuItem;
    }
}

