using System;
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

        private bool isMoreThan31Charactors(string txtSo)
        {
            DialogResult dr;
            if (txtSo.Length > 31)
            {
                dr = MessageBox.Show("Không được nhập quá 31 kí tự số", "Thông báo lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                return false;
            }
            return true;
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //lấy giá trị của 2 ô số
            double so1, so2, kq = 0;
            so1 = double.Parse(txtSo1.Text);
            so2 = double.Parse(txtSo2.Text);
            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked && so2 != 0) kq = so1 / so2;
            //Hiển thị kết quả lên trên ô kết quả
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
            bool isValid = this.isMoreThan31Charactors(txtSo1.Text);
            if (!isValid)
            {
                txtSo1.Focus();
            }
            if (string.IsNullOrWhiteSpace(txtSo1.Text))
            {
                MessageBox.Show("Ô số thứ nhất không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo1.Focus();  
            }
        }

        private void txtSo2_Leave(object sender, EventArgs e)
        {
            bool isValid = this.isMoreThan31Charactors(txtSo2.Text);
            if (!isValid)
            {
                txtSo2.Focus();
            }
            if (string.IsNullOrWhiteSpace(txtSo2.Text))
            {
                MessageBox.Show("Ô số thứ hai không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo2.Focus();  
            }
        }

        private void txtSo1_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!int.TryParse(textBox.Text, out _))
            {
                MessageBox.Show("Ô số thứ nhất không được nhập chữ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus(); 
                e.Cancel = true; 
            }
        }

        private void txtSo2_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!int.TryParse(textBox.Text, out _))
            {
                MessageBox.Show("Ô số thứ 2 không được nhập chữ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus(); 
                e.Cancel = true; 
            }
        }
    }
}
