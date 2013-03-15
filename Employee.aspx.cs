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

                    // TODO Vart hämtar jag användarnamnet ifrån? Sessionen kanske?
                    log.LogMessage("Användare: " + userId + " anmälde sjukskrivning, från IP adress: " + Request.UserHostAddress);
                    
                    // TODO add to database..
                    user.IllnessStart[0] = Convert.ToDateTime(txtFromDate.Text);
                    user.AddSickDays();
                    break;

                case 1: // "Sjukskriven av läkare"
                    
                    DateTime toDate = Convert.ToDateTime(txtToDate.Text);

                    // TODO Vart hämtar jag användarnamnet ifrån? Sessionen kanske?
                    log.LogMessage("Användare: " + userId + " anmälde sjukskrivning av läkare, från IP adress: " + Request.UserHostAddress);

                    // TODO add to database..
                    user.IllnessStart[0] = Convert.ToDateTime(txtFromDate.Text);
                    user.MedicalCertificateExpires[0] = Convert.ToDateTime(txtToDate.Text);
                    user.MedicalCertifcate[0] = true;
                    user.AddSickDays();
                    break;

                case 2: // "Vård av barn"
                    
                    string ssn = txtChild.Text;

                    // TODO Vart hämtar jag användarnamnet ifrån? Sessionen kanske?
                    log.LogMessage("Användare: " + userId + " anmälde vård av barn, från IP adress: " + Request.UserHostAddress);

                    // TODO add to database..
                    user.IllnessStart[0] = Convert.ToDateTime(txtFromDate.Text);
                    user.SocialSecurityNumberChild[0] = ssn;
                    user.AddChildSickDays();
                    break;
            }
        }
    }
}