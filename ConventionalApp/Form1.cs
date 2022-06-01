using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConventionalApp.Classes;
using ConventionalApp.Extensions;
using ConventionalApp.Models;

namespace ConventionalApp
{
    public partial class Form1 : Form
    {
        private BindingList<SomeEntity> _bindingList;
        private readonly BindingSource _bindingSource = new();
        public Form1()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;

            Shown += Form1_Shown;
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                _bindingList = new BindingList<SomeEntity>(await Operations.ReadEntitiesAsync());
                _bindingSource.DataSource = _bindingList;
            });

            dataGridView1.DataError += DataGridView1OnDataError;
            dataGridView1.DataSource = _bindingSource;
            dataGridView1.ExpandColumns();

            foreach (var button in Controls.OfType<Button>())
            {
                button.Enabled = true;
            }
        }

        /// <summary>
        /// Prevent default dialog, disallow wrong data types
        /// DateTime uses a custom column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Hey what's up: {e.Exception.Message}");
            e.Cancel = true;
        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Position <= -1) return;

            SomeEntity current = _bindingList[_bindingSource.Position];
            MessageBox.Show($@"{current.Id, -3}{current.SomeDateTime,-12:d}{current.SomeEnum}");
        }

        /// <summary>
        /// Will perform an update even if there are no changes, we can do better
        /// here or with EF Core but that is out of scope
        /// </summary>
        private async void UpdateCurrentButton_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Position <= -1) return;

            SomeEntity current = _bindingList[_bindingSource.Position];

            var (success, exception) = await Operations.UpdateEntity(current);

            MessageBox.Show(success ? "Updated" : $"Failed with {exception.Message}");

        }

        private void VisibleIdCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["IdColumn"].Visible = VisibleIdCheckBox.Checked;
        }
    }
}
