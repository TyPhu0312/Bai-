using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    [Serializable] class CHocSinh
    {
        private string m_mshs;
        private string m_hoten;
        private DateTime m_ngaysinh;
        private string m_phai;
        private string m_diachi;

        public string Mshs { get => m_mshs; set => m_mshs = value; }
        public string Hoten { get => m_hoten; set => m_hoten = value; }
        public DateTime Ngaysinh { get => m_ngaysinh; set => m_ngaysinh = value; }
        public string Phai { get => m_phai; set => m_phai = value; }
        public string Diachi { get => m_diachi; set => m_diachi = value; }

        public CHocSinh()
        {
            m_mshs = "";
            m_hoten = "";
            m_ngaysinh = DateTime.Now;
            m_phai = "";
            m_diachi = "";
        }
        public CHocSinh(string ma,string hoten, DateTime ngaysinh,string phai, string diachi)
        {
            m_mshs = ma;
            m_hoten = hoten;
            m_ngaysinh = ngaysinh;
            m_phai = phai;
            m_diachi = diachi;
        }
    }
}
