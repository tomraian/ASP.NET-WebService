using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService.Models;
using System.Text.RegularExpressions;
public partial class Admin_Default : System.Web.UI.Page
{
    protected ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        var MaNguoiDung = Request.QueryString["MaNguoiDung"];
        bool isNumber = ServiceTinTuc.IsNumeric(MaNguoiDung);
        if (string.IsNullOrWhiteSpace(Request.QueryString["MaNguoiDung"]) || isNumber == false)
        {
            Response.Redirect("../404.aspx");
        }
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["MaNguoiDung"]))
            {
                DataSet NguoiDung = ServiceTinTuc.LayDuLieu("NguoiDung where MaNguoiDung = '" + MaNguoiDung + "' ");
                int count = NguoiDung.Tables[0].Rows.Count;
                if (count > 0)
                {
                    txtTenNguoiDung.Text = NguoiDung.Tables[0].Rows[0]["TenNguoiDung"].ToString();
                    Email.Text = NguoiDung.Tables[0].Rows[0]["Email"].ToString();
                    password.Text = NguoiDung.Tables[0].Rows[0]["MatKhau"].ToString();
                    HinhAnh.ImageUrl = "../../Uploads/" + NguoiDung.Tables[0].Rows[0]["HinhDaiDien"].ToString();
                    NgaySinh.Value = NguoiDung.Tables[0].Rows[0]["NgaySinh"].ToString();
                    DiaChi.Text = NguoiDung.Tables[0].Rows[0]["DiaChi"].ToString();
                    sodienthoai.Value = NguoiDung.Tables[0].Rows[0]["SDT"].ToString();
                    GioiTinh.Value = NguoiDung.Tables[0].Rows[0]["GioiTinh"].ToString();
                    VaiTro.Text = NguoiDung.Tables[0].Rows[0]["VaiTro"].ToString();
                }
                else
                {
                    Response.Redirect("../404.aspx");
                }
            }
        }
    }

    private bool IsNumeric(string input)
    {
        bool isNumber = int.TryParse(input, out _);
        return isNumber;
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        var MaNguoiDung = Request.QueryString["MaNguoiDung"];
        var tennguoidung = txtTenNguoiDung.Text.ToString();
        var email = Email.Text.ToString();
        var pass = password.Text.ToString();
        var hinhanh = HinhAnh.ImageUrl.ToString();
        var ngaysinh = NgaySinh.Value.ToString();
        var diachi = DiaChi.Text.ToString();
        var sdt = sodienthoai.Value;
        var gioitinh = GioiTinh.Value;
        var vaitro = VaiTro.Text.ToString();
        bool status = ServiceTinTuc.CapNhatDuLieuNguoiDung(Convert.ToInt32(MaNguoiDung), tennguoidung, email, pass, hinhanh,Convert.ToDateTime(ngaysinh),diachi,Convert.ToInt32(sdt),Convert.ToByte(gioitinh), Convert.ToInt32(vaitro));

        if (status == true)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
    }

    protected void SubmitBack_Click(object sender, EventArgs e)
    {
        var MaNguoiDung = Request.QueryString["MaNguoiDung"];
        var tennguoidung = txtTenNguoiDung.Text.ToString();
        var email = Email.Text.ToString();
        var pass = password.Text.ToString();
        var hinhanh = HinhAnh.ImageUrl.ToString();
        var ngaysinh = NgaySinh.Value.ToString();
        var diachi = DiaChi.Text.ToString();
        var sdt = sodienthoai.Value;
        var gioitinh = GioiTinh.Value;
        var vaitro = VaiTro.Text.ToString();
        ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
        bool status = ServiceTinTuc.CapNhatDuLieuNguoiDung(Convert.ToInt32(MaNguoiDung), tennguoidung, email, pass, hinhanh, Convert.ToDateTime(ngaysinh), diachi, Convert.ToInt32(sdt), Convert.ToByte(gioitinh), Convert.ToInt32(vaitro));

        if (status == true)
        {
            Response.Redirect("DanhSach.aspx");
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
    }
}