using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace ITMO.Course.ADONet.Lab8.Ex1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext (@"Data Source=DESKTOP-7CC6RCE\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=True");
            //var results = from c in db.GetTable<Customer>()
            //              where c.City == "London"
            //              select c;
            //foreach (var c in results)
            //    listBox1.Items.Add(c.ToString());

            var custQuery =
          from cust in db.GetTable<Customer>()
          where cust.Orders.Any()
          select cust;
            foreach (var custObj in custQuery)
            {
                ListViewItem item =
                    listView1.Items.Add(custObj.CustomerID.ToString());
                item.SubItems.Add(custObj.City.ToString());
                item.SubItems.Add(custObj.Orders.Count.ToString());
            }

        }
    }
}
