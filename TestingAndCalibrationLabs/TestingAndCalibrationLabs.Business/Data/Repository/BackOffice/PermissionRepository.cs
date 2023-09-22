using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Repository class for Permission
    /// </summary>
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
        /// <returns></returns>
        public int Create(PermissionModel permissionModel)
        {
            string query = @"Insert into [permission] (Name,PermissionModuleTypeId,PermissionTypeId)
                                values (@Name,@PermissionModuleTypeId,@PermissionTypeId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, permissionModel);
        }
        /// <summary>
        /// Getting all records from Permission
        /// </summary>
        /// <returns></returns>
        public List<PermissionModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PermissionModel>(@"SELECT p.Id, p.Name, p.PermissionModuleTypeId, p.PermissionTypeId, pmt.[Name] as PermissionModuleTypeName, 
                                                    pt.[Name] as PermissionTypeName
                                                From[Permission] p
                                                    inner join[PermissionModuleType] pmt on pmt.Id= p.PermissionModuleTypeId
                                                    inner join[PermissionType] pt on pt.Id= p.PermissionTypeId
											  where
                                                    pmt.IsDeleted = 0
                                                    and pt.IsDeleted = 0
                                                    and p.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id For Permission
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PermissionModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PermissionModel>(@"SELECT p.Id, p.Name, p.PermissionModuleTypeId, p.PermissionTypeId, pmt.[Name] as PermissionModuleTypeName, 
                                                    pt.[Name] as PermissionTypeName
                                                From[Permission] p
                                                    inner join[PermissionModuleType] pmt on pmt.Id= p.PermissionModuleTypeId
                                                    inner join[PermissionType] pt on pt.Id= p.PermissionTypeId
											  where
                                                    pmt.IsDeleted = 0
                                                    and pt.IsDeleted = 0
                                                    and p.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record From Permission
        /// </summary>
        /// <param name="permissionModel"></param>
        /// <returns></returns>
        public int Update(PermissionModel permissionModel)
        {
            string query = @"update [Permission] Set 
                                    Name=@Name,
                                  PermissionModuleTypeId = @PermissionModuleTypeId
                                 Where
                                IsDeleted = 0 and
                                Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, permissionModel);
        }
    }
}
