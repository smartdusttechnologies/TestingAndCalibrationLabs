using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Implimenting Interface for post method in SurveyRepository
    /// </summary>
    public interface ISurveyRepository
    {
        /// <summary>
        /// Insert the record to database
        /// </summary>
        /// <param name="surveymodel"></param>
        /// <returns></returns>
        int Insert(SurveyModel surveymodel);

        /// <summary>
        /// Inser the record and sends mail to user by role
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
        int InsertCollection(List<SurveyModel>mailsend);
    }
}