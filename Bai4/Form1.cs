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
    public partial class Form1 : Form
    {
        private List<CHocSinh> dshs;
    
        public Form1()
        {
            InitializeComponent();
        }
        private void hienThi()
        {
            dgvHocSinh.DataSource = dshs.ToList();
        }
        private CHocSinh tim(string ma)
        {
            foreach (CHocSinh a in dshs)
            {
                if (a.Mshs==ma)
                {
                    return a;
                }   
               
            }
            return null;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            dshs = new List<CHocSinh>();
            docFile("hocsinh.out");
            hienThi();
            //if (docFile("hocsinh.out") == true)
            //{
            //    hienThi();
            //    MessageBox.Show("đọc được file", "Thông báo");
            //}
            //else
            //{
            //    MessageBox.Show("Không đọc được file", "Thông báo");
            //}

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CHocSinh hs = new CHocSinh();
            hs.Mshs = txtMaSo.Text;
            hs.Hoten = txtHoTen.Text;
            hs.Diachi = txtDiaChi.Text;
            hs.Ngaysinh = dtpNgaySinh.Value.Date;
            if (radNam.Checked==true)
            {
                hs.Phai = "Nam";
            }
            else
            {
                hs.Phai = "Nu";
            }
            if (tim(hs.Mshs)==null)
            {
                dshs.Add(hs);
                hienThi();
            }
            else
            {
                MessageBox.Show("Mã số " + hs.Mshs + " đã tồn tại", "thông báo");
            }

        }

        private void dgvHocSinh_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSo.Text = dgvHocSinh.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = dgvHocSinh.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(dgvHocSinh.Rows[e.RowIndex].Cells[2].Value.ToString());
            if (dgvHocSinh.Rows[e.RowIndex].Cells[3].Value.ToString() == "Nam")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }

            txtDiaChi.Text = dgvHocSinh.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mahs = txtMaSo.Text;

            if (MessageBox.Show("Ban co muon xoa hoc sinh nay khong", "thong bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (CHocSinh a in dshs)
                {
                    if (a.Mshs==mahs)
                    {
                            dshs.Remove(a);
                            hienThi();
                            return;
                    }
                    else
                    {
                        MessageBox.Show("khong tim thay hoc sinh", "Thong bao");
                    }
                }
            }
            else
            {
                MessageBox.Show("Hoc sinh nay chua duoc xoa", "Thong bao");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mhs= txtMaSo.Text;
            foreach ( CHocSinh a in dshs)
            {
                if (a.Mshs==mhs)
                {
                    a.Hoten = txtHoTen.Text;
                    a.Mshs=txtMaSo.Text;
                    a.Diachi=txtDiaChi.Text;
                    if (radNam.Checked == true)
                    {
                        a.Phai = "Nam";
                    }
                    else a.Phai = "Nữ";
                    a.Ngaysinh = dtpNgaySinh.Value.Date;
                    hienThi();
                    MessageBox.Show("Bạn đã sửa thành công", "Thông báo");
                }
            }
        }
        public bool ghiFile(string tenfile)
        {
            try
            {
                FileStream f = new FileStream(tenfile, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, dshs);
                f.Close();
                return true;
            }
            catch (Exception)
            {
                 return false;
            }
        }
        
        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            if (ghiFile("hocsinh.out") == true)
            {
                MessageBox.Show("Bạn đã ghi file thành công", "Thông báo");
            }
            else MessageBox.Show("Ghi file không thành công", "Thông báo");
        }
        public bool docFile(string tenfile)
        {
            try
            {
                FileStream f = new FileStream(tenfile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                
                dshs=bf.Deserialize(f) as List<CHocSinh>;
                f.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
