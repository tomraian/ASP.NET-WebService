using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        NextNews.DataSource = ServiceTinTuc.LayDanhSachBaiViet();
        NextNews.DataBind();
        carousel.DataSource = ServiceTinTuc.LayDanhSachBaiViet();
        carousel.DataBind();
    }
}