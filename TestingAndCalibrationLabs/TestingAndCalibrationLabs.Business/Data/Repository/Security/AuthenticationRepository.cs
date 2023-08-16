using Dapper;
using System.Data;
using System.Linq;
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
        /// Save UserId in DB After Reset Password
        /// </summary>
        /// <param name="userId"></param>
        public PasswordLogin GetUserIdPassword(int userId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PasswordLogin>("Select pl.* From [User] u inner join [PasswordLogin] pl on u.id=pl.userId where u.Id = pl.UserId and (u.IsDeleted=0 AND u.Locked=0 AND u.IsActive=1)", new { userId }).FirstOrDefault();
        }
        /// <summary>
        /// Save Email Token in DB
        /// </summary>
        /// <param name="Email"></param>
        public UserModel GetLoginEmail(string email)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserModel>("Select top 1  * From[User] where Email=@Email and(IsDeleted=0 AND Locked=0 AND IsActive=1)", new { email }).FirstOrDefault();
        }
        /// <summary>
        /// Insert OTP in DB
        /// </summary>
        /// <param name="OTP"></param>
        /// <param name="userid"></param>
        public UserModel InsertOtp(string otp,int userId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserModel>(@"IF EXISTS( Select 1 from [UserOtp] where UserId=@UserId) UPDATE [UserOtp] set Otp=@OTP,CreatedDate = GetDate() where UserId = @UserId
                  ELSE Insert into [UserOtp](UserId,OTP,CreatedDate) values (@UserId,@Otp ,GetDate())", new { otp, userId }).FirstOrDefault();
        }
        /// <summary>
        /// OTP in DB
        /// </summary>
        /// <param name="OTP"></param>
        public UserModel GetOTP(int userId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<UserModel>("select u.Id ,uo.Otp,u.Email,uo.CreatedDate From [User] u inner join [UserOtp] uo on u.Id =uo.UserId  where uo.UserId =@UserId  ;", new {userId}).FirstOrDefault();
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