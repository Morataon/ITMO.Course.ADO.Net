using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.Course.ADONet.Lab4.Ex1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetCustomersButton_Click(object sender, EventArgs e)
        {
            NORTHWNDDataSet NorthwindDataset1 = new NORTHWNDDataSet();
            NORTHWNDDataSetTableAdapters.CustomersTableAdapter CustomersTableAdapter1 = new NORTHWNDDataSetTableAdapters.CustomersTableAdapter();
            CustomersTableAdapter1.Fill(NorthwindDataset1.Customers);
            foreach (NORTHWNDDataSet.CustomersRow NWCustomer in NorthwindDataset1.Customers.Rows)
            {
                CustomersListBox.Items.Add(NWCustomer.CompanyName);            
            }
        }
    }
}
