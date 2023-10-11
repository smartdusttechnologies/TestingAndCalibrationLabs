using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using TestingAndCalibrationLabs.Business.Infrastructure;
using TestingAndCalibrationLabs.Business.Core.Model.Common;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.BackOffice;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Data.Repository.BackOffice
{
    /// <summary>
    /// Repository Class for Template
    /// </summary>
    public class TemplateRepository : ITemplateRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public TemplateRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// This method to get The List of Template
        /// </summary>
        /// <returns></returns>
        public List<TemplateModel> Get() {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<TemplateModel>(@"Select * from [Template]").ToList();

        }
        /// <summary>
        /// This method to get the data by the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TemplateModel GetById(int id) 
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return  db.Query<TemplateModel>(@"Select * from [Template]  where Id = @Id", new { Id = id }).First();
        
        }
        /// <summary>
        /// This method to create a data in Template
        /// </summary>
        /// <param name="templateModel"></param>
        /// <returns></returns>
        public int Create(TemplateModel templateModel)
        {
            
            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"INSERT INTO Template (TemplateName,FileId) VALUES (@TemplateName,@FileId)";
            return db.Execute(query, templateModel);
            
        }
        /// <summary>
        /// This method is to update in a existing Data in Template
        /// </summary>
        /// <param name="templateModel"></param>
        /// <returns></returns>
        public bool Update(TemplateModel templateModel) {

            using IDbConnection db = _connectionFactory.GetConnection;
            string query = @"UPDATE Template SET TemplateName = @TemplateName WHERE Id = @Id";
            if( db.Execute(query, templateModel)>0)
                return true;
            else
                return false;
        }
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            string query = @"  DELETE FROM Template    WHERE FileId = @id;    DELETE FROM ImageUpload    WHERE Id = @id;
";

         
             if(db.Execute(query, new { id }) > 1)
                return true;
             else 
                return false;
        }

    }
}
