using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        User Get(int id);

        User Get(string userName);

        int Insert(User user, PasswordLogin passwordLogin);
    }
}
