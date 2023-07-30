﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NguoiDung_DanhSach : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["DeleteStatus"] != null && Session["DeleteStatus"].ToString() == "ok")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Xóa thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
            Session.Remove("DeleteStatus");
        }
        else if (Session["DeleteStatus"] != null && Session["DeleteStatus"].ToString() == "error")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Xóa thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
            Session.Remove("DeleteStatus");
        }
        else if (Session["UpdateStatus"] != null && Session["UpdateStatus"].ToString() == "ok")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
            Session.Remove("UpdateStatus");
        }
        else if (Session["UpdateStatus"] != null && Session["UpdateStatus"].ToString() == "error")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
            Session.Remove("UpdateStatus");
        }
        ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
        DanhSachNguoiDung.DataSource = ServiceTinTuc.loadNguoiDung();
        DanhSachNguoiDung.DataBind();
        if (DanhSachNguoiDung.Rows.Count < 1)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Chưa có dữ liệu',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else
        {

            DanhSachNguoiDung.UseAccessibleHeader = true;
            DanhSachNguoiDung.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}