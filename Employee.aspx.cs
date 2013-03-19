using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User user = new User();
        if (!user.Auth())
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid) 
        {
            User user = new User();
            int userId = user.getUserId();
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);

            // Anger vilken typ som är vald i radiobutton-listan. 
            int sicknessType = RadioButtonList1.SelectedIndex;

            Log log = new Log();

            user.GetUserData();
            switch (sicknessType)
            {
                case 0: // "Första sjukdagen"

                    // Loggar akriviteten till loggfilen
                    log.LogMessage("Användare: " + userId + " anmälde sjukskrivning, från IP adress: " + Request.UserHostAddress);
                    
                    // add to database..
                    user.IllnessStart.Add(Convert.ToDateTime(txtFromDate.Text));
                    user.MedicalCertificateExpires.Add(Convert.ToDateTime(txtToDate.Text));
                    user.MedicalCertificate.Add(false);
                    user.ChildIllness.Add(false);
                    user.SocialSecurityNumberChild.Add(string.Empty);
                    user.AddSickDays();
                    lblMessage.Text = "Din sjukanmanälan är registrerad!";
                    break;

                case 1: // "Sjukskriven av läkare"
                    
                    DateTime toDate = Convert.ToDateTime(txtToDate.Text);

                    if (!String.IsNullOrWhiteSpace(txtToDate.Text))
                    {
                        // Loggar akriviteten till loggfilen
                        log.LogMessage("Användare: " + userId + " anmälde sjukskrivning av läkare, från IP adress: " + Request.UserHostAddress);

                        // add to database..
                        user.IllnessStart.Add(Convert.ToDateTime(txtFromDate.Text));
                        user.MedicalCertificateExpires.Add(Convert.ToDateTime(txtToDate.Text));
                        user.MedicalCertificate.Add(true);
                        user.ChildIllness.Add(false);
                        user.SocialSecurityNumberChild.Add(string.Empty);
                        user.AddSickDays();
                        lblMessage.Text = "Din sjukanmanälan är registrerad!";
                    }
                    else
                    {
                        lblMessage.Text = "Ange ett slutdatum för sjukskrivningen.";
                    }

                    break;

                case 2: // "Vård av barn"

                    if (!String.IsNullOrWhiteSpace(txtChild.Text))
                    {

                        string ssn = txtChild.Text;

                        // Loggar akriviteten till loggfilen
                        log.LogMessage("Användare: " + userId + " anmälde vård av barn, från IP adress: " + Request.UserHostAddress);

                        // add to database..
                        user.IllnessStart.Add(Convert.ToDateTime(txtFromDate.Text));
                        user.MedicalCertificateExpires.Add(Convert.ToDateTime(txtToDate.Text));
                        user.MedicalCertificate.Add(false);
                        user.ChildIllness.Add(true);
                        user.SocialSecurityNumberChild.Add(ssn);
                        user.AddSickDays();
                        lblMessage.Text = "Din sjukanmanälan är registrerad!";
                    }
                    else 
                    {
                        lblMessage.Text = "Ange barnets personnummer.";
                    }

                   break;
            }
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        User user = new User();
        user.Logout();
        Response.Redirect("Default.aspx");
    }
}