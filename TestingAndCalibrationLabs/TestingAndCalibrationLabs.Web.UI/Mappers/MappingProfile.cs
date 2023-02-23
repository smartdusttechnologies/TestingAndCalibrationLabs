using AutoMapper;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Mappers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
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
            CreateMap<UiControlCategoryTypeDTO,UiControlCategoryTypeModel>().ReverseMap();
            CreateMap<ModuleDTO,ModuleModel>().ReverseMap();
            CreateMap<WorkflowDTO,WorkflowModel>().ReverseMap();
            CreateMap<WorkflowStageDTO,WorkflowStageModel>().ReverseMap();
            CreateMap<UiPageNavigationModel, UiPageNavigationDTO>().ReverseMap();
        }
    }
}