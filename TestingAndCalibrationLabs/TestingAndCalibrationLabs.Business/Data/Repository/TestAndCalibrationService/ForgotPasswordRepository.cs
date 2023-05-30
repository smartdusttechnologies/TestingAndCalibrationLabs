using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;
using PagedList;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Connection between Database using IsSurveyRepository we establish a connection
    /// </summary>
    public class ForgotPasswordRepository : IForgotPasswordRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ForgotPasswordRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public int Insert(EmailModel mailsend)
        {
            string query = @"Insert into [Survey](Name, Email, Mobile, Address, City, State, Pincode, TestingType, Comments) 
                values (@Name, @Email, @Mobile, @Address, @City, @State, @PinCode, @TestingType, @Comments)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, new { Email = mailsend.Email.First(), Name = mailsend.Name, });
        }
        public int InsertCollection(EmailModel mailsend)
        {
            string query = @"[Survey](Name, Email, Mobile, Address, City, State, Pincode, TestingType, Comments) 
                values (@Name, @Email, @Mobile, @Address, @City, @State, @PinCode, @TestingType, @Comments)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, mailsend);
        }
    }
}
