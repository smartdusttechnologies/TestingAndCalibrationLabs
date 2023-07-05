using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// Service Interface For List Sorter
    /// </summary>
    public interface IListSorterService
    {
        /// <summary>
        /// Sort List To Json For Combo Tree Source
        /// </summary>
        /// <param name="listSorterModels"></param>
        /// <returns></returns>
        string SortListToJson(List<ListSorterModel> listSorterModels);
        /// <summary>
        /// Sort Selected Ids To Use In ComboTree
        /// </summary>
        /// <param name="tests"></param>
        /// <returns></returns>
        string SelectedOptionSort(List<ListSorterModel> tests);
        //string MethodName(List<ListSorterModel> listSorterModels);
        IEnumerable<Node<ListSorterModel>> HirearichyCreate(List<ListSorterModel> listSorterModels);
    }
}
