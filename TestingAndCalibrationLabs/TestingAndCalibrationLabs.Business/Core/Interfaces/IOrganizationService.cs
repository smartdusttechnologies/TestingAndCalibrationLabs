using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface IOrganizationService
    {
        List<Organization> Get();
        List<Organization> Get(SessionContext sessionContext);
        Organization Get(SessionContext sessionContext, int id);
    }
}
