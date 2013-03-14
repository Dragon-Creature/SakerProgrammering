using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin : System.Web.UI.Page
{
    User user;
    // TEST TEST TEST. Testar lite bara. Detta ska inte var här sen såklart.
    protected void Page_Load(object sender, EventArgs e)
    {
        user = new User();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            user.GetUserData(Convert.ToInt32(txtSearch.Text));
            GridView1.DataSource = user;                        // Kan hända att vi behöver en Lista av user, så gridden blir nöjd.
            
            GridView1.DataBind();
            
            // Loggar aktiviteten
            Log log = new Log();
            log.LogMessage("Admin gjorde en sökning på anställningsnummer: " + txtSearch.Text + " från IP adress: " + Request.UserHostAddress);
        }
    }
}