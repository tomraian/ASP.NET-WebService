using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebService.Models;

public partial class DangNhap : System.Web.UI.Page
{
    protected ServiceTinTuc.WebService1SoapClient ServiceTinTuc = new ServiceTinTuc.WebService1SoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        //HttpCookie cookie = new HttpCookie("Auth_ID");
        //cookie.Value = "abc"; 
        //cookie.Expires = DateTime.Now.AddHours(3);
        //Response.SetCookie(cookie);
       
    }
    protected void BtnDangNhap_Click(object sender, EventArgs e)
    {
        string Email = emailaddress.Value;
        string MatKhau = password.Value;
        int CheckLogin = ServiceTinTuc.Authencation(Email, MatKhau, 1);
        if (CheckLogin == 1)
        {
            HttpCookie cookie = new HttpCookie("Auth_Info");

            DataSet NguoiDung = ServiceTinTuc.LayDuLieu("nguoidung where email = '" + Email + "' ");
            string MaNguoiDung = NguoiDung.Tables[0].Rows[0]["MaNguoiDung"].ToString();
            string TenNguoiDung = NguoiDung.Tables[0].Rows[0]["TenNguoiDung"].ToString();

            List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
{
        new KeyValuePair<string, string>("UserId",MaNguoiDung ),
        new KeyValuePair<string, string>("UserName",TenNguoiDung ),
};

            kvpList.Insert(0, new KeyValuePair<string, string>("New Key 1", "New Value 1"));
            foreach (KeyValuePair<string, string> kvp in kvpList)
            {
                cookie.Value += string.Format("{0} {1}", kvp.Key, kvp.Value);
            }
            Response.Cookies.Add(cookie);
            cookie.Expires = DateTime.Now.AddHours(3);
            Response.SetCookie(cookie);
            //Response.Redirect("Default.aspx");

        }
        else if (CheckLogin == 0)
        {
            Debug.Text = "Sai email hiac mk";
        }
        else
        {
            Debug.Text = "co loi vua xat ra";
        }
    }

}