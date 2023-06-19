using Dapper;
using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public AuthenticationRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public PasswordLogin GetLoginPassword(string userName)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PasswordLogin>("Select top 1  pl.* From [User] u inner join [PasswordLogin] pl on u.id=pl.userId where u.userName=@userName and (u.IsDeleted=0 AND u.Locked=0 AND u.IsActive=1)", new { userName }).FirstOrDefault();
        }

        /// <summary>
        /// Save Email Token in DB
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>

        public ForgotPasswordModel GetLoginEmail(string Email)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<ForgotPasswordModel>("Select top 1  * From[User] where Email=@Email and(IsDeleted=0 AND Locked=0 AND IsActive=1)", new { Email }).FirstOrDefault();
        }
        /// <summary>
        /// Insert OTP in DB
        /// </summary>
        /// <param name="OTP"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ForgotPasswordModel InsertOtp(string OTP,int userid )
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            //return db.Query<ForgotPasswordModel>(@"Insert into [UserOtp](OTP , CreatedDate) 
            //    values (@Otp , GetDate())", new { OTP }).FirstOrDefault();


            return db.Query<ForgotPasswordModel>(@"Insert into [UserOtp](UserId,OTP,CreatedDate) 
            values (@UserId,@Otp ,GetDate())", new { OTP,userid }).FirstOrDefault();

        }

        /// <summary>
        /// OTP in DB
        /// </summary>
        /// <param name="OTP"></param>
        /// <returns></returns>

        public ForgotPasswordModel GetOTP(string OTP)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<ForgotPasswordModel>("SELECT uo.UserId,uo.Otp,u.Email FROM [UserOtp] uo INNER JOIN [User] u ON uo.UserId = u.Id where uo.Otp =@OTP ", new { OTP }).FirstOrDefault();

            //return db.Query<ForgotPasswordModel>("SELECT OTP And UserId FROM [UserOtp] WHERE Email = @Email", new { OTP }).FirstOrDefault();
        }

        /// <summary>
        /// Save Login Token in DB
        /// </summary>
        public int SaveLoginToken(LoginToken loginToken)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            int userId = db.Query<int>(@"Select u.Id From [User] u Where u.UserName = @UserName", new { loginToken.UserName }).FirstOrDefault();
            loginToken.UserId = userId;

            int loginTokenUserId = db.Query<int>(@"Select userId From [LoginToken] Where  UserId = @userId", new { userId }).FirstOrDefault();

            string query = loginTokenUserId > 0 ?
              @"update [LoginToken] Set 
                    AccessToken = @AccessToken,
                    RefreshToken = @RefreshToken,
                    AccessTokenExpiry = @AccessTokenExpiry,
                    DeviceCode = @DeviceCode,
                    DeviceName = @DeviceName,
                    RefreshTokenExpiry = @RefreshTokenExpiry
                  Where UserId = @UserId"
              :
              @"Insert into [LoginToken](UserId, AccessToken, RefreshToken, AccessTokenExpiry, DeviceCode, DeviceName, RefreshTokenExpiry) 
                values (@UserId, @AccessToken, @RefreshToken, @AccessTokenExpiry, @DeviceCode, @DeviceName, @RefreshTokenExpiry)";

            return db.Execute(query, loginToken);
        }
    }
}
