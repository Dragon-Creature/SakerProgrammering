using System.Text.RegularExpressions;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public class User
{
    private int useerId = -1;//
    private string name;
    private string role;
    private Regex passwordPolicy;
    private DateTime illnessStart;//
    private DateTime medicalCertificateExpires;//
    private bool medicalCertifcate = false;//
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
        List<Users> user = employeeDB.getUserInfo(useerId);
        string dPassword = user[0].Password.Replace(" ", string.Empty);
        Password = HashPassword(Password);
        if ((String.Compare(Password, dPassword)) == 0 && useerId == user[0].Id)
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
    public void GetUserData(int userId)
    {
        HttpSessionState httpss = HttpContext.Current.Session;
        int useerId = Convert.ToInt32(httpss["useerId"]);
        string Password = Convert.ToString(httpss["Password"]);
        Users user = new Users();
        DataClassesDataContext db = new DataClassesDataContext();
        
        //GridView gw = employeeDB.getUserInfo(useerId);
        user = employeeDB.getUserInfo(useerId)[0];
        this.UseerId = user.Id;
        this.Name = user.Name;
        this.Role = user.Roles[0].RoleName;
        this.IllnessStart = user.Illnesses[0].Start;
        this.MedicalCertifcate = user.Illnesses[0].medicalCertifcate;
        this.SocialSecurityNumberChild = user.ChildIllnesses[0].socialSecurity;
    }
    public int getUserId()
    {
        HttpSessionState httpss = HttpContext.Current.Session;
        return Convert.ToInt32(httpss["useerId"]);
    }
    public void AddSickDays()
    {
        employeeDB.AddSickDays(this);
    }
    public void AddChildSickDays()
    {
        employeeDB.AddChildSickDays(this);
    }
}