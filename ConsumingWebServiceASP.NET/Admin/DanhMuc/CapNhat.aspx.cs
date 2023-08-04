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
        var MaDanhMuc = Request.QueryString["MaDanhMuc"];
        bool isNumber = ServiceTinTuc.IsNumeric(MaDanhMuc);
        if (string.IsNullOrWhiteSpace(Request.QueryString["MaDanhMuc"]) || isNumber == false)
        {
            Response.Redirect("../404.aspx");
        }
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["MaDanhMuc"]))
            {
                DataSet DanhMuc = ServiceTinTuc.LayDuLieu("danhmuc where MaDanhMuc = '" + MaDanhMuc + "' ");
                int count = DanhMuc.Tables[0].Rows.Count;
                if (count > 0)
                {
                    txtTenDanhMuc.Text = DanhMuc.Tables[0].Rows[0]["TenDanhMuc"].ToString();
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
        var MaDanhMuc = Request.QueryString["MaDanhMuc"];
        var tendanhmuc = txtTenDanhMuc.Text.ToString();


        if (tendanhmuc == "")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Tên không được để trống',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else
        {
            bool status = ServiceTinTuc.CapNhatDuLieuDanhMuc(Convert.ToInt32(MaDanhMuc), tendanhmuc);
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
        var MaDanhMuc = Request.QueryString["MaDanhMuc"];
        var tendanhmuc = txtTenDanhMuc.Text.ToString();
        if (tendanhmuc == "")
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Tên không được để trống',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else
        {
            ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
            bool status = ServiceTinTuc.CapNhatDuLieuDanhMuc(Convert.ToInt32(MaDanhMuc), tendanhmuc);
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