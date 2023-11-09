using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.BackOffice
{
    public class UserClaimRepository : IUserClaimRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserClaimRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record In UserClaim
        /// </summary>
        /// <param name="userClaimModel"></param>
        public int Create(UserClaimModel userClaimModel)
        {
            string query = @"Insert into [userClaim] (UserId,PermissionId,ClaimTypeId)
                                values (@UserId,@PermissionId,@ClaimTypeId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, userClaimModel);
        }
        /// <summary>
        /// Getting all records from UserClaim
        /// </summary>
        public List<UserClaimModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserClaimModel>(@"SELECT uc.Id, uc.UserId, un.[UserName] as UserName, uc.PermissionId, p.[Name] as PermissionName, 
                                                    uc.ClaimTypeId, ct.[Name] as ClaimTypeName 
                                                From[UserClaim] uc
                                                    inner join[User] un on uc.UserId = un.Id
													inner join[Permission] p on uc.PermissionId = p.Id
													inner join[ClaimType] ct on uc.ClaimTypeId = ct.Id
											  where
											            uc.IsDeleted = 0
                                                    and un.IsDeleted = 0
                                                    and p.IsDeleted = 0
                                                    and ct.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id For UserClaim
        /// </summary>
        /// <param name="id"></param>
        public UserClaimModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserClaimModel>(@"SELECT uc.Id, uc.UserId, un.[UserName] as UserName, uc.PermissionId, p.[Name] as PermissionName, 
                                                    uc.ClaimTypeId, ct.[Name] as ClaimTypeName 
                                                From[UserClaim] uc
                                                    inner join[User] un on uc.UserId = un.Id
													inner join[Permission] p on uc.PermissionId = p.Id
													inner join[ClaimType] ct on uc.ClaimTypeId = ct.Id
											  where
											            uc.Id = @Id
                                                    and un.IsDeleted = 0
                                                    and p.IsDeleted = 0
                                                    and ct.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record From UserClaim
        /// </summary>
        /// <param name="userClaimModel"></param>
        public int Update(UserClaimModel userClaimModel)
        {
            string query = @"update [UserClaim] Set 
                                    UserId=@UserId,
                                  PermissionId = @PermissionId,
                                  ClaimTypeId = @ClaimTypeId
                                 Where
                                IsDeleted = 0 and
                                Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, userClaimModel);
        }
    }
}
