namespace TowerSearch
{
    partial class Return
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
            this.label1 = new System.Windows.Forms.Label();
            this.fName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Grade = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // fName
            // 
            this.fName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.fName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.fName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.fName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fName.Location = new System.Drawing.Point(106, 40);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(100, 19);
            this.fName.TabIndex = 0;
            this.fName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fName.Enter += new System.EventHandler(this.fName_Enter);
            this.fName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fName_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // lName
            // 
            this.lName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.lName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.lName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(106, 108);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(100, 19);
            this.lName.TabIndex = 1;
            this.lName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lName.Enter += new System.EventHandler(this.lName_Enter);
            this.lName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lName_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Part Name";
            // 
            // pName
            // 
            this.pName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.pName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.pName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.pName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pName.Location = new System.Drawing.Point(106, 179);
            this.pName.Name = "pName";
            this.pName.Size = new System.Drawing.Size(100, 19);
            this.pName.TabIndex = 2;
            this.pName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pName.Enter += new System.EventHandler(this.pName_Enter);
            this.pName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pName_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Quantity";
            // 
            // Quantity
            // 
            this.Quantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.Quantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.Location = new System.Drawing.Point(134, 314);
            this.Quantity.MaxLength = 2;
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(43, 19);
            this.Quantity.TabIndex = 4;
            this.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button1.Location = new System.Drawing.Point(-3, 346);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(336, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Grade";
            // 
            // Grade
            // 
            this.Grade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.Grade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grade.Location = new System.Drawing.Point(127, 242);
            this.Grade.MaxLength = 2;
            this.Grade.Name = "Grade";
            this.Grade.Size = new System.Drawing.Size(54, 19);
            this.Grade.TabIndex = 3;
            this.Grade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Grade.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Grade_KeyUp);
            // 
            // Return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.ClientSize = new System.Drawing.Size(328, 385);
            this.Controls.Add(this.Grade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Return";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Return";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Return_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Quantity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Grade;
    }
}