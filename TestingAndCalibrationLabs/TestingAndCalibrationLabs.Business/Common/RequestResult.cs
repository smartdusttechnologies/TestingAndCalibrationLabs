using System.Collections.Generic;
namespace TestingAndCalibrationLabs.Business.Common
{
    public class RequestResult<T> : ResultBase
    {
        #region public Properties
        /// <summary>
        /// This represents the requested data type objet when method is successfull.
        /// </summary>
        public T RequestedObject { get; set; }
        /// <summary>
        /// This represents the successfull status when there is no error message and the requested object is not null.
        /// </summary>
        public bool IsSuccessful
        {
            get
            {
                bool successful = !HasFailureMessages();
                if (successful && RequestedObject == null)
                {
                    successful = false;
                }
                return successful;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestResult&lt;T&gt;"/> class.
        /// </summary>
        public RequestResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestResult&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="requestedObject">The requested object.</param>
        public RequestResult(T requestedObject) : this()
        {
            RequestedObject = requestedObject;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestResult&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="validationMessages">The validation messages.</param>
        public RequestResult(IList<ValidationMessage> validationMessages)
            : this()
        {
            ValidationMessages = validationMessages;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestResult&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="requestedObject">The requested object.</param>
        /// <param name="validationMessages">The validation messages.</param>
        public RequestResult(T requestedObject, IList<ValidationMessage> validationMessages)
            : this()
        {
            RequestedObject = requestedObject;
            ValidationMessages = validationMessages;
        }

        #endregion
    }
}
