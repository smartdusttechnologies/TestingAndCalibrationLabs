using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository.BackOffice
{
    public class GroupClaimRepository : IGroupClaimRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public GroupClaimRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record In GroupClaim
        /// </summary>
        /// <param name="groupClaimModel"></param>
        public int Create(GroupClaimModel groupClaimModel)
        {
            string query = @"Insert into [GroupClaim] (GroupId,ClaimTypeId,PermissionId)
                                values (@GroupId,@ClaimTypeId,@PermissionId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, groupClaimModel);
        }
        /// <summary>
        /// Getting all records from GroupClaim
        /// </summary>
        public List<GroupClaimModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<GroupClaimModel>(@"SELECT gc.Id, gc.GroupId, g.[Name] as GroupName, gc.ClaimTypeId, ct.[Name] as ClaimTypeName,
													gc.PermissionId, p.[Name] as PermissionName
                                                From[GroupClaim] gc
                                                    inner join[Group] g on gc.GroupId = g.Id
                                                    inner join[ClaimType] ct on gc.ClaimTypeId = ct.Id
													inner join[Permission] p on gc.PermissionId = p.Id
											  where
                                                        gc.IsDeleted=0
                                                    and g.IsDeleted = 0
                                                    and ct.IsDeleted = 0
                                                    and p.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id For GroupClaim
        /// </summary>
        /// <param name="id"></param>
        public GroupClaimModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<GroupClaimModel>(@"SELECT gc.Id, gc.GroupId, g.[Name] as GroupName, gc.ClaimTypeId, ct.[Name] as ClaimTypeName,
													gc.PermissionId, p.[Name] as PermissionName
                                                From[GroupClaim] gc
                                                    inner join[Group] g on gc.GroupId = g.Id
                                                    inner join[ClaimType] ct on gc.ClaimTypeId = ct.Id
													inner join[Permission] p on gc.PermissionId = p.Id
											  where
                                                        gc.Id = @Id
                                                    and g.IsDeleted = 0
                                                    and ct.IsDeleted = 0
                                                    and p.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record From GroupClaim
        /// </summary>
        /// <param name="groupClaimModel"></param>
        public int Update(GroupClaimModel groupClaimModel)
        {
            string query = @"update [GroupClaim] Set 
                                  GroupId = @GroupId,
                                  ClaimTypeId = @ClaimTypeId,
                                  PermissionId = @PermissionId
                                 Where
                                IsDeleted = 0 and
                                Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, groupClaimModel);
        }
    }
}
