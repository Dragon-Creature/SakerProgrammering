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
        s = ConfigurationManager.ConnectionStrings["dataBaseStructure"].ConnectionString;
        conn = new SqlConnection(s);
        command = conn.CreateCommand();
	}
    internal void AddLog(Log log)
    {
        //Behöver en tabell för att spara loggen.
    }
    internal void AddSickDays(User user)
    {
        try
        {
            DateTime illnessStart = user.IllnessStart;
            DateTime medicalCertificateExpires = user.MedicalCertificateExpires;
            Bitmap medicalCertifcate = user.MedicalCertifcate;
            int anstalldId = user.UseerId;
            command.CommandText = "INSERT INTO Illnes (Start, Expires, medicalCertifcate, AnstalldId) VALUES (@illnessStart, @medicalCertificateExpires, @medicalCertifcate, @anstalldId)";

            command.Parameters.AddWithValue("@illnessStart", illnessStart);
            command.Parameters.AddWithValue("@medicalCertificateExpires", medicalCertificateExpires);
            command.Parameters.AddWithValue("@medicalCertifcate", medicalCertifcate);
            command.Parameters.AddWithValue("@anstalldId", anstalldId);

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
            int anstalldId = user.UseerId;
            command.CommandText = "INSERT INTO ChildIllness (Start, socialSecurity, AnstalldId) VALUES (@illnessStart, @socialSecurityNumberChild, @anstalldId)";

            command.Parameters.AddWithValue("@illnessStart", illnessStart);
            command.Parameters.AddWithValue("@socialSecurityNumberChild", socialSecurityNumberChild);
            command.Parameters.AddWithValue("@anstalldId", anstalldId);
        }
        catch (SqlException ex)
        {
            //Nånting
        }
    }
}