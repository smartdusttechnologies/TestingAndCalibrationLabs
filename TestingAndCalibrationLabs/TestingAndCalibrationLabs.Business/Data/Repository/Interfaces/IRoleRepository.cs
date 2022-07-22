using System.Collections.Generic;


namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Abstract method to get Role for Orgnization
        /// </summary>
        List<(int, string)> GetRoleWithOrg(string userName);
    }
}
