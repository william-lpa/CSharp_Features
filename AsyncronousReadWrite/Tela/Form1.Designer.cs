namespace AsyncronousReadWrite
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnAsync4 = new System.Windows.Forms.Button();
            this.btnAsync5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_NonAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 122);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(594, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // btnAsync4
            // 
            this.btnAsync4.Location = new System.Drawing.Point(252, 151);
            this.btnAsync4.Name = "btnAsync4";
            this.btnAsync4.Size = new System.Drawing.Size(173, 23);
            this.btnAsync4.TabIndex = 1;
            this.btnAsync4.Text = "I/O Assíncrono C# 4.0";
            this.btnAsync4.UseVisualStyleBackColor = true;
            this.btnAsync4.Click += new System.EventHandler(this.btnAsync4_Click);
            // 
            // btnAsync5
            // 
            this.btnAsync5.Location = new System.Drawing.Point(431, 151);
            this.btnAsync5.Name = "btnAsync5";
            this.btnAsync5.Size = new System.Drawing.Size(173, 23);
            this.btnAsync5.TabIndex = 2;
            this.btnAsync5.Text = "I/O Assíncrono C# 5.0";
            this.btnAsync5.UseVisualStyleBackColor = true;
            this.btnAsync5.Click += new System.EventHandler(this.btnAsync5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "0%";
            // 
            // btn_NonAsync
            // 
            this.btn_NonAsync.Location = new System.Drawing.Point(73, 151);
            this.btn_NonAsync.Name = "btn_NonAsync";
            this.btn_NonAsync.Size = new System.Drawing.Size(173, 23);
            this.btn_NonAsync.TabIndex = 4;
            this.btn_NonAsync.Text = "I/O Não Assíncrono";
            this.btn_NonAsync.UseVisualStyleBackColor = true;
            this.btn_NonAsync.Click += new System.EventHandler(this.btn_NonAsync_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 330);
            this.Controls.Add(this.btn_NonAsync);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAsync5);
            this.Controls.Add(this.btnAsync4);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnAsync4;
        private System.Windows.Forms.Button btnAsync5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_NonAsync;
    }
}

