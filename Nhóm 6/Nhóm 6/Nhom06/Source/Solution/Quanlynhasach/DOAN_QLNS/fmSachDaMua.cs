﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Configuration;

namespace DOAN_QLNS
{
    public partial class fmSachDaMua : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection cnn;
        public fmSachDaMua()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
            sqlDataSource1.Fill();
        }

        private void btnGetInfo_Click(object sender, EventArgs e)
        {
            if(txtIDCus.Text == "")
            {
                MessageBox.Show("Please insert value!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else 
            {
                DBService db = new DBService();
                db.openconn();
                string sql = "SELECT* FROM KhachHang WHERE KH_id='" + txtIDCus.Text + "'";
                SqlDataReader dr = db.getDataReader(sql);
                if (dr.HasRows)
                {
                    dr.Read();
                    dr.GetString(0);
                    txtNameCus.Text = dr.GetString(1).ToString();
                    txtPhone.Text = dr.GetString(2).ToString();
                    txtEmail.Text = dr.GetString(3).ToString();
                    txtAddress.Text = dr.GetString(4).ToString();                   
                    txtDebt.Text = dr.GetDouble(5).ToString();
                }
                else
                {
                    MessageBox.Show("Not found!");
                    txtIDCus.Text = txtNameCus.Text = txtAddress.Text = txtPhone.Text = txtEmail.Text = txtDebt.Text = "";
                }
                db.openconn();
            }
        }
    }
}