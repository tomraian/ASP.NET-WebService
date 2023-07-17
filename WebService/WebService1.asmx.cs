using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Xml;
using WebService.Models;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public string checkSession()
        {
            return HttpContext.Current.Session.SessionID;
        }
        string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; // tạo kết nối tới sql bằng config
        // lấy dữ liệu theo bảng bằng tham số được truyền
        [WebMethod]
        public DataSet LayDuLieu(string table)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_select", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenbang", table);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
        // Thêm danh mục
        [WebMethod]
        public bool ThemDuLieuDanhMuc(string tendanhmuc)
        {
            //using (SqlConnection con = new SqlConnection(conStr))
            //{
            //    SqlCommand cmd = new SqlCommand("sp_InsertDanhMuc", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@tendanhmuc", tendanhmuc);
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //}
            Models.DanhMuc DanhMuc = new Models.DanhMuc
            {
                TenDanhMuc = tendanhmuc
            };
            bool status = DanhMuc.ThemMoi();
            if (status == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Sửa danh mục
        [WebMethod]
        public bool CapNhatDuLieuDanhMuc(int madanhmuc, string tendanhmuc)
        {
            //using (SqlConnection con = new SqlConnection(conStr))
            //{
            //    SqlCommand cmd = new SqlCommand("sp_InsertDanhMuc", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@tendanhmuc", tendanhmuc);
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //}
            Models.DanhMuc DanhMuc = new Models.DanhMuc
            {
                MaDanhMuc = madanhmuc,
                TenDanhMuc = tendanhmuc
            };
            bool status = DanhMuc.CapNhat();
            if (status == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Thêm Bài Viết
        [WebMethod]
        public bool ThemDuLieuBaiViet(string tieude, string tomtat, string noidung, string hinhthunho, string chuthichhinh, int luotxem,DateTime ngaydang, int manguoidung, int madanhmuc)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                //SqlCommand cmd = new SqlCommand("sp_InsertBaiViet", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@tieude", tieude);
                //cmd.Parameters.AddWithValue("@tomtat", tomtat);
                //cmd.Parameters.AddWithValue("@noidung", noidung);
                //cmd.Parameters.AddWithValue("@hinhthunho", hinhthunho);
                //cmd.Parameters.AddWithValue("@chuthichhinh", chuthichhinh);
                //cmd.Parameters.AddWithValue("@luotxem", luotxem);
                //cmd.Parameters.AddWithValue("@ngaydang", ngaydang);
                //cmd.Parameters.AddWithValue("@manguoidung", manguoidung);
                //cmd.Parameters.AddWithValue("@madanhmuc", madanhmuc);
                //con.Open();
                //cmd.ExecuteNonQuery();
                Models.BaiViet baiViet = new Models.BaiViet
                {
                    TieuDe = tieude,
                    TomTat = tomtat,
                    NoiDung = noidung,
                    HinhThuNho = hinhthunho,
                    ChuThichHinh = chuthichhinh,
                    LuotXem = luotxem,
                    NgayDang = ngaydang,
                    MaNguoiDung = manguoidung,
                    MaDanhMuc = madanhmuc
                };
                bool status = baiViet.ThemMoi();
                if (status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // xóa dữ liệu theo bảng và điều kiện
        [WebMethod]
        public bool CapNhatDuLieuBaiViet(int mabaiviet,string tieude, string tomtat, string noidung, string hinhthunho, string chuthichhinh, int luotxem, DateTime ngaydang, int manguoidung, int madanhmuc)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                //SqlCommand cmd = new SqlCommand("sp_InsertBaiViet", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@tieude", tieude);
                //cmd.Parameters.AddWithValue("@tomtat", tomtat);
                //cmd.Parameters.AddWithValue("@noidung", noidung);
                //cmd.Parameters.AddWithValue("@hinhthunho", hinhthunho);
                //cmd.Parameters.AddWithValue("@chuthichhinh", chuthichhinh);
                //cmd.Parameters.AddWithValue("@luotxem", luotxem);
                //cmd.Parameters.AddWithValue("@ngaydang", ngaydang);
                //cmd.Parameters.AddWithValue("@manguoidung", manguoidung);
                //cmd.Parameters.AddWithValue("@madanhmuc", madanhmuc);
                //con.Open();
                //cmd.ExecuteNonQuery();
                Models.BaiViet baiViet = new Models.BaiViet
                {
                    MaBaiViet = mabaiviet,  
                    TieuDe = tieude,
                    TomTat = tomtat,
                    NoiDung = noidung,
                    HinhThuNho = hinhthunho,
                    ChuThichHinh = chuthichhinh,
                    LuotXem = luotxem,
                    NgayDang = ngaydang,
                    MaNguoiDung = manguoidung,
                    MaDanhMuc = madanhmuc
                };
                bool status = baiViet.CapNhat();
                if (status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //public bool ThemDuLieuNguoiDung(string tieude, string tomtat, string noidung, string hinhthunho, string chuthichhinh, int luotxem, DateTime ngaydang, int manguoidung, int madanhmuc)
        //{
        //    using (SqlConnection con = new SqlConnection(conStr))
        //    {
        //        //SqlCommand cmd = new SqlCommand("sp_InsertBaiViet", con);
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.Parameters.AddWithValue("@tieude", tieude);
        //        //cmd.Parameters.AddWithValue("@tomtat", tomtat);
        //        //cmd.Parameters.AddWithValue("@noidung", noidung);
        //        //cmd.Parameters.AddWithValue("@hinhthunho", hinhthunho);
        //        //cmd.Parameters.AddWithValue("@chuthichhinh", chuthichhinh);
        //        //cmd.Parameters.AddWithValue("@luotxem", luotxem);
        //        //cmd.Parameters.AddWithValue("@ngaydang", ngaydang);
        //        //cmd.Parameters.AddWithValue("@manguoidung", manguoidung);
        //        //cmd.Parameters.AddWithValue("@madanhmuc", madanhmuc);
        //        //con.Open();
        //        //cmd.ExecuteNonQuery();
        //        Models.BaiViet baiViet = new Models.BaiViet
        //        {
        //            TieuDe = tieude,
        //            TomTat = tomtat,
        //            NoiDung = noidung,
        //            HinhThuNho = hinhthunho,
        //            ChuThichHinh = chuthichhinh,
        //            LuotXem = luotxem,
        //            NgayDang = ngaydang,
        //            MaNguoiDung = manguoidung,
        //            MaDanhMuc = madanhmuc
        //        };
        //        bool status = baiViet.ThemMoi();
        //        if (status == true)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        // xóa dữ liệu theo bảng và điều kiện

        [WebMethod]
        public void XoaDuLieu(string tenbang, string dieukien)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenbang", tenbang);
                cmd.Parameters.AddWithValue("@dieukien", dieukien);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
