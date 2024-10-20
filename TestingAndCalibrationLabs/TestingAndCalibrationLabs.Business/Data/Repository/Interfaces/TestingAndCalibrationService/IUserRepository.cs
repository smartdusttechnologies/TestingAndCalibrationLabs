﻿using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<string> Get();
        User Get(int id);
        User Get(string userName);
        int Insert(User user, PasswordLogin passwordLogin);
    }
}