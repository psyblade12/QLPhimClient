using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace QLPhimClient.Forms
{
    public partial class FormQuanLyTaiKhoan : Form
    {
        
        bool them = false;
        public FormQuanLyTaiKhoan()
        {
            using(WebClient wc = new WebClient())
            {
                InitializeComponent();
                wc.Encoding = Encoding.UTF8;
                string diachi = "http://localhost/QLPhimService/NguoiDungService.svc/doctatca";
                string json = wc.DownloadString(diachi);
                var model = JsonConvert.DeserializeObject<List<NguoiDung>>(json);
                bs.DataSource = model;
            }
        }
        BindingSource bs = new BindingSource();
        private void FormQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                cbbNhomNguoiDung.DisplayMember = "Ten";
                cbbNhomNguoiDung.ValueMember = "NhomNguoiDungID";
                string diachi = "http://192.168.1.5/QLPhimService/NhomNguoiDungService.svc/laynhomnguoidung";
                string json = wc.DownloadString(diachi);
                var model2 = JsonConvert.DeserializeObject<List<NhomNguoiDung>>(json);
                cbbNhomNguoiDung.DataSource = model2;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = bs;
                bs.PositionChanged += Bs_PositionChanged1;
                bs.MoveFirst();
                Xuat();
            }
        }
        public void Xuat()
        {
            if (them == false)
            {
                NguoiDung current = bs.Current as NguoiDung;
                txtTen.Text = current.Ten;
                txtPassword.Text = current.MatKhau;
                cbbNhomNguoiDung.SelectedValue = current.NhomNguoiDungID;
            }
        }

        public void Clear()
        {
            txtTen.Clear();
            txtPassword.Clear();
            cbbNhomNguoiDung.SelectedIndex = 0;
        }

        private void Bs_PositionChanged1(object sender, EventArgs e)
        {
            Xuat();
        }
        public class NhomNguoiDung
        {
            public int NhomNguoiDungID { set; get; }
            public string Ten { set; get; }
            public string MaSo { set; get; }
        }
        public class NguoiDung
        {
            public string MatKhau { get; set; }
            public int NguoiDungID { get; set; }
            public int NhomNguoiDungID { get; set; }
            public string Ten { get; set; }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnTiepTheo_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            them = true;
            Clear();
            txtTen.Focus();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                if (them == true)
                {
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string diachi = "http://192.168.1.5/QLPhimService/NguoiDungService.svc/them";
                    var obj = new { MatKhau = txtPassword.Text, NguoiDungID = 0, Ten = txtTen.Text, NhomNguoiDungID = cbbNhomNguoiDung.SelectedValue };
                    string chuoijson = JsonConvert.SerializeObject(obj);
                    string ketquatrave = wc.UploadString(diachi, "POST", chuoijson);
                    MessageBox.Show(ketquatrave);
                    bs.Add(obj);
                    dataGridView1.DataSource = bs;
                    bs.MoveLast();
                    them = false;
                }
                else
                {
                    wc.Encoding = Encoding.UTF8;
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string diachi = "http://localhost/QLPhimService/NguoiDungService.svc/sua";
                    NguoiDung current = bs.Current as NguoiDung;
                    current.Ten = txtTen.Text;
                    current.MatKhau = txtPassword.Text;
                    current.NhomNguoiDungID = Convert.ToInt32((cbbNhomNguoiDung.SelectedValue));
                    string chuoijson = JsonConvert.SerializeObject(current);
                    string ketquatrave = wc.UploadString(diachi, "PUT", chuoijson);
                    bs.EndEdit();
                    MessageBox.Show(ketquatrave);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                NguoiDung current = bs.Current as NguoiDung;
                string diachi = "http://localhost/QLPhimService/NguoiDungService.svc/xoa/" + current.NguoiDungID;
                string ketquatrave = wc.UploadString(diachi, "DELETE", "");
                MessageBox.Show(ketquatrave);
                bs.RemoveCurrent();
                Xuat();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string diachi = "http://localhost/QLPhimService/NguoiDungService.svc/doctatca";
                string json = wc.DownloadString(diachi);
                var model = JsonConvert.DeserializeObject<List<NguoiDung>>(json);
                bs.DataSource = model;
                dataGridView1.DataSource = bs;
            }
        }
    }
}
