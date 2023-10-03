using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.Course.ADONet.FinalTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDataLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = afDataSet1.Customers;
            sqlDataAdapter1.Fill(afDataSet1.Customers);
        }

        private void sqlDataAdapter1_RowUpdating(object sender, System.Data.SqlClient.SqlRowUpdatingEventArgs e)
        {
            AFDataSet.CustomersRow CustRow = (AFDataSet.CustomersRow)e.Row;
            DialogResult responce = MessageBox.Show("Continue updating " + CustRow.CustomerId.ToString() + "?", "Continue update?", MessageBoxButtons.YesNo);
            if (responce == DialogResult.No)
            {
                e.Status = UpdateStatus.SkipCurrentRow;
                afDataSet1.Customers.Clear();
                sqlDataAdapter1.Fill(afDataSet1.Customers);
            }
        }

        private void sqlDataAdapter1_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
        {
            AFDataSet.CustomersRow CustRow = (AFDataSet.CustomersRow)e.Row;
            MessageBox.Show(CustRow.CustomerId.ToString() + " has been updated ");
            afDataSet1.Customers.Clear();
            sqlDataAdapter1.Fill(afDataSet1.Customers);
        }

        private void sqlDataAdapter1_FillError(object sender, FillErrorEventArgs e)
        {
            DialogResult response = MessageBox.Show("The following error occured while filling the DataSet:" + e.Errors.Message.ToString() + " Continue attempting to fill?", "FillError Encountered", MessageBoxButtons.YesNo);
            if (response == DialogResult.Yes)
            {
                e.Continue = true;
            }
            else 
            {
                e.Continue = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            sqlDataAdapter1.Update(afDataSet1);
        }
    }
}
