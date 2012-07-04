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
    public class StateTester
    {
        [Test]
        public void AddState()
        {
            State state = null;
            int id = 0;
            ISession configDbSession = NHibernateSessionProvider.ConfigDBSession.OpenSession();
            using (var trnx = configDbSession.BeginTransaction())
            {
                try
                {
                    state = new State();
                    state.Country = configDbSession.QueryOver<Country>().List()[0];
                    state.Name = "Tamil Nadu";
                    configDbSession.Save(state);
                    trnx.Commit();
                    id = state.ID;
                    state = null;
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                }
            }

            using (var trnx = configDbSession.BeginTransaction())
            {
                var n1state = configDbSession.Get<State>(id);
                NUnit.Framework.Assert.AreEqual(n1state.ID, id);
            }
        }
    }
}


