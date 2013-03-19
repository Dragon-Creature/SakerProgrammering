#pragma checksum "D:\Github\SakerProgrammering\Admin.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "741CB4EC4BF83D315C9CA61A9665244F433C8FE2"

#line 1 "D:\Github\SakerProgrammering\Admin.aspx.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User user = new User();
        if (!user.Auth() && String.Compare(user.Role, "Admin") == 0)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // Init
        User user = new User();
        String medicalCertificateExpires = "";
        String socialSecurityNumberChild = "";

        if (Page.IsValid)
        {
            DataTable dt = new DataTable();
            user.GetEmployeeInfo(txtSearch.Text);   // Hämta all info om en efterfrågad medlem

            /**********Lägg till kolumner**********/
            dt.Columns.Add("ID");
            dt.Columns.Add("Fr.o.m");
            dt.Columns.Add("Läkarintyg");
            dt.Columns.Add("T.o.m");
            dt.Columns.Add("VAB");
            dt.Columns.Add("Barnets Personnummer");

            /****************Spara all medlemsinfo till en datatabell****************/
            for (int i = 0; i < user.IllnessStart.Count; ++i)
            {
                if (user.MedicalCertificate[i] == false)
                    medicalCertificateExpires = string.Empty;
                else
                    medicalCertificateExpires = user.MedicalCertificateExpires[i].ToString();

                if (String.IsNullOrEmpty(user.SocialSecurityNumberChild[i]))
                    socialSecurityNumberChild = string.Empty;
                else
                    socialSecurityNumberChild = user.SocialSecurityNumberChild[i];

                dt.LoadDataRow(new object[] { user.UserId, user.IllnessStart[i], user.MedicalCertificate[i], medicalCertificateExpires, user.ChildIllness[i], socialSecurityNumberChild }, true);
            }

            /**********Spara datatabellen till gridden*************/
            gridViewUserInfo.DataSource = dt;
            gridViewUserInfo.DataBind();
            
            // Loggar aktiviteten
            Log log = new Log();
            log.LogMessage("Admin gjorde en sökning på anställningsnummer: " + txtSearch.Text + " från IP adress: " + Request.UserHostAddress);
        }
    }
}

#line default
#line hidden
