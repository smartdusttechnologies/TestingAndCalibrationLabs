using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice
{
    public interface IGroupService
    {
        /// <summary>
        /// Get All Record From Group Service
        /// </summary>
        List<GroupModel> Get();

        /// <summary>
        /// Insert Record In Group Service
        /// </summary>
        /// <param name="groupModel"></param>
        RequestResult<int> Create(GroupModel groupModel);

        /// <summary>
        /// Delete Record In Group Service
        /// </summary>
        /// <param name="id"></param>
        bool Delete(int id);

        /// <summary>
        /// Get Record By Id From Group Service
        /// </summary>
        /// <param name="id"></param>
        GroupModel GetById(int id);

        /// <summary>
        /// Edit Record From Group Service
        /// </summary>
        /// <param name="groupModel"></param>
        /// <param Id="id"></param>
        RequestResult<int> Update(int id, GroupModel groupModel);
    }
}
