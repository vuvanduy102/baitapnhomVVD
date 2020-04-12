using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace nhan_vien
{
    class Funtions
    {
        class Functions
        {
            public static SqlConnection Conn;  //Khai báo đối tượng kết nối
            public static string connString;   //Khai báo biến chứa chuỗi kết nối

            public static void Connect()
            {
                //Thiết lập giá trị cho chuỗi kết nối
                connString = "Data Source=DESKTOP-6TI18BN\\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True";
                Conn = new SqlConnection();                 //Cấp phát đối tượng
                Conn.ConnectionString = connString;         //Kết nối
                Conn.Open();                                //Mở kết nối
            }

            public static void Disconnect()
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();       //Đóng kết nối
                    Conn.Dispose();     //Giải phóng tài nguyên
                    Conn = null;
                }
            }
        }


    }
}
