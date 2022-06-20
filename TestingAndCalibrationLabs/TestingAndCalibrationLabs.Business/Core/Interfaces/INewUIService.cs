using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface INewUIService
    {
        RequestResult<int> Add(NewUIModel newUIModel);
        bool servives(NewUIModel newUIModel);
    }
}
