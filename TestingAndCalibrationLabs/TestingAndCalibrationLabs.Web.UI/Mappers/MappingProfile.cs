using AutoMapper;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Common;
using TestingAndCalibrationLabs.Web.UI.Models;

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
            CreateMap<UiPageNavigationModel, UiPageNavigationDTO>().ReverseMap();
            CreateMap<TemplateModel, TemplateDTO>().ReverseMap();
            CreateMap<LayoutMModel, LayoutMDTO>().ReverseMap();
            CreateMap<ModuleLayoutModel, ModuleLayoutDTO>().ReverseMap();

        }
    }
}