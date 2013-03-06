#pragma checksum "D:\Github\SakerProgrammering\Default.aspx.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "426AD1A58524B589624B2C6DAA1BC79AAB88CB55"

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
        user.Login(Convert.ToInt32(txtUsUserId.Text), txtpassword.Text);
    }
}

#line default
#line hidden
