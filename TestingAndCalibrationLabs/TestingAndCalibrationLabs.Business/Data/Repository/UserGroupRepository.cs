using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserGroupRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Insert Record In User Group
        /// </summary>
        /// <param name="userGroupModel"></param>
        public int Create(UserGroupModel userGroupModel)
        {
            string query = @"Insert into [userGroup] (GroupId,UserId)
                                values (@GroupId,@UserId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, userGroupModel);
        }
        /// <summary>
        /// Getting all records from User Group
        /// </summary>
        public List<UserGroupModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserGroupModel>(@"SELECT ug.Id, ug.GroupId, ug.UserId, gn.[Name] as GroupName, 
                                                    un.[UserName] as UserName
                                                From[UserGroup]ug
                                                    inner join[Group] gn on gn.Id= ug.GroupId
                                                    inner join[User] un on un.Id= ug.UserId
											  where
                                                    gn.IsDeleted = 0
                                                    and un.IsDeleted = 0
                                                    and ug.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Getting Record By Id For User Group
        /// </summary>
        /// <param name="id"></param>
        public UserGroupModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserGroupModel>(@"SELECT ug.Id, ug.GroupId, ug.UserId, gn.[Name] as GroupName, 
                                                    un.[UserName] as UserName
                                                From[UserGroup]ug
                                                    inner join[Group] gn on gn.Id= ug.GroupId
                                                    inner join[User] un on un.Id= ug.UserId
											  where
                                                    ug.Id = @id and
                                                    gn.IsDeleted = 0
                                                    and un.IsDeleted = 0
                                                    and ug.IsDeleted = 0", new { isDeleted = 0, Id = id }).FirstOrDefault();
        }
        /// <summary>
        /// Edit Record From User Group
        /// </summary>
        /// <param name="userGroupModel"></param>
        public int Update(UserGroupModel userGroupModel)
        {
            string query = @"update [UserGroup] Set 
                                  GroupId = @GroupId,
                                  UserId = @UserId
                                 Where
                                IsDeleted = 0 and
                                Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, userGroupModel);
        }
    }
}
