using System;
using Com.MvTech.BusinessEntities;
using Com.MvTech.BusinessEntities.BP;
using Com.MvTech.Db.NHibernateProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;

namespace EBill_Tester
{
    [TestFixture]
    public class CityTester
    {
        [Test]
        public void AddCity()
        {
            City city = null;
            int id = 0;
            ISession configDbSession = NHibernateSessionProvider.ConfigDBSession.OpenSession();
            using (var trnx = configDbSession.BeginTransaction())
            {
                try
                {
                    city = new City();
                    city.State = configDbSession.QueryOver<State>().List()[0];
                    city.State.Country = city.State.Country;
                    city.Name = "Podatur Pet";
                    configDbSession.Save(city);
                    trnx.Commit();
                    id = city.ID;
                    city = null;
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                }
            }

             using (var trnx = configDbSession.BeginTransaction())
            {
                 var n1city = configDbSession.Get<City>(id);
                NUnit.Framework.Assert.AreEqual(n1city.ID,id);                             
            }   
        }
    }
}


