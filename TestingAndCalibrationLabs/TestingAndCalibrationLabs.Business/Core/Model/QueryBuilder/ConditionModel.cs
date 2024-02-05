

namespace TestingAndCalibrationLabs.Business.Core.Model.QueryBuilder
{
    public  class ConditionModel
    {
        /// <summary>
        /// it will store the Value for Condition of QueryBuilder
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// it will store the Where Condition value of QueryBuilder
        /// </summary>
        public string Where { get; set; }
        /// <summary>
        /// it will store the Operator of QueryBuilder
        /// </summary>
        public string operators { get; set; }
        /// <summary>
        /// it will store the TableName of QueryBuilder
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// it will store the Operator Type for QueryBuilder
        /// </summary>
        public string OperatorType { get; set; }
    }
}
