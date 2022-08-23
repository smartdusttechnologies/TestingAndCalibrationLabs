using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    public class UiPageTypeService : IUiPageTypeService
    {
       
        public readonly IGenericRepository<UiPageTypeModel> _genericRepository;
        public UiPageTypeService( IGenericRepository<UiPageTypeModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// To Create Record For Ui Page Type
        /// </summary>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageTypeModel uiPageTypeModel)
        {
            _genericRepository.Insert(uiPageTypeModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// To Delete Record From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// To Edit Record For Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeModel"></param>
        /// <returns></returns>
        public RequestResult<int> Edit( UiPageTypeModel uiPageTypeModel)
        {
            _genericRepository.Update(uiPageTypeModel);
            return new RequestResult<int>(1);
        }
       public List<UiPageTypeModel> GetAll()
        {
            return _genericRepository.Get();
        }
        
        
        /// <summary>
        /// To Get Record By Id From Ui Page Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageTypeModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
    }
}
