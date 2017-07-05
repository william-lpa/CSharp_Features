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
            this.btnNonAssync = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 122);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(594, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // btnNonAssync
            // 
            this.btnNonAssync.Location = new System.Drawing.Point(245, 93);
            this.btnNonAssync.Name = "btnNonAssync";
            this.btnNonAssync.Size = new System.Drawing.Size(173, 23);
            this.btnNonAssync.TabIndex = 1;
            this.btnNonAssync.Text = "I/O Não Assíncrono";
            this.btnNonAssync.UseVisualStyleBackColor = true;
            this.btnNonAssync.Click += new System.EventHandler(this.btnNonAssync_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(245, 151);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(173, 23);
            this.btnAsync.TabIndex = 2;
            this.btnAsync.Text = "I/O Assíncrono";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 330);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnNonAssync);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnNonAssync;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.Label label1;
    }
}

