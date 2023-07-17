using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["MaDanhMuc"]))
        {
            var MaDanhMuc = Request.QueryString["MaDanhMuc"];
            var tendanhmuc = ServiceTinTuc.LayDuLieu("danhmuc where MaDanhMuc = '" + MaDanhMuc + "' ");
            int count = tendanhmuc.Tables[0].Rows.Count;
            if (count > 0)
            {
                lbltest.Text = "Tên danh mục cũ: " + tendanhmuc.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                Session["UpdateStatus"] = "error";
                Response.Redirect("DanhSach.aspx");
            }
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        var MaDanhMuc = Convert.ToInt32(Request.QueryString["MaDanhMuc"].ToString());
        var TenDanhMuc = txtTenDanhMuc.Text;
        if (TenDanhMuc == "")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Tên Danh mục không được để trống',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }else
        {
            bool status = ServiceTinTuc.CapNhatDuLieuDanhMuc(MaDanhMuc, TenDanhMuc);
            if (status == true)
            {
                Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
            }
            else
            {
                Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Cập nhật thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
            }
        }
        
    }
    protected void SubmitBack_Click(object sender, EventArgs e)
    {
        var MaDanhMuc = Convert.ToInt32(Request.QueryString["MaDanhMuc"].ToString());
        var TenDanhMuc = txtTenDanhMuc.Text;
        if (TenDanhMuc == "")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Tên Danh mục không được để trống',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else
        {
            bool status = ServiceTinTuc.CapNhatDuLieuDanhMuc(MaDanhMuc, TenDanhMuc);
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
}