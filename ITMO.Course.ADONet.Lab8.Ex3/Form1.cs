using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.Course.ADONet.Lab8.Ex3
{
    public partial class Form1 : Form
    {
        NORTHWND db = new NORTHWND(@"D:\ITMO\ITMO.Course.ADONet\ITMO.Course.ADONet\ITMO.Cource.DBNorthwind\NORTHWND.MDF");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string param = textBox1.Text; 
            var custquery = db.CustOrdersDetail(Convert.ToInt32(param));
            string msg = ""; // выполняем ХП и отображаем результаты
            foreach (CustOrdersDetailResult custOrdersDetail in custquery)
            {
                msg = msg + custOrdersDetail.ProductName + "\n";
            }
            if (msg == "")
                msg = "No results.";
            MessageBox.Show(msg);
            param = ""; // так мы очищаем переменные для дальнейшего использования
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string param = textBox2.Text;
            var custquery = db.CustOrderHist(param);
            string msg = "";
            foreach (CustOrderHistResult custOrdHist in custquery)
            {
                msg = msg + custOrdHist.ProductName + "\n";
            }
            MessageBox.Show(msg);
            param = "";
            textBox2.Text = "";
        }
    }
}
