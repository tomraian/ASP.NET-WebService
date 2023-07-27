using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService.Models;

public partial class ChiTiet : System.Web.UI.Page
{
    protected ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Ma = Request.QueryString["Ma"];
        ChiTietNoiDung.DataSource = ServiceTinTuc.LayDuLieu("baiViet where MaBaiViet = '" + Ma + "'");
        ChiTietNoiDung.DataBind();
        TinLienQuan.DataSource = ServiceTinTuc.LayBaiVietLienQuan(Convert.ToInt32(Ma.ToString()));
        TinLienQuan.DataBind();
        TinMoiNhat.DataSource = ServiceTinTuc.LayNhungBaiVietMoiNhat();
        TinMoiNhat.DataBind();
        NoiDungBinhLuan.DataSource = ServiceTinTuc.LayBinhLuan(3, Convert.ToInt32(Ma));
        NoiDungBinhLuan.DataBind();

    }
    protected void SubmitBinhLuan_Click1(object sender, EventArgs e)
    {

        string MabaiViet = Request.QueryString["Ma"];
        int MaNguoiDung = 3;
        DateTime ngaydang = DateTime.Now;
        string NoiDungBinhLuan = txtNoiDungBinhLuan.Text;
        bool status = ServiceTinTuc.ThemDuLieuBinhLuan(NoiDungBinhLuan, ngaydang, MaNguoiDung, Convert.ToInt32(MabaiViet));

        if (status)
        {
            Response.Redirect("chitiet.aspx?Ma=" + MabaiViet + "");
        }
    }
}