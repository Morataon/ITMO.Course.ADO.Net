﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace ITMO.Course.ADONet.Lab3.Ex3_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder results = new System.Text.StringBuilder();
            sqlCommand1.CommandType = CommandType.Text;
            sqlConnection1.Open();
            SqlDataReader reader = sqlCommand1.ExecuteReader();
            bool MoreResults = false;
            do
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        results.Append(reader[i].ToString() + "\t");
                    }
                    results.Append(Environment.NewLine);
                }
                MoreResults = reader.NextResult();
            } while (MoreResults);
            MoreResults = reader.NextResult();
             //while (MoreResults);
            reader.Close();
            sqlCommand1.Connection.Close();
            ResultsTextBox.Text = results.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder results = new System.Text.StringBuilder();
            sqlCommand2.CommandType = CommandType.StoredProcedure;
            sqlCommand2.CommandText = "Ten most expensive products";
            sqlConnection1.Open();
            SqlDataReader reader = sqlCommand2.ExecuteReader();
            bool MoreResults = false;
            do
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        results.Append(reader[i].ToString() + "\t");
                    }
                    results.Append(Environment.NewLine);
                }
                MoreResults = reader.NextResult();
            } while (MoreResults);
            MoreResults = reader.NextResult();
            //while (MoreResults);
            reader.Close();
            sqlCommand1.Connection.Close();
            ResultsTextBox.Text = results.ToString();

        }

        private void ResultsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sqlCommand3.CommandType = CommandType.Text;
                sqlCommand3.CommandText = "CREATE TABLE SalesPersons (" +
                       "[SalesPersonID] [int] IDENTITY(1,1) NOT NULL, " +
                       "[FirstName] [nvarchar](50)  NULL, " +
                       "[LastName] [nvarchar](50)  NULL)";
                sqlCommand3.Connection.Open();
                sqlCommand3.ExecuteNonQuery();
                // sqlCommand3.Connection.Close();
                MessageBox.Show("Таблица SalesPersons создана");

            }
            catch (SqlException XcpSQL)
            {
                foreach (SqlError se in XcpSQL.Errors)
                {
                    MessageBox.Show(se.Message,
                    "SQL Error code " + se.Number,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                sqlCommand3.Connection.Close();
            }
                  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder results = new System.Text.StringBuilder();
            sqlCommand4.CommandType = CommandType.Text;
            sqlCommand4.Parameters["@City"].Value = CityTextBox.Text;
            sqlConnection1.Open();
            SqlDataReader reader = sqlCommand4.ExecuteReader();
            bool MoreResults = false;
            do
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        results.Append(reader[i].ToString() + "\t");
                    }
                    results.Append(Environment.NewLine);
                }
                MoreResults = reader.NextResult();
            } while (MoreResults);
            reader.Close();
            sqlCommand4.Connection.Close();
            ResultsTextBox.Text = results.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder results = new System.Text.StringBuilder();
            sqlCommand5.Parameters["@CategoryName"].Value = CategoryNameTextBox.Text;
            sqlCommand5.Parameters["@OrdYear"].Value = OrdYearTextBox.Text;
            sqlCommand5.Connection.Open();
            SqlDataReader reader = sqlCommand5.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    results.Append(reader[i].ToString() + "\t");
                }
                results.Append(Environment.NewLine);
            }
            reader.Close();
            sqlCommand5.Connection.Close();
            ResultsTextBox.Text = results.ToString();
        }
    }
}
