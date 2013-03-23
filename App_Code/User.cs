using System.Text.RegularExpressions;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;

/*
 * FileName: User.cs
 * 
 * Author: Simon Lindgren och Remi Tonning
 * 
 */

public class User
{
    /// <summary>
    /// Initiering / Deklaration
    /// </summary>
    private int userId = -1;//
    private string name;
    private string role;
    private List<DateTime> illnessStart = new List<DateTime>();//
    private List<DateTime> medicalCertificateExpires = new List<DateTime>();//
    private List<bool> medicalCertificate = new List<bool>();//
    private List<string> socialSecurityNumberChild = new List<string>();//
    private List<bool> childIllness = new List<bool>();
    private EmployeeDB employeeDB = new EmployeeDB();

    /// <summary>
    /// Egenskaper
    /// </summary>
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
    public List<bool> MedicalCertificate
    {
        get { return this.medicalCertificate; }
        set { this.medicalCertificate = value; }
    }
    public List<string> SocialSecurityNumberChild
    {
        get { return this.socialSecurityNumberChild; }
        set { this.socialSecurityNumberChild = value; }
    }
    public List<bool> ChildIllness
    {
        get { return this.childIllness; }
        set { this.childIllness = value; }
    }

    
    /// <summary>
    /// Verifiering
    /// Checkar om anv�ndaren finns i databasen
    /// genom databasklassen
    /// och att l�senord st�mmer �verens
    /// </summary>
    /// <param name="useerId">Anv�ndaren id</param>
    /// <param name="Password">Anv�ndare l�senord</param>
    /// <returns></returns>
    public Boolean Login(int useerId, string Password)
    {
        Users user = employeeDB.GetUserData(useerId);
        if (user != null)
        {
            string dPassword = user.Password.Replace(" ", string.Empty);
            Password = HashPassword(Password);
            return Login(useerId, Password, dPassword);
        }
        return false;
    }

    /// <summary>
    /// Verifiering
    /// J�mf�r anv�ndaren l�senord med l�senord fr�n databas
    /// </summary>
    /// <param name="useerId">Anv�ndarens id</param>
    /// <param name="Password">Anv�ndarens l�senord</param>
    /// <param name="dPassword">L�senord fr�n databas</param>
    /// <returns></returns>
    private Boolean Login(int useerId, string Password, string dPassword)
    {
        if ((String.Compare(Password, dPassword)) == 0 && useerId > 0)
        {
            HttpSessionState httpss = HttpContext.Current.Session;
            httpss["useerId"] = useerId;
            httpss["Password"] = Password;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checkar om anv�ndare �r inloggad
    /// </summary>
    /// <returns></returns>
    public Boolean Auth()
    {
        HttpSessionState httpss = HttpContext.Current.Session;
        int useerId = Convert.ToInt32(httpss["useerId"]);
        string Password = Convert.ToString(httpss["Password"]);
        if (String.IsNullOrEmpty(Password))
        {
            return false;
        }
        Users user = employeeDB.GetUserData(useerId);
        if (user != null)
        {
            string dPassword = user.Password.Replace(" ", string.Empty);
            return Login(useerId, Password, dPassword);
        }
        return false;
    }

    /// <summary>
    /// Loggar ut anv�ndare
    /// </summary>
    public void Logout()
    {
        HttpSessionState httpss = HttpContext.Current.Session;
        httpss.Remove("useerId");
        httpss.Remove("Password");
    }

    /// <summary>
    /// Hashar anv�ndarens l�senord vid inloggning,
    /// med SHA256
    /// </summary>
    /// <param name="Password"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Spar all info om anv�ndaren h�mtat
    /// fr�n databasen via databasklassen
    /// </summary>
    public void GetUserData()
    {
        HttpSessionState httpss = HttpContext.Current.Session;
        int useerId = Convert.ToInt32(httpss["useerId"]);
        Users user = new Users();

        user = employeeDB.GetUserData(useerId);
        if (user != null)
        {
            this.UserId = user.Id;
            this.Name = user.Name.Replace(" ", string.Empty);
            this.Role = user.Roles.RoleName.Replace(" ", string.Empty);

            for (int i = 0; i < user.Illnesses.Count; ++i)
            {
                this.IllnessStart.Add(user.Illnesses[i].Start);
                this.MedicalCertificate.Add((bool)user.Illnesses[i].MedicalCertificate);
                this.MedicalCertificateExpires.Add(user.Illnesses[i].Expires);
                this.ChildIllness.Add((bool)user.Illnesses[i].ChildIllness);
                this.SocialSecurityNumberChild.Add(user.Illnesses[i].SocialSecurity);
            }
        }
    }

    /// <summary>
    /// Spar all info om anv�ndaren h�mtat
    /// fr�n databasen
    /// Sidor f�r anv�ndare med adminr�ttigheter
    /// �r beroende av denna metod
    /// </summary>
    /// <param name="userId"></param>
    public void GetEmployeeInfo(string userId)
    {
        Users user = new Users();

        user = employeeDB.GetUserData(Convert.ToInt32(userId));
        if (user != null)
        {
            this.UserId = user.Id;
            this.Name = user.Name.Replace(" ", string.Empty);
            this.Role = user.Roles.RoleName.Replace(" ", string.Empty);

            for (int i = 0; i < user.Illnesses.Count; ++i)
            {
                this.IllnessStart.Add(user.Illnesses[i].Start);
                this.MedicalCertificate.Add((bool)user.Illnesses[i].MedicalCertificate);
                this.MedicalCertificateExpires.Add(user.Illnesses[i].Expires);
                this.ChildIllness.Add((bool)user.Illnesses[i].ChildIllness);
                this.SocialSecurityNumberChild.Add(user.Illnesses[i].SocialSecurity);
            }
        }
    }

    /// <summary>
    /// H�mtar anv�ndarens id
    /// </summary>
    /// <returns></returns>
    public int GetUserId()
    {
        HttpSessionState httpss = HttpContext.Current.Session;
        return Convert.ToInt32(httpss["useerId"]);
    }

    /// <summary>
    /// Spara sjukanm�lan till databas
    /// via databasklassen.
    /// Sidor f�r sjukanm�lan nyttjar 
    /// denna metod
    /// </summary>
    public void AddSickDays()
    {
        employeeDB.AddSickDays(this);
    }
}