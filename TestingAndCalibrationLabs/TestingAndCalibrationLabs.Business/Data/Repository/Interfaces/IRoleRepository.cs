using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IRoleRepository
    {
        List<(int, string)> GetRoleWithOrg(string userName);
    }
}
