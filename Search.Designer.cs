namespace TowerSearch
{
    partial class Search
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.partName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tower = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Side = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.xCoordinate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.yCoordinate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.button1.Location = new System.Drawing.Point(-6, 276);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(337, 49);
            this.button1.TabIndex = 5;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.button1_KeyUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Part Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // partName
            // 
            this.partName.AcceptsTab = true;
            this.partName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.partName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.partName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.partName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.partName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partName.Location = new System.Drawing.Point(86, 56);
            this.partName.MaxLength = 30;
            this.partName.Name = "partName";
            this.partName.Size = new System.Drawing.Size(141, 19);
            this.partName.TabIndex = 0;
            this.partName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.partName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.partName_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tower #";
            // 
            // Tower
            // 
            this.Tower.AcceptsTab = true;
            this.Tower.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.Tower.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tower.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tower.Location = new System.Drawing.Point(68, 136);
            this.Tower.MaxLength = 1;
            this.Tower.Name = "Tower";
            this.Tower.Size = new System.Drawing.Size(50, 19);
            this.Tower.TabIndex = 1;
            this.Tower.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Tower.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Tower_KeyUp);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Side #";
            // 
            // Side
            // 
            this.Side.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Side.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.Side.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Side.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Side.Location = new System.Drawing.Point(180, 136);
            this.Side.MaxLength = 1;
            this.Side.Name = "Side";
            this.Side.Size = new System.Drawing.Size(47, 19);
            this.Side.TabIndex = 2;
            this.Side.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Side.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Side_KeyUp);
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(64, 180);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(66, 20);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Row (X)";
            // 
            // xCoordinate
            // 
            this.xCoordinate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.xCoordinate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xCoordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xCoordinate.Location = new System.Drawing.Point(68, 221);
            this.xCoordinate.MaxLength = 2;
            this.xCoordinate.Name = "xCoordinate";
            this.xCoordinate.Size = new System.Drawing.Size(50, 19);
            this.xCoordinate.TabIndex = 3;
            this.xCoordinate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.xCoordinate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.xCoordinate_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(158, 180);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 10, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Column (Y)";
            // 
            // yCoordinate
            // 
            this.yCoordinate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.yCoordinate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yCoordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yCoordinate.Location = new System.Drawing.Point(180, 221);
            this.yCoordinate.MaxLength = 2;
            this.yCoordinate.Name = "yCoordinate";
            this.yCoordinate.Size = new System.Drawing.Size(50, 19);
            this.yCoordinate.TabIndex = 4;
            this.yCoordinate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yCoordinate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.yCoordinate_KeyUp);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.ClientSize = new System.Drawing.Size(319, 321);
            this.Controls.Add(this.yCoordinate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.xCoordinate);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Side);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tower);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.partName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Search";
            this.ShowInTaskbar = false;
            this.Text = "Search";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox partName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Side;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox xCoordinate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox yCoordinate;
    }
}