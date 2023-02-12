using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Services
{
    internal interface IUiPageNavigationCategoryRepository
    {
        void Create(UiNavigationCategoryModel pageControl);
        List<UiNavigationCategoryModel> Get();
        UiNavigationCategoryModel GetById(int id);
        void Update(UiNavigationCategoryModel pageControl);
    }
}