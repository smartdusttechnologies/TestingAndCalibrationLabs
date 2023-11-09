using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Infrastructure;
namespace TestingAndCalibrationLabs.Business.Data.Repository.BackOffice
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserRoleRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record In User Role
        /// </summary>
        /// <param name="userRoleModel"></param>
        public int Create(UserRoleModel userRoleModel)
        {
            string query = @"Insert into [userRole] (UserId, RoleId)
                                values (@UserId, @RoleId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, userRoleModel);
        }
        /// <summary>
        /// Getting all records from User Role
        /// </summary>
        public List<UserRoleModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserRoleModel>(@"SELECT ur.Id, ur.UserId, u.[UserName] as UserName,
                                                               ur.RoleId, r.[Name] as RoleName
                                                    From[UserRole]ur
                                                    inner join[User] u on u.Id = ur.UserId
                                                    inner join[Role] r on r.Id = ur.RoleId
											  where
                                                        ur.IsDeleted = 0
                                                    and u.IsDeleted = 0
                                                    and r.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id For User Role
        /// </summary>
        /// <param name="id"></param>
        public UserRoleModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserRoleModel>(@"SELECT ur.Id, ur.UserId, u.[UserName] as UserName,
                                                               ur.RoleId, r.[Name] as RoleName
                                                    From[UserRole]ur
                                                    inner join[User] u on u.Id = ur.UserId
                                                    inner join[Role] r on r.Id = ur.RoleId
											  where
                                                         ur.Id = @Id and
                                                        ur.IsDeleted = 0
                                                    and u.IsDeleted = 0
                                                    and r.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record From User Role
        /// </summary>
        /// <param name="userRoleModel"></param>
        public int Update(UserRoleModel userRoleModel)
        {
            string query = @"update [UserRole] Set 
                                  UserId = @UserId,
                                  RoleId = @RoleId
                                 Where
                                IsDeleted = 0 and
                                Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, userRoleModel);
        }
    }
}
