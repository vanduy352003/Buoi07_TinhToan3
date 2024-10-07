﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            double so1, so2, kq = 0;

            // Kiểm tra dữ liệu hợp lệ cho ô "Số thứ nhất"
            if (!double.TryParse(txtSo1.Text, out so1))
            {
                MessageBox.Show("Dữ liệu của ô Số thứ nhất không được rỗng. Vui lòng nhập một số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo1.Focus();               
                txtSo1.SelectAll();           
                return;                     
            }

            // Tiếp tục kiểm tra dữ liệu của ô "Số thứ hai"
            if (!double.TryParse(txtSo2.Text, out so2))
            {
                MessageBox.Show("Dữ liệu của ô Số thứ hai không được rỗng. Vui lòng nhập một số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo2.Focus();                
                txtSo2.SelectAll();            
                return;                       
            }

            // Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked)
            {
                if (so2 == 0)
                {
                    MessageBox.Show("Không thể chia cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                kq = so1 / so2;
            }

            // Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();
        }

        private void txtSo1_Click(object sender, EventArgs e)
        {
            txtSo1.SelectAll();
        }

        private void txtSo1_Enter(object sender, EventArgs e)
        {
            txtSo1.SelectAll();
        }

        private void txtSo2_Click(object sender, EventArgs e)
        {
            txtSo2.SelectAll();
        }

        private void txtSo2_Enter(object sender, EventArgs e)
        {
            txtSo2.SelectAll();
        }

        private void txtSo1_Leave(object sender, EventArgs e)
        {
            /*if (string.IsNullOrWhiteSpace(txtSo1.Text))
            {
                MessageBox.Show("Ô số thứ nhất không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo1.Focus();
            }*/
        }

        private void txtSo2_Leave(object sender, EventArgs e)
        {
            /*if (string.IsNullOrWhiteSpace(txtSo2.Text))
            {
                MessageBox.Show("Ô số thứ hai không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo2.Focus();  
            }*/
        }
    }
}
