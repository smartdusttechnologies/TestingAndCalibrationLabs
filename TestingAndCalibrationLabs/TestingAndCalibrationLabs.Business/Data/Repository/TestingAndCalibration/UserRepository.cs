using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
        /// <returns></returns>
        List<string> Interfaces.IUserRepository.Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return (List<string>)db.Query<string>("select Email from [Users] where Role='Admin'");
        }
    }
}