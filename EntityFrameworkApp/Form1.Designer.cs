
namespace EntityFrameworkApp
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
            this.CurrentButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SomeDateTimeColumn = new EntityFrameworkApp.Classes.DataGridViewCalendarColumn();
            this.SomeIntColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SomeEnumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentButton
            // 
            this.CurrentButton.Image = global::EntityFrameworkApp.Properties.Resources.blueInformation_32Small;
            this.CurrentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CurrentButton.Location = new System.Drawing.Point(12, 356);
            this.CurrentButton.Name = "CurrentButton";
            this.CurrentButton.Size = new System.Drawing.Size(93, 23);
            this.CurrentButton.TabIndex = 3;
            this.CurrentButton.Text = "Current";
            this.CurrentButton.UseVisualStyleBackColor = true;
            this.CurrentButton.Click += new System.EventHandler(this.CurrentButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.SomeDateTimeColumn,
            this.SomeIntColumn,
            this.SomeEnumColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(410, 329);
            this.dataGridView1.TabIndex = 4;
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "ID";
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Width = 50;
            // 
            // SomeDateTimeColumn
            // 
            this.SomeDateTimeColumn.DataPropertyName = "SomeDateTime";
            this.SomeDateTimeColumn.HeaderText = "Data time";
            this.SomeDateTimeColumn.Name = "SomeDateTimeColumn";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 391);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CurrentButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EF Core";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CurrentButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private Classes.DataGridViewCalendarColumn SomeDateTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SomeIntColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SomeEnumColumn;
    }
}

