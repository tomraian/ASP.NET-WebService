﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChiTiet : System.Web.UI.Page
{
    protected ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        string Ma = Request.QueryString["Ma"];
        ChiTietNoiDung.DataSource = ServiceTinTuc.LayDuLieu("baiViet where MaBaiViet = '"+Ma+"'");
        ChiTietNoiDung.DataBind();
    }
}