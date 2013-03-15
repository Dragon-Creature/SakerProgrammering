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
    private int userId = -1;//
    private string name;
    private string role;
    private Regex passwordPolicy;
    private List<DateTime> illnessStart = new List<DateTime>();//
    private List<DateTime> medicalCertificateExpires = new List<DateTime>();//
    private List<bool> medicalCertifcate = new List<bool>();//
    private List<string> socialSecurityNumberChild = new List<string>();//
    private EmployeeDB employeeDB = new EmployeeDB();

    public int UserId 
    {
        get { return this.userId; }
        set { this.userId = value; }
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
    public List<DateTime> IllnessStart
    {
        get { return this.illnessStart; }
        set { this.illnessStart = value; }
    }
    public List<DateTime> MedicalCertificateExpires
    {
        get { return this.medicalCertificateExpires; }
        set { this.medicalCertificateExpires = value; }
    }
    public List<bool> MedicalCertifcate
    {
        get { return this.medicalCertifcate; }
        set { this.medicalCertifcate = value; }
    }
    public List<string> SocialSecurityNumberChild
    {
        get { return this.socialSecurityNumberChild; }
        set { this.socialSecurityNumberChild = value; }
    }

    public Boolean Login(int useerId, string Password)
    {
        List<Users> user = employeeDB.GetUserData(useerId);
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
    public void GetUserData()
    {
        HttpSessionState httpss = HttpContext.Current.Session;
        int useerId = Convert.ToInt32(httpss["useerId"]);
        string Password = Convert.ToString(httpss["Password"]);
        Users user = new Users();
        
        user = employeeDB.GetUserData(useerId)[0];
        this.UserId = user.Id;
        this.Name = user.Name;
        this.Role = user.Roles.RoleName;
        
        for (int i = 0; i < user.Illnesses.Count; ++i)
        {
            this.IllnessStart.Add(user.Illnesses[i].Start);
            this.MedicalCertifcate.Add(user.Illnesses[i].medicalCertifcate);
        }

        for (int i = 0; i < user.ChildIllnesses.Count; ++i)
            this.SocialSecurityNumberChild.Add(user.ChildIllnesses[i].socialSecurity);
    }
    public void GetEmployeeInfo(string userId)
    {
        Users user = new Users();

        user = employeeDB.GetUserData(Convert.ToInt32(userId))[0];
        this.UserId = user.Id;
        this.Name = user.Name;
        this.Role = user.Roles.RoleName;
        if (user.Illnesses.Count > 0)
        {
            for (int i = 0; i < user.Illnesses.Count; ++i)
            {
                this.IllnessStart.Add(user.Illnesses[i].Start);
                this.MedicalCertifcate.Add(user.Illnesses[i].medicalCertifcate);
                this.medicalCertificateExpires.Add(user.Illnesses[i].Expires);
            }
        }
        for (int i = 0; i < user.ChildIllnesses.Count; ++i)
            this.SocialSecurityNumberChild.Add(user.ChildIllnesses[i].socialSecurity);
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