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
        var MaBinhLuan = Request.QueryString["MaBinhLuan"];
        bool isNumber = ServiceTinTuc.IsNumeric(MaBinhLuan);
        if (string.IsNullOrWhiteSpace(Request.QueryString["MaBinhLuan"]) || isNumber == false)
        {
            Response.Redirect("../404.aspx");
        }

        if (!String.IsNullOrEmpty(Request.QueryString["MaBinhLuan"]))
        {
            int count = ServiceTinTuc.LayDuLieu("BinhLuan where MaBinhLuan = '" + MaBinhLuan + "' ").Tables[0].Rows.Count;
            if (count > 0)
            {
                ServiceTinTuc.XoaDuLieu("BinhLuan", "MaBinhLuan = '" + MaBinhLuan + "'");
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
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Xóa thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }

    }
}