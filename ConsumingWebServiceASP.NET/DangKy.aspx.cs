using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebService.Models;

public partial class DangNhap : System.Web.UI.Page
{
    protected ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnDangKy_Click(object sender, EventArgs e)
    {
        string Username = username.Value;
        string email = emailaddress.Value;
        string pass = password.Value;
        if (username.ToString() == "" || email.ToString() == "" || pass.ToString() == "")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Nhập đủ các trường',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else
        {

            DataSet NguoiDung = ServiceTinTuc.LayDuLieu("NguoiDung where Email = '" + email + "' ");
            int count = NguoiDung.Tables[0].Rows.Count;
            if (count == 0)
            {
                bool status = ServiceTinTuc.DangKy(Username, email, pass, 1);
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
    }
}