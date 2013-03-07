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
    public void AddLog(Log log)
    {
        //Behöver en tabell för att spara loggen. Om vi inte ska spara som fil, som redan är implementerat.
    }
    public void AddSickDays(User user)
    {
        using (TransactionScope ts = new TransactionScope())
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {

                Illness illness = new Illness();
                illness.Start = user.IllnessStart;
                illness.Expires = user.MedicalCertificateExpires;
                illness.medicalCertifcate = Convert.ToInt32(user.MedicalCertifcate);
                //illness.AnstalldId = user.UseerId;    FUNGERAR EJ!!!

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
                childIllness.Start = user.IllnessStart;
                childIllness.socialSecurity = user.SocialSecurityNumberChild;
                //childIllness.AnstalldId = user.UseerId;   // TODO!! En konflikt med FOREIGN KEY FUNGERAR EJ!!!
                db.SubmitChanges();

                db.ChildIllnesses.InsertOnSubmit(childIllness);
                db.SubmitChanges();
            }

            ts.Complete();
        }
    }

    public GridView getUserInfo(int useerId)
    {
        GridView gridView1 = new GridView();

        gridView1.DataSource = getIllness(useerId);     // TODO!! Måste checka ifall den returnerar 0, om den gör det. Anropa getChildIllness(int useerId)
        gridView1.DataBind();
        
        return gridView1;
    }
    private List<Illness> getIllness(int useerId)
    {
        List<Illness> user = new List<Illness>();
        using (DataClassesDataContext db = new DataClassesDataContext())
        {
            var userData = from u in db.Illnesses
                           where u.Id == useerId    // TODO!! Ska egentligen vara where u.AnstalldId == useerId. Måste ha nåt fungerande att testa med.
                       select u;


            if (userData.Count() > 0)
                user = userData.ToList();
        }

        return user;
    }
    private List<ChildIllness> getChildIllness(int useerId)
    {
        List<ChildIllness> user = new List<ChildIllness>();
        using (DataClassesDataContext db = new DataClassesDataContext())
        {
            var userData = from u in db.ChildIllnesses
                           where u.Id == useerId
                           select u;

            if (userData.Count() > 0)
                user = userData.ToList();
        }

        return user;
    }
}