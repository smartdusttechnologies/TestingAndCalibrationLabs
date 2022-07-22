using AutoMapper;
namespace TestingAndCalibrationLabs.Web.UI.Mappers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<UI.Models.Sample.SampleModelDTO,Business.Core.Model.SampleModel>().ReverseMap();
        
        }
    }
}