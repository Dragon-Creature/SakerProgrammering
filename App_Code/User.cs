using System.Text.RegularExpressions;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;
using System.Web;
using System.Web.UI.WebControls;

public class User
{
    private int useerId;//
    private string name;
    private string role;
    private Regex passwordPolicy;
    private DateTime illnessStart;//
    private DateTime medicalCertificateExpires;//
    private bool medicalCertifcate;//
    private string socialSecurityNumberChild;//
    private EmployeeDB employeeDB = new EmployeeDB();

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
    public bool MedicalCertifcate
    {
        get { return this.medicalCertifcate; }
        set { this.medicalCertifcate = value; }
    }
    public string SocialSecurityNumberChild
    {
        get { return this.socialSecurityNumberChild; }
        set { this.socialSecurityNumberChild = value; }
    }

    public Boolean Login(int useerId, string Password)
    {

        GridView gw = employeeDB.getUserInfo(useerId);
        string dPassword = "";
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
            GridView gw = employeeDB.getUserInfo(useerId);
        }
    }
    public void AddSickDays(Bitmap MedicalCertifcate)
    {

    }
    public void AddChildSickDays(string SocialSecurityNumberChild)
    {

    }
}