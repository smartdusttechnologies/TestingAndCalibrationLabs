using System;
using System.Collections.Generic;
using System.Text;
using TestingAndCalibrationLabs.Business.Core.Interfaces.MetirialTest;
using TestingAndCalibrationLabs.Business.Core.Model.MetirialTest;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces.MetirialTest;

namespace TestingAndCalibrationLabs.Business.Services.MetirialTest
{
    public class TestingCategoryLookupService : ITestingCategoryLookupService
    {
        private readonly ITestingCategoryLookupRepository _testingCategoryLookupRepository;

        public TestingCategoryLookupService(ITestingCategoryLookupRepository testingCategoryLookupRepository)
        {
            _testingCategoryLookupRepository = testingCategoryLookupRepository;
        }
        public List<TestingCategoryLookupModel> GetTests()
        {
            return _testingCategoryLookupRepository.GetTests();
        }

        public TestingCategoryLookupModel GetTests(int id)
        {
            return _testingCategoryLookupRepository.GetTests(id);
        }
    }
}
