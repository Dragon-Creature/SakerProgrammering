using System.Text.RegularExpressions;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

public class User
{
    private int useerId;
    private string name;
    private string role;
    private Regex passwordPolicy;
    private DateTime illnessStart;
    private DateTime medicalCertificateExpires;
    private Bitmap medicalCertifcate;
    private string socialSecurityNumberChild;
    public Boolean Login(int useerId, string Password)
    {
        //TODO get hashed password from database
        string dPassword = "gjfnvj";
        Password = HashPassword(Password);
        if (Password == dPassword && useerId != null && Password != null)
        {
            return true;
        }
        return false;
    }
    public void Logout()
    {
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
    }
    public void AddSickDays(Bitmap MedicalCertifcate)
    {
    }
    public void AddChildSickDays(string SocialSecurityNumberChild)
    {
    }
}