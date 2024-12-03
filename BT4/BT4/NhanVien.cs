using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT4
{
    public class NhanVien
    {
        public string MSVN { get; set; }
        public string TenNV { get; set; }
        public decimal LuongCB { get; set; }

        public NhanVien(string msnv, string tenNV, decimal luongCB)
        {
            MSVN = msnv;
            TenNV = tenNV;
            LuongCB = luongCB;
        }
    }
}
