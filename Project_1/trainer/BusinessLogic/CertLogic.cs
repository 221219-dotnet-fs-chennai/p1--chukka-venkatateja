//using System;
//using Models;
//using System.Collections;

//namespace BusinessLogic
//{
//    public class CertLogic : ICrud<ACertModel, UCertModel>
//    {

//        public IList GetAll(int id)
//        {
//            DataEf.Entities.VenkatContext cnt = new DataEf.Entities.VenkatContext();


//            var query1 = (from st in cnt.Certs
//                          where st.UsId == id
//                          select st).ToList();

//            var tr = query1.Select(x => new CertModel()
//            {
//                CertId = x.CertId,
//                CertificationName = x.CertificationName,
//                AcquiredFrom = x.AcquiredFrom,
//                CertLicence = x.CertLicence
//            }).ToList();

//            return tr;
//        }





//        public bool Add(int id, ACertModel aCertModel)
//        {
//            DataEf.Entities.Cert cert = new DataEf.Entities.Cert();

//            cert.CertificationName = aCertModel.CertificationName;
//            cert.AcquiredFrom = aCertModel.AcquiredFrom;
//            cert.CertLicence = aCertModel.CertLicence;
//            cert.UsId = id;

//            DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();
//            venkatContext.Certs.Add(cert);

//            int res = venkatContext.SaveChanges();
//            if (res > 0)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }




//        public bool Delete(int id)
//        {
//            DataEf.Entities.Cert cert = new DataEf.Entities.Cert() { CertId = id };
//            DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();
//            venkatContext.Certs.Attach(cert);
//            venkatContext.Certs.Remove(cert);
//            int k = venkatContext.SaveChanges();
//            if (k > 0)
//            {
//                return true;
//            }
//            else
//            {
//                return true;
//            }
//        }




//        public bool Update(int id, UCertModel uCertModel)
//        {
//            DataEf.Entities.Cert cert = new DataEf.Entities.Cert();
//            cert.CertId = uCertModel.CertId;
//            cert.AcquiredFrom = uCertModel.AcquiredFrom;
//            cert.CertificationName = uCertModel.CertificationName;
//            cert.CertLicence = uCertModel.CertLicence;
//            cert.UsId = id;

//            DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();
//            venkatContext.Certs.Update(cert);
//            int j = venkatContext.SaveChanges();
//            if (j > 0)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//    }
//}

