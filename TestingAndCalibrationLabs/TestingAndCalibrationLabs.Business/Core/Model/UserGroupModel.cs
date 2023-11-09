using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("UserGroup")]
    /// <summary>
    /// User Group.
    /// </summary>
    public class UserGroupModel
    {
        [DbColumn]
        /// <summary>
        /// It contains id of UserGroup
        /// </summary>/// 
        public int Id { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains GroupId of UserGroup
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// It Contains Group Name of the UserGroup.
        /// </summary>
        public string GroupName { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains UserId of the User Group.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// It Contains UserName of the User Group.
        /// </summary>
        public string UserName { get; set; }
    }
}
