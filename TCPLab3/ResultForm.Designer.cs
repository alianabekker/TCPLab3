
namespace TCPLab3
{
    partial class ResultForm
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
            this.tbResult = new System.Windows.Forms.RichTextBox();
            this.tbAverageCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbResult
            // 
            this.tbResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbResult.Location = new System.Drawing.Point(39, 69);
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.Size = new System.Drawing.Size(488, 369);
            this.tbResult.TabIndex = 0;
            this.tbResult.Text = "";
            // 
            // tbAverageCount
            // 
            this.tbAverageCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbAverageCount.Location = new System.Drawing.Point(598, 103);
            this.tbAverageCount.Name = "tbAverageCount";
            this.tbAverageCount.ReadOnly = true;
            this.tbAverageCount.Size = new System.Drawing.Size(125, 34);
            this.tbAverageCount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Переходы состояний";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Среднее количество выстрелов";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAverageCount);
            this.Controls.Add(this.tbResult);
            this.Name = "ResultForm";
            this.Text = "Result";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbResult;
        private System.Windows.Forms.TextBox tbAverageCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}