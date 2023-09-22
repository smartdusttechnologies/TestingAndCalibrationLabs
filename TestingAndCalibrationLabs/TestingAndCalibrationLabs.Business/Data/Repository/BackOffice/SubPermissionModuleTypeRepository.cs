using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Repository class for SubPermissionModuleType
    /// </summary>
    public class SubPermissionModuleTypeRepository : ISubPermissionModuleTypeRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public SubPermissionModuleTypeRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record In SubPermissionModuleType 
        /// </summary>
        /// <param name="subPermissionModuleTypeModel"></param>
        /// <returns></returns>
        public int Create(SubPermissionModuleTypeModel subPermissionModuleTypeModel)
        {
            string query = @"Insert into [SubPermissionModuleType] (Name,PermissionModuleTypeId)
                                values (@Name,@PermissionModuleTypeId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, subPermissionModuleTypeModel);
        }
        /// <summary>
        /// Getting all records from SubPermissionModuleType 
        /// </summary>
        /// <returns></returns>
        public List<SubPermissionModuleTypeModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<SubPermissionModuleTypeModel>(@"SELECT spmt.Id, spmt.Name, pmt.[Name] as PermissionModuleTypeName                                                     
                                                From[SubPermissionModuleType] spmt
                                                    inner join[PermissionModuleType] pmt on spmt.PermissionModuleTypeId=pmt.Id
											  where
                                                    spmt.IsDeleted=0 and 
													pmt.IsDeleted=0").ToList();
        }

        /// <summary>
        /// Getting Record By Id For SubPermissionModuleType 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SubPermissionModuleTypeModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<SubPermissionModuleTypeModel>(@"SELECT spmt.Id, spmt.Name, pmt.[Name] as PermissionModuleTypeName                                                     
                                                From[SubPermissionModuleType] spmt
                                                    inner join[PermissionModuleType] pmt on spmt.PermissionModuleTypeId=pmt.Id
											  where
											        spmt.Id=@Id and
                                                    spmt.IsDeleted=0 and 
													pmt.IsDeleted=0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record From subPermissionModuleType
        /// </summary>
        /// <param name="subPermissionModuleTypeModel"></param>
        /// <returns></returns>
        public int Update(SubPermissionModuleTypeModel subPermissionModuleTypeModel)
        {
            string query = @"update [SubPermissionModuleType] Set 
                                    Name=@Name,
                                  PermissionModuleTypeId = @PermissionModuleTypeId
                                 Where
                                IsDeleted = 0 and
                                Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, subPermissionModuleTypeModel);
        }
    }
}
