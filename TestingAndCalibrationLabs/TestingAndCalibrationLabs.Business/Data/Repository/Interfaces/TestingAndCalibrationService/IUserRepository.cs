﻿using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<string> Get();
        UserModel Get(int id);
        UserModel Get(string userName);
        List<UserModel> GetByListid();
        //List<UserModel> GetByclaimListid();
        int Insert(UserModel user, PasswordLogin passwordLogin);

    }
}