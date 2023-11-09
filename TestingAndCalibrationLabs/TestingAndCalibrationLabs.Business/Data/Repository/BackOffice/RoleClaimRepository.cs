using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Infrastructure;



namespace TestingAndCalibrationLabs.Business.Data.Repository.BackOffice
{
    public class RoleClaimRepository : IRoleClaimRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public RoleClaimRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record In RoleClaim
        /// </summary>
        /// <param name="roleClaimModel"></param>
        public int Create(RoleClaimModel roleClaimModel)
        {
            string query = @"Insert into [roleClaim] (RoleId,PermissionId,ClaimTypeId)
                                values (@RoleId,@PermissionId,@ClaimTypeId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, roleClaimModel);
        }
        /// <summary>
        /// Getting all records from RoleClaim
        /// </summary>
        public List<RoleClaimModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<RoleClaimModel>(@"SELECT rc.Id, rc.RoleId, r.[Name] as RoleName, rc.PermissionId, p.[Name] as PermissionName, 
                                                    rc.ClaimTypeId, ct.[Name] as ClaimTypeName 
                                                From[RoleClaim] rc
                                                    inner join[Role] r on rc.RoleId = r.Id
													inner join[Permission] p on rc.PermissionId = p.Id
													inner join[ClaimType] ct on rc.ClaimTypeId = ct.Id
                                                    where
                                                        rc.IsDeleted = 0
                                                    and r.IsDeleted = 0
                                                    and p.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id For RoleClaim
        /// </summary>
        /// <param name="id"></param>
        public RoleClaimModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<RoleClaimModel>(@"SELECT rc.Id, rc.RoleId, r.[Name] as RoleName, rc.PermissionId, p.[Name] as PermissionName, 
                                                    rc.ClaimTypeId, ct.[Name] as ClaimTypeName 
                                                From[RoleClaim] rc
                                                    inner join[Role] r on rc.RoleId = r.Id
													inner join[Permission] p on rc.PermissionId = p.Id
													inner join[ClaimType] ct on rc.ClaimTypeId = ct.Id
											  where
											            rc.Id = @Id
                                                    and r.IsDeleted = 0
                                                    and p.IsDeleted = 0
                                                    and ct.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record From RoleClaim
        /// </summary>
        /// <param name="roleClaimModel"></param>
        public int Update(RoleClaimModel roleClaimModel)
        {
            string query = @"update [RoleClaim] Set 
                                    RoleId=@RoleId,
                                  PermissionId = @PermissionId,
                                  ClaimTypeId = @ClaimTypeId
                                 Where
                                IsDeleted = 0 and
                                Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, roleClaimModel);
        }
    }
}
