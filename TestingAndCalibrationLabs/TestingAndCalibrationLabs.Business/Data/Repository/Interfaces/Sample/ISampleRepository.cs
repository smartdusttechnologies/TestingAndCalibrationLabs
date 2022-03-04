using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using PagedList;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Creating Interface for SampleRepository
    /// </summary>
    public interface ISampleRepository
    {
        int Insert(SampleModel sample);
        int Update(SampleModel sample);
        List<SampleModel> Get();
        SampleModel Get(int id);
        bool Delete(int id);
        int InsertCollection(List<SampleModel> sample);
    }
}
