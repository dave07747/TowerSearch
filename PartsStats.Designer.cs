namespace TowerSearch
{
    partial class PartsStats
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
            this.partBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
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
            this.dataGridView1.DataSource = this.partBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(277, 301);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // partNameDataGridViewTextBoxColumn
            // 
            this.partNameDataGridViewTextBoxColumn.DataPropertyName = "PartName";
            this.partNameDataGridViewTextBoxColumn.HeaderText = "Part Name";
            this.partNameDataGridViewTextBoxColumn.Name = "partNameDataGridViewTextBoxColumn";
            this.partNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // towerDataGridViewTextBoxColumn
            // 
            this.towerDataGridViewTextBoxColumn.DataPropertyName = "Tower";
            this.towerDataGridViewTextBoxColumn.HeaderText = "Tower";
            this.towerDataGridViewTextBoxColumn.Name = "towerDataGridViewTextBoxColumn";
            this.towerDataGridViewTextBoxColumn.ReadOnly = true;
            this.towerDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.towerDataGridViewTextBoxColumn.Visible = false;
            // 
            // sideDataGridViewTextBoxColumn
            // 
            this.sideDataGridViewTextBoxColumn.DataPropertyName = "Side";
            this.sideDataGridViewTextBoxColumn.HeaderText = "Side";
            this.sideDataGridViewTextBoxColumn.Name = "sideDataGridViewTextBoxColumn";
            this.sideDataGridViewTextBoxColumn.ReadOnly = true;
            this.sideDataGridViewTextBoxColumn.Visible = false;
            // 
            // xCoordinateDataGridViewTextBoxColumn
            // 
            this.xCoordinateDataGridViewTextBoxColumn.DataPropertyName = "XCoordinate";
            this.xCoordinateDataGridViewTextBoxColumn.HeaderText = "XCoordinate";
            this.xCoordinateDataGridViewTextBoxColumn.Name = "xCoordinateDataGridViewTextBoxColumn";
            this.xCoordinateDataGridViewTextBoxColumn.ReadOnly = true;
            this.xCoordinateDataGridViewTextBoxColumn.Visible = false;
            // 
            // yCoordinateDataGridViewTextBoxColumn
            // 
            this.yCoordinateDataGridViewTextBoxColumn.DataPropertyName = "YCoordinate";
            this.yCoordinateDataGridViewTextBoxColumn.HeaderText = "YCoordinate";
            this.yCoordinateDataGridViewTextBoxColumn.Name = "yCoordinateDataGridViewTextBoxColumn";
            this.yCoordinateDataGridViewTextBoxColumn.ReadOnly = true;
            this.yCoordinateDataGridViewTextBoxColumn.Visible = false;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // timesTakenOutDataGridViewTextBoxColumn
            // 
            this.timesTakenOutDataGridViewTextBoxColumn.DataPropertyName = "TimesTakenOut";
            this.timesTakenOutDataGridViewTextBoxColumn.HeaderText = "Times Taken Out";
            this.timesTakenOutDataGridViewTextBoxColumn.Name = "timesTakenOutDataGridViewTextBoxColumn";
            this.timesTakenOutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // partBindingSource
            // 
            this.partBindingSource.DataSource = typeof(TowerSearch.Part);
            // 
            // PartsStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 301);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PartsStats";
            this.ShowIcon = false;
            this.Text = "Parts Statistics";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PartsStats_FormClosed);
            this.Load += new System.EventHandler(this.PartsStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource partBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn towerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sideDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xCoordinateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yCoordinateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timesTakenOutDataGridViewTextBoxColumn;
    }
}