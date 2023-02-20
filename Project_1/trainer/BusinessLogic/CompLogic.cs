using System;
using Models;
using System.Collections;

namespace BusinessLogic
{
    public class CompLogic : ICrud<ACompModel, UCompModel>
    {

        public IList GetAll(int id)
        {
            DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();
            var query = (from st in venkatContext.Comps
                         where st.UsId == id
                         select st).ToList();
            var tr = query.Select(x => new CompModel()
            {
                CompId = x.CompId,
                CompName = x.CompName,
                About = x.About,
                StartDate = x.StartDate,
                EndDate = x.EndDate,

            }).ToList();
            return tr;

        }

        public bool Add(int id, ACompModel aCompModel)
        {
            DataEf.Entities.Comp comp = new DataEf.Entities.Comp();
            comp.About = aCompModel.About;
            comp.CompName = aCompModel.CompName;
            comp.StartDate = aCompModel.StartDate;
            comp.EndDate = aCompModel.EndDate;
            comp.UsId = id;

            DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();
            venkatContext.Comps.Add(comp);
            int res = venkatContext.SaveChanges();
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            };
        }



        public bool Delete(int id)
        {
            DataEf.Entities.Comp comp = new DataEf.Entities.Comp() { CompId = id };
            DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();
            venkatContext.Comps.Attach(comp);
            venkatContext.Comps.Remove(comp);
            int k = venkatContext.SaveChanges();
            if (k > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public bool Update(int id, UCompModel uCompModel)
        {
            DataEf.Entities.Comp comp = new DataEf.Entities.Comp();
            comp.CompId = uCompModel.CompId;
            comp.About = uCompModel.About;
            comp.CompName = uCompModel.CompName;
            comp.StartDate = uCompModel.StartDate;
            comp.EndDate = uCompModel.EndDate;
            comp.UsId = id;
            DataEf.Entities.VenkatContext venkatContext = new DataEf.Entities.VenkatContext();
            venkatContext.Comps.Update(comp);
            int j = venkatContext.SaveChanges();
            if (j > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }



    }
}

