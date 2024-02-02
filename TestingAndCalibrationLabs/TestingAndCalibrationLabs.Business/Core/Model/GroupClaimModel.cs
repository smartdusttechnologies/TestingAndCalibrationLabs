using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    [DbTable("GroupClaim")]
    public class GroupClaimModel
    {
        [DbColumn]
        /// <summary>
        /// It contains id of GroupClaim
        /// </summary>/// 
        public int Id { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains GroupId of the GroupClaim.
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// It Contains GroupName of the GroupClaim.
        /// </summary>
        public string GroupName { get; set; }

        [DbColumn]
        /// <summary>
        ///It Contains ClaimTypeId of the GroupClaim.
        /// </summary>
        public int ClaimTypeId { get; set; }
        /// <summary>
        /// It Contains ClaimTypeName of the GroupClaim.
        /// </summary>
        public string ClaimTypeName { get; set; }
        [DbColumn]
        /// <summary>
        ///It Contains PermissionId of the GroupClaim.
        /// </summary>
        public int PermissionId { get; set; }
        /// <summary>
        /// It Contains PermissionName of the GroupClaim.
        /// </summary>
        public string PermissionName { get; set; }
    }
}
