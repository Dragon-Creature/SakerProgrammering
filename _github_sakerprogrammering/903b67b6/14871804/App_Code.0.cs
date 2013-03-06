#pragma checksum "D:\Github\SakerProgrammering\App_Code\EmployeeDB.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19C563B025059490B9194BFD12264E64A8A749E9"

#line 1 "D:\Github\SakerProgrammering\App_Code\EmployeeDB.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;

/// <summary>
/// Summary description for EmployeeDB
/// </summary>
public class EmployeeDB
{
    SqlConnection conn;
    String s;
    SqlCommand command;
	public EmployeeDB()
	{
        //s = ConfigurationManager.ConnectionStrings["dataBaseStructure"].ConnectionString;
        
        conn = new SqlConnection(s);
        command = conn.CreateCommand();
	}
    internal void AddLog(Log log)
    {
        //Behöver en tabell för att spara loggen. Om vi inte ska spara som fil, som redan är implementerat.
    }
    internal void AddSickDays(User user)
    {
        try
        {
            DateTime illnessStart = user.IllnessStart;
            DateTime medicalCertificateExpires = user.MedicalCertificateExpires;
            Bitmap medicalCertifcate = user.MedicalCertifcate;
            int useerId = user.UseerId;
            command.CommandText = "INSERT INTO Illnes (Start, Expires, medicalCertifcate, AnstalldId) VALUES (@illnessStart, @medicalCertificateExpires, @medicalCertifcate, @useerId)";

            command.Parameters.AddWithValue("@illnessStart", illnessStart);
            command.Parameters.AddWithValue("@medicalCertificateExpires", medicalCertificateExpires);
            command.Parameters.AddWithValue("@medicalCertifcate", medicalCertifcate);
            command.Parameters.AddWithValue("@useerId", useerId);

            conn.Open();
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            //Nånting
        }
    }
    internal void AddChildSickDays(User user)
    {
        try
        {
            DateTime illnessStart = user.IllnessStart;
            string socialSecurityNumberChild = user.SocialSecurityNumberChild;
            int useerId = user.UseerId;
            command.CommandText = "INSERT INTO ChildIllness (Start, socialSecurity, AnstalldId) VALUES (@illnessStart, @socialSecurityNumberChild, @useerId)";

            command.Parameters.AddWithValue("@illnessStart", illnessStart);
            command.Parameters.AddWithValue("@socialSecurityNumberChild", socialSecurityNumberChild);
            command.Parameters.AddWithValue("@useerId", useerId);

            conn.Open();
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            //Nånting
        }
    }
    internal User getUserInfo(int useerId)
    {
        User user = new User();

        

        return user;
    }
}

#line default
#line hidden
