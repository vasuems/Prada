using System;
using Com.MvTech.BusinessEntities;
using Com.MvTech.BusinessEntities.BP;
using Com.MvTech.BusinessEntities.Users;
using Com.MvTech.Db.NHibernateProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;
using Com.MvTech.Db;
using Com.MvTech.BusinessComponents;
using Com.MvTech.Framework.Db;

namespace EBill_Tester
{
    [TestFixture]
    public class BpTester : IEntityData
    {
        public EntityMetaData GetTableData()
        {
            return null;
        }
        [Test]
        public void AddBusinessPartner()
        {
            BusinessPartner bp = new BusinessPartner();
            ISession bpDbSession = NHibernateSessionProvider.BPDBSessionFactory(this).OpenSession();
            using (var trnx = bpDbSession.BeginTransaction())
            {
                try
                {
                    //bpDbSession.Save(bp);
                    //permanentAddress.BP = bp;
                    ////permanentAddress.AddressType = AddressType.PermanentAddress.GetKey();
                    //communicationAddress.BP = bp;
                    ////communicationAddress.AddressType = AddressType.CommunicationAddress.GetKey();
                    //bpDbSession.Save(permanentAddress);
                    //bpDbSession.Save(communicationAddress);
                    //trnx.Commit();
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    throw e;
                }
            }
        }
        //[Test]
        //public void AddBusinessPartner()
        //{
        //    BusinessPartner bp = new BusinessPartner();
        //    ISession bpDbSession = NHibernateSessionProvider.BPDBSessionFactory(this).OpenSession();
        //    using (var trnx = bpDbSession.BeginTransaction())
        //    {
        //        try
        //        {
        //            bpDbSession.Save(bp);
        //            permanentAddress.BP = bp;
        //            //permanentAddress.AddressType = AddressType.PermanentAddress.GetKey();
        //            communicationAddress.BP = bp;
        //            //communicationAddress.AddressType = AddressType.CommunicationAddress.GetKey();
        //            bpDbSession.Save(permanentAddress);
        //            bpDbSession.Save(communicationAddress);
        //            trnx.Commit();                    
        //        }
        //        catch (Exception e)
        //        {
        //            string msg = e.Message;
        //            throw e;
        //        }
        //    }
        //    User user = new User();
        //    user.ID = bp.ID;
        //    user.FirstName = "Meenakshi";
        //    user.LastName = "V";
        //    user.MobilePhone = 94456;
        //    user.DOB = new DateTime(1996, 7, 1);
        //    user.EMail = "vasu_ems@yahoo.com";
        //    user.Gender = 1;
        //    ISession userDbSession = NHibernateSessionProvider.UserDBSession.OpenSession();
        //    using (var trnx = userDbSession.BeginTransaction())
        //    {
        //        try
        //        {
        //            userDbSession.Save(user);
        //            trnx.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            string msg = e.Message;
        //            throw e;
        //        }                
        //    }            
        //}
    }
}


