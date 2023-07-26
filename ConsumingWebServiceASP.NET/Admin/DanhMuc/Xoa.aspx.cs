using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DanhMuc_Xoa : System.Web.UI.Page
{
    ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        var MaDanhMuc = Request.QueryString["MaDanhMuc"];
        bool isNumber = ServiceTinTuc.IsNumeric(MaDanhMuc);
        if (string.IsNullOrWhiteSpace(Request.QueryString["MaDanhMuc"]) || isNumber == false)
        {
            Response.Redirect("../404.aspx");
        }

        if (!String.IsNullOrEmpty(Request.QueryString["MaDanhMuc"]))
        {
            int count = ServiceTinTuc.LayDuLieu("danhmuc where MaDanhMuc = '" + MaDanhMuc + "' ").Tables[0].Rows.Count;
            if (count > 0)
            {
                ServiceTinTuc.XoaDuLieu("DanhMuc", "MaDanhMuc = '" + MaDanhMuc + "'");
                Session["DeleteStatus"] = "ok";
                Response.Redirect("DanhSach.aspx");
            }
            else
            {
                Response.Redirect("../404.aspx");
            }
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Xoa thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }

    }
}