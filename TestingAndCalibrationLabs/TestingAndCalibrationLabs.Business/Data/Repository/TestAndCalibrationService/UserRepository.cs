﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// using the userRespository
        /// </summary>
        private readonly IConnectionFactory _connectionFactory;
        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        ///get the data of the required user with specified role[Admin]
        /// </summary>
        List<string> Interfaces.IUserRepository.Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return (List<string>)db.Query<string>("select Email from [User] where UserName='sysadmin'");
        }
        /// <summary>
        /// Get User Based on Id
        /// </summary>
        public UserModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserModel>("Select top 1 * From [User] where Id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }
        /// <summary>
        /// Get User Based on Name
        /// </summary>
        public UserModel Get(string userName)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserModel>("Select top 1 * From [User] where UserName=@userName and IsDeleted=0", new { userName }).FirstOrDefault();
        }
        /// <summary>
        /// Get User Based on Email exist or not
        /// </summary>
        /// <param name="Email"></param>
        public UserModel GetEmail(string Email)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserModel>("Select top 1 * From [User] where Email=@Email and IsDeleted=0", new { Email }).FirstOrDefault();
        }
        /// <summary>
        /// Select User Email At the Time of Email Verify.
        /// </summary>
        /// <param name="userId"></param>
        public UserModel SelectEmail(int userId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserModel>("select u.Id,u.Mobile, u.Email From [User] u where u.Id = @userId", new { userId }).FirstOrDefault();
        }
        /// <summary>
        /// Update EmailValidatioStatus after validation
        /// <returns>UserModel</returns>
        /// </summary>
        /// <param name="userId"></param>
        public UserModel EmailValidationStatusUpdate(int userId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserModel>("UPDATE [User] SET EmailValidationStatus='1' WHERE Id=@userId", new { userId }).FirstOrDefault();
        }
        /// <summary>
        /// Update MobileValidationStatusUpdate
        /// </summary>
        /// <param name="userId"></param>
        public UserModel MobileValidationStatusUpdate(int userId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserModel>("UPDATE [User] SET MobileValidationStatus='1' WHERE Id=@userId", new { userId }).FirstOrDefault();
        }
        /// <summary>
        /// Method to Insert User Info in DB
        /// </summary>
        public int Insert(UserModel user, PasswordLogin passwordLogin)
        {
            var p = new DynamicParameters();
            p.Add("Id", 0, DbType.Int32, ParameterDirection.Output);
            p.Add("@UserName", user.UserName);
            p.Add("@FirstName", user.FirstName);
            p.Add("@LastName", user.LastName);
            p.Add("@Email", user.Email);
            p.Add("@Mobile", user.Mobile);
            p.Add("@Country", user.Country);
            p.Add("@ISDCode", user.ISDCode);
            p.Add("@TwoFactor", user.TwoFactor);
            p.Add("@Locked", user.Locked);
            p.Add("@IsActive", user.IsActive);
            p.Add("@EmailValidationStatus", user.EmailValidationStatus);
            p.Add("@MobileValidationStatus", user.MobileValidationStatus);
            p.Add("@OrgId", user.OrgId);
            p.Add("@AdminLevel", user.AdminLevel);
            string userInsertQuery = @"Insert into [User](UserName, FirstName, LastName, Email, Mobile, Country, ISDCode, TwoFactor, Locked, IsActive, EmailValidationStatus, MobileValidationStatus, OrgId, AdminLevel) 
                values (@UserName, @FirstName, @LastName, @Email, @Mobile, @Country, @ISDCode, @TwoFactor, @Locked, @IsActive, @EmailValidationStatus, @MobileValidationStatus, @OrgId, @AdminLevel);
                SELECT @Id = @@IDENTITY";
            string passwordLoginInsertQuery = @"Insert into [PasswordLogin](PasswordHash, PasswordSalt, UserId, ChangeDate) 
                values (@PasswordHash, @PasswordSalt, @UserId, @ChangeDate)";
            string userRoleInsertQuery = @"Insert into [UserRole](UserId, RoleId) values (@UserId, @RoleId)";
            using IDbConnection db = _connectionFactory.GetConnection;
            using var transaction = db.BeginTransaction();
            db.Execute(userInsertQuery, p, transaction);
            int insertedUserId = p.Get<int>("@Id");
            passwordLogin.UserId = insertedUserId;
            passwordLogin.ChangeDate = DateTime.Now;
            db.Execute(passwordLoginInsertQuery, passwordLogin, transaction);
            // assign the general user role by default.
            db.Execute(userRoleInsertQuery, new { UserId = insertedUserId, RoleId = 2 }, transaction);
            transaction.Commit();
            return insertedUserId;
        }
        /// <summary>
        /// Method to Update Password
        /// </summary>
        /// <param name="newpassword"></param>
        public int UpdatePassword(UserModel UserModel)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@PasswordHash", "PasswordHash");
            parameter.Add("@PasswordSalt", "PasswordSalt");
            parameter.Add("@ChangeDate", "ChangeDate");
            string changepasswordQuery = @"update [PasswordLogin] Set
                                           PasswordHash = @PasswordHash,
                                           PasswordSalt = @PasswordSalt,
                                           ChangeDate =@ChangeDate
                                                Where UserId = @UserId";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(changepasswordQuery, UserModel);
        }
    }
}