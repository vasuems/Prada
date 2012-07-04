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
    public class User1Tester
    {
        //[Test]
        //public void AddCountry()
        //{
        //    Country country = null;
        //    int id = 0;
        //    ISession configDbSession = NHibernateSessionProvider.ConfigDBSession.OpenSession();
        //    using (var trnx = configDbSession.BeginTransaction())
        //    {
        //        try
        //        {
        //            country = new Country();
        //            country.Name = "India";
        //            configDbSession.Save(country);
        //            trnx.Commit();
        //            id = country.ID;
        //            country = null;
        //        }
        //        catch (Exception e)
        //        {
        //            string msg = e.Message;
        //        }
        //    }

        //     using (var trnx = configDbSession.BeginTransaction())
        //    {
        //         var n1country = configDbSession.Get<Country>(id);
        //        NUnit.Framework.Assert.AreEqual(n1country.ID,id);                             
        //    }   
        //}
    }
}


