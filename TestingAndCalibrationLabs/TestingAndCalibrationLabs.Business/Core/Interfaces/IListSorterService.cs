using System.Collections.Generic;
using System.Text.Json.Serialization;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IListSorterService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listSorterModels"></param>
        /// <returns></returns>
        string SortListToJson(List<ListSorterModel> listSorterModels);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tests"></param>
        /// <returns></returns>
        string SelectedOptionSort(List<ListSorterModel> tests);
    }
}
