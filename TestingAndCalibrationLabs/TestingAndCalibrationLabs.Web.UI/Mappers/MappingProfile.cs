using AutoMapper;
namespace TestingAndCalibrationLabs.Web.UI.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UI.Models.Sample.SampleModelDTO, Business.Core.Model.SampleModel>().ReverseMap();
            CreateMap<Business.Core.Model.MetirialTest.TestingCategoryLookupModel, Models.MeterialTests.TestingCategoryLookupModelDTO>().ReverseMap();
            CreateMap<Business.Core.Model.MetirialTest.TestingCategoryLookupModel, Models.MeterialTests.TestingCategoryLookupModelDTO>();
        }
    }
}
