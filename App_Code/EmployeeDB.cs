using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Transactions;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for EmployeeDB
/// </summary>
public class EmployeeDB
{
    public EmployeeDB()
    {
    }
    public void AddSickDays(User user)
    {
        using (TransactionScope ts = new TransactionScope())
        {

            using (DataClassesDataContext db = new DataClassesDataContext())
            {

                Illness illness = new Illness();
                illness.Start = user.IllnessStart[0];
                illness.medicalCertifcate = user.MedicalCertifcate[0];
                if (illness.medicalCertifcate == true)     // Om användaren är sjukskriven av läkare, ange data. Annars, ange ett defaultvärde. Blir ett exception annars om inget anges.
                    illness.Expires = user.MedicalCertificateExpires[0];
                else
                    illness.Expires = Convert.ToDateTime("1900-01-01");
                illness.AnstalldId = user.UserId;

                db.Illnesses.InsertOnSubmit(illness);
                db.SubmitChanges();
            }
            ts.Complete();
        }
        
    }
    public void AddChildSickDays(User user)
    {
        using (TransactionScope ts = new TransactionScope())
        {

            using (DataClassesDataContext db = new DataClassesDataContext())
            {

                ChildIllness childIllness = new ChildIllness();
                childIllness.Start = user.IllnessStart[0];
                childIllness.socialSecurity = user.SocialSecurityNumberChild[0];
                childIllness.AnstalldId = user.UserId;
                db.SubmitChanges();

                db.ChildIllnesses.InsertOnSubmit(childIllness);
                db.SubmitChanges();
            }
            ts.Complete();
        }   
    }

    public List<Users> GetUserData(int useerId)
    {
        List<Users> user = new List<Users>();
        DataClassesDataContext db = new DataClassesDataContext();
        
        var userData = from u in db.Users
                    where u.Id == useerId
                    select u;

        if (userData.Count() > 0)
            user = userData.ToList();
        
        return user;
    }
}