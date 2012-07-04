using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.MvTech.BusinessEntities;
using Com.MvTech.BusinessEntities.Users;
using Com.MvTech.BusinessEntities.Security;
using Com.MvTech.BusinessEntities.BP;
using Com.MvTech.Db.NHibernateProvider;
using NHibernate;

namespace TesterConsole
{
    class Program
    {
        public Country AddCountry()
        {
            Country country = null;                
            using (ISession configDbSession = NHibernateSessionProvider.ConfigDBSession.OpenSession())
            {
                using (var trnx = configDbSession.BeginTransaction())
                {
                    try
                    {
                        country = new Country();
                        country.Name = "India";
                        configDbSession.Save(country);
                        trnx.Commit();                        
                    }
                    catch (Exception e)
                    {
                        string msg = e.Message;
                    }
                }
            }
            return country;
        }
        public State AddState(Country country)
        {
            State state = null;                
            using (ISession configDbSession = NHibernateSessionProvider.ConfigDBSession.OpenSession())
            {
                using (var trnx = configDbSession.BeginTransaction())
                {
                    try
                    {
                        state = new State();
                        state.Name = "Tamil Nadu";
                        state.Country = country;
                        configDbSession.Save(state);
                        trnx.Commit();
                    }
                    catch (Exception e)
                    {
                        string msg = e.Message;
                    }
                }
            }
            return state;
        }
        public City AddCity(State state)
        {
            City city = null;
            using (ISession configDbSession = NHibernateSessionProvider.ConfigDBSession.OpenSession())
            {
                using (var trnx = configDbSession.BeginTransaction())
                {
                    try
                    {
                        city = new City();
                        city.Name = "Podatur Pet";
                        city.State = state;
                        configDbSession.Save(city);
                        trnx.Commit();
                    }
                    catch (Exception e)
                    {
                        string msg = e.Message;
                    }
                }
            }
            return city;
        }

        public void AddRole()
        {
            using (ISession userDbSession = NHibernateSessionProvider.UserDBSession.OpenSession())
            {
                using (var trnx = userDbSession.BeginTransaction())
                {
                    try
                    {
                        Role role = new Role();
                        role.Name = "Admin";
                        userDbSession.Save(role);
                        trnx.Commit();
                    }
                    catch (Exception e)
                    {
                        string msg = e.Message;
                    }
                }
            }
            
        }
        public void AddBp()
        {
            using (ISession bpDbSession = NHibernateSessionProvider.BPDBSessionFactory(this).OpenSession())
            {
                using (var trnx = bpDbSession.BeginTransaction())
                {
                    try
                    {
                        BusinessPartner bp = new BusinessPartner();
                        bp.IsEnabled = true;
                        //bp.TimeStamp = DateTo4BytesString();
                        //bp.TimeStamp = BitConverter.GetBytes(Convert.ToUInt32(DateTime.Now.ToString()));
                        bpDbSession.SaveOrUpdate(bp);
                        trnx.Commit();
                        bp = null;
                    }
                    catch (Exception e)
                    {
                        string msg = e.Message;
                    }
                }
            }
        }
        public void GetAllBp()
        {
            using (ISession bpDbSession = NHibernateSessionProvider.BPDBSessionFactory.OpenSession())
            {
                using (bpDbSession.BeginTransaction())
                {
                    try
                    {
                        var bps = bpDbSession.CreateCriteria<BusinessPartner>().List<BusinessPartner>();
                    }
                    catch (Exception e)
                    {
                        string msg = e.Message;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Country country = p.AddCountry();
            State state = p.AddState(country);
            p.AddCity(state);
            p.AddRole();
            //p.AddBp();
            //p.GetAllBp();
        }
    }
}
