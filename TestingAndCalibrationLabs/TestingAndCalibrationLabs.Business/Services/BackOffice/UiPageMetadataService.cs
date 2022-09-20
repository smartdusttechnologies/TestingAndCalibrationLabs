using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services
{
    /// <summary>
    /// Service Class For Ui Page Metadata
    /// </summary>
    public class UiPageMetadataService : IUiPageMetadataService
    {
        private readonly IUiPageMetadataCharacteristicsRepository _uiPageMetadataCharacteristicsRepository;
        public readonly IUiPageMetadataRepository _uiPageMetadataRepository;
        public UiPageMetadataService(IUiPageMetadataRepository uiPageMetadataRepository,IGenericRepository<UiPageMetadataModel> genericRepository, IUiPageMetadataCharacteristicsRepository uiPageMetadataCharacteristicsRepository)
        {
            _uiPageMetadataRepository = uiPageMetadataRepository;
            _uiPageMetadataCharacteristicsRepository = uiPageMetadataCharacteristicsRepository;
           
        }
        /// <summary>
        /// Insert Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="pageControl"></param>
        /// <returns></returns>
        public RequestResult<int> Create(UiPageMetadataModel pageControl)
        {
            int id = _uiPageMetadataRepository.Create(pageControl);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _uiPageMetadataRepository.Delete(id);
        }
        /// <summary>
        /// Get Record by Id For Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UiPageMetadataModel GetById(int id)
        {

            return _uiPageMetadataRepository.GetById(id);
        }
        /// <summary>
        /// Edit Record From Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageMetadataModel"></param>
        /// <returns></returns>
        public RequestResult<int> Update(int id, UiPageMetadataModel uiPageMetadataModel)
        {
            var lookupListBuild = new List<UiPageMetadataCharacteristicsModel>();
            var lookupList = _uiPageMetadataCharacteristicsRepository.GetByMetadataId(id);
           var existingIdsInCharacteristics = lookupList.Select(x=>x.LookupId);
           var newSelectedIdsInCharacteristics = uiPageMetadataModel.uiPageMetadataCharacteristics.Select(x=>x.LookupId);
            var listFinal = existingIdsInCharacteristics.Union(newSelectedIdsInCharacteristics);
            foreach (var item in listFinal)
            {
                if (!existingIdsInCharacteristics.Contains(item))
                {
                    lookupListBuild.Add(new UiPageMetadataCharacteristicsModel { LookupId = item, UiPageMetadataId = id });
                }
                if (!newSelectedIdsInCharacteristics.Contains(item))
                {
                    lookupListBuild.Add(new UiPageMetadataCharacteristicsModel { LookupId = item });
                }
                
            }
            uiPageMetadataModel.uiPageMetadataCharacteristics = lookupListBuild;
            _uiPageMetadataRepository.Update(uiPageMetadataModel);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Get All Records From Ui Page Metadata Type
        /// </summary>
        /// <returns></returns>
        public List<UiPageMetadataModel> Get()
        {
            return _uiPageMetadataRepository.Get();
        }
    }
}
