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
        if (Page.IsValid)
        {
            User user = new User();
            string userId = txtUserId.Text.Replace(" ", string.Empty);
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
                else
                    lblLoginFail.Visible = true;
            }

            // Loggar aktiviteten
            Log log = new Log();
            // Denna ska köras om inloggningen lyckades:
            log.LogMessage("Användare: " + user.Name + " loggade in på systemet från IP adress: " + Request.UserHostAddress);

            // Och den här om inloggning misslyckas:
            log.LogMessage("Ett misslyckat inloggningsförsök på anställningsnummer: " + txtUserId.Text + " gjordes från IP adress: " + Request.UserHostAddress);
        }
    }
    //protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    //{
    //    User user = new User();
    //    string userId = Login1.UserName;

    //    int num;
    //    if (int.TryParse(userId, out num))
    //    {
    //        if (!String.IsNullOrEmpty(userId) || !String.IsNullOrEmpty(Login1.Password))
    //        {
    //            if (user.Login(Convert.ToInt32(userId), Login1.Password))
    //            {
    //                user.GetUserData();

    //                if (user.Role == "admin")
    //                    Server.Transfer("Admin.aspx");
    //                else
    //                    Server.Transfer("Employee.aspx");
    //            }
    //        }
    //    }

    //    // Loggar aktiviteten
    //    Log log = new Log();
    //    // Denna ska köras om inloggningen lyckades:
    //    log.LogMessage("Användare: " + user.Name + " loggade in på systemet från IP adress: " + Request.UserHostAddress);

    //    // Och den här om inloggning misslyckas:
    //    log.LogMessage("Ett misslyckat inloggningsförsök på anställningsnummer: " + userId + " gjordes från IP adress: " + Request.UserHostAddress);
    //}
}