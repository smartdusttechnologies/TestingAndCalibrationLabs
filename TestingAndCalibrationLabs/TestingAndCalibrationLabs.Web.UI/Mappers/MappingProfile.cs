using AutoMapper;
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

        }
    }
}
