using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Business.Services.BackOffice
{
    public class GroupService : IGroupService
    {
        private readonly IGenericRepository<GroupModel> _genericRepository;
        public GroupService(IGenericRepository<GroupModel> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        /// <summary>
        /// Get All Records From Group Service
        /// </summary>
        public List<GroupModel> Get()
        {
            var pageNavigation = _genericRepository.Get();
            return pageNavigation;
        }
        /// <summary>
        /// Insert Record In Group Service
        /// </summary>
        /// <param name="groupModel"></param>
        public RequestResult<int> Create(GroupModel groupModel)
        {
            _genericRepository.Insert(groupModel);

            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete Record From Group Service
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            return _genericRepository.Delete(id);
        }
        /// <summary>
        /// Get Record By Id From Group Service
        /// </summary>
        /// <param name="id"></param>
        public GroupModel GetById(int id)
        {
            return _genericRepository.Get(id);
        }
        /// <summary>
        /// Edit Record By Group Service
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupModel"></param>
        public RequestResult<int> Update(int id, GroupModel groupModel)
        {
            _genericRepository.Update(groupModel);
            return new RequestResult<int>(1);
        }
    }
}
