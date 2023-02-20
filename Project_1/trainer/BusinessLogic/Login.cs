using System.Numerics;
using System.Xml.Linq;
//using DataEf;
using DataEf;
using Models;
using static Azure.Core.HttpHeader;
using System.Collections.Generic;
using System.Collections;


namespace BusinessLogic;
public class Login
{

    public int LoginSubmit(string EmailID, string Password)
    {
        int usid = 0;
        DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();

        var query = from b in venkatContext.Users where b.EmailId == EmailID && b.Password == Password select b;

        foreach (var q in query)
        {
            usid = q.UserId;

        }

        if (usid > 0)
        {
            return usid;
        }

        else
        {
            return usid;
        }
    }


    public int SignUpSubmit(UserModel user)
    {
        DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();
        DataEf.Entities.User user1 = new DataEf.Entities.User();

        user1.FirstName = user.FirstName;
        user1.LastName = user.LastName;
        user1.EmailId = user.EmailId;
        user1.Password = user.Password;
        user1.PhoneNo = user.PhoneNo;
        user1.City = user.City;

        venkatContext.Users.Add(user1);
        int i = venkatContext.SaveChanges();
        return i;
    }

    public IQueryable<DataEf.Entities.User> SignUpUser()
    {
        DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();

        var query = from b in venkatContext.Users select b;

        return query;

    }

    //public IList GetAll(int id)
    //{
    //    DataEf.Entities.VenkatContext cnt = new DataEf.Entities.VenkatContext();


    //    var query1 = (from st in cnt.Certs
    //                  where st.UsId == id
    //                  select st).ToList();

    //    var tr = query1.Select(x => new CertModel()
    //    {
    //        CertId = x.CertId,
    //        CertificationName = x.CertificationName,
    //        AcquiredFrom = x.AcquiredFrom,
    //        CertLicence = x.CertLicence
    //    }).ToList();

    //    return tr;
    //}

    public IList getUser(int id)
    {
        DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();

        var query = (from st in venkatContext.Users
                     where st.UserId == id
                     select st).ToList();

        return query;
    }
}








public class LoginClass
{
    public string EmailID { get; set; }
    public string Password { get; set; }

}

