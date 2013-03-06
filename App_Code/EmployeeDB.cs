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
    public EmployeeDB()
    {
    }
    internal void AddLog(Log log)
    {
        //Behöver en tabell för att spara loggen. Om vi inte ska spara som fil, som redan är implementerat.
    }
    internal void AddSickDays(User user)
    {
        // Get the connectionstring from web.config
        String s = ConfigurationManager.ConnectionStrings["ourConnectionString"].ConnectionString;
        // Create a connection between application and server
        SqlConnection conn = new SqlConnection(s);
        // Create command so we can add/delete/read values from/to database
        SqlCommand command = conn.CreateCommand();

        try
        {
            // Open the connection
            conn.Open();

            // Get the users data
            DateTime illnessStart = user.IllnessStart;
            DateTime medicalCertificateExpires = user.MedicalCertificateExpires;
            bool haveCertificate = user.MedicalCertifcate;
            int medicalCertifcate = haveCertificate ? 1 : 0;
            int useerId = user.UseerId;

            // Create SQL query
            command.CommandText = "INSERT INTO dbo.Illnes (Start, Expires, medicalCertifcate, AnstalldId) VALUES (@illnessStart, @medicalCertificateExpires, @medicalCertifcate, @useerId)";

            // Parameterized queries. Add values to database.
            command.Parameters.Add("@illnessStart", SqlDbType.DateTime);
            command.Parameters.Add("@medicalCertificateExpires", SqlDbType.DateTime);
            command.Parameters.Add("@medicalCertifcate", SqlDbType.Int);
            command.Parameters.Add("@useerId", SqlDbType.Int);

            // Execute command and close the connection
            command.ExecuteNonQuery();
            conn.Close();
        }
        catch (SqlException ex)
        {
            //Nånting
        }

    }
    internal void AddChildSickDays(User user)
    {
        // Get the connectionstring from web.config
        String s = ConfigurationManager.ConnectionStrings["ourConnectionString"].ConnectionString;
        // Create a connection between application and server
        SqlConnection conn = new SqlConnection(s);
        // Create command so we can add/delete/read values from/to database
        SqlCommand command = conn.CreateCommand();

        try
        {
            // Open the connection
            conn.Open();

            // Get the users data
            DateTime illnessStart = user.IllnessStart;
            string socialSecurityNumberChild = user.SocialSecurityNumberChild;
            int useerId = user.UseerId;

            // Create SQL query
            command.CommandText = "INSERT INTO dbo.ChildIllness (Start, socialSecurity, AnstalldId) VALUES (@illnessStart, @socialSecurityNumberChild, @useerId)";

            // Parameterized queries. Add values to database.
            command.Parameters.Add("@illnessStart", SqlDbType.DateTime);
            command.Parameters.Add("@socialSecurityNumberChild", SqlDbType.NChar);
            command.Parameters.Add("@useerId", SqlDbType.Int);

            // Execute command and close the connection
            command.ExecuteNonQuery();
            conn.Close();
        }
        catch (SqlException ex)
        {
            //Nånting
        }
    }
    
    internal User getUserInfo(int useerId)
    {
        // Init
        User user = new User();
        SqlDataReader reader1, reader2;
        string socialSecurityNumberChild;
        
        // Declare userid to get correct userinfo from database
        int userId = useerId;

        // Get the connectionstring from web.config
        String s = ConfigurationManager.ConnectionStrings["ourConnectionString"].ConnectionString;
        // Create a connection between application and server
        SqlConnection conn = new SqlConnection(s);
        // Create command so we can add/delete/read values from/to database
        SqlCommand command = conn.CreateCommand();

        try
        {
            // Open the connection
            conn.Open();

            // Create SQL query
            command.CommandText = "SELECT (Start, Expires, medicalCertifcate, AnstalldId) FROM dbo.Illness WHERE (AnstalldId = $userId)";

            // Dont need to close connection because its handled by using-directive
            using (reader1 = command.ExecuteReader())
            {
                if (reader1 != null)
                {
                    // Get data from database
                    while (reader1.Read())
                    {
                        user.IllnessStart = (DateTime)command.Parameters["Start"].Value;
                        user.MedicalCertificateExpires = (DateTime)command.Parameters["Expires"].Value;
                        user.MedicalCertifcate = (Boolean)command.Parameters["Expires"].Value;
                        user.UseerId = (Int32)command.Parameters["AnstalldId"].Value;
                    }
                }
            }
        }
        catch (SqlException ex)
        {

        }

        return user;
    }
}