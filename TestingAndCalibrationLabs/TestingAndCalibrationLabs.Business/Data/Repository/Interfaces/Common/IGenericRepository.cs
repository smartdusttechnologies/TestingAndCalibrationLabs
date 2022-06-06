﻿using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        int Insert(T lookupTypeModel);
        int InsertCollection(List<T> model);
        int Update(T lookupTypeModel);
        List<T> Get();
        List<T> Get<FType>(string columnName, FType value);
        T Get(int id);
        T Get(string name);
        bool Delete(int id);
    }
}
