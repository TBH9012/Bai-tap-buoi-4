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
    public partial class Form1 : Form
    {
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNhanVien formNhanVien = new FormNhanVien();
            if (formNhanVien.ShowDialog() == DialogResult.OK)
            {
                danhSachNhanVien.Add(formNhanVien.NhanVienMoi);
                UpdateDataGridView();
            }
        }

        private void UpdateDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var nhanVien in danhSachNhanVien)
            {
                dataGridView1.Rows.Add(nhanVien.MSVN, nhanVien.TenNV, nhanVien.LuongCB);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string msnv = row.Cells[0].Value.ToString();
                NhanVien nhanVienSua = danhSachNhanVien.FirstOrDefault(nv => nv.MSVN == msnv);

                if (nhanVienSua != null)
                {
                    FormNhanVien formNhanVien = new FormNhanVien(nhanVienSua);
                    if (formNhanVien.ShowDialog() == DialogResult.OK)
                    {
                        nhanVienSua.MSVN = formNhanVien.NhanVienMoi.MSVN;
                        nhanVienSua.TenNV = formNhanVien.NhanVienMoi.TenNV;
                        nhanVienSua.LuongCB = formNhanVien.NhanVienMoi.LuongCB;
                        UpdateDataGridView();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string msnv = row.Cells[0].Value.ToString();
                var nhanVienXoa = danhSachNhanVien.FirstOrDefault(nv => nv.MSVN == msnv);
                if (nhanVienXoa != null)
                {
                    danhSachNhanVien.Remove(nhanVienXoa);
                    UpdateDataGridView();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
