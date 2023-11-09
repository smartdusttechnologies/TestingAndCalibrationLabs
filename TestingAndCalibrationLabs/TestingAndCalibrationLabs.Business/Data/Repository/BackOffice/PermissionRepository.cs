using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Infrastructure;
namespace TestingAndCalibrationLabs.Business.Data.Repository.BackOffice
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public PermissionRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record In Permission
        /// </summary>
        /// <param name="permissionModel"></param>
        public int Create(PermissionModel permissionModel)
        {
            string query = @"Insert into [Permission] (PermissionModuleTypeId, PermissionTypeId)
                                values (@PermissionModuleTypeId, @PermissionTypeId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, permissionModel);
        }
        /// <summary>
        /// Getting all records from Permission
        /// </summary>
        public List<PermissionModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PermissionModel>(@"SELECT p.Id, p.[Name], p.PermissionModuleTypeId, pmt.[Name] as PermissionModuleTypeName,  p.PermissionTypeId,
                                                    pt.[Name] as PermissionTypeName
                                                From[Permission] p
                                                    inner join[PermissionModuleType] pmt on p.PermissionModuleTypeId = pmt.Id
                                                    inner join[PermissionType] pt on p.PermissionTypeId = pt.Id
											  where
                                                    pmt.IsDeleted = 0
                                                    and pt.IsDeleted = 0
                                                    and p.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id For Permission
        /// </summary>
        /// <param name="id"></param>
        public PermissionModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PermissionModel>(@"SELECT p.Id, p.[Name], p.PermissionModuleTypeId, pmt.[Name] as PermissionModuleTypeName,  p.PermissionTypeId,
                                                    pt.[Name] as PermissionTypeName
                                                From[Permission] p
                                                    inner join[PermissionModuleType] pmt on p.PermissionModuleTypeId = pmt.Id
                                                    inner join[PermissionType] pt on p.PermissionTypeId = pt.Id
											  where
                                                        p.Id = @Id
                                                    and pmt.IsDeleted = 0
                                                    and pt.IsDeleted = 0
                                                    and p.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record From Permission
        /// </summary>
        /// <param name="permissionModel"></param>
        public int Update(PermissionModel permissionModel)
        {
            string query = @"update [Permission] Set 
                                  PermissionModuleTypeId = @PermissionModuleTypeId,
                                  PermissionTypeId = @PermissionTypeId
                                 Where
                                IsDeleted = 0 and
                                Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, permissionModel);
        }
    }
}
