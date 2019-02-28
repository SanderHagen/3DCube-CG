namespace MatrixTransformations
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.scaleLabel = new System.Windows.Forms.Label();
            this.TransXLabel = new System.Windows.Forms.Label();
            this.scaleVal = new System.Windows.Forms.Label();
            this.transxVal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.Location = new System.Drawing.Point(12, 9);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(40, 13);
            this.scaleLabel.TabIndex = 0;
            this.scaleLabel.Text = "Scale: ";
            // 
            // TransXLabel
            // 
            this.TransXLabel.AutoSize = true;
            this.TransXLabel.Location = new System.Drawing.Point(12, 33);
            this.TransXLabel.Name = "TransXLabel";
            this.TransXLabel.Size = new System.Drawing.Size(44, 13);
            this.TransXLabel.TabIndex = 1;
            this.TransXLabel.Text = "TransX:";
            this.TransXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scaleVal
            // 
            this.scaleVal.AutoSize = true;
            this.scaleVal.Location = new System.Drawing.Point(59, 9);
            this.scaleVal.Name = "scaleVal";
            this.scaleVal.Size = new System.Drawing.Size(35, 13);
            this.scaleVal.TabIndex = 2;
            this.scaleVal.Text = "label1";
            // 
            // transxVal
            // 
            this.transxVal.AutoSize = true;
            this.transxVal.Location = new System.Drawing.Point(59, 33);
            this.transxVal.Name = "transxVal";
            this.transxVal.Size = new System.Drawing.Size(35, 13);
            this.transxVal.TabIndex = 3;
            this.transxVal.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 454);
            this.Controls.Add(this.transxVal);
            this.Controls.Add(this.scaleVal);
            this.Controls.Add(this.TransXLabel);
            this.Controls.Add(this.scaleLabel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label scaleLabel;
        private System.Windows.Forms.Label TransXLabel;
        private System.Windows.Forms.Label scaleVal;
        private System.Windows.Forms.Label transxVal;
    }
}

