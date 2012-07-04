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

namespace EBill_Tester
{
    [TestFixture]
    public class UserTester
    {
        [Test]
        public void AddUser()
        {
            City city = null;
            State state = null;
            Country country = null;
            ISession configDbSession = NHibernateSessionProvider.ConfigDBSession.OpenSession();
            using (var trnx = configDbSession.BeginTransaction())
            {
                try
                {
                    city = configDbSession.QueryOver<City>().List()[0];
                    state = city.State;
                    country = configDbSession.QueryOver<Country>().List()[0];                    
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    throw e;
                }
            }
            Address permanentAddress = new BpPermanentAddress();
            permanentAddress.Address1 = "3, Parimala Illam";
            permanentAddress.Address2 = "Ottraivadai Street";
            permanentAddress.CityId = city.ID;
            permanentAddress.StateId = state.ID;
            permanentAddress.CountryId = country.ID;
            permanentAddress.PinCode = 631208;
            Address communicationAddress = new BpCommunicationAddress();
            communicationAddress.Address1 = "3, Parimala Illam";
            communicationAddress.Address2 = "Ottraivadai Street";
            communicationAddress.CityId = city.ID;
            communicationAddress.StateId = state.ID;
            communicationAddress.CountryId = country.ID;
            communicationAddress.PinCode = 631208;
            BusinessPartner bp = new BusinessPartner();
            ISession bpDbSession = NHibernateSessionProvider.BPDBSessionFactory(this).OpenSession();
            using (var trnx = bpDbSession.BeginTransaction())
            {
                try
                {
                    bpDbSession.Save(bp);
                    permanentAddress.BP = bp;
                    //permanentAddress.AddressType = AddressType.PermanentAddress.GetKey();
                    communicationAddress.BP = bp;
                    //communicationAddress.AddressType = AddressType.CommunicationAddress.GetKey();
                    bpDbSession.Save(permanentAddress);
                    bpDbSession.Save(communicationAddress);
                    trnx.Commit();                    
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    throw e;
                }
            }
            User user = new User();
            user.ID = bp.ID;
            user.FirstName = "Meenakshi";
            user.LastName = "V";
            user.MobilePhone = 94456;
            user.DOB = new DateTime(1996, 7, 1);
            user.EMail = "vasu_ems@yahoo.com";
            user.Gender = 1;
            ISession userDbSession = NHibernateSessionProvider.UserDBSession.OpenSession();
            using (var trnx = userDbSession.BeginTransaction())
            {
                try
                {
                    userDbSession.Save(user);
                    trnx.Commit();
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    throw e;
                }                
            }            
        }
    }
}


