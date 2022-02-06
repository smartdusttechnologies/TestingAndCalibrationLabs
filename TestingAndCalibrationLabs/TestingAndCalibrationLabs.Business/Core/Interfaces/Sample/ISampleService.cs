using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    /// <summary>
    /// these ISampleService is implementing interface for SampleService
    /// </summary>
    public interface ISampleService
    {
        List<SampleModel> Get();
        List<SampleModel> GetPages(int pageIndex);
        SampleModel Get(int id);
        RequestResult<int> Add(SampleModel sample);
        RequestResult<int> Update(int id, SampleModel sample);
        bool Delete(int id);
        RequestResult<int> AddCollection(List<SampleModel> sample);
    }
}
