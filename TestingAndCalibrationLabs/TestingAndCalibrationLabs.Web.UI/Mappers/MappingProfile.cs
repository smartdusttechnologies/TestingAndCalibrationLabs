using AutoMapper;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Mappers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
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
            CreateMap<TestReportDTO,TestReportModel>().ReverseMap();
            CreateMap<AttachmentDTO,AttachmentModel>().ReverseMap();
            CreateMap<UiPageNavigationModel,UiPageNavigationDTO>().ReverseMap();
        }
    }
}