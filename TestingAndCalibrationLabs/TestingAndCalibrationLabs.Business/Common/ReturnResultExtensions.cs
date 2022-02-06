using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Business.Common
{
    /// <summary>
    /// this contains all the extenstion methods of requested results return type.
    /// </summary>
    public static class ReturnResultExtensions
    {
        /// <summary>
        /// Determines whether this instance has any failure Validation Messages
        /// </summary>
        public static bool HasFailureValidationMessages<T>(this T returnResult) where T : ResultBase
        {
            return returnResult.GetFailureValidationMessages().Count > 0;
        }

        /// <summary>
        /// Gets the subset of validation messages from <paramref name="returnResut"/> that are of severity Error or higher.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="returnResut">The return resut.</param>
        /// <returns></returns>
        public static IList<ValidationMessage> GetFailureValidationMessages<T>(this T returnResut) where T : ResultBase
        {
            List<ValidationMessage> errorValMsgs = new List<ValidationMessage>();
            if (returnResut.ValidationMessages != null)
            {
                errorValMsgs.AddRange(returnResut.ValidationMessages.GetFailureValidationMessages());
            }
            return errorValMsgs;
        }
    }
}
