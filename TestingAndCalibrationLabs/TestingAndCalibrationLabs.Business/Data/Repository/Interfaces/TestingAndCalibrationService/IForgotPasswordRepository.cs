using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    
    /// <summary>
    /// Implimenting Interface for post method in SurveyRepository
    /// </summary>
    public interface IForgotPasswordRepository
    {
        /// <summary>
        /// Insert the record to database
        /// </summary>
        /// <param name="forgotPasswordModel"></param>
        /// <returns></returns>
        int Insert(EmailModel forgotPasswordModel);

        /// <summary>
        /// Inser the record and sends mail to user by role
        /// </summary>
        /// <param name="forgotPassword"></param>
        /// <returns></returns>
        int InsertCollection(EmailModel forgotPassword);
    }
}