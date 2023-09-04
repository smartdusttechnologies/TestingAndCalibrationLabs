using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
   public interface IPasswordPolicyService
    {

        RequestResult<int> Create(PasswordPolicyModel passwordPolicyModel);
        bool Delete(int id);
        RequestResult<int> Update(PasswordPolicyModel passwordPolicyModel);
        List<PasswordPolicyModel> Get();
        PasswordPolicyModel GetById(int id);

    }
}
