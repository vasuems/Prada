using System;
using NHibernate;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using FluentNHibernate.Data;
using Com.MvTech.Framework.Db;
using System.Collections.Generic;

namespace Com.MvTech.Db.NHibernateProvider
{
    /// <summary>
    /// NHibernateHelper is a singleton class contains helper methods for database operation.
    /// </summary>
    internal class NHibernateHelper : IDbInstanceHelper
    {
        #region static variables
        private static NHibernateHelper nHibernateHelper;        
        #endregion
        #region instance variables
        private DbInstanceDetails dbInstanceDetails;
        private ISessionFactory dbMasterSessionFatory;
        private ISession dbMasterSession;
        private ITransaction dbMasterTransaction;
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=DbMaster;Integrated Security=True;Pooling=False";
        #endregion

        #region private constructor
        private NHibernateHelper()
        {
        }
        #endregion
        #region Instance creator
        /// <summary>
        /// Static property to instantiae singleton instance of NHibernateHelper
        /// </summary>        
        public static NHibernateHelper Instance
        {
            get
            {
                if(nHibernateHelper == null)
                {
                    nHibernateHelper = new NHibernateHelper();
                }
                return nHibernateHelper;
            }
        }
        #endregion
        #region Session Creator
        /// <summary>
        /// Instantiates session factory. Opens and returns session for DbMaster database using the session factory.
        /// </summary>
        /// <returns>
        /// ISession
        /// </returns>
        public ISession DbMasterSession
        {
            get
            {
                if (dbMasterSession == null)
                {
                    if (dbMasterSessionFatory == null)
                    {
                        dbMasterSessionFatory = CreateSessionFactory();
                    }
                    dbMasterSession = dbMasterSessionFatory.OpenSession();
                }
                return dbMasterSession;
            }           
        }
        #endregion
        #region DB Operations
        /// <summary>
        /// Add a new database instane details in to Db Master table.
        /// </summary>
        /// <param name="dbInstanceDetails"></param>
        /// <exception cref="System.ArgumentNullException">Throws argument null exception when parameter dbInstanceDetails is null 
        /// or any of the properties of DbInstanceDetails are null</exception>
        public void AddDbInstance(DbInstanceDetails dbInstanceDetails)
        {
            this.dbInstanceDetails = dbInstanceDetails;
            Validate();
            Save();            
        }
        /// <summary>
        /// Updates existing database instane details in Db Master tabe.
        /// </summary>
        /// <param name="dbInstanceDetails"></param>
        /// <exception cref="System.ArgumentNullException">Throws argument null exception when parameter dbInstanceDetails is null 
        /// or any of the properties of DbInstanceDetails are null</exception>
        public void UpdateDbInstance(DbInstanceDetails dbInstanceDetails)
        {
            this.dbInstanceDetails = dbInstanceDetails;
            Validate();
            Save(); 
        }
        /// <summary>
        /// Searches for the db instance which contains the entity record. 
        /// This method searches for a record which is in between start index and end index. 
        /// </summary>
        /// <param name="dbInstanceDetails"></param>
        /// <exception cref="System.ArgumentNullException">Throws argument null exception when parameter dbInstanceDetails is null 
        /// or any of the properties of DbInstanceDetails are null</exception>
        public DbInstanceDetails GetDbInstance(EntityMetaData entityMetaData)
        {
            int id = (int)entityMetaData.Id;
            using(dbMasterTransaction = dbMasterSession.BeginTransaction())
            {
                dbMasterSession.QueryOver<DbInstanceDetails>()
                    .Where(x => x.Id < id && x.Id > id)
                    .Select(d => d.DbInstanceName, d => d.ConnectionString);
            }
        }
        /// <summary>
        /// Returns all the db instances.
        /// </summary>
        public IList<DbInstanceDetails> GetAllDbInstance()
        {
            return dbMasterSession.QueryOver<DbInstanceDetails>()
                .Select(d => d.DbInstanceName, d => d.ConnectionString).List();
                
        }
        #endregion

        #region private methods
        /// <summary>
        /// Creates a new session factory for DbMAster using fluent configuration
        /// </summary>
        /// <returns>ISessionFactory</returns>
        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2008
                                    .ConnectionString(connectionString))
                                    .Mappings(m => m
                                    .FluentMappings.AddFromAssemblyOf<DbInstanceDetailsMap>())
                                    .BuildSessionFactory();

        }
        /// <summary>
        /// Validates DbInstanceDetails.
        /// </summary>
        /// <exception cref="System.ArgumentNullExeption">Throws argument null exceptio when 
        /// DbInstaceDetails is null or one or more of it's properties are null</exception>
        private void Validate()
        {
            if (dbInstanceDetails == null)
            {
                throw new ArgumentNullException("dbInstanceDetails");

            }
            if (dbInstanceDetails != null)
            {
                if (dbInstanceDetails.ConnectionString == null)
                {
                    throw new ArgumentNullException("ConnectionString");
                }
                if (dbInstanceDetails.DbInstanceName == null)
                {
                    throw new ArgumentNullException("DbInstanceName");
                }
                throw new ArgumentNullException("dbInstanceDetails");
            }
        }
        /// <summary>
        /// Saves or updates the DbInstanceDetails
        /// </summary>
        private void Save()
        {
            using (dbMasterTransaction = dbMasterSession.BeginTransaction())
            {
                dbMasterSession.SaveOrUpdate(dbInstanceDetails);
            }
        }
        #endregion 
    }
}
