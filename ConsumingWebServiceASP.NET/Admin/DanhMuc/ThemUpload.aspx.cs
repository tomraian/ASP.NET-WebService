using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Upload(object sender, EventArgs e)
    {
        //Get the name of the File.
        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

        //Get the content type of the File.
        string contentType = FileUpload1.PostedFile.ContentType;

        //Read the file data into Byte Array.
        BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream);
        byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);

        //Call the Web Service and pass the File data for upload.
        ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
        ServiceTinTuc.UploadFile(fileName, chuthich.Text, contentType, bytes);
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        //ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
        //bool status = ServiceTinTuc.ThemDuLieuDanhMuc(TenDanhMuc.Text.ToString());
        //if (status == true)
        //{
        //    Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Thêm thành công',position: 'top-right',loaderBg: '#004b36',bgColor:'#0ACF97'}) });</script>");
        //}
        //else
        //{
        //    Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Thêm thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");
        //}
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
}