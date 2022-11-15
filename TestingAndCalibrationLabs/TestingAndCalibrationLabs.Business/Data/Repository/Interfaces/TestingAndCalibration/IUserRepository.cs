using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// It is to get data from the User Table.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// To list user by role from the database
        /// </summary>
        /// <returns></returns>
        List<string> Get();

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User Get(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User Get(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="passwordLogin"></param>
        /// <returns></returns>
        int Insert(User user, PasswordLogin passwordLogin);
    }
}