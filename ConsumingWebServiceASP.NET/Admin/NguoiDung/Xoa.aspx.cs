using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BaiViet_Xoa : System.Web.UI.Page
{
    ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        var MaNguoiDung = Request.QueryString["MaNguoiDung"];
        bool isNumber = ServiceTinTuc.IsNumeric(MaNguoiDung);
        if (string.IsNullOrWhiteSpace(Request.QueryString["MaNguoiDung"]) || isNumber == false)
        {
            Response.Redirect("../404.aspx");
        }

        if (!String.IsNullOrEmpty(Request.QueryString["MaNguoiDung"]))
        {
            int count = ServiceTinTuc.LayDuLieu("NguoiDung where MaNguoiDung = '" + MaNguoiDung + "' ").Tables[0].Rows.Count;
            int isAdmin = Convert.ToInt32(ServiceTinTuc.LayDuLieu("NguoiDung where MaNguoiDung = '" + MaNguoiDung + "' ").Tables[0].Rows[0]["VaiTro"]);
            if (isAdmin != 1)
            {
                Response.Redirect("DanhSach.aspx");
                //Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Bạn không thể xóa tài khoản quản trị',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
            }
            else
            {
                if (count > 0)
                {
                    ServiceTinTuc.XoaDuLieu("NguoiDung", "MaNguoiDung = '" + MaNguoiDung + "'");
                    Session["DeleteStatus"] = "ok";
                    Response.Redirect("DanhSach.aspx");
                }
                else
                {
                    Response.Redirect("../404.aspx");
                }
            }

        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Xóa thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }

    }
}