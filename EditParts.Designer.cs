namespace TowerSearch
{
    partial class EditParts
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.towerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sideDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xCoordinateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yCoordinateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timesTakenOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.partBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.partNameDataGridViewTextBoxColumn,
            this.towerDataGridViewTextBoxColumn,
            this.sideDataGridViewTextBoxColumn,
            this.xCoordinateDataGridViewTextBoxColumn,
            this.yCoordinateDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.timesTakenOutDataGridViewTextBoxColumn});
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(551, 336);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // partNameDataGridViewTextBoxColumn
            // 
            this.partNameDataGridViewTextBoxColumn.DataPropertyName = "PartName";
            this.partNameDataGridViewTextBoxColumn.HeaderText = "Part Name";
            this.partNameDataGridViewTextBoxColumn.Name = "partNameDataGridViewTextBoxColumn";
            // 
            // towerDataGridViewTextBoxColumn
            // 
            this.towerDataGridViewTextBoxColumn.DataPropertyName = "Tower";
            this.towerDataGridViewTextBoxColumn.HeaderText = "Tower";
            this.towerDataGridViewTextBoxColumn.MaxInputLength = 1;
            this.towerDataGridViewTextBoxColumn.Name = "towerDataGridViewTextBoxColumn";
            // 
            // sideDataGridViewTextBoxColumn
            // 
            this.sideDataGridViewTextBoxColumn.DataPropertyName = "Side";
            this.sideDataGridViewTextBoxColumn.HeaderText = "Side";
            this.sideDataGridViewTextBoxColumn.MaxInputLength = 1;
            this.sideDataGridViewTextBoxColumn.Name = "sideDataGridViewTextBoxColumn";
            // 
            // xCoordinateDataGridViewTextBoxColumn
            // 
            this.xCoordinateDataGridViewTextBoxColumn.DataPropertyName = "XCoordinate";
            this.xCoordinateDataGridViewTextBoxColumn.HeaderText = "X-Coordinate";
            this.xCoordinateDataGridViewTextBoxColumn.MaxInputLength = 2;
            this.xCoordinateDataGridViewTextBoxColumn.Name = "xCoordinateDataGridViewTextBoxColumn";
            // 
            // yCoordinateDataGridViewTextBoxColumn
            // 
            this.yCoordinateDataGridViewTextBoxColumn.DataPropertyName = "YCoordinate";
            this.yCoordinateDataGridViewTextBoxColumn.HeaderText = "Y-Coordinate";
            this.yCoordinateDataGridViewTextBoxColumn.MaxInputLength = 2;
            this.yCoordinateDataGridViewTextBoxColumn.Name = "yCoordinateDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // timesTakenOutDataGridViewTextBoxColumn
            // 
            this.timesTakenOutDataGridViewTextBoxColumn.DataPropertyName = "TimesTakenOut";
            this.timesTakenOutDataGridViewTextBoxColumn.HeaderText = "TimesTakenOut";
            this.timesTakenOutDataGridViewTextBoxColumn.Name = "timesTakenOutDataGridViewTextBoxColumn";
            this.timesTakenOutDataGridViewTextBoxColumn.Visible = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(558, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 336);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // partBindingSource
            // 
            this.partBindingSource.DataSource = typeof(TowerSearch.Part);
            // 
            // EditParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 336);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EditParts";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit Parts";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EditParts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn towerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sideDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xCoordinateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCoordinateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timesTakenOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource partBindingSource;
    }
}