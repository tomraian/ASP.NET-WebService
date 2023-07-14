using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_DanhMuc_Xoa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["MaDanhMuc"]))
        {
            ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
            var MaDanhMuc = Request.QueryString["MaDanhMuc"];
            int count = ServiceTinTuc.LayDuLieu("danhmuc where MaDanhMuc = '" + MaDanhMuc + "' ").Tables[0].Rows.Count;
            if (count > 0)
            {
                ServiceTinTuc.XoaDuLieu("DanhMuc", "MaDanhMuc = '" + MaDanhMuc + "'");
                Session["DeleteStatus"] = "ok";
                Response.Redirect("DanhSach.aspx");
            }
            else
            {
                Session["DeleteStatus"] = "error";
                Response.Redirect("DanhSach.aspx");
            }
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Xoa thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }

    }
}