namespace TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder
{
    public class JoinChildModelDTO
    {
        /// <summary>
        /// It will store the Column 
        /// </summary>
        public string Columns { get; set; }
        /// <summary>
        /// It will store the Operator JoinType
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// It will store the Column2 value of JoinPart
        /// </summary>
        public string Column2 { get; set; }
        /// <summary>
        /// It will store the condition value for QueryBuilder
        /// </summary>
        public string Condition { get; set; }
    }
}
