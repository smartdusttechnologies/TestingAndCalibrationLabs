using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces
{
    public interface ISurveyService
    {
        /// <summary>
        /// This is used to send the mail of the survey to UI user and and dB user records by Role
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
        RequestResult<int> Add(SurveyModel mailSend);
    }
}