using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;
using TestingAndCalibrationLabs.Business.Infrastructure;

namespace TestingAndCalibrationLabs.Business.Data.Repository
{
    /// <summary>
    /// Repository Class For ModuleLayout
    /// </summary>
    public class ModuleLayoutRepository : IModuleLayoutRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ModuleLayoutRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// Get All Record From moduleLayout
        /// </summary>
        /// <returns></returns>
        public List<ModuleLayoutModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<ModuleLayoutModel>(@" Select ml.Id,ml.Name, ml.LayoutId,ml.ModuleId,l.Name as LayoutName,m.Name as ModuleName 
                                                From[ModuleLayout] ml
                                                    inner join [Layout] l on ml.LayoutId = l.Id
                                                    inner join[Module] m on ml.ModuleId = m.Id
                                                where
                                                     l.IsDeleted = 0
                                                    and m.IsDeleted = 0
                                                    and ml.IsDeleted = 0").ToList();
        }

        /// <summary>
        /// Get moduleLayout Record By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ModuleLayoutModel> GetAllByUiPageMetadataId(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<ModuleLayoutModel>(@"Select upm.UiPageMetadataId , upt.[Name] as LookupName, upt.Id
                                                From[UiPageMetadataCharacteristics] upm
                                                    inner join[Lookup] upt on upm.LookupId = upt.Id
                                                where
                                                     upm.UiPageMetadataId = @Id and
                                                     upm.IsDeleted = 0
                                                    and upt.IsDeleted = 0
                                                    ", new { Id = id }).ToList();
        }
       
        /// <summary>
        /// Create Record From ModuleLayout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public int Create(ModuleLayoutModel moduleLayoutModel)
        {
            string query = @"Insert into [ModuleLayout] (LayoutId,ModuleId,Name)
                                                 values (@LayoutId,@ModuleId,@Name)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, moduleLayoutModel);

        }
        /// <summary>
        /// GET Record From ModuleLayout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ModuleLayoutModel GetById(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var moduleLayoutById = db.Query<ModuleLayoutModel>(@"Select ml.Id,ml.Name, ml.LayoutId,ml.ModuleId,l.Name as LayoutName,m.Name as ModuleName 
                                                From[ModuleLayout] ml
                                                    inner join [Layout] l on ml.LayoutId = l.Id
                                                    inner join[Module] m on ml.ModuleId = m.Id
                                                where ml.Id = @Id
                                                    and l.IsDeleted = 0
                                                    and m.IsDeleted = 0
                                                    and ml.IsDeleted = 0", new { Id = id }).FirstOrDefault(); ;

            return moduleLayoutById;
        }
        public ModuleLayoutModel GetByModuleLayoutId(int moduleId)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            var moduleLayoutId = db.Query<ModuleLayoutModel>(@"Select ml.Id
                                                From[ModuleLayout] ml
                                                where ml.ModuleId = @ModuleId
                                                    and ml.IsDeleted = 0", new { ModuleId = moduleId }).FirstOrDefault();
            return moduleLayoutId;
        }
        /// <summary>
        /// Update Record From ModuleLayout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public int Update(ModuleLayoutModel moduleLayoutModel)
        {
            string query = @"update [ModuleLayout] Set  
                                
                                LayoutId = @LayoutId,
                                ModuleId = @ModuleId,
                                Name = @Name
                                Where id = @Id";

            using IDbConnection db = _connectionFactory.GetConnection;

            return db.Execute(query, moduleLayoutModel);
        }
        /// <summary>
        /// Delete Record From ModuleLayout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public bool Delete(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            db.Execute(@"update [ModuleLayout] Set 
                                    IsDeleted = 1
                                    Where Id = @Id", new { Id = id });
            return true;
        }
    }
}
