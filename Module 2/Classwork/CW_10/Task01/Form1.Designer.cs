
namespace Task01
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
            System.Windows.Forms.Button generateNextNumBtn;
            System.Windows.Forms.Label textLabel;
            this.numLabel = new System.Windows.Forms.Label();
            generateNextNumBtn = new System.Windows.Forms.Button();
            textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generateNextNumBtn
            // 
            generateNextNumBtn.Location = new System.Drawing.Point(263, 115);
            generateNextNumBtn.Name = "generateNextNumBtn";
            generateNextNumBtn.Size = new System.Drawing.Size(235, 64);
            generateNextNumBtn.TabIndex = 0;
            generateNextNumBtn.Text = "Следующий член ряда\r\n";
            generateNextNumBtn.UseVisualStyleBackColor = true;
            generateNextNumBtn.Click += new System.EventHandler(this.generateNextNumBtn_Click);
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.Location = new System.Drawing.Point(263, 216);
            textLabel.Name = "textLabel";
            textLabel.Size = new System.Drawing.Size(135, 20);
            textLabel.TabIndex = 1;
            textLabel.Text = "Член ряда Пелла: ";
            // 
            // numLabel
            // 
            this.numLabel.AutoSize = true;
            this.numLabel.Location = new System.Drawing.Point(405, 216);
            this.numLabel.Name = "numLabel";
            this.numLabel.Size = new System.Drawing.Size(9, 20);
            this.numLabel.TabIndex = 2;
            this.numLabel.Text = "\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numLabel);
            this.Controls.Add(textLabel);
            this.Controls.Add(generateNextNumBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numLabel;
    }
}

