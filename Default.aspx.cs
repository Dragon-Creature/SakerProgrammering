using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * FileName: Default.aspx.cs
 * 
 * Author: Joakim Hising - Front-End Logic
 * Author: Remi Tonning - Front & Back-End Logic
 * 
 */

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblLoginFail.Visible = false;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            User user = new User();
            string userId = txtUserId.Text;

            // Verifiering
            if (user.Login(Convert.ToInt32(userId), txtpassword.Text))
            {
                user.GetUserData();

                // Auktoritet
                if (user.Role == "admin")
                    Server.Transfer("Admin.aspx");
                else
                    Server.Transfer("Employee.aspx");
            }
            else
                lblLoginFail.Visible = true;


            // Loggar aktiviteten
            Log log = new Log();
            // Denna ska köras om inloggningen lyckades:
            log.LogMessage("Användare: " + user.Name + " loggade in på systemet från IP adress: " + Request.UserHostAddress);

            // Och den här om inloggning misslyckas:
            log.LogMessage("Ett misslyckat inloggningsförsök på anställningsnummer: " + txtUserId.Text + " gjordes från IP adress: " + Request.UserHostAddress);
        }
    }
}