using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// these SampleService is implementing interface for ISampleService
    /// </summary>
    public interface ISampleService
    {
        List<SampleModel> Get();
        SampleModel Get(int id);
        RequestResult<int> Add(SampleModel sample);
        RequestResult<int> Update(int id, SampleModel sample);
        bool Delete(int id);
        RequestResult<int> AddCollection(List<SampleModel> sample);
    }
}
