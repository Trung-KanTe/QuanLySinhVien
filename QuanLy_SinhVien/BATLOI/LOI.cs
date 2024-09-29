using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_SinhVien.BATLOI
{
    internal class LOI
    {
        public bool loi_Trong(string str)
        {
            if (str.Trim() == "")
                return true;
            return false;
        }
        public bool loi_ChuaSo(string str)
        {
            foreach (char c in str)
                if (char.IsDigit(c))
                    return true;
            return false;
        }
        public bool loi_ChuaKiTu(string str)
        {
            foreach (char c in str)
                if (!char.IsDigit(c)) 
                    return true;
            return false;
        }
        public bool loi_SDT(string str)
        {
            if (str.Trim().Length >= 7 && str.Trim().Length <= 11)
                return false;
            return true;
        }

        public bool loi_Trung_KhoaChinh(string str, DataGridView dtg)
        {
            foreach(DataGridViewRow row in dtg.Rows)
            {
                string cell = row.Cells[0].Value.ToString();
                if (cell != null && cell == str)
                    return true;
            }
            return false;
        }
    }
}
