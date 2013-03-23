using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

/*
 * FileName: Employee.aspx.cs
 * 
 * Author: Joakim Hising - Front-End Logic
 * Author: Remi Tonning - Back-End Logic
 * 
 */

public partial class Employee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User user = new User();
        if (!user.Auth())
        {
            Response.Redirect("~/Default.aspx");
        }

        //if (RadioButtonList1.SelectedIndex == 1)
        //    txtToDate.Visible = true;
        //if (RadioButtonList1.SelectedIndex == 2)
        //    txtChild.Visible = true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid) 
        {
            User user = new User();

            // Anger vilken typ som är vald i radiobutton-listan. 
            int sicknessType = RadioButtonList1.SelectedIndex;

            Log log = new Log();

            user.GetUserData();
            switch (sicknessType)
            {
                case 0: // "Första sjukdagen"

                    // Loggar akriviteten till loggfilen
                    log.LogMessage("Användare: " + user.GetUserId() + " anmälde sjukskrivning, från IP adress: " + Request.UserHostAddress);
                    
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

                    DateTime dateValue;
                    if (DateTime.TryParse(txtToDate.Text, out dateValue))
                    {
                        // Loggar akriviteten till loggfilen
                        log.LogMessage("Användare: " + user.GetUserId() + " anmälde sjukskrivning av läkare, från IP adress: " + Request.UserHostAddress);

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
                        lblToDateErrorMessage.Visible = true;
                    }

                    break;

                case 2: // "Vård av barn"

                    Match match = Regex.Match(txtChild.Text, @"^\d{6}-\d{4}", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        // Loggar akriviteten till loggfilen
                        log.LogMessage("Användare: " + user.GetUserId() + " anmälde vård av barn, från IP adress: " + Request.UserHostAddress);
                                            //ÅÅMMDD-xxxx
                        // add to database..
                        user.IllnessStart.Add(Convert.ToDateTime(txtFromDate.Text));
                        user.MedicalCertificateExpires.Add(Convert.ToDateTime(txtToDate.Text));
                        user.MedicalCertificate.Add(false);
                        user.ChildIllness.Add(true);
                        user.SocialSecurityNumberChild.Add(txtChild.Text);
                        user.AddSickDays();
                        lblMessage.Text = "Din sjukanmanälan är registrerad!";
                    }
                    else
                    {
                        lblSsnErrorMessage.Visible = true;
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