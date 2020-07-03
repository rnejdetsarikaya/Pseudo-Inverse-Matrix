namespace PseudoInverse
{
    partial class Steps
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.sign = new System.Windows.Forms.Label();
            this.equal = new System.Windows.Forms.Label();
            this.Left = new System.Windows.Forms.RichTextBox();
            this.Center = new System.Windows.Forms.RichTextBox();
            this.Right = new System.Windows.Forms.RichTextBox();
            this.Back = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.formulaPicture = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LeftLabel = new System.Windows.Forms.Label();
            this.CenterLabel = new System.Windows.Forms.Label();
            this.RightLabel = new System.Windows.Forms.Label();
            this.AdditionsLabel = new System.Windows.Forms.Label();
            this.MultiplactionLabel = new System.Windows.Forms.Label();
            this.AddtitionsCount = new System.Windows.Forms.Label();
            this.MultiplactionCount = new System.Windows.Forms.Label();
            this.LoopsLabel = new System.Windows.Forms.Label();
            this.LoopsCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.formulaPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // sign
            // 
            this.sign.AutoSize = true;
            this.sign.Location = new System.Drawing.Point(177, 233);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(17, 17);
            this.sign.TabIndex = 1;
            this.sign.Text = "X";
            // 
            // equal
            // 
            this.equal.AutoSize = true;
            this.equal.Location = new System.Drawing.Point(364, 233);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(16, 17);
            this.equal.TabIndex = 2;
            this.equal.Text = "=";
            // 
            // Left
            // 
            this.Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(118)))));
            this.Left.Location = new System.Drawing.Point(12, 154);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(167, 167);
            this.Left.TabIndex = 3;
            this.Left.Text = "";
            // 
            // Center
            // 
            this.Center.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(118)))));
            this.Center.Location = new System.Drawing.Point(191, 154);
            this.Center.Name = "Center";
            this.Center.Size = new System.Drawing.Size(167, 167);
            this.Center.TabIndex = 3;
            this.Center.Text = "";
            // 
            // Right
            // 
            this.Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(118)))));
            this.Right.Location = new System.Drawing.Point(381, 154);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(167, 167);
            this.Right.TabIndex = 3;
            this.Right.Text = "";
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(153)))), ((int)(((byte)(198)))));
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Location = new System.Drawing.Point(38, 407);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 35);
            this.Back.TabIndex = 4;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(153)))), ((int)(((byte)(198)))));
            this.Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Next.Location = new System.Drawing.Point(442, 407);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 35);
            this.Next.TabIndex = 5;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // formulaPicture
            // 
            this.formulaPicture.Location = new System.Drawing.Point(82, 33);
            this.formulaPicture.Name = "formulaPicture";
            this.formulaPicture.Size = new System.Drawing.Size(389, 74);
            this.formulaPicture.TabIndex = 7;
            this.formulaPicture.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(476, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 8;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LeftLabel
            // 
            this.LeftLabel.AutoSize = true;
            this.LeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.LeftLabel.Location = new System.Drawing.Point(12, 134);
            this.LeftLabel.Name = "LeftLabel";
            this.LeftLabel.Size = new System.Drawing.Size(0, 15);
            this.LeftLabel.TabIndex = 9;
            // 
            // CenterLabel
            // 
            this.CenterLabel.AutoSize = true;
            this.CenterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.CenterLabel.Location = new System.Drawing.Point(194, 134);
            this.CenterLabel.Name = "CenterLabel";
            this.CenterLabel.Size = new System.Drawing.Size(0, 15);
            this.CenterLabel.TabIndex = 9;
            // 
            // RightLabel
            // 
            this.RightLabel.AutoSize = true;
            this.RightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.RightLabel.Location = new System.Drawing.Point(404, 134);
            this.RightLabel.Name = "RightLabel";
            this.RightLabel.Size = new System.Drawing.Size(0, 15);
            this.RightLabel.TabIndex = 9;
            // 
            // AdditionsLabel
            // 
            this.AdditionsLabel.AutoSize = true;
            this.AdditionsLabel.Location = new System.Drawing.Point(188, 397);
            this.AdditionsLabel.Name = "AdditionsLabel";
            this.AdditionsLabel.Size = new System.Drawing.Size(66, 17);
            this.AdditionsLabel.TabIndex = 10;
            this.AdditionsLabel.Text = "Additions";
            // 
            // MultiplactionLabel
            // 
            this.MultiplactionLabel.AutoSize = true;
            this.MultiplactionLabel.Location = new System.Drawing.Point(188, 413);
            this.MultiplactionLabel.Name = "MultiplactionLabel";
            this.MultiplactionLabel.Size = new System.Drawing.Size(86, 17);
            this.MultiplactionLabel.TabIndex = 11;
            this.MultiplactionLabel.Text = "Multiplaction";
            // 
            // AddtitionsCount
            // 
            this.AddtitionsCount.AutoSize = true;
            this.AddtitionsCount.Location = new System.Drawing.Point(280, 397);
            this.AddtitionsCount.Name = "AddtitionsCount";
            this.AddtitionsCount.Size = new System.Drawing.Size(0, 17);
            this.AddtitionsCount.TabIndex = 12;
            // 
            // MultiplactionCount
            // 
            this.MultiplactionCount.AutoSize = true;
            this.MultiplactionCount.Location = new System.Drawing.Point(280, 416);
            this.MultiplactionCount.Name = "MultiplactionCount";
            this.MultiplactionCount.Size = new System.Drawing.Size(0, 17);
            this.MultiplactionCount.TabIndex = 12;
            // 
            // LoopsLabel
            // 
            this.LoopsLabel.AutoSize = true;
            this.LoopsLabel.Location = new System.Drawing.Point(188, 380);
            this.LoopsLabel.Name = "LoopsLabel";
            this.LoopsLabel.Size = new System.Drawing.Size(47, 17);
            this.LoopsLabel.TabIndex = 13;
            this.LoopsLabel.Text = "Loops";
            // 
            // LoopsCount
            // 
            this.LoopsCount.AutoSize = true;
            this.LoopsCount.Location = new System.Drawing.Point(280, 380);
            this.LoopsCount.Name = "LoopsCount";
            this.LoopsCount.Size = new System.Drawing.Size(0, 17);
            this.LoopsCount.TabIndex = 14;
            // 
            // Steps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.LoopsCount);
            this.Controls.Add(this.LoopsLabel);
            this.Controls.Add(this.MultiplactionCount);
            this.Controls.Add(this.AddtitionsCount);
            this.Controls.Add(this.MultiplactionLabel);
            this.Controls.Add(this.AdditionsLabel);
            this.Controls.Add(this.RightLabel);
            this.Controls.Add(this.CenterLabel);
            this.Controls.Add(this.LeftLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.formulaPicture);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.Center);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.equal);
            this.Controls.Add(this.sign);
            this.Name = "Steps";
            this.Size = new System.Drawing.Size(551, 460);
            this.Load += new System.EventHandler(this.Steps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.formulaPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label sign;
        private System.Windows.Forms.Label equal;
        private System.Windows.Forms.RichTextBox Left;
        private System.Windows.Forms.RichTextBox Center;
        private System.Windows.Forms.RichTextBox Right;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.PictureBox formulaPicture;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LeftLabel;
        private System.Windows.Forms.Label CenterLabel;
        private System.Windows.Forms.Label RightLabel;
        private System.Windows.Forms.Label AdditionsLabel;
        private System.Windows.Forms.Label MultiplactionLabel;
        private System.Windows.Forms.Label AddtitionsCount;
        private System.Windows.Forms.Label MultiplactionCount;
        private System.Windows.Forms.Label LoopsLabel;
        private System.Windows.Forms.Label LoopsCount;
    }
}
