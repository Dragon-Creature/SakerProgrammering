using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    // Testar lite bara. Detta ska inte var här sen såklart.
    protected void Page_Load(object sender, EventArgs e)
    {
        // Fungerar inte. Vi får en connection till databas, BRA!!! Men sen blir det ett exception vid command.ExecuteNonQuery();
        EmployeeDB db = new EmployeeDB();
        User user = new User();
        user.IllnessStart = Convert.ToDateTime("2013-03-06 00:00:00");
        user.MedicalCertificateExpires = Convert.ToDateTime("2013-04-06 00:00:00");
        user.MedicalCertifcate = true; //MedicalCertifcate;
        user.UseerId = 111;

        db.AddSickDays(user);

        db.getUserInfo(111);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
               
        }
    }
}