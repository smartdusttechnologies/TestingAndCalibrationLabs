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
        ///created Instert interface
        int Insert(SampleModel sample);

        /// <summary>
        /// created interface for update
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        int Update(SampleModel sample);

        /// <summary>
        /// created interface for listing
        /// </summary>
        /// <returns></returns>
        List<SampleModel> Get();

        /// <summary>
        /// created interface for get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SampleModel Get(int id);

        /// <summary>
        /// crearte interface for delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        
        /// <summary>
        /// create interface for insert collection
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        int InsertCollection(List<SampleModel> sample);
    }
}
