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
    public partial class FormTimTheoTheLoai : Form
    {
        public FormTimTheoTheLoai()
        {
            InitializeComponent();
        }

        private void FormTimTheoTheLoai_Load(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string diachi = "http://192.168.1.5/QLPhimService/PhimService.svc/laytheloai";
                string json = wc.DownloadString(diachi);
                List<string> model = JsonConvert.DeserializeObject<List<string>>(json);
                cbbTheLoai.DataSource = model;
            }
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string diachi = "http://192.168.1.5/QLPhimService/PhimService.svc/timtheotheloai?theloai="+ cbbTheLoai.SelectedItem.ToString();
                string json = wc.DownloadString(diachi);
                List<Phim> model = JsonConvert.DeserializeObject<List<Phim>>(json);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = model;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string diachi = "http://192.168.1.5/QLPhimService/PhimService.svc/timtheotheloai?theloai=" + cbbTheLoai.SelectedItem.ToString();
                string json = wc.DownloadString(diachi);
                List<Phim> model = JsonConvert.DeserializeObject<List<Phim>>(json);
                dataGridView1.DataSource = model;
            }
        }
    }
}
