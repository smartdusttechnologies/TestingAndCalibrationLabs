using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly string _tableName;

        public OrganizationRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Method to get Orgnization Name
        /// </summary>
        public List<Organization> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<Organization>("Select OrgName From [Organization]").ToList();
        }
        public List<Organization> Get(SessionContext sessionContext)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<Organization>("Select * From [Organization] where (Id=@OrganizationId OR @OrganizationId = 0) and IsDeleted=0", new { sessionContext.OrganizationId }).ToList();
        }

        /// <summary>
        /// Method to get Orgnzation name Based on OrgId
        /// </summary>
        public Organization Get(SessionContext sessionContext, int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<Organization>("Select top 1 * From [Organization] where Id=@id and (Id=@OrganizationId OR @OrganizationId = 0) and IsDeleted=0", new { id, sessionContext.OrganizationId }).FirstOrDefault();
        }
        public List<OrganizationModel> Getby()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<OrganizationModel>("Select * From [Organization] where IsDeleted=0", _tableName).ToList();
        }
    }
}
