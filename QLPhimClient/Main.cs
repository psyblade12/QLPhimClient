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

namespace QLPhimClient
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátRaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormDangNhap form = new Forms.FormDangNhap();
            form.ShowDialog();
        }

        private void đăngKíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormQuanLyTaiKhoan form = new Forms.FormQuanLyTaiKhoan();
            form.ShowDialog();
        }

        private void phimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormCapNhatPhim form = new Forms.FormCapNhatPhim();
            form.ShowDialog();
        }

        private void phimTheoThểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormTimTheoTheLoai form = new Forms.FormTimTheoTheLoai();
            form.ShowDialog();
        }

        private void phimMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormPhimMoi form = new Forms.FormPhimMoi();
            form.ShowDialog();
        }

        private void phimTheoXuấtChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormTraCuuTheoXuatChieu form = new Forms.FormTraCuuTheoXuatChieu();
            form.ShowDialog();
        }
    }
}
