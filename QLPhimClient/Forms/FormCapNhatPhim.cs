using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhimClient.Forms
{
    public partial class FormCapNhatPhim : Form
    {
        bool them = false;
        BindingSource bs = new BindingSource();
        public FormCapNhatPhim()
        {
            using (WebClient wc = new WebClient())
            {
                InitializeComponent();
                wc.Encoding = Encoding.UTF8;
                string diachi = "http://localhost/QLPhimService/PhimService.svc/doctatca";
                string json = wc.DownloadString(diachi);
                var model = JsonConvert.DeserializeObject<List<Phim>>(json);
                bs.DataSource = model;
                bs.PositionChanged += Bs_PositionChanged;
                bs.MoveFirst();
                Xuat();
            }
        }
        public void Xuat()
        {
            Phim current = bs.Current as Phim;
            txtDaoDien.Text = current.DaoDien;
            txtDoDai.Text = Convert.ToString(current.DoDai);
            txtGioiThieu.Text = current.GioiThieu;
            txtHangSanXuat.Text = current.HangPhim;
            txtNuocSanXuat.Text = current.NuocSanXuat;
            txtPhienBan.Text = current.PhienBan;
            txtTenPhim.Text = current.Ten;
            txtTheLoai.Text = current.TheLoai;
            txtDienVien.Text = current.DienVien;
        }
        public void Clear()
        {
            txtDaoDien.Clear();
            txtDoDai.Clear();
            txtGioiThieu.Clear();
            txtHangSanXuat.Clear();
            txtNuocSanXuat.Clear();
            txtPhienBan.Clear();
            txtTenPhim.Clear();
            txtTheLoai.Clear();
            txtDienVien.Clear();
        }
        private void Bs_PositionChanged(object sender, EventArgs e)
        {
            if(them == false)
            {
                Xuat();
            }
        }

        private void txtTheLoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCapNhatPhim_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            them = true;
            Clear();
            txtTenPhim.Focus();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string diachi = "http://192.168.1.5/QLPhimService/PhimService.svc/themphim";
                    Phim obj = new Phim { Ten = txtTenPhim.Text, DienVien= txtDienVien.Text, DaoDien  = txtDaoDien.Text, DoDai = Convert.ToInt32(txtDoDai.Text), GioiThieu = txtGioiThieu.Text, HangPhim = txtHangSanXuat.Text, NuocSanXuat= txtNuocSanXuat.Text, PhienBan = txtPhienBan.Text, TheLoai = txtTheLoai.Text };
                    string chuoijson = JsonConvert.SerializeObject(obj);
                    string ketquatrave = wc.UploadString(diachi, "POST", chuoijson);
                    bs.Add(obj);
                    bs.MoveLast();
                    them = false;
                    MessageBox.Show(ketquatrave);
                }
            }
            else
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string diachi = "http://192.168.1.5/QLPhimService/PhimService.svc/suaphim";
                    Phim current = bs.Current as Phim;
                    current.Ten = txtTenPhim.Text;
                    current.DaoDien = txtDaoDien.Text;
                    current.DienVien = txtDienVien.Text;
                    current.DoDai = Convert.ToInt32(txtDoDai.Text);
                    current.GioiThieu = txtDoDai.Text;
                    current.HangPhim = txtHangSanXuat.Text;
                    current.NuocSanXuat = txtNuocSanXuat.Text;
                    current.PhienBan = txtPhienBan.Text;
                    current.TheLoai = txtTheLoai.Text;
                    string chuoijson = JsonConvert.SerializeObject(current);
                    string ketquatrave = wc.UploadString(diachi, "PUT", chuoijson);
                    bs.EndEdit();
                    MessageBox.Show(ketquatrave);
                }
            }
        }

        private void btnBo_Click(object sender, EventArgs e)
        {
            them = false;
            Xuat();
        }
    }
}
