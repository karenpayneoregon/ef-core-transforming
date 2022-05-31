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
        }

        private void DataGridView1OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Debug.WriteLine(e.Exception.Message);
            e.Cancel = true;
        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {
            SomeEntity current = _bindingList[_bindingSource.Position];
            MessageBox.Show($"{current.Id, -3}{current.SomeDateTime,-12:d}{current.SomeEnum}");
        }
    }
}
