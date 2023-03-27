
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IOrganizationRepository
    {
        List<Organization> Get();
        List<Organization> Get(SessionContext sessionContext);
        Organization Get(SessionContext sessionContext, int id);
        List<OrganizationModel> Getby();

    }
}
