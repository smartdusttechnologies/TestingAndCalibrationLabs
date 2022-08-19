using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IUiPageTypeService
    {
        /// <summary>
        /// To
        /// </summary>
        /// <returns></returns>
        List<UiPageTypeModel> GetAll();
        List<DataTypeModel> GetDataType();
        List<UiControlTypeModel> GetUiControlType();
        List<UiPageValidationTypeModel> GetUiPageValType();
        List<UiPageMetadataModel> GetUiPageMetadataType();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UiPageTypeModel GetById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        RequestResult<int> Create(UiPageTypeModel uiPageTypeModel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        RequestResult <int> Edit(int id ,UiPageTypeModel uiPageTypeModel);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

    }
}
