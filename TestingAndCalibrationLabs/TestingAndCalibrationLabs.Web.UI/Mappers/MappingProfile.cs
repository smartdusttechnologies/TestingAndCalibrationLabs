using AutoMapper;
using TestingAndCalibrationLabs.Web.UI.Models;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;

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
            CreateMap<UserDTO, Business.Core.Model.UserModel>().ReverseMap();
            CreateMap<UI.Models.TestReportDTO, Business.Core.Model.TestReportModel>().ReverseMap();
            CreateMap<UI.Models.AttachmentDTO, Business.Core.Model.AttachmentModel>().ReverseMap();
            CreateMap<UI.Models.UiPageTypeDTO, Business.Core.Model.UiPageTypeModel>().ReverseMap();
            CreateMap<UI.Models.UiControlTypeDTO, Business.Core.Model.UiControlTypeModel>().ReverseMap();
            CreateMap<UI.Models.DataTypeDTO, Business.Core.Model.DataTypeModel>().ReverseMap();
            CreateMap<UI.Models.UiPageValidationDTO, Business.Core.Model.UiPageValidationModel>().ReverseMap();
            CreateMap<UI.Models.UiPageValidationType, Business.Core.Model.UiPageValidationTypeModel>().ReverseMap();
            CreateMap<Models.QueryBuilderDTO, Business.Core.Model.QueryBuilder.QueryBuilderModel>().ReverseMap();
            CreateMap<Models.QueryBuilderRecordDTO, Business.Core.Model.QueryBuilder.QueryRecordModel>().ReverseMap();
            CreateMap<Models.QueryBuilderColNamesDTO, Business.Core.Model.QueryBuilder.QueryBuilderColNames>().ReverseMap();
            CreateMap<Models.UiQueryBuilderColumn, Business.Core.Model.UiQueryGenerator>().ReverseMap();
            CreateMap<Models.QueryGenerator, Business.Core.Model.UiQueryBuilder>().ReverseMap();
            CreateMap<Models.JoinChildModel, Business.Core.Model.QueryBuilder.JoinChildModelDTO>().ReverseMap();
            CreateMap<Models.JoinModel, Business.Core.Model.QueryBuilder.JoinModelDTO>().ReverseMap();
            CreateMap<Models.ConditionModelDTO, Business.Core.Model.QueryBuilder.ConditionModel>().ReverseMap();
            CreateMap<UiPageNavigationModel, UiPageNavigationDTO>().ReverseMap();
            CreateMap<DashboardModel , DashboardDTO>().ReverseMap();
        }
    }
}