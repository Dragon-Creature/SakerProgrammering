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
                illness.medicalCertifcate = Convert.ToInt32(user.MedicalCertifcate);
                if(illness.medicalCertifcate == 1)     // Om användaren är sjukskriven av läkare, ange data. Annars, ange ett defaultvärde. Blir ett exception annars om inget anges.
                    illness.Expires = user.MedicalCertificateExpires;
                else
                    illness.Expires = Convert.ToDateTime("1900-01-01");
                illness.AnstalldId = user.UseerId;

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
                childIllness.AnstalldId = user.UseerId;   // TODO!! En konflikt med FOREIGN KEY FUNGERAR EJ!!!
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
        List<Users> user = new List<Users>();
        using (DataClassesDataContext db = new DataClassesDataContext())
        {
            var userData = from u in db.Users
                       where u.Id == useerId
                       select u;

            if (userData.Count() > 0)
                user = userData.ToList();
        }

        gridView1.DataSource = user;
        gridView1.DataBind();

        return gridView1;
    }
    //private List<Illness> getIllness(int useerId)
    //{
    //    List<Illness> user = new List<Illness>();
    //    using (DataClassesDataContext db = new DataClassesDataContext())
    //    {
    //        var userData = from u in db.Illnesses
    //                       where u.Id == useerId    // TODO!! Ska egentligen vara where u.AnstalldId == useerId. Måste ha nåt fungerande att testa med.
    //                       select u;


    //        if (userData.Count() > 0)
    //            user = userData.ToList();
    //    }

    //    return user;
    //}
    //private List<ChildIllness> getChildIllness(int useerId)
    //{
    //    List<ChildIllness> user = new List<ChildIllness>();
    //    using (DataClassesDataContext db = new DataClassesDataContext())
    //    {
    //        var userData = from u in db.ChildIllnesses
    //                       where u.Id == useerId
    //                       select u;

    //        if (userData.Count() > 0)
    //            user = userData.ToList();
    //    }

    //    return user;
    //}
}