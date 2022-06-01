
namespace ConventionalApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SomeDateColumn = new ConventionalApp.Classes.DataGridViewCalendarColumn();
            this.SomeIntColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SomeEnumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentButton = new System.Windows.Forms.Button();
            this.UpdateCurrentButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.VisibleIdCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.SomeDateColumn,
            this.SomeIntColumn,
            this.SomeEnumColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(410, 329);
            this.dataGridView1.TabIndex = 1;
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "ID";
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Width = 50;
            // 
            // SomeDateColumn
            // 
            this.SomeDateColumn.DataPropertyName = "SomeDateTime";
            dataGridViewCellStyle1.Format = "g";
            this.SomeDateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.SomeDateColumn.HeaderText = "Some date";
            this.SomeDateColumn.Name = "SomeDateColumn";
            this.SomeDateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SomeDateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SomeIntColumn
            // 
            this.SomeIntColumn.DataPropertyName = "SomeInt";
            this.SomeIntColumn.HeaderText = "Some Int";
            this.SomeIntColumn.Name = "SomeIntColumn";
            // 
            // SomeEnumColumn
            // 
            this.SomeEnumColumn.DataPropertyName = "SomeEnum";
            this.SomeEnumColumn.HeaderText = "Some Enum";
            this.SomeEnumColumn.Name = "SomeEnumColumn";
            // 
            // CurrentButton
            // 
            this.CurrentButton.Enabled = false;
            this.CurrentButton.Image = global::ConventionalApp.Properties.Resources.blueInformation_32Small;
            this.CurrentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CurrentButton.Location = new System.Drawing.Point(12, 356);
            this.CurrentButton.Name = "CurrentButton";
            this.CurrentButton.Size = new System.Drawing.Size(122, 23);
            this.CurrentButton.TabIndex = 2;
            this.CurrentButton.Text = "Current";
            this.toolTip1.SetToolTip(this.CurrentButton, "Get current entity");
            this.CurrentButton.UseVisualStyleBackColor = true;
            this.CurrentButton.Click += new System.EventHandler(this.CurrentButton_Click);
            // 
            // UpdateCurrentButton
            // 
            this.UpdateCurrentButton.Enabled = false;
            this.UpdateCurrentButton.Image = ((System.Drawing.Image)(resources.GetObject("UpdateCurrentButton.Image")));
            this.UpdateCurrentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateCurrentButton.Location = new System.Drawing.Point(300, 356);
            this.UpdateCurrentButton.Name = "UpdateCurrentButton";
            this.UpdateCurrentButton.Size = new System.Drawing.Size(122, 23);
            this.UpdateCurrentButton.TabIndex = 3;
            this.UpdateCurrentButton.Text = "Update current";
            this.toolTip1.SetToolTip(this.UpdateCurrentButton, "Update current entity");
            this.UpdateCurrentButton.UseVisualStyleBackColor = true;
            this.UpdateCurrentButton.Click += new System.EventHandler(this.UpdateCurrentButton_Click);
            // 
            // VisibleIdCheckBox
            // 
            this.VisibleIdCheckBox.AutoSize = true;
            this.VisibleIdCheckBox.Checked = true;
            this.VisibleIdCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VisibleIdCheckBox.Location = new System.Drawing.Point(156, 360);
            this.VisibleIdCheckBox.Name = "VisibleIdCheckBox";
            this.VisibleIdCheckBox.Size = new System.Drawing.Size(72, 19);
            this.VisibleIdCheckBox.TabIndex = 4;
            this.VisibleIdCheckBox.Text = "Id visible";
            this.VisibleIdCheckBox.UseVisualStyleBackColor = true;
            this.VisibleIdCheckBox.CheckedChanged += new System.EventHandler(this.VisibleIdCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 391);
            this.Controls.Add(this.VisibleIdCheckBox);
            this.Controls.Add(this.UpdateCurrentButton);
            this.Controls.Add(this.CurrentButton);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data provider";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private Classes.DataGridViewCalendarColumn SomeDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SomeIntColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SomeEnumColumn;
        private System.Windows.Forms.Button CurrentButton;
        private System.Windows.Forms.Button UpdateCurrentButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox VisibleIdCheckBox;
    }
}

