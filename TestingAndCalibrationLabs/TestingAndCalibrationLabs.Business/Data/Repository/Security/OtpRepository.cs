using Dapper;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    public class OtpRepository : IOtpRepsitory
    {
        private readonly IConnectionFactory _connectionFactory;
        public OtpRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
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
        ///<param name = "OTP" ></ param >
        /// < param name="userid"></param>
        public OtpModel InsertOtp(string otp, int userId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<OtpModel>(@"IF EXISTS( Select 1 from [UserOtp] where UserId=@UserId) UPDATE [UserOtp] set Otp=@OTP,CreatedDate = GetDate() where UserId = @UserId
                      ELSE Insert into [UserOtp](UserId,OTP,CreatedDate) values (@UserId,@Otp ,GetDate())", new { otp, userId }).FirstOrDefault();
        }
        /// <summary>
        /// OTP in DB
        /// </summary>
        /// <param name = "OTP" ></ param >
        public OtpModel GetOTP(int userId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<OtpModel>("select u.Id ,uo.Otp,u.Email,uo.CreatedDate From [User] u inner join [UserOtp] uo on u.Id =uo.UserId  where uo.UserId =@UserId  ;", new { userId }).FirstOrDefault();
        }
        /// <summary>
        /// Get Email  in DB
        /// </summary>
        ///<param name = "OTP" ></ param >
        public OtpModel GetEmail(int userId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<OtpModel>("select u.Id, u.Email From [User] u where u.Id = @userId", new { userId }).FirstOrDefault();
        }
    }
}
