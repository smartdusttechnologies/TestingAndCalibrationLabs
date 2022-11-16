using AutoMapper;
using TestingAndCalibrationLabs.Web.UI.Models;
using TestingAndCalibrationLabs.Business.Core.Model;

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
            CreateMap<UiPageValidationTypeDTO, UiPageValidationTypeModel>().ReverseMap();
            CreateMap<UiNavigationCategoryDTO, UiNavigationCategoryModel>().ReverseMap();
            CreateMap<LookupDTO, LookupModel>().ReverseMap();
            CreateMap<LookupCategoryDTO, LookupCategoryModel>().ReverseMap();
            CreateMap<Business.Common.Node<UiPageMetadataModel>,Node<UiPageMetadataDTO>>();
            CreateMap<TestReportDTO,TestReportModel>().ReverseMap();
            CreateMap<AttachmentDTO,AttachmentModel>().ReverseMap();
        }
    }
}