namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class UserModel : Entity
    {
        
        public UserModel(string emailId)
        {
            Email = emailId;
        }
        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Role by designation, like admin, manager etc
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Email address of the user by role.
        /// </summary>
        public string Email { get; set; }
    }
}