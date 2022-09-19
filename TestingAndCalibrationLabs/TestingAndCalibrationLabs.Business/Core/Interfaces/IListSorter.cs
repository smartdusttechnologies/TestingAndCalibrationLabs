using System.Collections.Generic;
using System.Text.Json.Serialization;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IListSorter
    {
        string MethodName(List<ListSorterModel> listSorterModels);
        string SelectedOptionSort(List<ListSorterModel> tests);
    }
}
