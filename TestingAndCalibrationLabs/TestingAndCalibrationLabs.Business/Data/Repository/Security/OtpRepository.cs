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
    }
}
