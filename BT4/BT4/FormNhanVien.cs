using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT4
{
    public partial class FormNhanVien : Form
    {
        public NhanVien NhanVienMoi { get; private set; }
        public FormNhanVien()
        {
            InitializeComponent();
        }

        public FormNhanVien(NhanVien nhanVien)
        {
            InitializeComponent();

            txtMSNV.Text = nhanVien.MSVN;
            txtTenNV.Text = nhanVien.TenNV;
            txtLuongCB.Text = nhanVien.LuongCB.ToString();

            NhanVienMoi = nhanVien;
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string msnv = txtMSNV.Text;
            string tenNV = txtTenNV.Text;
            decimal luongCB;

            if (string.IsNullOrWhiteSpace(msnv) || string.IsNullOrWhiteSpace(tenNV) || !decimal.TryParse(txtLuongCB.Text, out luongCB))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            NhanVienMoi = new NhanVien(msnv, tenNV, luongCB);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
