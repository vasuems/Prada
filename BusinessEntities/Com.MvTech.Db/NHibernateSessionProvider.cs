using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate;
using System.Reflection;
using NHibernate.Dialect;
using Com.MvTech.BusinessEntities.BP;
using Com.MvTech.Db.Sql.NHibernate.Config.Mapping;
using Com.MvTech.Db.Sql.NHibernate.Bp.Mapping;
using Com.MvTech.Db.Sql.NHibernate.Users.Mapping;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using FluentNHibernate.Data;
using NHibernate.Linq;
using Com.MvTech.Framework.Db;


namespace Com.MvTech.Db.NHibernateProvider
{
    public enum DbInstance
    {
        AccountDb,
        BpDb,
        ConifgDb,
        TradingPartnerDb,
        UserDb,
    }
    public class NHibernateSessionProvider
    {
        private Dictionary<string,ISession> dbInstances;
        
#region Instantiating DB Session Factories
        public ISessionFactory BPDBSessionFactory(IEntityData tableData)
        {
            if (bpDbSessionFactory == null)
            {
                tableData.GetTableData();
                try
                {
                    string bpDbConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=businesspartner;Integrated Security=True;";
                    bpDbSessionFactory = BuildSessionFactory
                    (
                        bpDbConnectionString, 
                        GetAssembly
                        (
                            new BusinessPartnerMap().GetType()
                        )
                    );
                                                
                }
                catch(Exception e)
                {
                    string msg = e.Message;
                }
            }
            return bpDbSessionFactory;                
            
        }
        public ISessionFactory ConfigDBSession
        {
            get
            {
                if (configDbSessionFactory == null)
                {
                    try
                    {
                        string configDbConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=configdb;Integrated Security=True;";
                        configDbSessionFactory = BuildSessionFactory
                        (
                            configDbConnectionString, 
                            GetAssembly
                            (
                                new CityMap().GetType()
                            )
                        );
                                                
                    }
                    catch(Exception e)
                    {
                        string msg = e.Message;
                    }
                }
                return configDbSessionFactory;
            }
        }
        public ISessionFactory UserDBSession
        {
            get
            {
                if (userDbSessionFactory == null)
                {
                    try
                    {
                        string userDbConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=user;Integrated Security=True;";
                        userDbSessionFactory = BuildSessionFactory
                        (
                            userDbConnectionString, 
                            GetAssembly
                            (
                                new UserMap().GetType()
                            )
                        );
                                                
                    }
                    catch(Exception e)
                    {
                        string msg = e.Message;
                    }
                }
                return userDbSessionFactory;
            }
        }
        public ISessionFactory TPDBSession
        {
            get
            {
                if (tpDbSessionFactory == null)
                {
                    try
                    {
                        string tpDbConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=tradingpartner;Integrated Security=True;";
                        tpDbSessionFactory = BuildSessionFactory
                        (
                            tpDbConnectionString, 
                            GetAssembly
                            (
                                new BusinessPartnerMap().GetType()
                            )
                        );
                                                
                    }
                    catch(Exception e)
                    {
                        string msg = e.Message;
                    }
                }
                return tpDbSessionFactory;
            }
        }

        public ISessionFactory AccountDBSession
        {
            get
            {
                if (accountDbSessionFactory == null)
                {
                    try
                    {
                        string accountDbConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=account;Integrated Security=True;";
                        accountDbSessionFactory = BuildSessionFactory
                        (
                            accountDbConnectionString,
                            GetAssembly
                            (
                                new BusinessPartnerMap().GetType()
                            )
                        );

                    }
                    catch (Exception e)
                    {
                        string msg = e.Message;
                    }
                }
                return accountDbSessionFactory;
            }
        }
#endregion
        #region Fluent Configuration
        private ISessionFactory BuildSessionFactory( string connectionString, Assembly assembly)
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2008
                                    .ConnectionString(connectionString))
                                    .Mappings(m => m
                                    .FluentMappings.AddFromAssembly(assembly))
                                    .BuildSessionFactory();

        }
        #endregion

        #region Util Methods
        private Assembly GetAssembly(Type type)
        {
            return Assembly.GetAssembly(type);

        }
        #endregion
    }
}
