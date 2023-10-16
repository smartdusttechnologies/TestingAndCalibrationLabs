using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For UiPageMetadataCharacterisctis
    /// </summary>
    public class ModuleLayoutServices : IModuleLayoutService
    {
        private readonly IModuleLayoutRepository _moduleLayoutRepository;

        public ModuleLayoutServices(IModuleLayoutRepository moduleLayoutRepository)
        {
            _moduleLayoutRepository = moduleLayoutRepository;
        }
        /// <summary>
        /// Get moduleLayout Record By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ModuleLayoutModel> GetByMetadataId(int id)
        {
            return _moduleLayoutRepository.GetByPageMetadataId(id);
        }
        /// <summary>
        /// Get All moduleLayout Record
        /// </summary>
        /// <returns></returns>
        public List<ModuleLayoutModel> Get()
        {
            return _moduleLayoutRepository.Get();
        }
        /// <summary>
        /// Get All Record For moduleLayoutDTO based on Id
        /// </summary>
        /// <returns></returns>
        public ModuleLayoutModel GetById(int id)
        {
            return _moduleLayoutRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record From moduleLayoutDTO
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moduleLayoutModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(ModuleLayoutModel moduleLayoutModel)
        {
            _moduleLayoutRepository.Update(moduleLayoutModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Insert Record In moduleLayoutDTO
        /// </summary>
        /// <param name="moduleLayoutModel"></param>
        /// <returns></returns>

        public RequestResult<int> Create(ModuleLayoutModel moduleLayoutModel)
        {
            _moduleLayoutRepository.Create(moduleLayoutModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From moduleLayoutDTO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _moduleLayoutRepository.Delete(id);
        }


    }
}
