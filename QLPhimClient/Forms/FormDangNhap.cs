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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string diachi = string.Format("http://192.168.1.5/QLPhimService/NguoiDungService.svc/dangnhap?ten={0}&ma={1}",txtTen.Text, txtPassword.Text);
                string json = wc.DownloadString(diachi);
                if(json == "true")
                {
                    MessageBox.Show("Đăng nhập thành công.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể đăng nhập.");
                }
            }
        }
    }
}
