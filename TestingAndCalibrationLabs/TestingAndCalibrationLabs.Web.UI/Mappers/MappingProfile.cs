using AutoMapper;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Mappers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.RecordDTO, Business.Core.Model.RecordModel>().ReverseMap();
            CreateMap<Models.UiPageMetadataDTO, Business.Core.Model.UiPageMetadataModel>().ReverseMap();
            CreateMap<Models.RecordsDTO, Business.Core.Model.RecordsModel>().ReverseMap();
            CreateMap<Models.UiPageDataDTO, Business.Core.Model.UiPageDataModel>().ReverseMap();
            CreateMap<Web.UI.Models.ValidationMessage, Business.Common.ValidationMessage>().ReverseMap();  
            CreateMap<UI.Models.Sample.SampleModelDTO,Business.Core.Model.SampleModel>().ReverseMap();
            CreateMap<UserDTO, Business.Core.Model.User>().ReverseMap();

        }
    }
}