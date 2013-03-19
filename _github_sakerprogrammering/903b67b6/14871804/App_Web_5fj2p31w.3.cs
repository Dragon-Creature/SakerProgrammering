#pragma checksum "D:\Github\SakerProgrammering\Default.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1867666594FE5C6F7834436DDAD1EE448D1A4321"

#line 1 "D:\Github\SakerProgrammering\Default.aspx.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        User user = new User();
        string userId = txtUsUserId.Text.Replace(" ", string.Empty);
        string password = txtpassword.Text.Replace(" ", string.Empty);

        if (!String.IsNullOrEmpty(userId) || !String.IsNullOrEmpty(password))
        {
            if (user.Login(Convert.ToInt32(userId), password))
            {
                user.GetUserData();

                if (user.Role == "admin")
                    Server.Transfer("Admin.aspx");
                else
                    Server.Transfer("Employee.aspx");
            }
        }
        
        // Loggar aktiviteten
        Log log = new Log();
        // Denna ska köras om inloggningen lyckades:
        log.LogMessage("Användare: " + user.Name + " loggade in på systemet från IP adress: " + Request.UserHostAddress);

        // Och den här om inloggning misslyckas:
        log.LogMessage("Ett misslyckat inloggningsförsök på anställningsnummer: " + txtUsUserId.Text + " gjordes från IP adress: " + Request.UserHostAddress);
    }
}

#line default
#line hidden
