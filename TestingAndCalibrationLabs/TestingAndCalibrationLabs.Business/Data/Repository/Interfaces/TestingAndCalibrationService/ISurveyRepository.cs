using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces
{
    /// <summary>
    /// Implimenting Interface for post method in SurveyRepository
    /// </summary>
    public interface ISurveyRepository
    {
        int Insert(SurveyModel surveymodel);
        int InsertCollection(List<SurveyModel>mailsend);
    }
}