#pragma checksum "D:\Github\SakerProgrammering\App_Code\User.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2A43F51500560EA2687DC49DCD36C6446A046C9E"

#line 1 "D:\Github\SakerProgrammering\App_Code\User.cs"
using System.Text.RegularExpressions;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;
using System.Web;

public class User
{
    private int useerId;//
    private string name;
    private string role;
    private Regex passwordPolicy;
    private DateTime illnessStart;//
    private DateTime medicalCertificateExpires;//
    private Bitmap medicalCertificate;//
    private string socialSecurityNumberChild;//

    public int UseerId 
    {
        get { return this.useerId; }
        set { this.useerId = value; }
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public string Role
    {
        get { return this.role; }
        set { this.role = value; }
    }
    public DateTime IllnessStart
    {
        get { return this.illnessStart; }
        set { this.illnessStart = value; }
    }
    public DateTime MedicalCertificateExpires
    {
        get { return this.medicalCertificateExpires; }
        set { this.medicalCertificateExpires = value; }
    }
    public Bitmap MedicalCertificate
    {
        get { return this.medicalCertificate; }
        set { this.medicalCertificate = value; }
    }
    public string SocialSecurityNumberChild
    {
        get { return this.socialSecurityNumberChild; }
        set { this.socialSecurityNumberChild = value; }
    }

    public Boolean Login(int useerId, string Password)
    {

        //TODO get hashed password from database
        string dPassword = "gjfnvj";
        Password = HashPassword(Password);
        if (Password == dPassword && useerId != null && Password != null)
        {
            HttpSessionState httpss = HttpContext.Current.Session;
            httpss["useerId"] = useerId;
            httpss["Password"] = Password;
            return true;
        }
        return false;
    }
    public void Logout()
    {
        HttpSessionState httpss = HttpContext.Current.Session;
        httpss.Remove("useerId");
        httpss.Remove("Password");
    }
    private string HashPassword(string Password)
    {
        SHA256Managed crypt = new SHA256Managed();
        string hash = String.Empty;
        byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(Password), 0, Encoding.ASCII.GetByteCount(Password));
        foreach (byte bit in crypto)
        {
            hash += bit.ToString("x2");
        }
        return hash;
    }
    public void GetUserData()
    {
        HttpSessionState httpss = HttpContext.Current.Session;
        int useerId = Convert.ToInt32(httpss["useerId"]);
        string Password = Convert.ToString(httpss["Password"]);
        if (Login(useerId, Password))
        {
            //TODO get userdata.
        }
    }
    public void AddSickDays(Bitmap MedicalCertificate)
    {

    }
    public void AddChildSickDays(string SocialSecurityNumberChild)
    {

    }
}

#line default
#line hidden
