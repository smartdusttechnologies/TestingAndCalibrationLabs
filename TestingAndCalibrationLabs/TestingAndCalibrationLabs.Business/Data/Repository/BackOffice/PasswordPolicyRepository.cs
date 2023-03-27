using TestingAndCalibrationLabs.Business.Infrastructure;
using System.Collections.Generic;
using System.Data;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using Dapper;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{

    public class PasswordPolicyRepository : IPasswordPolicyRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public PasswordPolicyRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<PasswordPolicyModel> GetByOrgId(int OrgId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PasswordPolicyModel>(@"select * from PasswordPolicy where OrgId = @OrgId and IsDeleted = 0", new { OrgId = OrgId }).ToList();

        }
        /// <summary>
        /// Insert Record in PasswordPolicy
        /// </summary>
        /// <param name="passwordPolicyModel"></param>
        /// <returns></returns>
        public int Create(PasswordPolicyModel passwordPolicyModel)
        {
            string query = @"Insert into [PasswordPolicy] (OrgId,MinCaps,MinSmallChars,MinSpecialChars,MinNumber,MinLength,AllowUserName,DisAllPastPassword,DisAllowedChars,ChangeIntervalDays)
                                                  values (@OrgId,@MinCaps,@MinSmallChars,@MinSpecialChars,@MinNumber ,@MinLength ,@AllowUserName ,@DisAllPastPassword ,@DisAllowedChars ,@ChangeIntervalDays)";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, passwordPolicyModel);
        }

        
        /// <summary>
        /// Getting All Records From PasswordPolicy
        /// </summary>
        /// <returns></returns>
        public List<PasswordPolicyModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<PasswordPolicyModel>(@"Select p.Id,
                                                            p.OrgId,
                                                            o.[OrgName] as OrganizationOrgName, 
                                                            o.[OrgCode] as OrganizationOrgCode,
                                                            
                                                            p.MinCaps,
                                                            p.MinSmallChars,
															p.MinSpecialChars,
															p.MinNumber,
															p.MinLength,
															p.AllowUserName,
															p.DisAllPastPassword,
															p.DisAllowedChars,
															p.ChangeIntervalDays
														
                                                    From [PasswordPolicy] p
                                                    inner join [Organization] o on p.OrgId = o.Id
                                                    
                                                where 
                                                    p.IsDeleted = 0 
                                                    and o.IsDeleted = 0
                                                    ").ToList();
        }
        /// <summary>
        /// Getting Record By Id PasswordPolicy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PasswordPolicyModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var OrgId = db.Query<PasswordPolicyModel>(@"Select p.Id,
                                                            p.OrgId,
                                                            o.[OrgName] as OrganizationOrgName, 
                                                            o.[OrgCode] as OrganizationOrgCode,
                                                            
                                                            p.MinCaps,
                                                            p.MinSmallChars,
															p.MinSpecialChars,
															p.MinNumber,
															p.MinLength,
															p.AllowUserName,
															p.DisAllPastPassword,
															p.DisAllowedChars,
															p.ChangeIntervalDays
														
                                                    From [PasswordPolicy] p
                                                    inner join [Organization] o on p.OrgId = o.Id
                                                    
                                                where 
                                                       p.Id=@Id
                                                   and p.IsDeleted = 0 
                                                    and o.IsDeleted = 0", new { Id = id }).FirstOrDefault();

            return OrgId;
        }
        /// <summary>
        /// Edit Record For PasswordPolicy 
        /// </summary>
        /// <param name="passwordPolicyModel"></param>
        /// <returns></returns>
        public int Update(PasswordPolicyModel passwordPolicyModel)
        {

            string query = @"update [PasswordPolicy] Set  
                                OrgId = @OrgId,                                
                                MinCaps = @MinCaps,
                                MinSmallChars=@MinSmallChars,
                                MinSpecialChars=@MinSpecialChars,
                                MinNumber=@MinNumber,
                                MinLength=@MinLength,
                                AllowUserName=@AllowUserName,
                                DisAllPastPassword=@DisAllPastPassword,
                                DisAllowedChars=@DisAllowedChars,
                                ChangeIntervalDays=@ChangeIntervalDays
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;


            return db.Execute(query, passwordPolicyModel);
        }
        /// <summary>
        /// Delete Record From PasswordPolicy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            db.Execute(@"update [PasswordPolicy] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }

    }
}
