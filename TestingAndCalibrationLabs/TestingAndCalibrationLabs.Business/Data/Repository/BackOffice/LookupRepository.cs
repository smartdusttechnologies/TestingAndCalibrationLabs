using TestingAndCalibrationLabs.Business.Infrastructure;
using System.Collections.Generic;
using System.Data;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using Dapper;
using System.Linq;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    
    public class LookupRepository : ILookupRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public LookupRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<LookupModel> GetByLookupCategoryId(int lookupCategoryId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<LookupModel>(@"select * from Lookup where LookupCategoryId = @LookupCategoryId and IsDeleted = 0", new { LookupCategoryId =lookupCategoryId}).ToList();

        }
        /// <summary>
        /// Insert Record in Lookup
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        public int Create(LookupModel lookupModel)
        {
            string query = @"Insert into [Lookup] (LookupCategoryId,Name)
                                                  values (@LookupCategoryId,@Name)";
            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, lookupModel);
        }
        /// <summary>
        /// Getting All Records From Lookup
        /// </summary>
        /// <returns></returns>
        public List<LookupModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<LookupModel>(@"Select   l.Id,
                                                            l.LookupCategoryId,
                                                            lc.[Name] as LookupCategoryName, 
                                                            
                                                            l.Name
                                                                                                                   
                                                    From [Lookup] l
                                                    inner join [LookupCategory] lc on l.LookupCategoryId = lc.Id
                                                    
                                                where 
                                                    l.IsDeleted = 0 
                                                    and lc.IsDeleted = 0
                                                    ").ToList();
        }
        /// <summary>
        /// Getting Record By Id Lookup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LookupModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var lookupCategoryId = db.Query<LookupModel>(@"Select l.Id,
                                                       l.LookupCategoryId,     
													 lc.[Name] as LookupCategoryName, 								
                                                     l.Name
                                                    From [Lookup] l													
                                                   inner join [LookupCategory] lc on l.LookupCategoryId = lc.Id                                              
                                                where 
                                                        l.Id=@Id
                                                     and l.IsDeleted = 0 
                                                    and lc.IsDeleted = 0", new { Id = id }).FirstOrDefault();

            return lookupCategoryId;
        }
        /// <summary>
        /// Edit Record For Lookup 
        /// </summary>
        /// <param name="lookupModel"></param>
        /// <returns></returns>
        public int Update(LookupModel lookupModel)
        {

            string query = @"update [Lookup] Set  
                                LookupCategoryId = @LookupCategoryId,                                
                                Name = @Name                              
                                Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;


            return db.Execute(query, lookupModel);
        }
        /// <summary>
        /// Delete Record From Lookup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            db.Execute(@"update [Lookup] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }
        public List<LookupModel> GetLookupCategoryId(int lookupCategoryId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<LookupModel>(@"Select L.* From[Lookup] L INNER JOIN[LookupCategory] lc ON L.LookupCategoryId = lc.Id and lc.IsDeleted = 0 where LookupCategoryId = @LookupCategoryId and L.IsDeleted = 0", new { LookupCategoryId = lookupCategoryId }).ToList(); 

        }
    }
}
