using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService.Models;
using System.Text.RegularExpressions;
using System.IO;

public partial class Admin_Default : System.Web.UI.Page
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
        LoadHinhAnh();
        if (!IsPostBack)
        {
            LoadDanhMuc();
            LoadBaiViet();
        }
    }
    public void LoadBaiViet()
    {
        var MaBaiViet = Request.QueryString["MaBaiViet"];
        bool isNumber = ServiceTinTuc.IsNumeric(MaBaiViet);
        if (!String.IsNullOrEmpty(Request.QueryString["MaBaiViet"]))
        {
            DataSet BaiViet = ServiceTinTuc.LayDuLieu("BaiViet where MaBaiViet = '" + MaBaiViet + "' ");
            int count = BaiViet.Tables[0].Rows.Count;
            if (count > 0)
            {
                TieuDe.Text = BaiViet.Tables[0].Rows[0]["TieuDe"].ToString();
                DanhMuc.SelectedValue = BaiViet.Tables[0].Rows[0]["MaDanhMuc"].ToString();
                TomTat.Text = BaiViet.Tables[0].Rows[0]["TomTat"].ToString();
                NoiDung.Text = BaiViet.Tables[0].Rows[0]["NoiDung"].ToString();
                HinhAnh.ImageUrl = "../../Uploads/" + BaiViet.Tables[0].Rows[0]["HinhThuNho"].ToString();
                ChuThichAnh.Text = BaiViet.Tables[0].Rows[0]["ChuThichHinh"].ToString();
                TenHinhAnhCu.Value = BaiViet.Tables[0].Rows[0]["HinhThuNho"].ToString();
            }
            else
            {
                Response.Redirect("../404.aspx");
            }
        }
    }
    public void LoadDanhMuc()
    {
        DanhMuc.DataTextField = "TenDanhMuc";
        DanhMuc.DataValueField = "MaDanhMuc";
        DanhMuc.DataSource = ServiceTinTuc.LayDuLieu("DanhMuc");
        DanhMuc.DataBind();
    }
    public void LoadHinhAnh()
    {
        string[] filesindirectory = Directory.GetFiles(Server.MapPath("~/Uploads"));
        List<String> images = new List<string>(filesindirectory.Count());

        foreach (string item in filesindirectory)
        {
            images.Add(String.Format("~/Uploads/{0}", System.IO.Path.GetFileName(item)));
        }

        RepeaterImages.DataSource = images;
        RepeaterImages.DataBind();
    }
    public string Init_SlugName(string text)
    {
        for (int i = 32; i < 48; i++)
        {
            text = text.Replace(((char)i).ToString(), " ");
        }
        text = text.Replace(".", "-");

        text = text.Replace(" ", "-");

        text = text.Replace(",", "-");

        text = text.Replace(";", "-");

        text = text.Replace(":", "-");

        Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

        string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);

        return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

    }
    public void CapNhatDuLieuBaiViet(string XuLy)
    {
        var MaBaiViet = Request.QueryString["MaBaiViet"];
        DataSet BaiViet = ServiceTinTuc.LayDuLieu("BaiViet where MaBaiViet = '" + MaBaiViet + "' ");
        if (Convert.ToInt32(DanhMuc.SelectedValue) == -1)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Chưa chọn danh mục',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else if (TieuDe.Text.Length < 1 || TomTat.Text.Length < 1 || NoiDung.Text.Length < 1)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Nhập đầy đủ các trường',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else
        {
            try
            {

                string fileName = BaiViet.Tables[0].Rows[0]["HinhThuNho"].ToString();
                if (AnhThuNho.HasFile)
                {
                    string pathName = Path.GetExtension(AnhThuNho.FileName.ToString());
                    fileName = Init_SlugName(AnhThuNho.FileName.ToString() + "-" + DateTime.Now + "-" + 1) + pathName;
                    debug.Text = fileName;
                    ServiceTinTuc.UploadFile(fileName, ChuThichAnh.Text, AnhThuNho.FileContent.ToString(), AnhThuNho.FileBytes);
                }
                bool status = ServiceTinTuc.CapNhatDuLieuBaiViet(Convert.ToInt32(MaBaiViet), TieuDe.Text, TomTat.Text, NoiDung.Text, fileName, ChuThichAnh.Text, 0, DateTime.Now, 3, Convert.ToInt32(DanhMuc.SelectedValue));
                if (status == true)
                {
                    if (XuLy == "ThongBao")
                    {
                        Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Thêm thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
                    }
                    else if (XuLy == "DieuHuong")
                    {
                        Response.Redirect("DanhSach.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Thêm thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Có lỗi vừa xảy ra. Vui lòng thử lại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
            }
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {

        CapNhatDuLieuBaiViet("ThongBao");
        LoadBaiViet();
    }
    protected void SubmitBack_Click(object sender, EventArgs e)
    {

        CapNhatDuLieuBaiViet("DieuHuong");
    }
    protected void UploadImage_Click(object sender, EventArgs e)
    {
        ServiceTinTuc.UploadFile(FileImage.FileName, ChuThichFile.Text, FileImage.FileContent.ToString(), FileImage.FileBytes);
        Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Upload ảnh thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
        LoadHinhAnh();
    }
}