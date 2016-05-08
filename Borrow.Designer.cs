namespace TowerSearch
{
    partial class Borrow
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
            this.label4 = new System.Windows.Forms.Label();
            this.pName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Grade = new System.Windows.Forms.NumericUpDown();
            this.checkBoxMultiple = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(94, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // fName
            // 
            this.fName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.fName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.fName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(62)))), ((int)(((byte)(27)))));
            this.fName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fName.Location = new System.Drawing.Point(80, 114);
            this.fName.MaxLength = 50;
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(125, 22);
            this.fName.TabIndex = 0;
            this.fName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fName.Enter += new System.EventHandler(this.fName_Enter);
            this.fName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fName_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(94, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // lName
            // 
            this.lName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.lName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.lName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(62)))), ((int)(((byte)(27)))));
            this.lName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lName.Location = new System.Drawing.Point(80, 189);
            this.lName.MaxLength = 50;
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(125, 22);
            this.lName.TabIndex = 1;
            this.lName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lName.Enter += new System.EventHandler(this.lName_Enter);
            this.lName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lName_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(114, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(97, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Part Name";
            // 
            // pName
            // 
            this.pName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.pName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.pName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(62)))), ((int)(((byte)(27)))));
            this.pName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pName.Location = new System.Drawing.Point(80, 269);
            this.pName.MaxLength = 50;
            this.pName.Name = "pName";
            this.pName.Size = new System.Drawing.Size(125, 22);
            this.pName.TabIndex = 3;
            this.pName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pName.Enter += new System.EventHandler(this.pName_Enter);
            this.pName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pName_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(105, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Quantity";
            // 
            // Quantity
            // 
            this.Quantity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Quantity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Quantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(62)))), ((int)(((byte)(27)))));
            this.Quantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Quantity.Location = new System.Drawing.Point(80, 345);
            this.Quantity.MaxLength = 2;
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(125, 22);
            this.Quantity.TabIndex = 5;
            this.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Quantity_KeyUp);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(62)))), ((int)(((byte)(27)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(-6, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(295, 43);
            this.button1.TabIndex = 6;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyUp);
            // 
            // Grade
            // 
            this.Grade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(62)))), ((int)(((byte)(27)))));
            this.Grade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Grade.Location = new System.Drawing.Point(127, 36);
            this.Grade.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.Grade.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.Grade.Name = "Grade";
            this.Grade.Size = new System.Drawing.Size(41, 25);
            this.Grade.TabIndex = 7;
            this.Grade.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.Grade.ValueChanged += new System.EventHandler(this.Grade_ValueChanged);
            // 
            // checkBoxMultiple
            // 
            this.checkBoxMultiple.AutoSize = true;
            this.checkBoxMultiple.FlatAppearance.BorderSize = 0;
            this.checkBoxMultiple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxMultiple.Location = new System.Drawing.Point(200, 249);
            this.checkBoxMultiple.Name = "checkBoxMultiple";
            this.checkBoxMultiple.Size = new System.Drawing.Size(65, 17);
            this.checkBoxMultiple.TabIndex = 8;
            this.checkBoxMultiple.Text = "Multiple?";
            this.checkBoxMultiple.UseVisualStyleBackColor = true;
            this.checkBoxMultiple.CheckedChanged += new System.EventHandler(this.checkBoxMultiple_CheckedChanged);
            // 
            // Borrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(166)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.checkBoxMultiple);
            this.Controls.Add(this.Grade);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Borrow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = " Borrow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Borrow_FormClosed);
            this.Load += new System.EventHandler(this.pName_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.Grade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Quantity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown Grade;
        private System.Windows.Forms.CheckBox checkBoxMultiple;
    }
}