using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NguoiDung_ThemMoi : System.Web.UI.Page
{
    protected ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        VaiTro.DataSource = ServiceTinTuc.LayDuLieu("VaiTro");
        VaiTro.DataValueField = "MaVaiTro";
        VaiTro.DataTextField = "TenVaiTro";
        VaiTro.DataBind();
        VaiTro.SelectedValue = 1.ToString();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        var tennguoidung = txtTenNguoiDung.Text.ToString();
        var email = Email.Text.ToString();
        var pass = password.Text.ToString();
        var vaitro = VaiTro.Text.ToString();

        DataSet NguoiDung = ServiceTinTuc.LayDuLieu("NguoiDung where Email = '" + email + "' ");
        int count = NguoiDung.Tables[0].Rows.Count;
        if (count == 0)
        {
            bool status = ServiceTinTuc.DangKy(tennguoidung, email, pass, Convert.ToInt32(vaitro));
            if (status)
            {
                Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Đăng ký thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
            }
            else
            {
                Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Có lỗi xảy ra',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

            }
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Email đã tồn tại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }
    }

    protected void SubmitBack_Click(object sender, EventArgs e)
    {
        var tennguoidung = txtTenNguoiDung.Text.ToString();
        var email = Email.Text.ToString();
        var pass = password.Text.ToString();
        var vaitro = VaiTro.Text.ToString();

        DataSet NguoiDung = ServiceTinTuc.LayDuLieu("NguoiDung where Email = '" + email + "' ");
        int count = NguoiDung.Tables[0].Rows.Count;
        if (count == 0)
        {
            bool status = ServiceTinTuc.DangKy(tennguoidung, email, pass, Convert.ToInt32(vaitro));
            if (status)
            {
                Response.Redirect("DanhSach.aspx");
            }
            else
            {
                Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Có lỗi xảy ra',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

            }
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Email đã tồn tại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }
    }
}
