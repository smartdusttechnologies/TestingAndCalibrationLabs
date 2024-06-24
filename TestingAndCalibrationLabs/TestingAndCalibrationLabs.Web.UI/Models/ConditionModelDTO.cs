namespace TestingAndCalibrationLabs.Web.UI.Models
{
    public class ConditionModelDTO
    {
        /// <summary>
        /// To Store value of Condition
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// To store Where Condition
        /// </summary>
        public string Where { get; set; }
        /// <summary>
        /// To store the value of Operator Type
        /// </summary>
        public string Operators { get; set; }    
        /// <summary>
        /// To save the Table Name Of QueryBuilder
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// To Store operator Type for QueryBuilder
        /// </summary>
        public string OperatorType { get; set; }
    }
}
