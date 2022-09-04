namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class UserModel : Entity
    {
        
        public UserModel(string emailId)
        {
            Email = emailId;
        }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}