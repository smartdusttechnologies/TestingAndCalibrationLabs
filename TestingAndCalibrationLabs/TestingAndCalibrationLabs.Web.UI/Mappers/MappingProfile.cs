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
            CreateMap<Web.UI.Models.ValidationMessage, Business.Common.ValidationMessage>().ReverseMap();  
            CreateMap<UserDTO, Business.Core.Model.UserModel>().ReverseMap();
            CreateMap<UiPageTypeDTO, UiPageTypeModel>().ReverseMap();
            CreateMap<UiControlTypeDTO, UiControlTypeModel>().ReverseMap();
            CreateMap<DataTypeDTO, DataTypeModel>().ReverseMap();
            CreateMap<UiPageValidationDTO, UiPageValidationModel>().ReverseMap();
            CreateMap<UiPageValidationTypeDTO, UiPageValidationTypeModel>().ReverseMap();
            CreateMap<UiNavigationCategoryDTO, UiNavigationCategoryModel>().ReverseMap();
            CreateMap<LookupDTO, LookupModel>().ReverseMap();
            CreateMap<LookupCategoryDTO, LookupCategoryModel>().ReverseMap();
            CreateMap<Business.Common.Node<UiPageMetadataModel>, Web.UI.Models.Node<UiPageMetadataDTO>>();
            CreateMap<UserDTO, Business.Core.Model.User>().ReverseMap();
            CreateMap<UI.Models.TestReportDTO, Business.Core.Model.TestReportModel>().ReverseMap();
            CreateMap<UI.Models.AttachmentDTO, Business.Core.Model.AttachmentModel>().ReverseMap();
            CreateMap<UI.Models.UiPageTypeModel, Business.Core.Model.UiPageTypeModel>().ReverseMap();
            CreateMap<UI.Models.UiControlTypeModel, Business.Core.Model.UiControlTypeModel>().ReverseMap();
            CreateMap<UI.Models.DataTypeModel, Business.Core.Model.DataTypeModel>().ReverseMap();
            CreateMap<UI.Models.UiPageValidationModel, Business.Core.Model.UiPageValidationModel>().ReverseMap();
            CreateMap<UI.Models.UiPageValidationType, Business.Core.Model.UiPageValidationTypeModel>().ReverseMap();

        }
    }
}