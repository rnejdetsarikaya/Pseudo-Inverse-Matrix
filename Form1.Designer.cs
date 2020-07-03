namespace PseudoInverse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.randomMatrix = new System.Windows.Forms.Button();
            this.setMatrix = new System.Windows.Forms.Button();
            this.numericM = new System.Windows.Forms.NumericUpDown();
            this.numericN = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericN)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(124)))), ((int)(((byte)(145)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 45);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // randomMatrix
            // 
            this.randomMatrix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(153)))), ((int)(((byte)(198)))));
            this.randomMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.randomMatrix.Location = new System.Drawing.Point(207, 337);
            this.randomMatrix.Name = "randomMatrix";
            this.randomMatrix.Size = new System.Drawing.Size(130, 45);
            this.randomMatrix.TabIndex = 0;
            this.randomMatrix.Text = "Random Matrix";
            this.randomMatrix.UseVisualStyleBackColor = false;
            this.randomMatrix.Click += new System.EventHandler(this.randomMatrix_Click);
            // 
            // setMatrix
            // 
            this.setMatrix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(153)))), ((int)(((byte)(198)))));
            this.setMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setMatrix.Location = new System.Drawing.Point(71, 337);
            this.setMatrix.Name = "setMatrix";
            this.setMatrix.Size = new System.Drawing.Size(130, 45);
            this.setMatrix.TabIndex = 1;
            this.setMatrix.Text = "Set Matrix";
            this.setMatrix.UseVisualStyleBackColor = false;
            this.setMatrix.Click += new System.EventHandler(this.setMatrix_Click);
            // 
            // numericM
            // 
            this.numericM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(118)))));
            this.numericM.Location = new System.Drawing.Point(29, 337);
            this.numericM.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericM.Name = "numericM";
            this.numericM.Size = new System.Drawing.Size(36, 22);
            this.numericM.TabIndex = 2;
            this.numericM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericN
            // 
            this.numericN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(118)))));
            this.numericN.Location = new System.Drawing.Point(29, 359);
            this.numericN.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericN.Name = "numericN";
            this.numericN.Size = new System.Drawing.Size(36, 22);
            this.numericN.TabIndex = 3;
            this.numericN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "M";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "N";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(7, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(330, 45);
            this.button1.TabIndex = 6;
            this.button1.Text = "Get Inverse";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(349, 394);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericN);
            this.Controls.Add(this.numericM);
            this.Controls.Add(this.setMatrix);
            this.Controls.Add(this.randomMatrix);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Pseudo Inverse Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button randomMatrix;
        private System.Windows.Forms.Button setMatrix;
        private System.Windows.Forms.NumericUpDown numericM;
        private System.Windows.Forms.NumericUpDown numericN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

