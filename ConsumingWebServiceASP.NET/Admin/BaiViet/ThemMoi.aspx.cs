using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        ExploreImage();
        if (!IsPostBack)
        {
            DanhMuc.DataTextField = "TenDanhMuc";
            DanhMuc.DataValueField = "MaDanhMuc";
            DanhMuc.DataSource = ServiceTinTuc.LayDuLieu("DanhMuc");
            DanhMuc.DataBind();
        }
    }
    public void ExploreImage()
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
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(DanhMuc.SelectedValue) == -1)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Chưa chọn danh mục',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else if (TieuDe.Text.Length < 1 || TomTat.Text.Length < 1 || NoiDung.Text.Length < 1)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Nhập đầy đủ các trường',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else if (!AnhThuNho.HasFile)
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Chưa thêm ảnh hiển thị',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
        else
        {
            try
            {
                string pathName = Path.GetExtension(AnhThuNho.FileName.ToString());
                string fileName = Init_SlugName(AnhThuNho.FileName.ToString() + "-" + DateTime.Now + "-" + 1) + pathName;
                ServiceTinTuc.UploadFile(fileName, ChuThichAnh.Text, AnhThuNho.FileContent.ToString(), AnhThuNho.FileBytes);
                bool status = ServiceTinTuc.ThemDuLieuBaiViet(TieuDe.Text, TomTat.Text, NoiDung.Text, fileName, ChuThichAnh.Text, 0, DateTime.Now, 3, Convert.ToInt32(DanhMuc.SelectedValue));
                if (status == true)
                {
                    Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Thêm thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
                }
                else
                {
                    Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Thêm thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
                }
            }
            catch (Exception ex) //Catch Other Exception
            {
                Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Có lỗi vừa xảy ra. Vui lòng thử lại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
            }
        }
    }
    protected void SubmitBack_Click(object sender, EventArgs e)
    {
        //ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
        //bool status = ServiceTinTuc.ThemDuLieuDanhMuc(TenDanhMuc.Text.ToString());
        //if (status == true)
        //{
        //    Response.Redirect("DanhSach.aspx");
        //}
        //else
        //{
        //    Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Thêm thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        //}
    }
    protected void UploadImage_Click(object sender, EventArgs e)
    {
        if (FileImage.HasFile)
        {
            string pathName = Path.GetExtension(FileImage.FileName.ToString());
            string fileName = Init_SlugName(FileImage.FileName.ToString() + "-" + DateTime.Now + "-" + 1) + pathName;

            ServiceTinTuc.UploadFile(fileName, ChuThichFile.Text, FileImage.FileContent.ToString(), FileImage.FileBytes);
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Upload ảnh thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
            ExploreImage();
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Chưa chọn ảnh để upload',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        }
    }
}