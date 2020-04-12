using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace khach_hang
{
    public partial class frmkhachhang : Form
    {
        
        public frmkhachhang()
        {
            InitializeComponent();
        }
       
        public void ketnoi()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
            con.Open();
            string sql = "select * from khachhang";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            dataGridView1.DataSource = table;

        }
        private void frmkhachhang_Load(object sender, EventArgs e)
        {
            ketnoi();
        }
        int index;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {

                index = dataGridView1.CurrentRow.Index;
                txtmakhach.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txttenkhach.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txtngaysinh.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                txtgioitinh.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                txtdiachi.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            txtmakhach.ReadOnly = false;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
                con.Open();
                string sql = "insert into khachhang values('" + txtmakhach.Text + "','" + txttenkhach.Text + "','" + txtngaysinh.Text + "','" + txtgioitinh.Text + "','" + txtdiachi.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                ketnoi();
                MessageBox.Show("bạn lưu thành công");
            }
            catch
            {
                MessageBox.Show("không lưu được vì trùng mã");
                txtmakhach.Clear();
                txttenkhach.Clear();
                txtngaysinh.Clear();
            }
            finally
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlykhachsan;Integrated Security=True");
                con.Close();
            }
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtmakhach.Enabled = false;


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtmakhach.Text = "";
            txttenkhach.Text = "";
            txtngaysinh.Text = "";
            txtgioitinh.Text = "";
            txtdiachi.Text = "";
            txtmakhach.Enabled = true;
            txtmakhach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtmakhach.ReadOnly = true;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
            con.Open();
            string sql = "update khachhang set tenkhach='" + txttenkhach.Text + "',ngaysinh='" + txtngaysinh.Text + "',gioitinh='" + txtgioitinh.Text + "',diachi='" + txtdiachi.Text + "' where makhach='" + txtmakhach.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ketnoi();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmakhach.TextLength == 0)
            {
                MessageBox.Show("bạn chưa chọn dòng xóa");
            }
            txtmakhach.ReadOnly = false;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
            con.Open();
            string sql = "delete from khachhang where makhach='" + txtmakhach.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ketnoi();
            txtmakhach.Clear();
            txttenkhach.Clear();
            txtngaysinh.Clear();
            txtgioitinh.Clear();
            txtdiachi.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtmakhach.Text = "";
            txttenkhach.Text = "";
            txtngaysinh.Text = "";
            txtgioitinh.Text = "";
            txtdiachi.Text = "";
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmakhach.Enabled = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
