using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicTier;
using DTO;

namespace PresentaionTier
{
    public partial class SanPhamForm : Form
    {
        DanhMucBUS objDM = new DanhMucBUS();
        SanPhamBUS objSP = new SanPhamBUS();
        DataTable tbSP;
        public SanPhamForm()
        {
            InitializeComponent();
        }



        private void SanPhamForm_Load(object sender, EventArgs e)
        {
            string strMaDM = Form1.strMaDanhMuc_Chon;
            tbSP = objSP.GetSanPhamByMADM(strMaDM);
            dataGridView1.DataSource = tbSP;

            cbDanhMuc.DataSource = objDM.GetDanhMuc();
            cbDanhMuc.DisplayMember = "TenDM";
            cbDanhMuc.ValueMember = "MaDM";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string strMasp = "";
            if ((strMasp = dataGridView1.CurrentRow.Cells[0].Value.ToString()) != "")
            {
                SanPham sp = objSP.GetSanPhamByMASP(strMasp);
                txtMaSP.Text = sp.MaSanPham;
                txtTenSP.Text = sp.TenSanPham;
                txtSoLuong.Text = sp.SoLuong.ToString();
                txtGia.Text = sp.DonGia.ToString();
                txtXuatXu.Text = sp.XuatXu;
                cbDanhMuc.SelectedValue = sp.MaDanhMuc;

              
            }

                
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
           try {
                int sl = Convert.ToInt32(txtSoLuong.Text);
                int dg = Convert.ToInt32(txtGia.Text);
                SanPham sp = new SanPham(txtMaSP.Text,txtTenSP.Text, sl, dg, txtXuatXu.Text, cbDanhMuc.SelectedValue.ToString() );

                if(objSP.AddSanPham(sp)) {
                    MessageBox.Show("Them mot san pham thanh con ");
                    dataGridView1.DataSource = objSP.GetSanPhamByMADM(Form1.strMaDanhMuc_Chon);
                    
                }
                else
                {
                    MessageBox.Show("Co loi trong qua trinh them san pham");

                }
            }
            catch (Exception ex ) {
                MessageBox.Show("Co loi trong qua trinh them san pham");
            }
        }
        
        private void ResetTextFields()
        {
            txtGia.Text = "";
            txtMaSP.Text = "";
           txtTenSP.Text = "";
           txtSoLuong.Text = "";
            txtXuatXu.Text = "";
            cbDanhMuc.SelectedIndex = -1;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            try
            {
                int sl = Convert.ToInt32(txtSoLuong.Text);
                int dg = Convert.ToInt32(txtGia.Text);
                SanPham sp = new SanPham(txtMaSP.Text, txtTenSP.Text, sl, dg, txtXuatXu.Text, cbDanhMuc.SelectedValue.ToString());
                if (objSP.UpdateSanPham(sp))
                {
                    MessageBox.Show("Da thay doi thanh cong");
                    dataGridView1.DataSource = objSP.GetSanPhamByMADM(Form1.strMaDanhMuc_Chon);
                    ResetTextFields();


                }
                else
                {
                    MessageBox.Show("Co loi trong qua trinh luu san pham");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Co loi trong qua trinh luuw san pham");
            }
        }
    }

}
