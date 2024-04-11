namespace TestingAndCalibrationLabs.Business.Common
{
    /// <summary>
    /// Enum For ActivityType
    /// </summary>
    public enum ActivityType
    {
        None,
        EmailServices
    }
    /// <summary>
    /// Enum For Activity Metadata Type
    /// </summary>
    public enum ActivityMetadataType
    {
        Static = 1015,
        Dynamic = 1016
    }
    /// <summary>
    /// Enum For Ui Control Type
    /// </summary>
    public enum UiControlType
    {
        None,
        text,
        password,
        checkbox,
        radio,
        file,
        submit,
        button,
        textarea,
        date,
        email,
        image,
        number,
        tel,
        time,
        url,
        reset,
        week,
        search,
        range,
        month,
        hidden,
        datetimelocal,
        color,
        card,
        processStatus,
        subLevel1ProcessStatus,
        tabs = 28,
        subLevel1Tabs,
        collapsableSection,
        subLevel1CollapsableSection,
        dropdown,
        grid,
        pincode,
        year,
        question,
        workflowStage
       
    }

    public enum UiControlTypeId
    {
        uiControlTypeId = 25,
        UiControlType = 29,
        UiControlCategoryTypeId = 1017,
        DataTypeId = 1
    }

    public enum UiControlCategoryType
    {
        num = 2010,
        MultiControlGrid
    }

    /// <summary>
    /// Enum For Permission Module Type
    /// </summary>
    public enum PermissionModuleType
    {
        DefaultModulePermission,
        UiPageTypePermission,
        UiPageMetadataPermission,
        UiControlTypePermission
    }

    //public class CustomClaimTypes
    //{
    //    public const string Permission = "Application.Permission";
    //    public const string UserId = "UserId";
    //    public const string OrganizationId = "OrganizationId";
    //}
    /// <summary>
    /// Emum For Custom Claim Type
    /// </summary>
    public enum CustomClaimType
    {
        DefaultClaim,
        ApplicationPermission,
        UserId,
        OrganizationId
    }
    /// <summary>
    /// Enum For Permission Type
    /// </summary>
    public enum PermissionType
    {
        None,
        Create,
        Update,
        Read,
        Delete
    }
}
