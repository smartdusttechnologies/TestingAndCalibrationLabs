namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// Types of Permission
    /// </summary>

    public static class Permissions
    {
        public static class UsersPermissions
        {
            public const string Add = "users.add";
            public const string Edit = "users.edit";
            public const string Read = "users.read";
            public const string Delete = "users.delete";
            public const string EditRole = "users.edit.role";
        }

        public static class TeamsPermissions
        {
            public const string AddRemove = "teams.addremove";
            public const string EditManagers = "teams.edit.managers";
            public const string Delete = "teams.delete";
        }
    }
}
