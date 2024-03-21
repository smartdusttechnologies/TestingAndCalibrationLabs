﻿using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<string> Get();
        UserModel Get(int id);
        UserModel Get(string userName);
        int Insert(UserModel user, PasswordLogin passwordLogin);
        /// <summary>
        /// create for add user details of external login
        /// </summary>
        int ExternalInsert(UserModel user);
    }
}