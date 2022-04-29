using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.MetirialTest
{
    public interface ITestingCategoryLookupService
    {
        List<Model.MetirialTest.TestingCategoryLookupModel> GetTests();
        Model.MetirialTest.TestingCategoryLookupModel GetTests(int id);
    }
}
