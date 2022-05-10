using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Model.MetirialTest;

namespace TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.MetirialTest
{
    public interface ITestingCategoryLookupRepository
    {
        List<TestingCategoryLookupModel> GetTests();


        TestingCategoryLookupModel GetTests(int id);
    }
}
