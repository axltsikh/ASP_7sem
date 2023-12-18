
namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.StudentsLabel = new System.Windows.Forms.Label();
            this.NotesLabel = new System.Windows.Forms.Label();
            this.StudentsOutput = new System.Windows.Forms.Label();
            this.NotesOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StudentsLabel
            // 
            this.StudentsLabel.AutoSize = true;
            this.StudentsLabel.Location = new System.Drawing.Point(54, 45);
            this.StudentsLabel.Name = "StudentsLabel";
            this.StudentsLabel.Size = new System.Drawing.Size(55, 13);
            this.StudentsLabel.TabIndex = 0;
            this.StudentsLabel.Text = "Студенты";
            // 
            // NotesLabel
            // 
            this.NotesLabel.AutoSize = true;
            this.NotesLabel.Location = new System.Drawing.Point(277, 45);
            this.NotesLabel.Name = "NotesLabel";
            this.NotesLabel.Size = new System.Drawing.Size(45, 13);
            this.NotesLabel.TabIndex = 1;
            this.NotesLabel.Text = "Оценки";
            // 
            // StudentsOutput
            // 
            this.StudentsOutput.AutoSize = true;
            this.StudentsOutput.Location = new System.Drawing.Point(54, 75);
            this.StudentsOutput.Name = "StudentsOutput";
            this.StudentsOutput.Size = new System.Drawing.Size(0, 13);
            this.StudentsOutput.TabIndex = 2;
            // 
            // NotesOutput
            // 
            this.NotesOutput.AutoSize = true;
            this.NotesOutput.Location = new System.Drawing.Point(277, 75);
            this.NotesOutput.Name = "NotesOutput";
            this.NotesOutput.Size = new System.Drawing.Size(0, 13);
            this.NotesOutput.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NotesOutput);
            this.Controls.Add(this.StudentsOutput);
            this.Controls.Add(this.NotesLabel);
            this.Controls.Add(this.StudentsLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StudentsLabel;
        private System.Windows.Forms.Label NotesLabel;
        private System.Windows.Forms.Label StudentsOutput;
        private System.Windows.Forms.Label NotesOutput;
    }
}

