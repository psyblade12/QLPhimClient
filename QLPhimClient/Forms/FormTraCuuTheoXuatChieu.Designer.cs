namespace QLPhimClient.Forms
{
    partial class FormTraCuuTheoXuatChieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbbNgayChieu = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLiệtKê = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày Chiếu";
            // 
            // cbbNgayChieu
            // 
            this.cbbNgayChieu.FormattingEnabled = true;
            this.cbbNgayChieu.Location = new System.Drawing.Point(52, 47);
            this.cbbNgayChieu.Name = "cbbNgayChieu";
            this.cbbNgayChieu.Size = new System.Drawing.Size(198, 21);
            this.cbbNgayChieu.TabIndex = 1;
            this.cbbNgayChieu.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(285, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 63);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ca chiếu";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(573, 41);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(39, 110);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(831, 236);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnLiệtKê
            // 
            this.btnLiệtKê.Location = new System.Drawing.Point(782, 81);
            this.btnLiệtKê.Name = "btnLiệtKê";
            this.btnLiệtKê.Size = new System.Drawing.Size(75, 23);
            this.btnLiệtKê.TabIndex = 4;
            this.btnLiệtKê.Text = "Liệt kê";
            this.btnLiệtKê.UseVisualStyleBackColor = true;
            this.btnLiệtKê.Click += new System.EventHandler(this.btnLiệtKê_Click);
            // 
            // FormTraCuuTheoXuatChieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 358);
            this.Controls.Add(this.btnLiệtKê);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbbNgayChieu);
            this.Controls.Add(this.label1);
            this.Name = "FormTraCuuTheoXuatChieu";
            this.Text = "FormTraCuuTheoXuatChieu";
            this.Load += new System.EventHandler(this.FormTraCuuTheoXuatChieu_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbNgayChieu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnLiệtKê;
    }
}