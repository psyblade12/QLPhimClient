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
    public partial class FormTraCuuTheoXuatChieu : Form
    {
        public FormTraCuuTheoXuatChieu()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormTraCuuTheoXuatChieu_Load(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string diachi = "http://192.168.1.5/QLPhimService/XuatChieuService.svc/docngay";
                string json = wc.DownloadString(diachi);
                List<DateTime> model = JsonConvert.DeserializeObject<List<DateTime>>(json);
                cbbNgayChieu.DataSource = model;
            }
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string diachi = "http://192.168.1.5/QLPhimService/XuatChieuService.svc/laycachieu";
                string json = wc.DownloadString(diachi);
                List<int> model = JsonConvert.DeserializeObject<List<int>>(json);
                foreach (int i in model)
                {
                    RadioButton rb = new RadioButton();
                    rb.Text = i.ToString();
                    flowLayoutPanel1.Controls.Add(rb);
                }
            }
        }

        private void btnLiệtKê_Click(object sender, EventArgs e)
        {
            string gioduocchon = "9";
            List<int> model;
            List<Phim> dsphimtimthay = new List<Phim>();
            foreach (RadioButton rb in flowLayoutPanel1.Controls)
            {
                if(rb.Checked == true)
                {
                    gioduocchon = rb.Text;
                    break;
                }
            }
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string diachi = "http://192.168.1.5/QLPhimService/XuatChieuService.svc/tim?ngay="+ cbbNgayChieu.Text +"&giobatbatdau="+gioduocchon;
                string json = wc.DownloadString(diachi);
                model = JsonConvert.DeserializeObject<List<int>>(json);
            }
            foreach(int i in model)
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    string diachi = "http://192.168.1.5/QLPhimService/PhimService.svc/doctheoma/" + i;
                    string json = wc.DownloadString(diachi);
                    dsphimtimthay.Add(JsonConvert.DeserializeObject<Phim>(json));
                }
            }
            foreach(Phim p in dsphimtimthay)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.ImageLocation = p.PosterURL;
                pb.Height = 200;
                pb.Width = 150;
                flowLayoutPanel2.Controls.Add(pb);
            }
        }
    }
}
