using AutoMapper;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Mappers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<UI.Models.Sample.SampleModelDTO,Business.Core.Model.SampleModel>().ReverseMap();
            CreateMap<UserDTO, Business.Core.Model.User>().ReverseMap();
            CreateMap<UI.Models.TestReportModel, Business.Core.Model.TestReportModel>().ReverseMap();
        }
    }
}