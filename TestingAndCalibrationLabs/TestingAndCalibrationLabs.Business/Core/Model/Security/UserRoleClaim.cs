namespace TestingAndCalibrationLabs.Business.Core.Model.Securities
{
    /// <summary>
    /// Class to get the user role with claims.
    /// </summary>
    public class UserRoleClaim : Entity
    {
        /// <summary>
        /// Orgnization Id.
        /// </summary>
        public int OrgId { get; set; }
        /// <summary>
        /// Role Id.
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Role Name.
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// User Id.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Claim Name.
        /// </summary>
        public string ClaimName { get; set; }
    }
}
