namespace TestingAndCalibrationLabs.Business.Common
{
    public enum ActivityType{
    None,
    EmailServices
    }
    public enum ActivityMetadataType
    {
        Static = 1015,
        Dynamic = 1016
    }
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
}
