using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin : System.Web.UI.Page
{
    List<User> users;
    User user;
    // TEST TEST TEST. Testar lite bara. Detta ska inte var här sen såklart.
    protected void Page_Load(object sender, EventArgs e)
    {
        users = new List<User>();
        user = new User();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            DataTable dt = new DataTable("tjo");
            //DataTable dt = gridViewUserInfo.DataSource as DataTable;
            user.GetEmployeeInfo(txtSearch.Text);
            users.Add(user);

            dt.Columns.Add("ID");
            dt.Columns.Add("Fr.o.m");
            dt.Columns.Add("Läkarintyg");
            dt.Columns.Add("T.o.m");
            dt.Columns.Add("Barnets personnummer");

            for (int i = 0; i < users[0].IllnessStart.Count(); ++i)
            {
                dt.LoadDataRow(new object[]{users[0].UserId, users[0].IllnessStart[i], users[0].MedicalCertifcate[i], users[0].MedicalCertificateExpires[i], users[0].SocialSecurityNumberChild[i]}, true);
            }


            gridViewUserInfo.DataSource = dt;                        // Kan hända att vi behöver en Lista av user, så gridden blir nöjd.
            gridViewUserInfo.DataBind();
            
            // Loggar aktiviteten
            Log log = new Log();
            log.LogMessage("Admin gjorde en sökning på anställningsnummer: " + txtSearch.Text + " från IP adress: " + Request.UserHostAddress);
        }
    }
}