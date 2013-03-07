using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin : System.Web.UI.Page
{
    EmployeeDB db;
    User user;
    // TEST TEST TEST. Testar lite bara. Detta ska inte var här sen såklart.
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new EmployeeDB();
        user = new User();
        // TEST 1.
        user.IllnessStart = Convert.ToDateTime("2013-03-06 00:00:00");
        user.MedicalCertificateExpires = Convert.ToDateTime("2013-04-06 00:00:00");
        user.MedicalCertifcate = true; //MedicalCertifcate;
        user.UseerId = 111;

        db.AddSickDays(user);     //FUNGERAR! Förutom att kunna spara userId


        // TEST 2
        //user.IllnessStart = Convert.ToDateTime("2013-03-06 00:00:00");
        //user.SocialSecurityNumberChild = "2011-06-11-0000";
        //user.UseerId = 222;

        //db.AddChildSickDays(user);        //FUNGERAR! Förutom att kunna spara userId



        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            // TEST 3
            DataTable dt = new DataTable();
            DataRow dr1 = dt.NewRow();
            GridView1.DataSource = db.getUserInfo(Convert.ToInt32(txtSearch.Text)).DataSource;
            
            GridView1.DataBind();
        }
    }
}