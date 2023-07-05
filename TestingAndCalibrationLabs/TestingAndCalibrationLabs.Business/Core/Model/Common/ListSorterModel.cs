namespace TestingAndCalibrationLabs.Business.Core.Model
{
    /// <summary>
    /// It Contains The Properties For List Sorter
    /// </summary>
    public class ListSorterModel : Entity
    {
        /// <summary>
        /// It Contains The Name Of The List Sorter 
        /// </summary>
         //public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// It Contains The ParentId Of The List Sorter
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// It Contains The Position For List Sorter
        /// </summary>
        public int Position { get; set; }
        //public string Category { get; set; }
    }
}
