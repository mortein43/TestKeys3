namespace TestKeys3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            KeyPress = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // KeyPress
            // 
            KeyPress.Location = new Point(32, 83);
            KeyPress.Name = "KeyPress";
            KeyPress.Size = new Size(730, 148);
            KeyPress.TabIndex = 0;
            KeyPress.Text = "label1";
            // 
            // label2
            // 
            label2.Location = new Point(30, 231);
            label2.Name = "label2";
            label2.Size = new Size(732, 193);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.Location = new Point(552, 32);
            label3.Name = "label3";
            label3.Size = new Size(187, 23);
            label3.TabIndex = 1;
            label3.Text = "label3";
            // 
            // button1
            // 
            button1.Location = new Point(12, 28);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Звіт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(149, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(162, 23);
            textBox1.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(346, 29);
            button2.Name = "button2";
            button2.Size = new Size(159, 23);
            button2.TabIndex = 7;
            button2.Text = "Прихований режим";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // label1
            // 
            label1.Location = new Point(148, 3);
            label1.Name = "label1";
            label1.Size = new Size(163, 23);
            label1.TabIndex = 8;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(KeyPress);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label KeyPress;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Label label1;
    }
}