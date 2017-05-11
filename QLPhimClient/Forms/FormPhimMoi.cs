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
    public partial class FormPhimMoi : Form
    {
        List<Phim> dsphimmoi;
        int dem = 0;
        public FormPhimMoi()
        {
            InitializeComponent();
        }
        private void FormPhimMoi_Load(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string diachi = "http://192.168.1.5/QLPhimService/PhimService.svc/layphimmoi/10";
                string json = wc.DownloadString(diachi);
                dsphimmoi = JsonConvert.DeserializeObject<List<Phim>>(json);
            }
            foreach (Phim p in dsphimmoi)
            {
                PictureBox pb = new PictureBox();
                pb.Tag = p.PhimID;
                dem = dem + 1;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.ImageLocation = p.PosterURL;
                pb.Height = 100;
                pb.Width = 150;
                flowLayoutPanel1.Controls.Add(pb);
                pb.Click += Pb_Click;
            }
            lblTenPhim.Text = dsphimmoi[0].Ten;
            lblHangPhim.Text = dsphimmoi[0].HangPhim;
            lblTheLoai.Text = dsphimmoi[0].TheLoai;
            lblDienVien.Text = dsphimmoi[0].DaoDien;
            lblDaoDien.Text = dsphimmoi[0].DienVien;
            pictureBox1.ImageLocation = dsphimmoi[0].PosterURL;
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox tamthoi = sender as PictureBox;
            Phim tim = dsphimmoi.Where(x => x.PhimID == Convert.ToInt32(tamthoi.Tag)).FirstOrDefault();
            lblTenPhim.Text = tim.Ten;
            lblHangPhim.Text = tim.HangPhim;
            lblTheLoai.Text = tim.TheLoai;
            lblDienVien.Text = tim.DaoDien;
            lblDaoDien.Text = tim.DienVien;
            pictureBox1.ImageLocation = tim.PosterURL;
        }
    }
}
