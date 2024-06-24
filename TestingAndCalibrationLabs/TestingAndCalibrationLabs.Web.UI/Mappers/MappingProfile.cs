using AutoMapper;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Common;
using TestingAndCalibrationLabs.Web.UI.Models;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;

namespace TestingAndCalibrationLabs.Web.UI.Mappers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<OrganizationDTO, Organization>().ReverseMap();
            CreateMap<WorkflowActivityDTO, WorkflowActivityModel>().ReverseMap();
            CreateMap<ActivityDTO, ActivityModel>().ReverseMap();
            CreateMap<ApplicationDTO, ApplicationModel>().ReverseMap();
            CreateMap<RecordDTO, RecordModel>().ReverseMap();
            CreateMap<UiPageMetadataDTO, UiPageMetadataModel>().ReverseMap();
            CreateMap<RecordsDTO, RecordsModel>().ReverseMap();
            CreateMap<UiPageDataDTO, UiPageDataModel>().ReverseMap();
            CreateMap<ValidationMessage, Business.Common.ValidationMessage>().ReverseMap();  
            CreateMap<UserDTO,UserModel>().ReverseMap();
            CreateMap<UiPageTypeDTO, UiPageTypeModel>().ReverseMap();
            CreateMap<UiControlTypeDTO, UiControlTypeModel>().ReverseMap();
            CreateMap<DataTypeDTO, DataTypeModel>().ReverseMap();
            CreateMap<UiPageValidationDTO, UiPageValidationModel>().ReverseMap();
            CreateMap<UiPageValidationType, UiPageValidationTypeModel>().ReverseMap();
            CreateMap<UiNavigationCategoryDTO, UiNavigationCategoryModel>().ReverseMap();
            CreateMap<LookupDTO, LookupModel>().ReverseMap();
            CreateMap<LookupCategoryDTO, LookupCategoryModel>().ReverseMap();
            CreateMap<Node<LayoutDTO>, Business.Common.Node<LayoutModel>>().ReverseMap();
            CreateMap<LayoutDTO, LayoutModel>().ReverseMap();
            CreateMap<TestReportDTO,TestReportModel>().ReverseMap();
            CreateMap<AttachmentDTO,AttachmentModel>().ReverseMap();
            CreateMap<UiPageMetadataCharacteristicsDTO, UiPageMetadataCharacteristicsModel>().ReverseMap();
            CreateMap<UiControlCategoryTypeDTO,UiControlCategoryTypeModel>().ReverseMap();
            CreateMap<ModuleDTO,ModuleModel>().ReverseMap();
            CreateMap<WorkflowDTO,WorkflowModel>().ReverseMap();
            CreateMap<WorkflowStageDTO,WorkflowStageModel>().ReverseMap();
            CreateMap<Models.RecordDTO, Business.Core.Model.RecordModel>().ReverseMap();
            CreateMap<Models.UiPageMetadataDTO, Business.Core.Model.UiPageMetadataModel>().ReverseMap();
            CreateMap<Models.RecordsDTO, Business.Core.Model.RecordsModel>().ReverseMap();
            CreateMap<Models.UiPageDataDTO, Business.Core.Model.UiPageDataModel>().ReverseMap();
            CreateMap<Web.UI.Models.ValidationMessage, Business.Common.ValidationMessage>().ReverseMap();  
            CreateMap<UserDTO, Business.Core.Model.UserModel>().ReverseMap();
            CreateMap<UI.Models.TestReportDTO, Business.Core.Model.TestReportModel>().ReverseMap();
            CreateMap<UI.Models.AttachmentDTO, Business.Core.Model.AttachmentModel>().ReverseMap();
            CreateMap<UI.Models.UiPageTypeDTO, Business.Core.Model.UiPageTypeModel>().ReverseMap();
            CreateMap<UI.Models.UiControlTypeDTO, Business.Core.Model.UiControlTypeModel>().ReverseMap();
            CreateMap<UI.Models.DataTypeDTO, Business.Core.Model.DataTypeModel>().ReverseMap();
            CreateMap<UI.Models.UiPageValidationDTO, Business.Core.Model.UiPageValidationModel>().ReverseMap();
            CreateMap<UI.Models.UiPageValidationType, Business.Core.Model.UiPageValidationTypeModel>().ReverseMap();
            CreateMap<Models.QueryBuilderDTO, Business.Core.Model.QueryBuilder.QueryBuilderModel>().ReverseMap();
            CreateMap<Models.QueryBuilderRecordDTO, Business.Core.Model.QueryBuilder.QueryRecordModel>().ReverseMap();
            CreateMap<Models.QueryBuilderColNamesDTO, Business.Core.Model.QueryBuilder.QueryBuilderColNames>().ReverseMap();
            CreateMap<Models.UiQueryBuilderColumn, Business.Core.Model.UiQueryGenerator>().ReverseMap();
            CreateMap<Models.QueryGenerator, Business.Core.Model.UiQueryBuilder>().ReverseMap();
            CreateMap<Models.JoinChildModel, Business.Core.Model.QueryBuilder.JoinChildModelDTO>().ReverseMap();
            CreateMap<Models.JoinModel, Business.Core.Model.QueryBuilder.JoinModelDTO>().ReverseMap();
            CreateMap<Models.ConditionModelDTO, Business.Core.Model.QueryBuilder.ConditionModel>().ReverseMap();
            CreateMap<UiPageNavigationModel, UiPageNavigationDTO>().ReverseMap();
            CreateMap<TemplateModel, TemplateDTO>().ReverseMap();
            CreateMap<LayoutMModel, LayoutMDTO>().ReverseMap();
            CreateMap<ModuleLayoutModel, ModuleLayoutDTO>().ReverseMap();

            CreateMap<OtpDTO, OtpModel>().ReverseMap();
            CreateMap<ExternalLogin, UserModel>().ReverseMap();
            CreateMap<PasswordPolicyModel, PasswordPolicyDTO>().ReverseMap();
            CreateMap<DashboardModel , DashboardDTO>().ReverseMap();
        }
    }
}