using System.Collections.Generic;

namespace TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder
{
    public class JoinModelDTO
    {
        /// <summary>
        /// It will store the value of JoinType 
        /// </summary>
        public string JoinType { get; set; }
        /// <summary>
        /// it will store the value of tablechoice for QueryBuilder
        /// </summary>
        public string TableChoice { get; set; }
        /// <summary>
        /// It will store the value of From Table
        /// </summary>
        public string TableFrom { get; set; }

        /// <summary>
        /// It will store the different condition Data for Join Part 
        /// </summary>
        public List<JoinChildModelDTO> JoinInfo { get; set; }
    }
}
