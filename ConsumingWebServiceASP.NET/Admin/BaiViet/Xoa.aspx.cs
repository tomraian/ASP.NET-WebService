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
        var MaBaiViet = Request.QueryString["MaBaiViet"];
        bool isNumber = ServiceTinTuc.IsNumeric(MaBaiViet);
        if (string.IsNullOrWhiteSpace(Request.QueryString["MaBaiViet"]) || isNumber == false)
        {
            Response.Redirect("../404.aspx");
        }

        if (!String.IsNullOrEmpty(Request.QueryString["MaBaiViet"]))
        {
            int count = ServiceTinTuc.LayDuLieu("BaiViet where MaBaiViet = '" + MaBaiViet + "' ").Tables[0].Rows.Count;
            if (count > 0)
            {
                ServiceTinTuc.XoaDuLieu("BaiViet", "MaBaiViet = '" + MaBaiViet + "'");
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